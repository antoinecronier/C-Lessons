using Microsoft.QueryStringDotNET;
using Microsoft.Toolkit.Uwp.Notifications;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DesignUWP
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public Data[] DataList { get; set; } =
    {
        new Data { Name = "One" },
        new Data { Name = "Two" },
        new Data { Name = "Three" },
    };

        public MainPage()
        {
            this.InitializeComponent();
            this.listView.ItemsSource = DataList;
        }

        private void Animation_Begin(object sender, RoutedEventArgs e)
        {
            myStoryboard.Begin();
        }
        private void Animation_Pause(object sender, RoutedEventArgs e)
        {
            myStoryboard.Pause();
        }
        private void Animation_Resume(object sender, RoutedEventArgs e)
        {
            myStoryboard.Resume();
        }
        private void Animation_Stop(object sender, RoutedEventArgs e)
        {
            myStoryboard.Stop();
        }

        private void ClosePopupClicked(object sender, RoutedEventArgs e)
        {
            // if the Popup is open, then close it 
            if (StandardPopup.IsOpen) { StandardPopup.IsOpen = false; }
        }

        private void ShowPopupOffsetClicked(object sender, RoutedEventArgs e)
        {
            // open the Popup if it isn't open already 
            if (!StandardPopup.IsOpen) { StandardPopup.IsOpen = true; }
        }

        private void Image_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            FlyoutBase.ShowAttachedFlyout((FrameworkElement)sender);
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            // Create the message dialog and set its content
            var messageDialog = new MessageDialog("No internet connection has been found.");

            // Add commands and set their callbacks; both buttons use the same callback function instead of inline event handlers
            messageDialog.Commands.Add(new UICommand(
                "Try again",
                new UICommandInvokedHandler(this.CommandInvokedHandler)));
            messageDialog.Commands.Add(new UICommand(
                "Close",
                new UICommandInvokedHandler(this.CommandInvokedHandler)));

            // Set the command that will be invoked by default
            messageDialog.DefaultCommandIndex = 0;

            // Set the command to be invoked when escape is pressed
            messageDialog.CancelCommandIndex = 1;

            // Show the message dialog
            await messageDialog.ShowAsync();
        }

        private void CommandInvokedHandler(IUICommand command)
        {
            // In a real app, these would be initialized with actual data
            string title = "Andrew sent you a picture";
            string content = "Check this out, Happy Canyon in Utah!";
            string image = "https://picsum.photos/360/202?image=883";
            string logo = "ms-appdata:///local/Andrew.jpg";

            // Construct the visuals of the toast
            ToastVisual visual = new ToastVisual()
            {
                BindingGeneric = new ToastBindingGeneric()
                {
                    Children =
                        {
                            new AdaptiveText()
                            {
                                Text = title
                            },

                            new AdaptiveText()
                            {
                                Text = content
                            },

                            new AdaptiveImage()
                            {
                                Source = image
                            }
                        },

                    AppLogoOverride = new ToastGenericAppLogo()
                    {
                        Source = logo,
                        HintCrop = ToastGenericAppLogoCrop.Circle
                    }
                }
            };

            // In a real app, these would be initialized with actual data
            int conversationId = 384928;

            // Construct the actions for the toast (inputs and buttons)
            ToastActionsCustom actions = new ToastActionsCustom()
            {
                Inputs =
    {
        new ToastTextBox("tbReply")
        {
            PlaceholderContent = "Type a response"
        }
    },

                Buttons =
    {
        new ToastButton("Reply", new QueryString()
        {
            { "action", "reply" },
            { "conversationId", conversationId.ToString() }

        }.ToString())
        {
            ActivationType = ToastActivationType.Background,
            ImageUri = "Assets/Reply.png",

            // Reference the text box's ID in order to
            // place this button next to the text box
            TextBoxId = "tbReply"
        },

        new ToastButton("Like", new QueryString()
        {
            { "action", "like" },
            { "conversationId", conversationId.ToString() }

        }.ToString())
        {
            ActivationType = ToastActivationType.Background
        },

        new ToastButton("View", new QueryString()
        {
            { "action", "viewImage" },
            { "imageUrl", image }

        }.ToString())
    }
            };

            // Now we can construct the final toast content
            ToastContent toastContent = new ToastContent()
            {
                Visual = visual,
                Actions = actions,

                // Arguments when the user taps body of toast
                Launch = new QueryString()
    {
        { "action", "viewConversation" },
        { "conversationId", conversationId.ToString() }

    }.ToString()
            };

            // And create the toast notification
            var toast = new ToastNotification(toastContent.GetXml());

            toast.ExpirationTime = DateTime.Now.AddDays(2);

            toast.Tag = "18365";
            toast.Group = "wallPosts";

            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }

        public class Data
        {
            public string Name { get; set; }
        }
    }
}

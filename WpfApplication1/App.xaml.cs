using ClassLibrary2;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApplication1
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        public Logger logger { get; set; }

        public App()
        {
            logger = new Logger("Logger1",LogMode.CURRENT_FOLDER,AlertMode.CONSOLE);
            logger.LifeCycle = true;

            //#region Base Life Cycle
            //this.Startup += App_Startup;
            //this.LoadCompleted += App_LoadCompleted;
            //this.Activated += App_Activated;
            //this.Deactivated += App_Deactivated;
            //this.SessionEnding += App_SessionEnding;
            //this.Exit += App_Exit;
            //#endregion

            //#region Errors
            //this.DispatcherUnhandledException += App_DispatcherUnhandledException;
            //#endregion

            //#region Navigation
            //this.FragmentNavigation += App_FragmentNavigation;
            //this.Navigated += App_Navigated;
            //this.Navigating += App_Navigating;
            //this.NavigationFailed += App_NavigationFailed;
            //this.NavigationProgress += App_NavigationProgress;
            //this.NavigationStopped += App_NavigationStopped;
            //#endregion
        }

        private void App_NavigationStopped(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            logger.Log("App_NavigationStopped");
        }

        private void App_NavigationProgress(object sender, System.Windows.Navigation.NavigationProgressEventArgs e)
        {
            logger.Log("App_NavigationProgress");
        }

        private void App_NavigationFailed(object sender, System.Windows.Navigation.NavigationFailedEventArgs e)
        {
            logger.Log("App_NavigationFailed");
        }

        private void App_Navigating(object sender, System.Windows.Navigation.NavigatingCancelEventArgs e)
        {
            logger.Log("App_Navigating");
        }

        private void App_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            logger.Log("App_Navigated");
        }

        private void App_FragmentNavigation(object sender, System.Windows.Navigation.FragmentNavigationEventArgs e)
        {
            logger.Log("App_FragmentNavigation");
        }

        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            logger.Log("App_Deactivated");
        }

        private void App_Exit(object sender, ExitEventArgs e)
        {
            logger.Log("App_Exit");
        }

        private void App_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            logger.Log("App_LoadCompleted");
        }

        private void App_SessionEnding(object sender, SessionEndingCancelEventArgs e)
        {
            logger.Log("App_SessionEnding");
        }

        private void App_Startup(object sender, StartupEventArgs e)
        {
            logger.Log("App_Startup");
        }

        private void App_Deactivated(object sender, EventArgs e)
        {
            logger.Log("App_Deactivated");
        }

        private void App_Activated(object sender, EventArgs e)
        {
            logger.Log("App_Activated");
        }
    }
}

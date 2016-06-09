// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

using System.Windows.Controls;

namespace App1.MyUserControl
{
    public sealed partial class AddRemoveUserControl : UserControl
    {
        #region attributs
        #endregion

        #region properties
        public Button AddBtn { get; set; }
        public Button RemoveBtn { get; set; }
        #endregion

        #region constructor
        public AddRemoveUserControl()
        {
            this.InitializeComponent();
            this.AddBtn = this.addBtn;
            this.RemoveBtn = this.removeBtn;
        }
        #endregion

        #region methods

        #endregion
    }
}

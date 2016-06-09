using App1.Model;
using App1.MyUserControl.Base;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace App1.MyUserControl
{
    public sealed partial class ClientUserControl : BaseUserControl
    {
        #region attributs
        private Client client;
        #endregion

        #region properties
        public Client Client
        {
            get
            {
                return this.client;
            }

            set
            {
                this.client = value;
                base.OnPropertyChanged("Client");
            }
        }
        #endregion

        #region constructor
        public ClientUserControl()
        {
            this.InitializeComponent();
            this.DataContext = this;
        }
        #endregion

        #region methods

        #endregion
    }
}

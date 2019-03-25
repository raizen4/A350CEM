using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace Client.Views
{
    public partial class TeamDetailsPage : ContentPage
    {
        public TeamDetailsPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            PopupNavigation.Instance.PushAsync(new Popup());
        }
    }
}

using Client.Models;
using Client.ViewModels;
using Xamarin.Forms;

namespace Client.Views
{
    public partial class AircraftInfoPage : ContentPage
    {
        AircraftInfoPageViewModel vm;
        public AircraftInfoPage()
        {
            InitializeComponent();
            this.vm = BindingContext as AircraftInfoPageViewModel;
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var aicraftPressed = e.Item as Aircraft;
            this.vm.ShowOrHideExtension(aicraftPressed);
        }
    }
}

using Client.Models;
using Client.ViewModels;
using Xamarin.Forms;

namespace Client.Views
{
    public partial class AircraftTasksPage : ContentPage
    {
        AircraftTasksPageViewModel vm;
        public AircraftTasksPage()
        {
            InitializeComponent();
            this.vm = BindingContext as AircraftTasksPageViewModel;
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var taskPressed = e.Item as MarlTaskAsCompleted;
            vm.ShowOrHideExtension(taskPressed);
        }
    }
}

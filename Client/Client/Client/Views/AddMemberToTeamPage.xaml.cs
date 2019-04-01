using Client.Models;
using Client.ViewModels;
using Xamarin.Forms;

namespace Client.Views
{
    public partial class AddMemberToTeamPage : ContentPage
    {
        private AddMemberToTeamPageViewModel vm;
        public AddMemberToTeamPage()
        {
            InitializeComponent();
            this.vm = BindingContext as AddMemberToTeamPageViewModel;
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var employeePressed = e.Item as Employee;
            vm.ShowOrHideExtension(employeePressed);
        }
    }
}

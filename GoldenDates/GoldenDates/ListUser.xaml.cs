using GoldenDates.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GoldenDates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListUser : ContentPage
    {
        Api _api;
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var listUsers = await _api.ListUsers();
            lvUsers.ItemsSource = listUsers;
        }
        public ListUser()
        {
            InitializeComponent();
            _api = new Api();
        }

        public async void btnAgregarUsuarioUser_Clicked(object sender, EventArgs e)
        {
            //App.MasterD.IsPresented = false;
            //await App.MasterD.Detail.Navigation.PushAsync(new Adduser());

            await Navigation.PushAsync(new AddUser());
        }



        private async void lvUsers_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selectedItem = (UserResponse)e.Item;
            await Navigation.PushAsync(new EditUser(selectedItem));
        }
    }
}
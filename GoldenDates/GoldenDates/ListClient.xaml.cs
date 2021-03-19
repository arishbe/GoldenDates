using GoldenDates.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GoldenDates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListClient : ContentPage
    {
       
        Api _api;
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var listClient = await _api.ListClient();
            lvClient.ItemsSource = listClient;
        }
        public ListClient()
        {
            InitializeComponent();
            _api = new Api();
        }

        public async void btnAgregarClienteCli_Clicked(object sender, EventArgs e)
        {
            //App.MasterD.IsPresented = false;
            //await App.MasterD.Detail.Navigation.PushAsync(new Adduser());

            await Navigation.PushAsync(new AddClient());
        }



        private async void lvClient_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selectedItem = (ClientResponse)e.Item;
            await Navigation.PushAsync(new EditClient(selectedItem));
        }
    }
}
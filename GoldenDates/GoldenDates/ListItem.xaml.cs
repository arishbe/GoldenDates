using System;
using GoldenDates.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GoldenDates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListItem : ContentPage
    {
        Api _api;
        protected async override void OnAppearing()
        {
            base.OnAppearing();
            var listItem = await _api.ListItems();
            lvItems.ItemsSource = listItem;
        }
        public ListItem()
        {
            InitializeComponent();
            _api = new Api();
        }
        private async void lvItem_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selectedItem = (ProductoResponse)e.Item;
            await Navigation.PushAsync(new EditItem(selectedItem));
        }

        public async void btnAgregarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddItem());
        }
        public async void btnEditarItem_Clicked(object sender, EventArgs e)
        {
            App.MasterD.IsPresented = false;
            await App.MasterD.Detail.Navigation.PushAsync(new EditItem());
        }
        public async void btnEliminarItem_Clicked(object sender, EventArgs e)
        {
            App.MasterD.IsPresented = false;
            await App.MasterD.Detail.Navigation.PushAsync(new DeleteItem());
        }
    }
}
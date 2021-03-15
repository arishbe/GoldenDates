using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GoldenDates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddItem : ContentPage
    {
        Api _api;
        public AddItem()
        {
            InitializeComponent();
            _api = new Api();

        }
        private async void btnAddItem_Clicked(object sender, EventArgs e)
        {
            var addItem = await _api.AddItem(new Models.ProductoRequest()
            {
                description = txtdescriptionItem.Text,
                cantidad = int.Parse(txtQuantity.Text),
                stockmin = int.Parse(txtstockmin.Text),
                stockmax = int.Parse(txtstockmax.Text),


            });
            await Navigation.PopAsync();

            await DisplayAlert("Alert", "Se agregó correctamente", "OK");
        }
    }
}
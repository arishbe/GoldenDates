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
    public partial class EditItem : ContentPage
    {
        Api _api;
        public EditItem()
        {
            InitializeComponent();
            _api = new Api();

        }
        public EditItem(ProductoResponse _item)
        {
            InitializeComponent();
            _api = new Api();
            txtitemid.Text = _item.id_prod.ToString();
            txtdescriptionItem.Text = _item.description;
            txtQuantity.Text = _item.id_prod.ToString();
            txtstockmax.Text = _item.id_prod.ToString();
            txtstockmin.Text = _item.id_prod.ToString();
        }
        private async void btnEditItem_Clicked(object sender, EventArgs e)
        {
            var EditItems = await _api.EditItems(new Models.ProductoRequest()
            {
                id_prod = int.Parse(txtitemid.Text),
                description = txtdescriptionItem.Text,
                cantidad = int.Parse(txtQuantity.Text),
                stockmin = int.Parse(txtstockmin.Text),
                stockmax = int.Parse(txtstockmax.Text),
            
            });
            await Navigation.PopAsync();

            await DisplayAlert("Alert", "Se editó correctamente", "OK");

        }
        private async void btnDeleteItem_Clicked(object sender, EventArgs e)
        {
            var deleteItem = await _api.DeleteItem(new Models.ProductoRequest()
            {
               id_prod = int.Parse(txtitemid.Text)
            });
            await Navigation.PopAsync();
            if (deleteItem)
            {
                await DisplayAlert("Alert", "Se Eliminó correctamente", "OK");
            }
            else
            {
                await DisplayAlert("Alert", "Hubo un problema al eliminar usuario", "OK");
            }

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GoldenDates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeleteItem : ContentPage
    {
        Api _api;
        public DeleteItem()
        {
            InitializeComponent();
            _api = new Api();

        }
        private async void btnDeleteItem_Clicked(object sender, EventArgs e)
        {
            var DeleteItem = await _api.DeleteItem(new Models.ProductoRequest()
            {
                id_prod = int.Parse(txtitemid.Text)
            });
            await DisplayAlert("Alert", "Se Eliminó correctamente", "OK");
        }
    }
}
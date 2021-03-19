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
    public partial class AddClient : ContentPage
    {
        Api _api;
        public AddClient()
        {
            InitializeComponent();
            _api = new Api();
        }
        private async void btnAddClient_Clicked(object sender, EventArgs e)
        {
            var addClient = await _api.AddClient(new Models.ClientRequest()
            {
                nombre = txtNombre.Text,
                apellido = txtApellido.Text,
                telefono = int.Parse(txtTelefono.Text),
                direccion = txtDireccion.Text,
             


            });
            await Navigation.PopAsync();

            await DisplayAlert("Alert", "Se agregó correctamente", "OK");
        }
    }
}

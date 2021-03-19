using GoldenDates.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GoldenDates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditClient : ContentPage
    {
        Api _api;
        public EditClient()
        {
            InitializeComponent();
            _api = new Api();
        }
        public EditClient(ClientResponse _client)
        {
            InitializeComponent();
            _api = new Api();
            txtidcli.Text = _client.id_cli.ToString();
            txtNombre.Text = _client.nombre;
            txtApellido.Text = _client.apellido;
            txtTelefono.Text = _client.telefono.ToString();
            txtDireccion.Text = _client.direccion;
        }
        private async void btnEditClient_Clicked(object sender, EventArgs e)
        {
            var EditClient = await _api.EditClient(new Models.ClientRequest()
            {
                id_cli = int.Parse(txtidcli.Text),
                nombre = txtNombre.Text,
                apellido = txtApellido.Text,
                telefono = int.Parse(txtTelefono.Text),
                direccion = txtDireccion.Text
            });
            await Navigation.PopAsync();
            await DisplayAlert("Alert", "Se editó correctamente", "OK");
        }
        private async void btnDeleteClient_Clicked(object sender, EventArgs e)
        {
            var deleteclient = await _api.DeleteClient(new Models.ClientRequest()
            {
                id_cli = int.Parse(txtidcli.Text)
            });
            await Navigation.PopAsync();
            if (deleteclient)
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
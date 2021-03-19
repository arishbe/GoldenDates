using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GoldenDates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeleteClient : ContentPage
    {
        Api _api;
        public DeleteClient()
        {
            InitializeComponent();
            _api = new Api();

        }
        private async void btnDeleteClient_Clicked(object sender, EventArgs e)
        {
            var deleteUsers = await _api.DeleteClient(new Models.ClientRequest()
            {
                id_cli = int.Parse(txtidcli.Text)
            });
            await DisplayAlert("Alert", "Se Eliminó correctamente", "OK");
        }
    }
}
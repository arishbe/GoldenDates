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
    public partial class DeleteUser : ContentPage
    {
        Api _api;
        public DeleteUser()
        {
            InitializeComponent();
            _api = new Api();

        }
        private async void btnDeleteUsers_Clicked(object sender, EventArgs e)
        {
            var deleteUsers = await _api.DeleteUsers(new Models.UserRequest()
            {
                id_user = int.Parse(txtuserdid.Text)
            });
            await DisplayAlert("Alert", "Se Eliminó correctamente", "OK");
        }
    }
}
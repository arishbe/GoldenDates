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
    public partial class AddUser : ContentPage
    {
        Api _api;
        public AddUser()
        {
            InitializeComponent();
            _api = new Api();

        }
        private async void btnAddUsers_Clicked(object sender, EventArgs e)
        {
            var addUser = await _api.AddUsers(new Models.UserRequest()
            {
                username = txtUsername.Text,
                password = txtPassword.Text,
                nombre = txtName.Text,
                apellido = txtLastname.Text,
                birthday = txtBirtday.Date


            });
            await Navigation.PopAsync();

            await DisplayAlert("Alert", "Se agregó correctamente", "OK");
        }
    }
}
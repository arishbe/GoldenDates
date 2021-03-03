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
    public partial class EditUser : ContentPage
    {
        Api _api;
        public EditUser()
        {
            InitializeComponent();
            _api = new Api();
        }
        public EditUser(UserResponse _user)
        {
            InitializeComponent();
            _api = new Api();
            txtUserId.Text = _user.id_user.ToString();
            txtUsername.Text = _user.username;
            txtPassword.Text = _user.password;
            txtName.Text = _user.nombre;
            txtLastname.Text = _user.apellido;
            txtBirtday.Date = _user.birthday;
        }
        private async void btnEditUser_Clicked(object sender, EventArgs e)
        {
            var EditUser = await _api.EditUsers(new Models.UserRequest()
            {
                id_user = int.Parse(txtUserId.Text),
                username = txtUsername.Text,
                password = txtPassword.Text,
                nombre = txtName.Text,
                apellido = txtLastname.Text,
                birthday = txtBirtday.Date
            });
            await Navigation.PopAsync();
            await DisplayAlert("Alert", "Se editó correctamente", "OK");
        }
        private async void btnDeleteUsers_Clicked(object sender, EventArgs e)
        {
            var deleteUsers = await _api.DeleteUsers(new Models.UserRequest()
            {
                id_user = int.Parse(txtUserId.Text)
            });
            await Navigation.PopAsync();
            if (deleteUsers)
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
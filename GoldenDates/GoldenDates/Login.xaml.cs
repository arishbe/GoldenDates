using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GoldenDates
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        Api _api;
        public Login()
        {
            InitializeComponent();
            _api = new Api();
        }
        private async void btnlogin_Clicked(object sender, EventArgs e)
        {
            var login = await _api.Login(new Models.LoginRequest()
            {
                username = txtusernamelogin.Text,
                password = txtpasswordlogin.Text,
            });

            if (login.id_user > 0)
            {
                //if (login.username == )
                //{

                //}
                //if login.username == username
                //si si  
                //if login.password == password
                //si si
                //ir al menu principal
                //sino password incorrecto
                //sino usuario incorrecto
                App.Current.MainPage = new Menu.MenuGD();

            }
            else
            {
                await DisplayAlert("Error", "Usuario o contraseña no valido ", "OK");
            }
            //App.Current.MainPage = new Menu.MenuPrincipal();
            //await App.MasterD.Detail.Navigation.PushAsync(new PrimeraPag());

        }
    }
}

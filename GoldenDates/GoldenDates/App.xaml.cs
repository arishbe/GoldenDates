﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GoldenDates
{
    public partial class App : Application
    {
        public static MasterDetailPage MasterD { get; set; }
        public App()
        {
            InitializeComponent();

            MainPage = new Login();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

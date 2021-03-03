using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GoldenDates.Menu
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuGDMaster : ContentPage
    {
        public ListView ListView;

        public MenuGDMaster()
        {
            InitializeComponent();

            BindingContext = new MenuGDMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MenuGDMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MenuGDMasterMenuItem> MenuItems { get; set; }

            public MenuGDMasterViewModel()
            {
                MenuItems = new ObservableCollection<MenuGDMasterMenuItem>(new[]
                {
                    new MenuGDMasterMenuItem { Id = 0, Title = "Listado de Usuarios", TargetType = typeof (ListUser) },
                    new MenuGDMasterMenuItem { Id = 1, Title = "Listado de Productos", TargetType = typeof (ListItem)},
                    new MenuGDMasterMenuItem { Id = 2, Title = "Listado de Clientes", TargetType = typeof (ListClient)  },
                   
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}
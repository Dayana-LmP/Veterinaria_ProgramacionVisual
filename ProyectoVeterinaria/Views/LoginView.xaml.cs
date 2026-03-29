using System;
using System.Windows;
using ProyectoVeterinaria.ViewModel;

namespace ProyectoVeterinaria.Views
{
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
        
            this.DataContext = new LoginViewModel();
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            Application.Current.Shutdown();
        }
    }
}


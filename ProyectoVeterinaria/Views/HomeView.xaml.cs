using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProyectoVeterinaria.Views
{
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
        }

        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            // Ya estás aquí
        }

        private void BtnConsultas_Click(object sender, RoutedEventArgs e)
        {
            new Consultas().Show();
            this.Close();
        }

        private void BtnMascotas_Click(object sender, RoutedEventArgs e)
        {
            new MascotasView().Show();
            this.Close();
        }

        private void BtnDueno_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Pantalla no creada");
        }

        private void BtnMedicamentos_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Pantalla no creada");
        }

        private void BtnEmpleados_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Pantalla no creada");
        }
    }
}
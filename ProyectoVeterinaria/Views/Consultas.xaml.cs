using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ProyectoVeterinaria.Views
{
    public partial class Consultas : Window
    {
        List<Consulta> lista = new List<Consulta>();
        string vacuna = "";

        public Consultas()
        {
            InitializeComponent();
        }

        private void BtnSi_Click(object sender, RoutedEventArgs e)
        {
            vacuna = "SI";
        }

        private void BtnNo_Click(object sender, RoutedEventArgs e)
        {
            vacuna = "NO";
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            if (txtMascota.Text == "" || txtDueno.Text == "" || txtServicio.Text == "" || vacuna == "")
            {
                MessageBox.Show("Completa todos los campos");
                return;
            }

            var nueva = new Consulta
            {
                Mascota = txtMascota.Text,
                Veterinario = txtDueno.Text,
                Estado = txtServicio.Text + " | Vacuna: " + vacuna
            };

            lista.Add(nueva);

            dgConsultas.ItemsSource = null;
            dgConsultas.ItemsSource = lista;

            MessageBox.Show("Guardado");

            //limpiar
            txtMascota.Text = "";
            txtDueno.Text = "";
            txtServicio.Text = "";
            vacuna = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }

    public class Consulta
    {
        public string Mascota { get; set; }
        public string Veterinario { get; set; }
        public string Estado { get; set; }
    }
} 
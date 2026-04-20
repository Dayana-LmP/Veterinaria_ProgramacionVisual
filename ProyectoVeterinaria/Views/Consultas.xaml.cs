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

        /*  private void Guardar_Click(object sender, RoutedEventArgs e)
          {
              if (txtMascota.Text == "" || txtDueno.Text == "" || txtServicio.Text == "" )
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
      } */

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            // 1. Recolectamos los servicios seleccionados del ListBox
            List<string> serviciosSeleccionados = new List<string>();
            foreach (var item in lstServicios.Items)
            {
                if (item is CheckBox cb && cb.IsChecked == true)
                {
                    serviciosSeleccionados.Add(cb.Content.ToString());
                }
            }

            // Convertimos la lista de servicios a un solo texto separado por comas
            string serviciosTexto = string.Join(", ", serviciosSeleccionados);

            // 2. Ajustamos la validación (ahora verificamos 'serviciosTexto' en lugar de 'txtServicio.Text')
            if (string.IsNullOrWhiteSpace(txtMascota.Text) ||
                string.IsNullOrWhiteSpace(txtVet.Text) ||
                string.IsNullOrEmpty(serviciosTexto))
            {
                MessageBox.Show("Completa todos los campos y selecciona al menos un servicio");
                return;
            }

            var nueva = new Consulta
            {
                Mascota = txtMascota.Text,
                // Usé txtVet porque en tu XAML anterior lo llamaste así para el Veterinario
                Veterinario = txtVet.Text,
                // 3. Guardamos los servicios seleccionados y el estado de la vacuna
                Estado = serviciosTexto 
            };

            lista.Add(nueva);

            dgConsultas.ItemsSource = null;
            dgConsultas.ItemsSource = lista;

            MessageBox.Show("Guardado exitosamente");

            // 4. Limpiar campos
            txtMascota.Text = "";
            txtVet.Text = "";
            

            // Limpiar los CheckBoxes del ListBox
            foreach (var item in lstServicios.Items)
            {
                if (item is CheckBox cb) cb.IsChecked = false;
            }
        }

        public class Consulta
        {
            public string Mascota { get; set; }
            public string Veterinario { get; set; }
            public string Estado { get; set; }
        }
    }
}
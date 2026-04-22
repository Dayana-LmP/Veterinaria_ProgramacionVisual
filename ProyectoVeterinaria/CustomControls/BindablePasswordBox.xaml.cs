using System.Windows;
using System.Windows.Controls;

namespace ProyectoVeterinaria.CustomControls
{
    public partial class BindablePasswordBox : UserControl
    {
        
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(string), typeof(BindablePasswordBox),
                new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnPasswordPropertyChanged));

        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        public BindablePasswordBox()
        {
            InitializeComponent();
        }

        //Este método se ejecuta cuando Password cambia desde ViewModel
        private static void OnPasswordPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is BindablePasswordBox passwordBox)
            {
                
                if (passwordBox._passwordBox.Password != (string)e.NewValue)
                {
                    passwordBox._passwordBox.Password = (string)e.NewValue;
                }
            }
        }

        //Este método se ejecuta cuando el usuario escribe en la interfaz
        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            Password = _passwordBox.Password;
        }
    }
}
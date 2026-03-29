using ProyectoVeterinaria.ViewModel;
using System.ComponentModel;
using System.Windows.Input;


    namespace ProyectoVeterinaria.ViewModel
    {
        public class LoginViewModel : ViewModelBase
        {
            // Campos
            private string _username;
            private string _password; // CAMBIADO: Antes era SecureString, ahora es string
            private string _errorMessage;

            // Propiedades
            public string Username
            {
                get => _username;
                set { _username = value; OnPropertyChanged(nameof(Username)); }
            }

            public string Password // CAMBIADO: Antes era SecureString, ahora es string
            {
                get => _password;
                set { _password = value; OnPropertyChanged(nameof(Password)); }
            }

            public string ErrorMessage
            {
                get => _errorMessage;
                set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); }
            }

            // Comando
            public ICommand LoginCommand { get; }

            public LoginViewModel()
            {
                LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            }

            private bool CanExecuteLoginCommand(object obj)
            {
                // El botón se activa si ambos tienen texto y son más de 3 caracteres
                return !string.IsNullOrWhiteSpace(Username) && Username.Length >= 3 &&
                       !string.IsNullOrWhiteSpace(Password) && Password.Length >= 3;
            }

            private void ExecuteLoginCommand(object obj)
            {
                // Lógica de prueba
                if (Username == "admin" && Password == "1234")
                {
                    System.Windows.MessageBox.Show("¡Inicio de sesión exitoso!");
                }
                else
                {
                    ErrorMessage = "* Usuario o contraseña incorrectos";
                }
            }
        }
    }
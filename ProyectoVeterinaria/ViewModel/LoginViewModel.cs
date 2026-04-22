using ProyectoVeterinaria.Model;
using ProyectoVeterinaria.Repositories;
using ProyectoVeterinaria.Views;
using System.Security;
using System.Security.Principal;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace ProyectoVeterinaria.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        
        private string _username;
        private string _password; 
        private string _errorMessage;
        private bool _isLoginVisible = true;
        private IUserRepository _userRepository;

        
        public string Username
        {
            get { return _username; }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public bool IsLoginVisible
        {
            get { return _isLoginVisible; }
            set
            {
                _isLoginVisible = value;
                OnPropertyChanged(nameof(IsLoginVisible));
            }
        }

        //Comandos
        public ICommand LoginCommand { get; }
        public IUserRepository UserRepository { get => _userRepository; set => _userRepository = value; }
        public ICommand ShowRegisterCommand { get; }

        //Constructor
        public LoginViewModel()
        {
            _userRepository = new UserRepository();
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            ShowRegisterCommand = new ViewModelCommand(ExecuteShowRegisterCommand);
        }

        private bool CanExecuteLoginCommand(object obj)
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(Username) || Username.Length < 3 ||
                Password == null || Password.Length < 3)
                validData = false;
            else
                validData = true;

            return validData;
        }

        public void ExecuteLoginCommand(object obj)
        {
            var isValidUser = UserRepository.AuthenticateUser(
                new System.Net.NetworkCredential(Username, Password));

            if (isValidUser)
            {
               
                System.Windows.MessageBox.Show("Inicio de sesión exitoso");

                var consultasWindow = new ProyectoVeterinaria.Views.Consultas();
                consultasWindow.Show();

                foreach (Window item in Application.Current.Windows)
                {
                    if (item.DataContext == this)
                    {
                        item.Close();
                        break;
                    }
                }
            }
            else
            {
                ErrorMessage = "* Usuario o contraseña incorrectos.";
            }
        }

        private void ExecuteShowRegisterCommand(object obj)
        {
            
            var registroView = new ProyectoVeterinaria.Views.RegistroView();
            registroView.Show();
        }
    }
}
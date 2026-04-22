
using ProyectoVeterinaria.Model;
using ProyectoVeterinaria.Repositories;
using System;
using System.Windows;
using System.Windows.Input;

namespace ProyectoVeterinaria.ViewModel
{
    public class RegistroViewModel : ViewModelBase
    {
        private UserModel _user;
        private string _errorMensage;
        private readonly IUserRepository _userRepository;

        public UserModel User
        {
            get => _user;
            set { _user = value; OnPropertyChanged(nameof(User)); }
        }

        public string ErrorMensage
        {
            get => _errorMensage;
            set { _errorMensage = value; OnPropertyChanged(nameof(ErrorMensage)); }
        }

        public ICommand AddCommand { get; }

        public RegistroViewModel()
        {
            _userRepository = new UserRepository();
            User = new UserModel();
            AddCommand = new ViewModelCommand(ExecuteAddCommand, CanExecuteAddCommand);
        }

        private bool CanExecuteAddCommand(object obj)
        {
            //El botón solo se activa si los campos básicos no están vacíos
            return !string.IsNullOrWhiteSpace(User.Username) &&
                   !string.IsNullOrWhiteSpace(User.Password) &&
                   !string.IsNullOrWhiteSpace(User.Name) &&
                   !string.IsNullOrWhiteSpace(User.Email);
        }

        private void ExecuteAddCommand(object obj)
        {
            //Verificar que las contraseñas coincidan
            if (User.Password != User.ConfirmPassword)
            {
                ErrorMensage = "* Las contraseñas no coinciden.";
                return;
            }

            try
            {
               
                var existingUser = _userRepository.GetByUsername(User.Username);
                if (existingUser != null)
                {
                    ErrorMensage = "* El nombre de usuario ya existe.";
                    return;
                }

                User.Id = Guid.NewGuid().ToString();

                _userRepository.Add(User);

                MessageBox.Show("Usuario registrado con éxito.", "Registro", MessageBoxButton.OK, MessageBoxImage.Information);

                User = new UserModel();
                ErrorMensage = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }
    }
}
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using ProyectoVeterinaria.Model;
using ProyectoVeterinaria.Repositories;

namespace ProyectoVeterinaria.ViewModel
{
    public class ManejoUsuariosViewModel : ViewModelBase
    {
        private ObservableCollection<UserModel> _users;
        private UserModel _selectedUser;
        private IUserRepository userRepository;

        public ObservableCollection<UserModel> Users
        {
            get => _users;
            set
            {
                _users = value;
                OnPropertyChanged();
            }
        }

        public UserModel SelectedUser
        {
            get => _selectedUser;
            set
            {
                _selectedUser = value;
                OnPropertyChanged();
            }
        }

        public ICommand RefreshCommand { get; }
        public ICommand DeleteCommand { get; }
        public ICommand EditCommand { get; }

        public ManejoUsuariosViewModel()
        {
            userRepository = new UserRepository();

            Users = new ObservableCollection<UserModel>(userRepository.GetAllUsers());

           
            RefreshCommand = new ViewModelCommand(ExecuteRefreshCommand);
            DeleteCommand = new ViewModelCommand(ExecuteDeleteUser);
            EditCommand = new ViewModelCommand(ExecuteEditUser);

            LoadUsers();
        }

        private void ExecuteRefreshCommand(object obj)
        {
            LoadUsers();
        }

        private void LoadUsers()
        {
           
            Users = new ObservableCollection<UserModel>(userRepository.GetAllUsers());
        }
        private void ExecuteDeleteUser(object obj)
        {
            if (obj is UserModel user)
            {
                userRepository.Delete(user);
                MessageBox.Show("Usuario eliminado");
                LoadUsers();
            }
        }

        private void ExecuteEditUser(object obj)
        {
            if (SelectedUser == null)
            {
                MessageBox.Show("Selecciona un usuario");
                return;
            }

            
            
        }
    }
}
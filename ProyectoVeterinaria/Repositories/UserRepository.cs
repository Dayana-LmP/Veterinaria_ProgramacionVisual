using ProyectoVeterinaria.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Windows; //Para el MessageBox

namespace ProyectoVeterinaria.Repositories
{
    public class UserRepository : RepositoryBase, IUserRepository
    {
        public bool AuthenticateUser(NetworkCredential credential)
        {
            bool validUser;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM [User1] WHERE Username = @username AND [Password] = @password";
                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = credential.UserName;
                command.Parameters.Add("@password", SqlDbType.NVarChar).Value = credential.Password;
                validUser = command.ExecuteScalar() == null ? false : true;
            }
            return validUser;
        }

        public void Add(UserModel userModel)
        {
            try
            {
                using (var connection = GetConnection())
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    //No incluimos la columna 'Id' porque es automaticamente generada por la base de datos

                    command.CommandText = @"INSERT INTO [User1] (Username, [Password], Name, LastName, Email, Rol) 
                        VALUES (@Username, @Password, @Name, @LastName, @Email, @Rol)";

                    command.Parameters.AddWithValue("@Username", userModel.Username);
                    command.Parameters.AddWithValue("@Password", userModel.Password);
                    command.Parameters.AddWithValue("@Name", userModel.Name);
                    command.Parameters.AddWithValue("@LastName", userModel.LastName);
                    command.Parameters.AddWithValue("@Email", userModel.Email);
                    command.Parameters.AddWithValue("@Rol", userModel.Rol);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar: " + ex.Message);
            }
        }

        public void Delete(UserModel userModel)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "DELETE FROM [User1] WHERE Id = @Id";
                command.Parameters.AddWithValue("@Id", userModel.Id);
                command.ExecuteNonQuery();
            }
        }

        public void Update(UserModel userModel)
        {
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "UPDATE [User1] SET Username = @Username, Name = @Name, LastName = @LastName, Email = @Email WHERE Id = @Id";
                command.Parameters.AddWithValue("@Id", userModel.Id);
                command.Parameters.AddWithValue("@Username", userModel.Username);
                command.Parameters.AddWithValue("@Name", userModel.Name);
                command.Parameters.AddWithValue("@LastName", userModel.LastName);
                command.Parameters.AddWithValue("@Email", userModel.Email);
                command.ExecuteNonQuery();
            }
        }

        public UserModel GetByUsername(string username)
        {
            UserModel user = null;
            using (var connection = GetConnection())
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "SELECT * FROM [User1] WHERE Username = @username";
                command.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        user = new UserModel()
                        {
                            Id = reader["Id"].ToString(),
                            Username = reader["Username"].ToString(),
                            Password = string.Empty,
                            Name = reader["Name"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Email = reader["Email"].ToString(),
                            Rol = reader["Rol"].ToString()
                        };
                    }
                }
            }
            return user;
        }

        public IEnumerable<UserModel> GetAllUsers()
        {
            var userList = new List<UserModel>();
            using (var connection = GetConnection())
            using (var command = new SqlCommand("SELECT * FROM [User1]", connection))
            {
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        userList.Add(new UserModel()
                        {
                            Id = reader["Id"].ToString(),
                            Username = reader["Username"].ToString(),
                            Name = reader["Name"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Email = reader["Email"].ToString()
                        });
                    }
                }
            }
            return userList;
        }
    }
}
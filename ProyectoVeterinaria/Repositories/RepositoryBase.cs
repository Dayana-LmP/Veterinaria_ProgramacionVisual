using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ProyectoVeterinaria.Repositories 
{
    public abstract class RepositoryBase
    {
        
        private readonly string _connectionString;

        public RepositoryBase()
        {
            //cadena para conectar a la base de datos.
            _connectionString =
                "Server = LAPTOPDAYANA\\DLGESTION;" +
                "Database = DataBaseVeterinaria;" +
                "Integrated Security = true";
        }

        //Método para conectar a la base de datos.
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

    }
}

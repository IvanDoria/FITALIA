using Fitalia.Interfaces;
using Fitalia.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;

namespace Fitalia.DAO
{
    public class IniciarSesionDAO : IIniciarSesionDAO
    {
        //private readonly SQLServerConfiguration _connectionString;
        private readonly ILogger<IniciarSesionDAO> _logger;

        public IniciarSesionDAO()
        {

        }

        /*public IniciarSesionDAO(IOptions<SQLServerConfiguration> connectionString, ILogger<IniciarSesionDAO> logger)
        {
            _connectionString = connectionString.Value;
            _logger = logger;
        }*/

        public Task<Usuario> buscarUsuario(Usuario usuario)
        {
            return null;
        }
    }
}

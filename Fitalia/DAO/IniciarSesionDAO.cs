using Fitalia.Interfaces;

namespace Fitalia.DAO
{
    public class IniciarSesionDAO : IIniciarSesionDAO
    {
        private readonly SQLServerConfiguration _connectionString;
        private readonly ILogger<IniciarSesionDAO> _logger;


        public LoginDAO(IOptions<SQLServerConfiguration> connectionString, ILogger<IniciarSesionDAO> logger)
        {
            _connectionString = connectionString.Value;
            _logger = logger;
        }

        public Task<Usuario> buscarUsuario(Usuario usuario)
        {

        }
    }
}

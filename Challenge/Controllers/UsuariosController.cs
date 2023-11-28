using Microsoft.AspNetCore.Mvc;

namespace Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        // Instancio el objeto Usuario de su Clase.
        Usuario usuario = new Usuario();

        // Creo la lista a utilizar para guardar en memoria los usuarios
        private static readonly List<Usuario> _usuarios = new List<Usuario>();

        // Endpoint para crear un usuario
        [HttpPost]
        public IActionResult CrearUsuario(string username, string password)
        {
            usuario.Id = Guid.NewGuid();
            usuario.Username = username;
            usuario.Password = password;
            usuario.PasswordEncriptada = password + " encriptado";
            _usuarios.Add(usuario);

            return Ok(usuario);
        }
        // Endpoint para obtener todos los usuarios
        [HttpGet]
        public IActionResult ObtenerTodosLosUsuarios() 
        {
            return Ok(_usuarios);
        }

        // Endpoint para buscar un usuario por nombre de usuario
        [HttpGet("{username}")]
        public IActionResult ObtenerUsuario(string username)
        {
            // Busco un usuario según su username (LINQ) y lo guardo en la var. Si no encuentra nada, se
            // guarda null y se muestra un mensaje.
            var usuario = _usuarios.Where(x => x.Username == username).FirstOrDefault();

            if (usuario == null)
            {
                return NotFound("Usuario no encontrado");
            }

            return Ok(usuario);
        }
    }

}

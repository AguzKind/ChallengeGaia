using Microsoft.AspNetCore.Mvc;

namespace Challenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        // Instancio los objetos
        Usuario usuario = new Usuario();
        Encriptacion encriptacion = new Encriptacion();
        Desencriptacion desencriptacion = new Desencriptacion();

        // Creo la lista a utilizar para guardar en memoria los usuarios
        private static readonly List<Usuario> _usuarios = new List<Usuario>();

        // Endpoint para crear un usuario
        [HttpPost]
        public IActionResult CrearUsuario(string username, string password)
        {
            usuario.Id = Guid.NewGuid();
            usuario.Username = username;
            usuario.Password = password;
            password = encriptacion.Encriptar(password);
            usuario.PasswordEncriptada = password;
            usuario.PasswordDesencriptada = desencriptacion.Desencriptar(password);
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
        [HttpGet("{IdOrUsername}")]
        public IActionResult ObtenerUsuarioPorUsername(string IdOrUsername)
        {
            // Busco un usuario por medio de LINQ (primero busca por ID, si no encuentra nada, por username)
            // y lo guardo en la var. Si no encuentra nada, se guarda null y se muestra un mensaje.
            var usuario = _usuarios.Where(x => Convert.ToString(x.Id) == IdOrUsername).FirstOrDefault();

            if (usuario == null)
            {
                usuario = _usuarios.Where(x => x.Username == IdOrUsername).FirstOrDefault();
                if (usuario == null)
                {
                    return NotFound("Usuario no encontrado");
                }
               
            } 
            return Ok(usuario);
        }
    }

}

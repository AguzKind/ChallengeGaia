using System.Net;

namespace UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        Challenge.Controllers.UsuariosController _usuariosController = new Challenge.Controllers.UsuariosController();
        Encriptacion _encriptacion = new Encriptacion();
        Desencriptacion _desencriptacion = new Desencriptacion();

        [Order(0)]
        [Test]
        public void TestPost()
        {
            _usuariosController.CrearUsuario("usuario1", "contraseña1");
            Assert.Pass("El usuario se agrego con exito");
        }

        [Order(1)]
        [Test]
        public void TestEncriptacion()
        {
            string resultado = _encriptacion.Encriptar("holacomoestas");
            Assert.That(resultado, Is.EqualTo("se$ts$iu$mu$ce$lu$h"));
        }
        [Order(2)]
        [Test]
        public void TestDesencriptacion()
        {
            string resultado = _desencriptacion.Desencriptar("eb$ia$rp$id$dr$uw$ss$ep$en$as$iu$ts$i");
            Assert.That(resultado, Is.EqualTo("estoesunapassworddeprueba"));
        }
    }
}
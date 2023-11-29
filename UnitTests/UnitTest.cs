namespace UnitTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        Encriptacion _encriptacion = new Encriptacion();
        Desencriptacion _desencriptacion = new Desencriptacion();

        [Order(0)]
        [Test]
        public void TestEncriptacion()
        {
            string resultado = _encriptacion.Encriptar("holacomoestas");
            Assert.That(resultado, Is.EqualTo("se$ts$iu$mu$ce$lu$h"));
        }
        [Order(1)]
        [Test]
        public void TestDesencriptacion()
        {
            string resultado = _desencriptacion.Desencriptar("eb$ia$rp$id$dr$uw$ss$ep$en$as$iu$ts$i");
            Assert.That(resultado, Is.EqualTo("estoesunapassworddeprueba"));
        }
    }
}
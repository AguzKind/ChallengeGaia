public class Encriptacion
    {
        public string Encriptar (string password)
    {
        // Con esta función, invierte los caracteres del string y los almacena en un array, despues los junta y los
        // guarda en en string.
        password = new string (password.Reverse().ToArray());
        return password;
    }
    }
public class Desencriptacion
{
    // Basicamente, son los mismos metodos que en la encriptacion, pero cada uno a la inversa.
    public string Desencriptar(string password)
    {
        password = AlgoritmoRecursividadInv(password.ToCharArray(), 0);
        password = CambiarVocalesInv(password);
        password = Reverso(password);

        // Devuelve la password desencriptada al endpoint.
        return password;
    }

    private static char[] vocales = { 'u', 'o', 'i', 'e', 'a' };

    public string Reverso(string texto)
    {
        // Con esta función, invierte los caracteres del string y los almacena en un array, despues los junta y los
        // guarda en en string.
        texto = new string(texto.Reverse().ToArray());
        return texto;
    }
    static string AlgoritmoRecursividadInv(char[] password, int indice)
    {
        // Al final del array, se devuelve el mismo pero como string.
        if (indice >= password.Length)
        {
            return new string(password);
        }

        // Verifco si es el caracter '$', si es lo elimino llamando la funcion EliminarCaracter.
        if (password[indice] == '$')
        {
            password = EliminarCaracter(password, indice);
        }

        // Llamada recursiva -> avanza al siguiente indice.
        return AlgoritmoRecursividadInv(password, indice + 1);
    }

    public static char[] EliminarCaracter(char[] array, int indice)
    {
        // Creo un array sin el elemento en la posicion actual.
        char[] nuevoArray = new char[array.Length - 1];

        // Copio los elementos antes de la posicion actual.
        for (int i = 0; i < indice; i++)
        {
            nuevoArray[i] = array[i];
        }

        // Copio los elementos despues de la posicion actual.
        for (int i = indice + 1; i < array.Length; i++)
        {
            nuevoArray[i - 1] = array[i];
        }

        // Devuelvo el array
        return nuevoArray;
    }

    // Funcion que recibe un caracter, y lo compara con los elementos del array vocales, si lo encuentra devuelve el
    // indice, sino devuelve -1 indicando que no se encontró.
    public static bool EsVocal(char c)
    {
        return Array.IndexOf(vocales, char.ToLower(c)) != -1;
    }
    public string CambiarVocalesInv(string password)
    {
        // Paso la cadena de texto password a un array.
        char[] arrayPassword = password.ToCharArray();


        for (int i = 0; i < arrayPassword.Length; i++)
        {
            // Guardo en una variable char el caracter del arrayPassword.
            char caracterActual = arrayPassword[i];

            // Confirmo si es una vocal o no.
            if (EsVocal(caracterActual))
            {
                // Guardo en un bool si era mayuscula o no.
                bool eraMayuscula = char.IsUpper(caracterActual);

                // Cambio a minúscula para comparar con el array de vocales.
                char vocalMinuscula = char.ToLower(caracterActual);

                // Encuentra la posición de la vocal en el array.
                int posicion = Array.IndexOf(vocales, vocalMinuscula);

                // Cambia la vocal a la siguiente en la lista, o a 'u' si es 'a'.
                char nuevaVocal = (posicion == 4) ? vocales[0] : vocales[posicion + 1];

                // Ya cambiada la vocal, la vuelvo mayuscula si asi lo fue.
                nuevaVocal = eraMayuscula ? char.ToUpper(nuevaVocal) : nuevaVocal;

                // Reemplaza la vocal en el texto.
                arrayPassword[i] = nuevaVocal;
            }
        }

        // Devuelve la password como un string.
        return new string(arrayPassword);
    }
}
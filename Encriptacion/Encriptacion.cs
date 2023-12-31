﻿public class Encriptacion
{
    public string Encriptar(string password)
    {
        password = Reverso(password);
        password = CambiarVocales(password);
        password = new string (AlgoritmoRecursividad(password.ToCharArray(), 2, 0));

        // Devuelve la password encriptada al endpoint.
        return password;
    }
    // Array con las vocales para hacer la comparacion
    private static char[] vocales = { 'a', 'e', 'i', 'o', 'u' };

    public string Reverso(string texto)
    {
        // Con esta función, invierte los caracteres del string y los almacena en un array, despues los junta y los
        // guarda en en string.
        texto = new string(texto.Reverse().ToArray());
        return texto;
    }

    // Funcion que recibe un caracter, y lo compara con los elementos del array vocales, si lo encuentra devuelve el
    // indice, sino devuelve -1 indicando que no se encontró.
    public static bool EsVocal(char c)
    {
        return Array.IndexOf(vocales, char.ToLower(c)) != -1;
    }


    public string CambiarVocales(string password)
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

                // Cambia la vocal a la siguiente en la lista, o a 'a' si es 'u'.
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

    public static char[] AlgoritmoRecursividad(char[] password, int posicion, int indice)
    {
        // Cuando se alcanza el final del texto original ->
        if (indice == password.Length)
        {
            // Se crea un nuevo array con espacio adicional para los '$'.
            char[] nuevoArray = new char[password.Length + (password.Length / 2)];

            // Copio el array original (password) al nuevo array con '$' cada 2 posiciones.
            for (int i = 0, j = 0; i < password.Length; i++, j++)
            {
                nuevoArray[j] = password[i];

                // Agrega '$' cada dos posiciones.
                if ((i + 1) % posicion == 0)
                {
                    nuevoArray[++j] = '$';
                }
            }

            return nuevoArray;
        }
        else
        {
            // Algoritmo recursivo -> Copia los elementos y avanza al siguiente índice.
            char[] resultadoParcial = AlgoritmoRecursividad(password, posicion, indice + 1);

            return resultadoParcial;
        }
    }
}
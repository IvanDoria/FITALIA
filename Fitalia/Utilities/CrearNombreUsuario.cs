namespace Fitalia.Utilities
{
    public class CrearNombreUsuario
    {
        private static Random random = new Random();

        public static string crearNombreUsuarioAleatorio(string nombre, string apellidoP, string apellidoM)
        {
            // 🔹 1. Partes posibles del código
            string palabra1 = nombre;
            List<string> palabras = new List<string>() {apellidoP,apellidoM };
            string palabra4 = palabras[random.Next(0,2)];
            string numeros = GenerarFragmento("0123456789", 4);
            string letras = GenerarFragmento("ABCDEFGHIJKLMNOPQRSTUVWXYZ", 3);
            string simbolos = GenerarFragmento("!@#$%^&*_", 2);

            // 🔹 2. Guardamos todas las partes en una lista
            List<string> partes = new List<string> { palabra1, palabra4, numeros, letras, simbolos };

            // 🔹 3. Mezclamos el orden aleatoriamente
            partes = partes.OrderBy(x => random.Next()).ToList();

            // 🔹 4. Unimos todas las partes en un solo string final
            string codigoFinal = string.Join("", partes);

            return codigoFinal;
        }

        // 🔹 Método auxiliar: genera fragmentos aleatorios con los caracteres que quieras
        private static string GenerarFragmento(string chars, int longitud)
        {
            return new string(Enumerable.Repeat(chars, longitud)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}

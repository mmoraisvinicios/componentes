using System.Text.RegularExpressions;

namespace Patterns.MediatRx.Services
{
    public class UtilService
    {
        public static string RemoveLetras(string texto)
        {
            var apenasDigitos = new Regex(@"[^\d]");
            return apenasDigitos.Replace(texto, "");
        }
    }
}

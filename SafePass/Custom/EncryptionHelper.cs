using SafePass.Models;
using SafePass.Data;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace SafePass.Custom
{
    public class EncryptionHelper
    {
        // Funcion para poder acceder a la confi de appsettings.json
        private readonly IConfiguration _configuration;

        public EncryptionHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Funcion de Encriptado
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Convertir la contraseña a bytes
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

                // Generar el hash
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);

                // Convertir el hash a una cadena hexadecimal
                StringBuilder hash = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    hash.Append(b.ToString("x2"));
                }

                return hash.ToString();
            }
        }
    }
}

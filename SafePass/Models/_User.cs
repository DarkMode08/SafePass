namespace SafePass.Models
{
    public class _User
    {
        public int id_User { get; set; }

        public required string Name { get; set; }

        public required string Email { get; set; }

        public required string Password { get; set; }

        // Propiedad para restablecer contraseña (tipo bit)
        public bool Reset { get; set; }

        // Propiedad para confirmar el usuario (tipo bit)
        public bool Confirm { get; set; }

        // Propiedad para el token (tipo varchar)
        public string Token { get; set; }
    }
}

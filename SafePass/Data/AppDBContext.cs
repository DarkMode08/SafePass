// Referencias para la conectividad
using Microsoft.EntityFrameworkCore; // Framework Instalado y en uso
using SafePass.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal; // Ubicacion de las clases
using System.Data.SqlClient; // ADO.NET

namespace SafePass.Data
{
    // EntityFramework
    // Esta clase es para definir todo lo relacionado con las bases de datos, funcionamientos de las tablas etc
    public class AppDBContext : DbContext // Uso de Herencia Perteneciente a EntityFramework para poder acceder a Metodos Necesarios
    {
        // Creacion del constructor
        // Este constructor recibe parametros de tipo opciones, para que sepa como comunicarse con la DB
        public AppDBContext(DbContextOptions<AppDBContext> _Options) : base(_Options)
        {

        }

        // Se Definen las tablas de la DB
        // DBSet es perteneciente a EntityFramework como tipo de dato, <User> es la llamada a la clase creada en Models
        public DbSet<_User> Users { get; set; }

        // Metodo que ayuda a sobre escribir en la tabla
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // TB identificador personal para Tabla
            modelBuilder.Entity<_User>(TB =>
            {
                // Personalizacion de la Tabla - id_User
                TB.HasKey(Colum => Colum.id_User); // Se define id_User como llave primaria

                // Aqui se define la caracteristica de la PK
                TB.Property(Colum => Colum.id_User)
                .UseIdentityColumn() // Valor aumenta de 1 en 1
                .ValueGeneratedOnAdd(); // Se genera cada entrada de registro a la tabla

                // Personalizacion de la Tabla - Name
                TB.Property(Colum => Colum.Name)
                .HasMaxLength(50);

                // Personalizacion de la Tabla - Email
                TB.Property(Colum => Colum.Name)
                .HasMaxLength(50);

                // Personalizacion de la Tabla - Password
                TB.Property(Colum => Colum.Name)
                .HasMaxLength(50);
            });

            // Hacer que modelBuilder apunte hacia la tabla User
            modelBuilder.Entity<_User>().ToTable("_User");

        }
    }
}

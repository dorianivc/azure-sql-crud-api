using System.ComponentModel.DataAnnotations;
namespace AzureSQL_API.Models
{
    public class Contacts
    {
        [Key]
        public string Identificador { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }

    }
}
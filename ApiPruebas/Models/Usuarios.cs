using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiPruebas.Models
{
	public class Usuarios
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdUsuario { get; set; }
        [Required]
        public string Nombre { get; set; }
        public int Edad { get; set; }
        [Required]
        public string Email { get; set; }
    }
}

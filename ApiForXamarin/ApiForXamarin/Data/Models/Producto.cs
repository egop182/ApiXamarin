using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiForXamarin.Data.Models
{
    public class Producto
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public string Nombre { get; set; }
        public string Peso { get; set;}
        public string Precio { get; set;}
        public long Cantidad { get; set; }
        public string Imagen { get; set; }

    }
}

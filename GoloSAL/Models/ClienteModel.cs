using System.ComponentModel.DataAnnotations;

namespace GoloSAL.Models
{
    public class ClienteModel
    {
        public int ClienteID { get; set; }

        [Required(ErrorMessage ="El campo Nombre es obligatorio")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El campo Direccion es obligatorio")]
        public string? Direccion {  get; set; }

        [Required(ErrorMessage = "El campo Telefono es obligatorio")]
        public string? Telefono { get; set; }


    }
}

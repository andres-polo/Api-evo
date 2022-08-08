using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Evo.Apiii.DataBase.Model.Shcemas
{
    public class PropietariosEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(45)]
        public string? Nombre { get; set; }
        [MaxLength(45)]
        public string? Direccion { get; set; }
        [MaxLength(45)]
        public string? Telefono { get; set; }
        [MaxLength(60)]
        public string? Correo { get; set; }
        public string? Comentario { get; set; }

        public virtual ICollection<MascotasEntity> Mascotas { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Evo.Apiii.DataBase.Model.Shcemas
{
    public class TipoMascotasEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(45)]
        public string? Descripcion { get; set; }
        public bool IsActive { get; set; } = true;

        public virtual ICollection<MascotasEntity> Mascotas { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Evo.Apiii.DataBase.Model.Shcemas
{
    public class MascotasEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(45)]
        public string? Nombre { get; set; }
        public int TipoDeMascotaId { get; set; }
        public int PropietarioId { get; set; }

        public virtual TipoMascotasEntity TipoMascotas { get; set; }
        public virtual PropietariosEntity Propietarios { get; set; }

    }
}

using Microsoft.AspNetCore.Mvc;

namespace Evo.Apiii.DTO
{
    public class MascotasDTO
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public int TipoDeMascotaId { get; set; }
        public int PropietarioId { get; set; }
        public bool IsActive { get; set; }
    }
}

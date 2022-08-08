using Evo.Apiii.DataBase.Model.Shcemas;
using Evo_DataAccess.Data;
using Microsoft.EntityFrameworkCore;

namespace Evo.Apiii.DataAccess.Mascotas
{
    public class MascotasRepository : IMascotasRepository
    {
        private readonly EvoContext _context;


        public MascotasRepository(EvoContext context)
        {
            _context = context;
        }

        public async Task<List<MascotasEntity>> getallMascotasRepo()
        {

            var data = await _context.mascotas.ToListAsync();
            return data;
        }

        public async Task<MascotasEntity> GetMascotasIdRepo(int Id)
        {
            return await _context.mascotas.AsNoTracking().FirstOrDefaultAsync(a => a.Id == Id);
        }

        public async Task<MascotasEntity> CreateMascotasRepo(MascotasEntity request)
        {
            MascotasEntity data = new()
            {
                Nombre = request.Nombre,
                TipoDeMascotaId = request.TipoDeMascotaId,
                PropietarioId = request.PropietarioId,
                IsActive = request.IsActive
            };
            await _context.mascotas.AddAsync(request);
            await _context.SaveChangesAsync();
            return data;
        }

        public async Task<bool> UpdateMascotasRepo(MascotasEntity request)
        {
            _context.Entry(request).State = EntityState.Modified;

            try
            {
                return await _context.SaveChangesAsync() > 0;
               
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public async Task<bool> UpdateStateMascotasRepo(int Id)
        {
            MascotasEntity data = await GetMascotasIdRepo(Id);
            if (data == null)
                throw new Exception($"Usuario no encontrado{Id}");

            data.IsActive = !data.IsActive;
            _context.Update(data);
            int ChangeStateCount = await _context.SaveChangesAsync();

            MascotasEntity response = new() { IsActive = ChangeStateCount > 0 };
            return response.IsActive;
        }

    }
}

using Evo.Apiii.DataBase.Model.Shcemas;

namespace Evo.Apiii.DataAccess.Mascotas
{
    public interface IMascotasRepository
    {
        Task<MascotasEntity> CreateMascotasRepo(MascotasEntity request);
        Task<List<MascotasEntity>> getallMascotasRepo();
        Task<MascotasEntity> GetMascotasIdRepo(int Id);
        Task<bool> UpdateMascotasRepo(MascotasEntity request);
        Task<bool> UpdateStateMascotasRepo(int Id);
    }
}
using Evo.Apiii.DataAccess.Mascotas;
using Evo.Apiii.DataBase.Model.Shcemas;
using Evo.Apiii.DTO;
using Evo.Apiii.Helper;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Evo.Apiii.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MascotasController : Controller
    {

        private IMascotasRepository _repository;
        public MascotasController(IMascotasRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("[action]")]
        public async Task<List<MascotasEntity>> GetAllPropetariosRepo()
        {
            var data = await _repository.getallMascotasRepo();
            return data;
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<ApiResponse> GetMascotasId(int id)
        {
            try
            {
                var data = await _repository.GetMascotasIdRepo(id);
                return new ApiResponse
                {
                    IsSuccess = true,
                    StatusCode = HttpStatusCode.OK,
                    Result = data,
                    Error = null
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Error = new()
                    {
                        Message = ex.Message,
                        Info = ex.StackTrace ?? throw new ArgumentNullException(nameof(ex.StackTrace))
                    }
                };
            }
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<ApiResponse> CreateMascotas(MascotasEntity request)
        {
            try
            {
                MascotasEntity data = await _repository.CreateMascotasRepo(request);
                return new ApiResponse
                {
                    IsSuccess = true,
                    StatusCode = HttpStatusCode.OK,
                    Result = data,
                    Error = null
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Error = new()
                    {
                        Message = ex.Message,
                        Info = ex.StackTrace ?? throw new ArgumentNullException(nameof(ex.StackTrace))
                    }
                };
            }
        }

        [Route("[action]")]
        [HttpPut]
        public async Task<ApiResponse> UpdateMascotas(MascotasDTO request)
        {
            try
            {
                MascotasEntity data = new()
                {
                    Id = request.Id,
                    Nombre = request.Nombre,
                    TipoDeMascotaId = request.TipoDeMascotaId,
                    PropietarioId = request.PropietarioId,
                    IsActive = request.IsActive
                };
                var response = await _repository.UpdateMascotasRepo(data);
                return new ApiResponse
                {
                    IsSuccess = true,
                    StatusCode = HttpStatusCode.OK,
                    Result = response,
                    Error = null
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Error = new()
                    {
                        Message = ex.Message,
                        Info = ex.StackTrace ?? throw new ArgumentNullException(nameof(ex.StackTrace))
                    }
                };
            }
        }


        [Route("[action]")]
        [HttpPost]
        public async Task<ApiResponse> Put(int request)
        {
            try
            {
                var data = await _repository.UpdateStateMascotasRepo(request);
                return new ApiResponse
                {
                    IsSuccess = true,
                    StatusCode = HttpStatusCode.OK,
                    Result = data,
                    Error = null
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse
                {
                    IsSuccess = false,
                    StatusCode = HttpStatusCode.BadRequest,
                    Error = new()
                    {
                        Message = ex.Message,
                        Info = ex.StackTrace ?? throw new ArgumentNullException(nameof(ex.StackTrace))
                    }
                };
            }
        }
    }

}

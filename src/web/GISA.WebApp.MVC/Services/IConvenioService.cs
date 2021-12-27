using GISA.WebApp.MVC.Models;
using System.Threading.Tasks;

namespace GISA.WebApp.MVC.Services
{
    public interface IConvenioService
    {
        Task<ResponseMessage> Registrar(ConvenioViewModel convenioViewModel);
        Task<ResponseMessage> Atualizar(ConvenioViewModel convenioViewModel);
    }
}

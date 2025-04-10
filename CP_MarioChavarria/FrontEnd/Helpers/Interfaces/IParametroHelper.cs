using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IParametroHelper
    {
        List<ParametroViewModel> GetAll();
        ParametroViewModel GetById(int id);
        ParametroViewModel AddParametro(ParametroViewModel parametroViewModel);
        ParametroViewModel EditParametro(ParametroViewModel parametroViewModel);
        void DeleteParametro(int id);
    }
}

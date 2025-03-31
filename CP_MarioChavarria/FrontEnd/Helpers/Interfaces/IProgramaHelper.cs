using FrontEnd.Models;

namespace FrontEnd.Helpers.Interfaces
{
    public interface IProgramaHelper
    {
        String Token { get; set; }
        List <ProgramaViewModel> GetAll();
        ProgramaViewModel GetById(int id);
        ProgramaViewModel AddPrograma(ProgramaViewModel ProgramaViewModel);
        ProgramaViewModel EditPrograma(ProgramaViewModel ProgramaViewModel);
        void DeletePrograma(int id);
    }
}

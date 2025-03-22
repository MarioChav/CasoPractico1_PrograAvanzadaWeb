using BackEnd.DTO;

namespace BackEnd.Services.Interfaces
{
    public interface IProgramaService
    {
        void AddPrograma(ProgramaDTO programa);
        void UpdatePrograma(ProgramaDTO programa);
        void DeletePrograma(int id);
        List<ProgramaDTO> GetProgramas();
        ProgramaDTO GetProgramaById(int id);

    }
}

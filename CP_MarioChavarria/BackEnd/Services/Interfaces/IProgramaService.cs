using BackEnd.DTO;

namespace BackEnd.Services.Interfaces
{
    public interface IProgramaService
    {

        List<ProgramaDTO> GetProgramas();
        ProgramaDTO Add (ProgramaDTO programa);
        ProgramaDTO Update(ProgramaDTO programa);
        void Delete(int id);
        ProgramaDTO GetById (int id);
    }
}

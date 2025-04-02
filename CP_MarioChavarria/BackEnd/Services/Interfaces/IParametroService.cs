using BackEnd.DTO;

namespace BackEnd.Services.Interfaces
{
    public interface IParametroService
    {
        List<ParametroDTO> GetParametros();
        ParametroDTO Add(ParametroDTO parametro);
        ParametroDTO Update(ParametroDTO parametro);
        void Delete(int id);
        ParametroDTO GetById(int id);
    }
}

using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;

namespace BackEnd.Services.Implementations
{
    public class ProgramaService : IProgramaService
    {

        IUnidadDeTrabajo _Unidad;

        public ProgramaService (IUnidadDeTrabajo unidadDeTrabajo)
        {
            _Unidad = unidadDeTrabajo;
        }

        ProgramaDTO Convertir(Programa programa)
        {
            return new ProgramaDTO
            {
                ProgramaId = programa.ProgramaId,
                Nombre = programa.Nombre,
                Tipo = programa.Tipo,
                Categoria = programa.Categoria
            };
        }

        Programa Convertir(ProgramaDTO programa)
        {
            return new Programa
            {
                ProgramaId = programa.ProgramaId,
                Nombre = programa.Nombre,
                Tipo = programa.Tipo,
                Categoria = programa.Categoria
            };
        }

        public ProgramaDTO Add(ProgramaDTO programa)
        {
            //throw new NotImplementedException();
            try 
            {
                _Unidad.ProgramasDAL.Add(Convertir(programa));

                _Unidad.Complete();
                return programa;
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ProgramaDTO GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<ProgramaDTO> GetProgramas()
        {
            throw new NotImplementedException();
        }

        public ProgramaDTO Update(ProgramaDTO programa)
        {
            throw new NotImplementedException();
        }
    }
}

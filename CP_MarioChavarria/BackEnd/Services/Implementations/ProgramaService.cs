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
            } catch (Exception) 
            {
                throw; 
            }
        }

        public void Delete(int id)
        {
            Programa programa = new Programa { ProgramaId = id };
            _Unidad.ProgramasDAL.Remove(programa);
            _Unidad.Complete();
            throw new NotImplementedException();
        }

        public ProgramaDTO GetById(int id)
        {
            var programa = _Unidad.ProgramasDAL.Get(id);
            return Convertir(programa);
        }

        public List<ProgramaDTO> GetProgramas()
        {
            var programas = _Unidad.ProgramasDAL.GetAll();
            List<ProgramaDTO> programaList = new List<ProgramaDTO>();
            foreach (var programa in programas)
            {
                programaList.Add(Convertir(programa));
            }
            return programaList;
        }

        public ProgramaDTO Update(ProgramaDTO programa)
        {
            try
            {
                _Unidad.ProgramasDAL.Update(Convertir(programa));
                _Unidad.Complete();
                return programa;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

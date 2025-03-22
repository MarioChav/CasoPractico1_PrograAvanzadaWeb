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

        ProgramaDTO Convertir(Programa programa)
        {
            //var progra = _Unidad.ProgramasDAL.Get((int)programa.ProgramaId);
            return new ProgramaDTO
            {
                ProgramaId = programa.ProgramaId,
                Nombre = programa.Nombre,
                Tipo = programa.Tipo,
                Categoria = programa.Categoria
            };
        }

        

        public void AddPrograma(ProgramaDTO programa)
        {
            //throw new NotImplementedException();
            //try 
            //{
            //    _Unidad.ProgramasDAL.Add(Convertir(programa));

            //    _Unidad.Complete();
            //    return programa;
            //} catch (Exception) 
            //{
            //    throw; 
            //}


            var programaEntity = Convertir(programa);
            _Unidad.ProgramasDAL.Add(programaEntity);
            _Unidad.Complete();

        }

        public void DeletePrograma(int id)
        {
            //Programa programa = new Programa { ProgramaId = id };
            //_Unidad.ProgramasDAL.Remove(programa);
            //_Unidad.Complete();
            //throw new NotImplementedException();

            var programa = new Programa { ProgramaId = id };
            _Unidad.ProgramasDAL.Remove(programa);
            _Unidad.Complete();
        }

        public List<ProgramaDTO> GetProgramas()
        {
            var programas = _Unidad.ProgramasDAL.GetAllProgramas();
            List<ProgramaDTO> programa = new List<ProgramaDTO>();
            foreach (var item in programas)
            {
                //programaList.Add(Convertir(programa));
                programa.Add(Convertir(item));
            }
            return programa;
        }

        public void UpdatePrograma(ProgramaDTO programa)
        {
            //try
            //{
            //    _Unidad.ProgramasDAL.Update(Convertir(programa));
            //    _Unidad.Complete();
            //    return programa;
            //}
            //catch (Exception)
            //{
            //    throw;
            //}


            var ProgramaEntity = Convertir(programa);
            _Unidad.ProgramasDAL.Update(ProgramaEntity);
            _Unidad.Complete();
        }

        public ProgramaDTO GetProgramaById(int id)
        {
            var programa = _Unidad.ProgramasDAL.Get(id);
            return Convertir(programa);
        }
    }
}

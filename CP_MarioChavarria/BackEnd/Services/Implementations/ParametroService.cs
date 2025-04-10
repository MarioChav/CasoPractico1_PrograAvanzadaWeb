using BackEnd.DTO;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;
using System.Text;

namespace BackEnd.Services.Implementations
{
    public class ParametroService : IParametroService
    {
        IUnidadDeTrabajo _Unidad;

        public ParametroService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _Unidad = unidadDeTrabajo;
        }

        ParametroDTO Convertir(Parametro parametro)
        {
            return new ParametroDTO
            {
                ParametroId = parametro.ParametroId,
                Descripcion = parametro.Descripcion
            };
        }

        Parametro Convertir(ParametroDTO parametro)
        {
            return new Parametro
            {
                ParametroId = parametro.ParametroId,
                Descripcion = parametro.Descripcion
            };
        }

        public ParametroDTO Add(ParametroDTO parametro)
        {
            try
            {
                _Unidad.ParametroDAL.Add(Convertir(parametro));
                _Unidad.Complete();
                return parametro;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(int id)
        {
            Parametro parametro = new Parametro { ParametroId = id };
            _Unidad.ParametroDAL.Remove(parametro);
            _Unidad.Complete();
        }

        public ParametroDTO GetById(int id)
        {
            var parametro = _Unidad.ParametroDAL.Get(id);
            return Convertir(parametro);
        }

        public List<ParametroDTO> GetParametros()
        {
            var parametros = _Unidad.ParametroDAL.GetAll();
            List<ParametroDTO> parametroList = new List<ParametroDTO>();
            foreach (var parametro in parametros)
            {
                parametroList.Add(Convertir(parametro));
            }
            return parametroList;
        }

        public ParametroDTO Update(ParametroDTO parametro)
        {
            try 
            {
                _Unidad.ParametroDAL.Update(Convertir(parametro));
                _Unidad.Complete();
                return parametro;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

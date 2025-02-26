using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    class UnidadDeTrabajo : IUnidadDeTrabajo
    {

        public IProgramasDAL ProgramasDAL { get; set; }

        private PeliculasContext _peliculasContext;

        public UnidadDeTrabajo(PeliculasContext peliculasContext, IProgramasDAL programasDAL)
        {
            this._peliculasContext = peliculasContext;
            this.ProgramasDAL = programasDAL;

        }

        public bool Complete()
        {
            //throw new NotImplementedException();

            try
            {
                _peliculasContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Dispose()
        {
            //throw new NotImplementedException();

            this._peliculasContext.Dispose();
        }
    }
}

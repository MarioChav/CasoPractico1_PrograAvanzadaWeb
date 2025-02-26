using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class ProgramasDAL : DALGenericoImpl<Programa>, IProgramasDAL
    {
        PeliculasContext _context;

        public ProgramasDAL(PeliculasContext context) : base(context)
        {
            _context = context;
        }
    }
}

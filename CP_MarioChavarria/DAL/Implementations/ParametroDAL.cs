using DAL.Interfaces;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class ParametroDAL : DALGenericoImpl<Parametro>, IParametroDAL
    {
        PeliculasContext _context;

        public ParametroDAL(PeliculasContext context) : base(context)
        {
            _context = context;
        }
    }
}

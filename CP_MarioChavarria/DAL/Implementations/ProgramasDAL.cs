using DAL.Interfaces;
using Entities.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class ProgramasDAL : DALGenericoImpl<Programa>, IProgramasDAL
    {
        private PeliculasContext _context;

        public ProgramasDAL(PeliculasContext context) : base(context)
        {
            _context = context;
        }

        public List<Programa> GetAllProgramas()
        {
            string query = "sp_GetAllProgramas";
            var resul = _context.Programas.FromSqlRaw(query);
            return resul.ToList();
        }

        public bool Add(Programa entity)
        {
            try
            {
                string sql = "exec [dbo].[sp_AddPrograma] @Nombre";

                var param = new SqlParameter[]
                {
                    new SqlParameter()
                    {
                        ParameterName = "@Nombre",
                        SqlDbType = System.Data.SqlDbType.VarChar,
                        Value = entity.Nombre
                    }
                 };

                _context
                    .Database
                    .ExecuteSqlRaw(sql, param);
                return true;
            }
            catch (Exception e)
            {

                return false;
            }
        }
    }
}

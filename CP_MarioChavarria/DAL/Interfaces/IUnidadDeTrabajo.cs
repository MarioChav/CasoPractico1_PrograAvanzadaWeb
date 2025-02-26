using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    interface IUnidadDeTrabajo : IDisposable
    {
        IProgramasDAL ProgramasDAL { get; }

        bool Complete ();
    }
}

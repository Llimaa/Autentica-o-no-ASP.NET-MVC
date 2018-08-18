using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutenticacaoAspnet._1_Infra
{
    interface IDb
    {
        IDbConnection connection();
    }
}

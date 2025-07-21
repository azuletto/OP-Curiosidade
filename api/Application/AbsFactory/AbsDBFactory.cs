using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AbsFactory
{
    public abstract class AbsDBFactory
    {
        //public abstract IDbConnection CreateConnection();
        public abstract void CreateConnection();
    }
}

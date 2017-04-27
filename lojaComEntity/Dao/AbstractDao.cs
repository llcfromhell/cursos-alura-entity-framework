using lojaComEntity.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lojaComEntity.Dao
{
    public abstract class AbstractDao
    {

        protected LojaContext ctx = new LojaContext("LojaContextConnectionString");

    }
}

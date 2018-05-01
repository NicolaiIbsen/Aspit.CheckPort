using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspit.CheckPorts.DataAccess;

namespace Aspit.CheckPorts.DataProvider
{
    public class DataProvider
    {
        private DataRepository repo;

        public DataProvider()
        {
            Repo = new DataRepository();
        }

        public DataRepository Repo { get => repo; set => repo = value; }
        
    }
}

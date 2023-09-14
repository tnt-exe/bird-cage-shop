using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class CageImageDAO
    {
        private static CageImageDAO _instance = null;
        private static readonly object _instanceLock = new object();
        private CageImageDAO() { }
        public static CageImageDAO SingletonInstance
        {
            get
            {
                lock (_instanceLock)
                {
                    if (_instance == null)
                    {
                        _instance = new CageImageDAO();
                    }
                    return _instance;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class CageDAO
    {
        private static CageDAO _instance = null; 
        private static readonly object _instanceLock = new object();
        private CageDAO() { }
        public static CageDAO SingletonInstance
        {
            get
            {
                lock (_instanceLock)
                {
                    if (_instance == null)
                    {
                        _instance = new CageDAO();
                    }
                    return _instance;
                }
            }
        }
    }
}

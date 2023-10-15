using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class ComponentDAO
    {
        private static ComponentDAO _instance = null;
        private static readonly object _instanceLock = new object();
        private ComponentDAO() { }
        public static ComponentDAO SingletonInstance
        {
            get
            {
                lock (_instanceLock)
                {
                    if (_instance == null)
                    {
                        _instance = new ComponentDAO();
                    }
                    return _instance;
                }
            }
        }

    }
}

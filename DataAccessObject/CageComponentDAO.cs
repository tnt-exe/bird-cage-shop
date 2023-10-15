﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObject
{
    public class CageComponentDAO
    {
        private static CageComponentDAO _instance = null;
        private static readonly object _instanceLock = new object();
        private CageComponentDAO() { }
        public static CageComponentDAO SingletonInstance
        {
            get
            {
                lock (_instanceLock)
                {
                    if (_instance == null)
                    {
                        _instance = new CageComponentDAO();
                    }
                    return _instance;
                }
            }
        }
    }
}
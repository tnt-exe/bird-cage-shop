﻿using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface ICageImageRepository
    {
        IEnumerable<CageImageDTO> GetCageImages(int cageId);
    }
}

using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface ICageComponentRepository
    {
        List<CageComponentDTO> GetComponentByCageId(int cageId);
        bool InsertCageComponent(CageComponentDTO cageComponentDTO);
        bool UpdateCageComponent(CageComponentDTO cageComponentDTO);
        bool DeleteCageComponent(int cageComponentId);
    }
}

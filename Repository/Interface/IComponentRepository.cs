using DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IComponentRepository
    {
        List<ComponentDTO> GetAllComponent();
        List<ComponentDTO> GetSearchComponent(string keyword);
        ComponentDTO GetComponentById(int id);
    }
}

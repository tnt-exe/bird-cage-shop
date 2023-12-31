﻿using DataTransferObject;

namespace Repository.Interface
{
    public interface IComponentRepository
    {
        List<ComponentDTO> GetAllComponent();
        List<ComponentDTO> GetSearchComponent(string keyword);
        ComponentDTO GetComponentById(int id);
        bool AddComponent(ComponentDTO component);
        bool UpdateComponent(ComponentDTO component);
        bool DeleteComponent(int componentId);
    }
}

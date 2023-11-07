using BusinessObject.Models;

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

        public List<Component> GetAllComponent()
        {
            List<Component> componentList;
            try
            {
                using (var db = new BirdCageShopContext())
                {
                    componentList = db.Components.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return componentList;
        }

        public Component GetComponentById(int componentId)
        {
            Component component;
            try
            {
                using (var db = new BirdCageShopContext())
                {
                    component = db.Components
                        .SingleOrDefault(component => component.ComponentId == componentId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return component;
        }

        public List<Component> GetSearchComponents(string keyword)
        {
            List<Component> componentList;
            try
            {
                using (var db = new BirdCageShopContext())
                {
                    componentList = db.Components
                        .Where(component => component.ComponentName.Contains(keyword))
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return componentList;
        }

        public bool AddComponent(Component component)
        {
            try
            {
                using (var db = new BirdCageShopContext())
                {
                    db.Components.Add(component);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return true;
        }

        public bool UpdateComponent(Component component)
        {
            try
            {
                using (var db = new BirdCageShopContext())
                {
                    db.Components.Update(component);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return true;
        }

        public bool DeleteComponent(int componentId)
        {
            try
            {
                using (var db = new BirdCageShopContext())
                {
                    var component = db.Components
                        .SingleOrDefault(component => component.ComponentId == componentId);
                    db.Components.Remove(component);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return true;
        }
    }
}

namespace DataAccessObject
{
    public class OrderDetailDAO
    {
        private static OrderDetailDAO _instance = null;
        private static readonly object _instanceLock = new object();
        private OrderDetailDAO() { }
        public static OrderDetailDAO SingletonInstance
        {
            get
            {
                lock (_instanceLock)
                {
                    if (_instance == null)
                    {
                        _instance = new OrderDetailDAO();
                    }
                    return _instance;
                }
            }
        }
    }
}

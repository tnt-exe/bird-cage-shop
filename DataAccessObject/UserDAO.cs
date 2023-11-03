using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DataAccessObject
{
    public class UserDAO
    {
        private static UserDAO _instance = null;
        private static readonly object _instanceLock = new object();
        private UserDAO() { }
        public static UserDAO SingletonInstance
        {
            get
            {
                lock (_instanceLock)
                {
                    if (_instance == null)
                    {
                        _instance = new UserDAO();
                    }
                    return _instance;
                }
            }
        }

        public List<User> Users
        {
            get
            {
                try
                {
                    using var db = new BirdCageShopContext();
                    return db.Users.ToList();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public User GetUser(string email, string pwd)
        {
            try
            {
                using var db = new BirdCageShopContext();
                var user = db.Users.Where(u => u.Email.Equals(email)
                        && u.Password.Equals(pwd)).FirstOrDefault();
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool AddUser(User user)
        {
            bool result = false;
            try
            {
                using var db = new BirdCageShopContext();
                db.Users.Add(user);
                result = db.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
                return false;
            }
            return result;
        }

        public bool ChangeUserStatus(int userId, int userStatus)
        {
            bool result = false;
            try
            {
                using var db = new BirdCageShopContext();
                User user = db.Users.Where(u => u.UserId == userId).FirstOrDefault();
                user.Status = userStatus;
                result = db.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
                return false;
            }
            return result;
        }

        public User GetUserById(int userId)
        {
            User user;
            try
            {
                using var db = new BirdCageShopContext();
                user = db.Users.Where(u => u.UserId == userId).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return user;
        }

        public bool UpdateUserEmailPassword(User userObj)
        {
            bool result = false;
            try
            {
                using var db = new BirdCageShopContext();
                User user = db.Users.Where(u => u.UserId == userObj.UserId).FirstOrDefault();
                user.Email = userObj.Email;
                user.Password = userObj.Password;
                result = db.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
                return false;
            }
            return result;
        }

        public bool UpdateUserInfo(User userObj)
        {
            bool result = false;
            try
            {
                using var db = new BirdCageShopContext();
                var user = db.Users.Find(userObj.UserId);

                userObj.Status = user.Status;
                userObj.Role = user.Role;
                
                db.Entry(user).CurrentValues.SetValues(userObj);
                result = db.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
                return false;
            }
            return result;
        }

        public bool IsEmailExisted(string email)
        {
            bool result = false;
            try
            {
                using var db = new BirdCageShopContext();
                User user = db.Users.Where(u => u.Email.Equals(email, StringComparison.Ordinal)).FirstOrDefault();
                if (user != null)
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }

        public bool IsPhoneExisted(string phone)
        {
            bool result = false;
            try
            {
                using var db = new BirdCageShopContext();
                User user = db.Users.Where(u => u.Phone.Equals(phone, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
                if (user != null)
                {
                    result = true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return result;
        }
    }
}

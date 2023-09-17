﻿using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public User GetUser(string email, string pwd)
        {
            User user;
            try
            {
                using var db = new BirdCageShopContext();
                user = db.Users.Where(u => u.Email.Equals(email, StringComparison.Ordinal) 
                        && u.Password.Equals(pwd, StringComparison.Ordinal)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return user;
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

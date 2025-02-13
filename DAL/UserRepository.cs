﻿using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class UserRepository : IUserRepository
    {
        private readonly PostgreSqlContext context;

        public UserRepository(PostgreSqlContext context)
        {
            this.context = context;

        }
        public void AddNewAdmin(User newAdmin)
        {
            context.Users.Add(newAdmin);
            context.SaveChanges();
        }

        public List<User> GetAllUsers()
        {
            return context.Users.ToList();
        }

        public User GetUserByID(int UserID)
        {
            return context.Users.FirstOrDefault(u => u.UserID == UserID);
        }

        public void UpdateUser(User newUser)
        {
            context.Users.Update(newUser);
            context.SaveChanges();
        }

        public void AddNewUser(User newUser)
        {
            context.Users.Add(newUser);
            context.SaveChanges();
        }
        public User Login(string Username, string Password)
        {
            Func<User, bool> expression = u => u.UserName == Username && u.Password == Password;
            return context.Users.FirstOrDefault(expression);
        }

        public void ChangePassword(int UserID, string NewPassword)
        {
            var user = GetUserByID(UserID);
            user.Password = NewPassword;
            context.Users.Update(user);
            context.SaveChanges();
        }
    }
}

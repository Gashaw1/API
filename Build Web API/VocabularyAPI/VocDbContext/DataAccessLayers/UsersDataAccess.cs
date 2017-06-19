using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VocDbContext.DataAccessLayers
{
    public class UsersDataAccess
    {
        protected string exMessage = "";
        protected List<Users> users;
        protected Users user;
        protected List<Definitions> definitions;
        protected List<Vocabularys> vocabularys;
        protected Definitions definition;
        protected Vocabularys vocabulary;
        protected VocabularyDbContext myDbContext;

        VocDataAccess vocDataAccess;

        //Check null or 0 int
        public static bool IsNullOrValue(int val)
        {
            if (val == null || val == 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        //return users and all its contents
        protected List<Users> returnUsers()
        {
            vocDataAccess = new VocDataAccess();
            users = new List<Users>();
            myDbContext = new VocabularyDbContext();
            // return myDbContext.Users.ToList();
            var result = from r in myDbContext.Users.ToList()
                         select r;
            if (result.Count() > 0)
            {
                foreach (Users ur in result)
                {
                    user = new Users();
                    user.UserID = ur.UserID;
                    user.UserName = ur.UserName;
                    user.Vocabularys = vocDataAccess.ReturnVocublarys(user.UserID, user.UserName);
                    users.Add(user);
                }
                return users;
            }
            else
            {
                return null;
            }
        }
        //add user
        protected bool AddUser(Users user)
        {
            try
            {
                using (myDbContext = new VocabularyDbContext())
                {
                    myDbContext.Users.Add(user);
                    int x = myDbContext.SaveChanges();
                    if (x >= 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                exMessage = ex.Message;
                return false;
            }
        }
        //return user id
        protected Users ReturnUser(string userName, string userPassword)
        {
            //ReturnVocublaryID(1);
            // UserExist(userName);
            if (UserExist(userName) == true)
            {
                user = new Users();
                myDbContext = new VocabularyDbContext();
                var result = from ur in myDbContext.Users.ToList()
                             where (ur.UserName == userName && ur.UserPassword == userPassword)
                             select ur;
                foreach (Users myUser in result)
                {
                    user = new Users();
                    user.UserID = myUser.UserID;
                    user.UserName = myUser.UserName;
                    user.UserPassword = "";
                    user.UserEmail = "";
                    user = myUser;
                }
            }         
            return user;
        }
        //Perform chedk if user exist
        //return true if exits
        protected bool UserExist(string userName)
        {
            myDbContext = new VocabularyDbContext();
            var count = (from c in myDbContext.Users
                         where c.UserName == userName
                         select c.UserName).Count();

            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //return user name by userID        
        protected string UserExist(int userId)
        {
            string str = "";
            try
            {
                myDbContext = new VocabularyDbContext();
                var result = ( from use in myDbContext.Users
                            where use.UserID == userId
                               select use.UserName).SingleOrDefault();


                str = result;


                return result;
                  
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        //check email inuse
        //return true if exist
        protected bool EmailExist(string userNameEmail)
        {
            myDbContext = new VocabularyDbContext();
            var count = (from c in myDbContext.Users
                         where c.UserEmail == userNameEmail
                         select c.UserEmail).Count();

            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
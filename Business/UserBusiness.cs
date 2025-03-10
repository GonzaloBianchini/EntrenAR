﻿using Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class UserBusiness
    {
        private DataAccess data;
        private RoleBusiness roleBusiness;
        public UserBusiness()
        {

        }

        /// <summary>
        /// Crea User, ideal para ser usada en PartnerBusiness y TrainerBusiness
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Devuelve lastIndex creado en BD, si falla, devuelve 0</returns>
        public int Create(User user)
        {
            data = new DataAccess();
            int lastIndex;

            try
            {
                data.SetStoredProcedure("insert_user");
                data.SetParameter("@UserName", user.userName);
                data.SetParameter("@UserPassword", user.userPassword);
                data.SetParameter("@IdRole", user.role.IdRole);
                data.ExecuteRead();

                data.Reader.Read();
                lastIndex = int.Parse(data.Reader["LastId"].ToString());

            }
            catch (Exception ex)
            {
                lastIndex = 0;
                throw ex;
            }
            finally
            {
                data.CloseConnection();
            }
            return lastIndex;
        }

        /// <summary>
        /// Lee User
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Devuelve User validado o null</returns>
        public User Read(int id)
        {
            data = new DataAccess();
            roleBusiness = new RoleBusiness();
            User auxUser = new User();

            try
            {
                data.SetQuery("select * from Users Where IdUser=@IdUser");
                data.SetParameter("@IdUser", id);
                data.ExecuteRead();

                if (data.Reader.Read())
                {
                    auxUser.idUser = id;
                    auxUser.userName = data.Reader["UserNickName"].ToString();
                    auxUser.userPassword = data.Reader["UserPassword"].ToString();
                    auxUser.role = roleBusiness.Read(int.Parse(data.Reader["IdRole"].ToString()));
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                data.CloseConnection();
            }
            return auxUser;
        }

        /// <summary>
        /// Lee User
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>Devuelve User validado o null</returns>
        public User Read(string userName)
        {
            data = new DataAccess();
            roleBusiness = new RoleBusiness();
            User auxUser = new User();
            //auxUser = null;

            try
            {
                data.SetQuery("select * from Users Where UserNickName=@userName");
                data.SetParameter("@userName", userName);
                data.ExecuteRead();

                if (data.Reader.Read())
                {
                    auxUser.idUser = int.Parse(data.Reader["IdUser"].ToString());
                    auxUser.userName = data.Reader["UserNickName"].ToString();
                    auxUser.userPassword = data.Reader["UserPassword"].ToString();
                    auxUser.role = roleBusiness.Read(int.Parse(data.Reader["IdRole"].ToString()));
                }
                else
                {
                    auxUser = null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                data.CloseConnection();
            }

            return auxUser;
        }

        public bool Update(User user)
        {
            data = new DataAccess();
            int rows;
            //roleBusiness = new RoleBusiness();
            try
            {
                data.SetQuery("UPDATE Users SET IdRole = @IdRole, UserNickName = @UserNickName, UserPassword = @UserPassword WHERE IdUser =@IdUser;");
                data.SetParameter("@IdRole", user.role.IdRole);
                data.SetParameter("@UserNickName", user.userName);
                data.SetParameter("@UserPassword", user.userPassword);
                data.SetParameter("@IdUser", user.idUser);

                rows = data.ExecuteAction();
            }
            catch (Exception ex)
            {
                rows = 0;
                throw ex;
            }
            finally
            {
                data.CloseConnection();
            }

            return (rows > 0);
        }

        public List<User> List()
        {
            roleBusiness = new RoleBusiness();
            data = new DataAccess();
            List<User> listUsers = new List<User>();
            try
            {
                data.SetQuery("select * from Users");
                data.ExecuteRead();

                while (data.Reader.Read())
                {
                    User auxUser = new User();

                    auxUser.idUser = int.Parse(data.Reader["IdUser"].ToString());
                    auxUser.role = roleBusiness.Read(int.Parse(data.Reader["IdRole"].ToString()));
                    auxUser.userName = data.Reader["UserNickName"].ToString();
                    auxUser.userPassword = data.Reader["UserPassword"].ToString();

                    listUsers.Add(auxUser);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                data.CloseConnection();
            }

            return listUsers;
        }
        /// <summary>
        /// devuelve el user validado o NULL
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User ValidateCredential(String userName, String password)
        {
            User auxUser = new User();

            try
            {
                auxUser = Read(userName);
                if (auxUser != null && !(auxUser.userPassword.Equals(password)))
                {
                    auxUser = null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return auxUser;
        }

        //No creo que use este metodo....
        public bool userNameAvailable(string userName)
        {
            data = new DataAccess();
            User auxUser = new User();

            bool flag;

            try
            {
               
                data.SetQuery("select * from Users where UserNickName = @UserName");
                data.SetParameter("@UserName", userName);
                data.ExecuteRead();

                if (data.Reader.Read())
                {
                    flag = false;   //Si leo alguno, esta ocupado ese UserName
                }
                else
                {
                    flag = true;
                }
            }
            catch (Exception)
            {
                throw new Exception("Problemas en User Business");
            }
            finally
            {
                data.CloseConnection();
            }

            return flag;
        }
    }
}

using Domain;
using System;
using System.Collections.Generic;
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

        //public bool Create(User user)
        //{
        //    Data = new DataAccess();

        //    try
        //    {
        //        Data.SetQuery("INSERT INTO Users (FirstName, LastName, BirthDate, Dni, Phone, Email, UserNickName, UserPassword) VALUES (@FirstName, @LastName, @BirthDate, @Dni, @Phone, @Email, @UserNickName, @UserPassword)");
        //        Data.SetParameter("@FirstName",user.FirstName);
        //        Data.SetParameter("@LastName",user.LastName);
        //        Data.SetParameter("@BirthDate",user.BirthDate);
        //        Data.SetParameter("@Dni",user.Dni);
        //        Data.SetParameter("@Phone",user.Phone);
        //        Data.SetParameter("@Email",user.Email);
        //        Data.SetParameter("@UserNickName",user.UserNickName);
        //        Data.SetParameter("@UserPassword",user.UserPassword);

        //        Data.ExecuteAction();
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //    finally
        //    {
        //        Data.CloseConnection();
        //    }

        //    return true;
        //}
        //prueba


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
    }
}

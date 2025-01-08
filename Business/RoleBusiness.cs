using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class RoleBusiness
    {
        private DataAccess data;

        public RoleBusiness() 
        {

        }

        public Role Read(int id)
        {
            data = new DataAccess();
            Role role = new Role();

            try
            {
                data.SetQuery("select * from Roles where IdRole=@IdRole");
                data.SetParameter("@IdRole", id);
                data.ExecuteRead();

                if(data.Reader.Read())
                {
                    role.IdRole = id;
                    role.Name = data.Reader["RoleName"].ToString();
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

            return role;
        }
    }
}

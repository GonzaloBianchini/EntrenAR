using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class DataAccess
    {
        private SqlConnection _connection;
        private SqlCommand _command;
        private SqlDataReader _reader;
        public SqlDataReader Reader { get { return _reader; } }

        public DataAccess()
        {
            _connection = new SqlConnection("server=.\\SQLEXPRESS; database=ENTRENAR_DB; integrated security=true");
            _command = new SqlCommand();
        }

        public void SetQuery(string query)
        {
            _command.CommandType = System.Data.CommandType.Text;
            _command.CommandText = query;
        }

        public void SetStoredProcedure(string sp)
        {
            _command.CommandType = System.Data.CommandType.StoredProcedure;
            _command.CommandText = sp;
        }

        public void ExecuteRead()
        {
            _command.Connection = _connection;
            try
            {
                _connection.Open();
                _reader = _command.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExecuteAction()
        {
            //TODO: hacer que esta funcion devuelva int rows, para chequear si se modificaron filas o no...
            _command.Connection = _connection;
            try
            {
                _connection.Open();
                _command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void SetParameter(string parameter, object value)
        {
            _command.Parameters.AddWithValue(parameter, value);
        }

        public void CloseConnection()
        {
            if(_reader != null)
                _reader.Close();
            _connection.Close();
        }
    }
}

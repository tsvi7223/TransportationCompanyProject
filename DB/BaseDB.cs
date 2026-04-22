using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportationCompanyProject.Model;

namespace TransportationCompanyProject.DB
{
    public abstract class BaseDB
    {
        private readonly string connectionString;
        protected OleDbConnection connection;
        protected OleDbCommand command;
        protected OleDbDataReader reader;

        protected abstract BaseEntity NewEntity();
        protected abstract BaseEntity CreateModel(BaseEntity entity);

        public BaseDB()
        {
            connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\..\..\DB\DBTransportationCompanyProject.accdb;Persist Security Info=False;";
            this.connection = new OleDbConnection(connectionString);
            command = new OleDbCommand();
            command.Connection = this.connection;
        }

        protected List<BaseEntity> Select()
        {
            List<BaseEntity> list = new List<BaseEntity>();
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                command.Connection = connection; // וידוא חיבור
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    BaseEntity entity = NewEntity();
                    list.Add(CreateModel(entity));
                }
            }
            //{"ספק 'Microsoft.ACE.OLEDB.12.0' אינו רשום במחשב המקומי."}
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(
                    ex.Message + "\nSQL: " + command.CommandText);
            }
            finally
            {
                if (reader != null && !reader.IsClosed) { reader.Close(); }
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
            return list;
        }
        //protected bool HasColumn(string columnName)
        //{
        //    for (int i = 0; i < reader.FieldCount; i++)
        //    {
        //        if (reader.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}
        protected void ExecuteNonQuery()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                command.Connection = connection;
                int recordsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(
                    ex.Message + "\nSQL: " + command.CommandText);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
    }
}

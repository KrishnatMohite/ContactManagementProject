using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObject;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace DataAccessLayer
{
    public class ContactDAL : IContactDAL
    {
        string connStr = ConfigurationManager.ConnectionStrings["ContactDbConnection"].ConnectionString;

        public int CreateContact(Contact objContact)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand sqlComm = new SqlCommand("USP_InsertContact", conn);
                sqlComm.Parameters.AddWithValue("@FirstName", objContact.FirstName);
                sqlComm.Parameters.AddWithValue("@LastName", objContact.LastName);
                sqlComm.Parameters.AddWithValue("@Email", objContact.Email);
                sqlComm.Parameters.AddWithValue("@PhoneNo", objContact.PhoneNo);
                sqlComm.Parameters.AddWithValue("@Status", objContact.Status);

                sqlComm.CommandType = CommandType.StoredProcedure;
                conn.Open();
                objContact.Id = Convert.ToInt32(sqlComm.ExecuteScalar());
                return objContact.Id;
            }
        }

        public void DeleteContact(int id)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand sqlComm = new SqlCommand("USP_DeleteContact", conn);               
                sqlComm.Parameters.AddWithValue("@Id", id);

                sqlComm.CommandType = CommandType.StoredProcedure;
                conn.Open();
                sqlComm.ExecuteNonQuery();                 
            }
        }

        public Contact GetContact(int id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                //conn.Open();
                SqlCommand sqlComm = new SqlCommand("USP_GetContact", conn);
                sqlComm.Parameters.AddWithValue("@Id", id);

                sqlComm.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlComm;
                da.Fill(dt);
            }

            Contact _contact = new Contact();
            foreach (DataRow irow in dt.Rows)
            {
                _contact.Id = Convert.ToInt32(irow["Id"]);
                _contact.FirstName = Convert.ToString(irow["FirstName"]);
                _contact.LastName = Convert.ToString(irow["LastName"]);
                _contact.Email = Convert.ToString(irow["Email"]);
                _contact.PhoneNo = Convert.ToString(irow["PhoneNo"]);
                _contact.Status = Convert.ToString(irow["Status"]);
            }
            return _contact;
        }

        public List<Contact> GetContacts()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                //conn.Open();
                SqlCommand sqlComm = new SqlCommand("USP_GetContacts", conn);
                //sqlComm.Parameters.AddWithValue("@TimeRange", TimeRange);

                sqlComm.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlComm;
                da.Fill(dt);
            }

            List<Contact> _lstContacts = new List<Contact>();
            foreach (DataRow irow in dt.Rows)
            {
                Contact _contact = new Contact();

                _contact.Id = Convert.ToInt32(irow["Id"]);
                _contact.FirstName = Convert.ToString(irow["FirstName"]);
                _contact.LastName = Convert.ToString(irow["LastName"]);
                _contact.Email = Convert.ToString(irow["Email"]);
                _contact.PhoneNo = Convert.ToString(irow["PhoneNo"]);
                _contact.Status = Convert.ToString(irow["Status"]);

                _lstContacts.Add(_contact);
            }
            return _lstContacts;
        }

        public int UpdateContact(Contact objContact)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand sqlComm = new SqlCommand("USP_UpdateContact", conn);
                sqlComm.Parameters.AddWithValue("@FirstName", objContact.FirstName);
                sqlComm.Parameters.AddWithValue("@LastName", objContact.LastName);
                sqlComm.Parameters.AddWithValue("@Email", objContact.Email);
                sqlComm.Parameters.AddWithValue("@PhoneNo", objContact.PhoneNo);
                sqlComm.Parameters.AddWithValue("@Status", objContact.Status);
                sqlComm.Parameters.AddWithValue("@Id", objContact.Id);

                sqlComm.CommandType = CommandType.StoredProcedure;
                conn.Open();
                objContact.Id = Convert.ToInt32(sqlComm.ExecuteScalar());
                return objContact.Id;
            }
        }
    }
}

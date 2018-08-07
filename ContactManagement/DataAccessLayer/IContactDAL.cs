using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObject;

namespace DataAccessLayer
{
    public interface IContactDAL
    {
        List<Contact> GetContacts();
        int CreateContact(Contact objContact);

        int UpdateContact(Contact objContact);

        Contact GetContact(int id);

        void DeleteContact(int id);
    }
}

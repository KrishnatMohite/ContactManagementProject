using DataObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface IContactBusinessLayer
    {
        List<Contact> GetContacts();

        int CreateContact(Contact objContact);

        int UpdateContact(Contact objContact);

        Contact GetContact(int id);

        void DeleteContact(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using DataObject;

namespace BusinessLayer
{
    public class ContactBusinessLayer : IContactBusinessLayer
    {
        private IContactDAL _objContactDAL;
        public ContactBusinessLayer(IContactDAL objContactDAL)
        {
            _objContactDAL = objContactDAL;
        }

        public int CreateContact(Contact objContact)
        {
            return _objContactDAL.CreateContact(objContact);
        }

        public void DeleteContact(int id)
        {
            _objContactDAL.DeleteContact(id);
        }

        public Contact GetContact(int id)
        {
            return _objContactDAL.GetContact(id);
        }

        public List<Contact> GetContacts()
        {
            return _objContactDAL.GetContacts();
        }

        public int UpdateContact(Contact objContact)
        {
            return _objContactDAL.UpdateContact(objContact);
        }
    }
}

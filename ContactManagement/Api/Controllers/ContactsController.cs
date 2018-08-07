using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataObject;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using BusinessLayer;

namespace ContactsPrjApi.Controllers
{
    public class ContactsController : ApiController
    {
        private IContactBusinessLayer _objContactBusinessLayer;

        public ContactsController(IContactBusinessLayer objContactBusinessLayer)
        {
            _objContactBusinessLayer = objContactBusinessLayer;
        }

        // GET: api/Contacts
        public List<Contact> Get()
        {
            return _objContactBusinessLayer.GetContacts();
        }

        // GET: api/Contacts/5
        public Contact Get(int id)
        {
            return _objContactBusinessLayer.GetContact(id);
        }

        // POST: api/Contacts
        public int Post([FromBody]Contact contact)
        {
            return _objContactBusinessLayer.CreateContact(contact);
        }

        // PUT: api/Contacts/5
        public int Put(int id, [FromBody]Contact contact)
        {
            return _objContactBusinessLayer.UpdateContact(contact);
        }

        // DELETE: api/Contacts/5
        public void Delete(int id)
        {
            _objContactBusinessLayer.DeleteContact(id);

        }
    }
}

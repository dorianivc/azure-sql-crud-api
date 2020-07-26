using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using AzureSQL_API.Models;

namespace AzureSQL_API.Controllers
{  
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController: Controller
    {
        private ContactsContext contactsContext;

        public ContactController(ContactsContext context){
            contactsContext= context;
        }   
        [HttpGet]
        public ActionResult<IEnumerable<Contacts>> GetAction(){
            return contactsContext.ContacsSet.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Contacts> Get(string id){
            var selectedContact =( from c in contactsContext.ContacsSet 
                                where c.Identificador == id
                                select c).FirstOrDefault();
            
            return selectedContact;
        }
        [HttpPost]
        public IActionResult Post([FromBody] Contacts value){
            Contacts newContacts= value;
            contactsContext.ContacsSet.Add(newContacts);
            contactsContext.SaveChanges();
            return Ok("Contact Added");

        }
       
       [HttpPut]
        public IActionResult Put([FromBody] Contacts value)
        {
            Contacts updatedContact = value;
            var selectedElement = contactsContext.ContacsSet.Find(updatedContact.Identificador);
            selectedElement.Nombre = value.Nombre;
            selectedElement.Email = value.Email;
            selectedElement.Telefono=value.Telefono;
            contactsContext.SaveChanges();
            return Ok("Contact updated");
        }
         [HttpDelete("{id}")]
         public IActionResult Delete(string id)
        {
            var selectedElement = contactsContext.ContacsSet.Find(id);
            contactsContext.ContacsSet.Remove(selectedElement);
            contactsContext.SaveChanges();
            return Ok("Contact deleted");
        }

        ~ContactController(){
            contactsContext.Dispose();
        }

    }
}
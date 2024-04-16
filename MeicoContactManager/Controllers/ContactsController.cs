using Meico.Models.ViewModels;
using Meico.Services.Web;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MeicoContactManager.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ILogger<ContactsController> _logger;

        public ContactsController(ILogger<ContactsController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult IndexPartial()
        {
            ViewBag.Contacts = ContactService.GetContacts(User?.Identity?.Name ?? "");
            return PartialView();
        }

        public IActionResult AddContactModal()
        {
            return PartialView("AddContact");
        }

        public bool? AddContact(ContactViewModel contact)
        {
            try
            {
                bool? response = ContactService.CreateContact(contact, User?.Identity?.Name ?? "");
                return response;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public IActionResult UpdateContactModal()
        {
            return PartialView("UpdateContact");
        }

        public bool? UpdateContact(ContactViewModel contact)
        {
            try
            {
                bool? response = ContactService.UpdateContact(contact);
                return response;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }

        public bool? DeleteContact(int contactId)
        {
            try
            {
                bool? response = ContactService.DeleteContact(contactId);
                return response;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }
        }
    }
}

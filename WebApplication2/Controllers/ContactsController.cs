using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Service;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("api/{userID}/[controller]")]
    public class ContactsController : Controller
    {
        private usersService Uservice;
        private contactsService service;

        public ContactsController()
        {
            Uservice = new usersService();
            service = new contactsService();
        }

        [HttpGet]
        // GET: Contacts
        public ActionResult Index(string userID)
        {
            return Json(Uservice.get(userID).contacts.GetAll());
        }

        [HttpGet("{id2}")]
        public ActionResult GetContactById(string? id2, string userID)
        {
            User user = Uservice.get(userID);
            return Json(user.contacts.get(id2));
        }

        [HttpPost]
        public ActionResult GetPost(string userID, [Bind("id,name,server")] Contact contact)
        {
            contact.MessegesService = new messegesService();
            contact.LastDate = DateTime.Now;
            contact.Last = "";
            User user = Uservice.get(userID);

            user.contacts.Add(contact);
            return Json(Uservice);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteContactById(string userID, string? id)
        {
            if (id == null)
            { return NotFound(); }
            Uservice.get(userID).contacts.Remove(id);
            return Json(Uservice);
        }

        [HttpPut("{id}")]
        public ActionResult PutContactById(string userID, string id, [Bind("id,name,server")] Contact contact)
        {
            Uservice.get(userID).contacts.Edit(id, contact);
            return Json(Uservice);
        }


        // GET: Contacts/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Contacts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contacts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

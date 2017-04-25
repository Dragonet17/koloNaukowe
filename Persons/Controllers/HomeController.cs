using Persons.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Persons.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    
        public ActionResult Person()
        {
            return View();




            //if (!ModelState.IsValid)
            //{
            //    if (per.Name=="Karol")
            //    {
            //        ModelState.AddModelError("Name", "Proszę podać imię !");
            //    }

            //    return View(per);
            //}
            //else
            //{
            //    return View("Login");
            //}
            //Person osoba = new Person();

            //ViewBag.Message = "Your contact page.";
            //Persons.Models.Person person = new Models.Person();

            //person.Name = "Karol";
            //person.Surname = "Cichoń";
            //person.Age = 26;

            //Persons.Models.Person person2 = new Models.Person();
            //person2.Name = "Aga";
            //person2.Surname = "Kowalska";
            //person2.Age = 21;


        }

     

        [HttpPost]
        public ActionResult Check(Person person)
        {
            //var imie = person.Name;
            if (person.Name == "?")
            {
                ModelState.AddModelError("Name", "Nie możesz być pytajnikiem !!!");
            }
            if (person.Age < 18)
            {
                ModelState.AddModelError("Age", "Powinieneeś być dorosły !!!");
            }
            var porsonEmail = Models.Person.GetPersons().FirstOrDefault(prs => prs.Email == person.Email);

            if (porsonEmail != null)
            {
                ModelState.AddModelError("Email", "Osoba z podanym mailem już istnieje");

            }
            if (!ModelState.IsValid)
            {
              
                return View("Person",person);
            }
            else
            {
               
                Models.Person.AddPerson(person);

                return RedirectToAction("ShowPersons");
            }
        
        }

        public ActionResult ShowPersons()
        {
            ViewBag.Info = false;
            var persons = Models.Person.GetPersons() ;

            if (persons == null)
            {
                ViewBag.Info = true;
                return RedirectToAction("Person");
            }
            return View(persons);
        }

        [ChildActionOnly]
        public ActionResult Login(Person person)
        {


            return View();
        }
    }
}
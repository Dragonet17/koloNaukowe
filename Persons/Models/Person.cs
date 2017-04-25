using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Persons.Models
{
    public class Person
    {
        [Required(ErrorMessage = "Podaj imie !")]
        [Display(Name = "Imie")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Imię powinno zawiarać minimum 3 znaki")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Podaj nazwisko !")]
        [Display(Name = "Nazwisko")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Nazwisko powinno zawiarać minimum 5 znaków")]

        public string Surname { get; set; }

        [Required(ErrorMessage = "Podaj wiek !")]
        [Display(Name = "Wiek")]
        [Range(0, 65, ErrorMessage = "Zakres wieku 0 - 65. ")]
        public int Age { get; set; }

        [Required]
        [EmailAddress]
        public  string Email { get; set; }

        private static List<Person> persons = new List<Person>();

        public static void AddPerson(Person person)
        {
            Person.persons.Add(person);
        }

        public static List<Person> GetPersons()
        {
            return Person.persons;
        }
    }
}
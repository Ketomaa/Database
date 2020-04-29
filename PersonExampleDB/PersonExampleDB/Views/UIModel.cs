using System;
using System.Collections.Generic;
using System.Text;
using PersonExampleDB.Data;
using PersonExampleDB.Repositories;

namespace PersonExampleDB.Views
{
    public class UIModel
    {
        private static readonly PersonRepository _personRepository = new PersonRepository();
        public void UpdatePerson()
        {
            Person updatePerson = _personRepository.ReadById(5003);
            updatePerson.FirstName = "James";
            updatePerson.LastName = "Bond";
            updatePerson.DateOfBirth = new DateTime(1998, 4, 26);
            updatePerson.EyeColor = "Blue";
            updatePerson.City = "Lontoo";
            updatePerson.Height = 185;
            updatePerson.Sex = "Male";
            _personRepository.Update(5003, updatePerson);
        }

        public void DeletePerson(int id)
        {
            ReadById(id);
            _personRepository.Delete(id);
            ReadById(id);
        }

        public void CreatePerson()
        {
            Person person = new Person();
            person.FirstName = "Tatu";
            person.LastName = "Ketomaa";
            person.City = "Lahti";
            person.ShoeSize = 43;

            _personRepository.Create(person);
        }

        public void ReadByCity()
        {
            var persons = _personRepository.ReadByCity("City");

            foreach (var p in persons)
            {
                Console.WriteLine($"{p.Id} {p.FirstName} {p.LastName} {p.City}");
            }

            Console.WriteLine("-----------------------------------");
        }

        public void ReadById(long id)
        {
            var person = _personRepository.ReadById(id);

            if (person == null)
                Console.WriteLine($"Asiakasta numerolla {id} ei löydy!");
            else
                Console.WriteLine($"{person.Id} {person.FirstName} {person.LastName} {person.City} ");
            foreach (var phone in person.Phone)
            {
                Console.WriteLine($"{phone.Type}: {phone.Number}");
            }
        }
    }
}

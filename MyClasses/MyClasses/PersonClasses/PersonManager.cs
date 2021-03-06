﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClasses
{
   public class PersonManager
    {
		public Person CreatePerson(string first, string last, bool isSupervisor)
		{
			Person ret = null;
			if (!string.IsNullOrEmpty(first))
			{
				if (isSupervisor)
				{
					ret = new Supervisor();

				}
				else
				{
					ret = new Employee();
				}

				//Assign variables
				ret.FirstName = first;
				ret.LastName = last;

			}
			return ret;
		}

        public List<Person> GetPeople()
        {
			List<Person> peopleExpected = new List<Person>();


			peopleExpected.Add(new Person() { FirstName = "Paul", LastName = "Sheriff" });
			peopleExpected.Add(new Person() { FirstName = "John", LastName = "Kuhn" });
			peopleExpected.Add(new Person() { FirstName = "Jim", LastName = "Ruhl" });

			return peopleExpected;
		}

        public List<Person> GetEmployees()
        {
            throw new NotImplementedException();
        }

        public List<Person> GetSupervisors()
		{
			List<Person> people = new List<Person>();
			people.Add(CreatePerson("Paul", "Sheriff", true));
			people.Add(CreatePerson("Michael", "Krasowski", true));
			return people;
		}

        public List<Person> GetSupervisorsAndEmployees()
        {
            throw new NotImplementedException();
        }
    }
}

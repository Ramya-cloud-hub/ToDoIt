﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Model;

namespace ToDo.Data
{
   public class People
    {
        static Person[] personArr = new Person[0];
        int find = 0;

        public int Size()
        {
            int length = personArr.Length;
            return length;
        }
        public static Person[] FindAll()
        {
            
            return personArr;
        }
        public Person FindById(int personId)
        {

            Person findPersonById = null;
            foreach(Person person in personArr)
            {
                if(person.PersonId == personId)
                {
                    findPersonById = person;
                }
            }
            return findPersonById;
        }
        public Person CreatNewPerson(string firstName, string lastName, int personId)
        {
            Person newPerson = new Person(firstName, lastName, personId);

            Person[] tempArray = personArr;
            tempArray = new Person[tempArray.Length + 1];
            tempArray[personArr.Length - 1] = newPerson;

            return newPerson;
        }
        public void Clear()
        {
            Array.Clear(personArr, 0, personArr.Length);
        }
        

    }
}

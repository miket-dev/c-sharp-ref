using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpRefExplained
{
    public class Student
    {
        public string _firstName;
        public StudentGroup _studentGroup;

        public int Number { get; set; }

        //убираем инкапсуляцию поля
        public string FirstName
        {
            get
            {
                return this._firstName;
            }
            set
            {
                this._firstName = value;
            }
        }
        public string  LastName { get; set; }

        public StudentGroup Group
        {
            get
            {
                return this._studentGroup;
            }
            set
            {
                this._studentGroup = value;
            }
        }
    }
}

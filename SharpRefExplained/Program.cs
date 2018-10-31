using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpRefExplained
{
    class Program
    {
        static void Main(string[] args)
        {
            var student = new Student
            {
                Number = 1,
                FirstName = "Student first name",
                LastName = "Student last name"
            };

            //!-- string это класс, но передается по значению, это специальная доработка

            //пробуем изменить имя без ref параметра
            ChangeName(student.FirstName);
            //не поменялось
            Contract.Ensures(student.FirstName == "Student first name");

            //изменяем имя с ref параметром
            //ChangeNameRef(ref student.FirstName); - свойство нельзя передавать с параметром ref
            ChangeNameRef(ref student._firstName); //а поле можно
            //поменялось
            Contract.Ensures(student.FirstName == "new student name");

            //!-- StudentGroup это класс и он передается по ссылке

            //пробуем назначить группу
            SetGroup(student._studentGroup);
            //не поменялась, так как изначально группа не задана
            //передается ссылка на сам объект, а не на поле класса
            Contract.Ensures(student._studentGroup == null);

            //назначаем группу
            SetGroupRef(ref student._studentGroup);
            //поменялась, класс при создании экземпляра выделяет память под хранение этого поля
            //и с ref мы передаем именно ссылку на эту выделенную область памяти внутри класса Student
           //хотя она и имеет значение null
            Contract.Ensures(student._studentGroup != null);

            //меняем номер группы
            ChangeGroupNumber(student._studentGroup);
            //номер поменялся, работаем именно с переданным объектом
            Contract.Ensures(student._studentGroup.Number == 123);
        }

        static void ChangeName(string name)
        {
            //оперируем локальной переменной с именем name
            //которая создается только для этой функции
            //и имеет значение той переменной, которое мы передали
            //и будет уничтожена при выходе из нее
            name = "new student name";
        }

        static void ChangeNameRef(ref string name)
        {
            //а здесь локальная переменная не создается
            //работаем именно с тем объектом, который был передан
            name = "new student name";
        }

        static void SetGroup(StudentGroup gr)
        {
            //хотя gr локальная переменная, она не относится ни к какому объекту
            //и с помощью new выделяется новая область памяти для хранения StudentGroup
            gr = new StudentGroup
            {
                Number = 300900
            };
        }

        static void SetGroupRef(ref StudentGroup gr)
        {
            //локальной переменной не создается
            //(пояснение по ссылке в Main)
            //создается новый экземпляр и записывается в ту область памяти, которую мы и передали
            gr = new StudentGroup
            {
                Number = 300900
            };
        }

        static void ChangeGroupNumber(StudentGroup gr)
        {
            //хотя и передали группу без параметра ref
            //она все равно передается по ссылке, т.к. класс
            gr.Number = 123;
        }
    }
}

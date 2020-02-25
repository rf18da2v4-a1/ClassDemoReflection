using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace ClassDemoReflection
{
    internal class ReflectionWorker
    {
        public void Start()
        {
            Object o = new Person() { Id = 9, Name = "Peter" };
            Console.WriteLine("Person object ==> " + o);

            /*
             * Reflection
             */
            Type t = o.GetType();

            Console.WriteLine("full name " + t.FullName);
            Console.WriteLine("is interface " + t.IsInterface);
            Console.WriteLine("is class " + t.IsClass);
            Console.WriteLine("Base Class type " + t.BaseType);

            Console.WriteLine(" === properties == ");
            foreach (PropertyInfo info in t.GetProperties())
            {
                Console.WriteLine(info);
            }

            Console.WriteLine(" === methods == ");
            foreach (MethodInfo info in t.GetMethods())
            {
                Console.WriteLine(info);
            }

            /*
             * Like to call a method
             */
            MethodInfo setIdMethod = t.GetMethods().First(m => m.Name == "set_Id");
            setIdMethod.Invoke(o, new object[] { 12 });
            Console.WriteLine("Person after call " + o);

            PropertyInfo idprop = t.GetProperties().First(p => p.Name == "Id");
            Object resObj = idprop.GetMethod.Invoke(o, null);
            Console.WriteLine($"Id prop is {idprop.Name} value {resObj}" );


            Recursive(23);
        }

        public void Recursive(int number)
        {
            // stop condition
            if (number < 0)
            {
                return;
            }

            // do somthing
            Console.WriteLine("stupid printout " + number);
            
            // call recursive with a smaller problem
            Recursive(number - 1);

        }
    }

    internal class Person
    {
        public String Name { get; set; }

        public int Id { get; set; }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Id)}: {Id}";
        }
    }
}
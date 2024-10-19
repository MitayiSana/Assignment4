namespace Assignment_4
{
    class Person
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }

    }
    class PersonImplememtation
    {
        public string GetName(IList<Person> person)
        {
            string res = " ";
            foreach (var i in person)
            {
                res += i.Name + " " + i.Address + " ";
            }
            return res;
        }
        public double Average(IList<Person> person)
        {
            double sum = 0;
            double count = 0;
            foreach (var i in person)
            {
                sum += i.Age;
                count++;
            }
            return sum / count;
        }
        public int Max(IList<Person> person)
        {
            int max = 0;
            foreach (var i in person)
            {
                if (i.Age > max)
                {
                    max = i.Age;

                }
            }
            return max;
        }
        public class Program
        {
            static void Main(string[] args)
            {
                IList<Person> p = new List<Person>();
                p.Add(new Person { Name = "Aarya", Address = "A2101", Age = 69 });
                p.Add(new Person { Name = "Daniel", Address = "D104", Age = 40 });
                p.Add(new Person { Name = "Ira", Address = "H801", Age = 25 });
                p.Add(new Person { Name = "Jennifer", Address = "I1704", Age = 33 });
                PersonImplememtation person = new PersonImplememtation();
                person.GetName(p);
                Console.WriteLine(person.GetName(p));
                person.Average(p);
                Console.WriteLine(person.Average(p));
                person.Max(p);
                Console.WriteLine(person.Max(p));
            }
        }
    }
}

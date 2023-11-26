namespace Exercise003
{
    using System;
    public class Person
    {

        public string name { get; }
        public int age { get; }

        public Person(string name, int age)
        {
            if(name == null || name == "" || name.Length > 40 || age < 0 || age > 120)
            {
                throw new ArgumentException("somethig went wrong");
            }
            this.name = name;
            this.age = age;
        }
    }
}
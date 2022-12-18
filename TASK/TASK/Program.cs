using System;
using System.Security.Cryptography;

namespace task;
public  class Person
{
    public string Name;
    public int Age;

    public Person(string name, int age)
    {
        if (name == null || name == "" || name.Length == 32)
        {
            throw new Exception("Invalid Name");
            
            return;
        }
        if (age <= 0 || age >= 128)
        {
            throw new Exception("Invalid Age");
            return;
        }
        Name = name;
        Age = age;
    }
    public virtual void print()
    {
        Console.WriteLine($"Name: {Name}, Age:{Age}");   
    }
}

public class Student : Person
{
    public int Year;
    public float GPA;
    public Student(string name, int age, int year, float gpa)
    :base(name,age)
    {
        if (year < 1 || year > 5)
        {
            throw new Exception("Invalid year");
            return;
        }
        if (gpa < 0 || gpa > 4)
        {
            throw new Exception("Invalid Gpa");
            return;
        }
        Year = year;
        GPA = gpa;
    }
    public override void print()
    {
        Console.WriteLine($"Name: {Name} Age: {Age} Year: {Year} GPA: {GPA}");   
    }
}
public class Staff : Person
{
    public double Salary;

    public int joinYear;
    public Staff(string name, int age, double salary, int joinyear)
    :base(name,age)
    {
        if (salary < 0 || salary > 12000)
        { throw new Exception("Invalid salary");
        return;
        }
        var d = DateTime.Today;
        var birthYear = d.Year - Age;
        if ((joinyear-birthYear)<21)
        { throw new Exception("Invalid Join Year");
        return;
        }
        Salary = salary;
        joinYear = joinyear;
    }
    public override void print()
    {
        Console.WriteLine($"My name{Name}, My age:{Age}, my salary:{Salary}");
    }
}
public class database
{
    public int curr ;
    public Person[] person = new Person[50];

    public void AddStudent(Student student)
    {
        person[curr++] = student;
    }

    public void AddStaff(Staff staff)
    {
        person[curr++] = staff;
    }

    public void AddPerson(Person per)
    {
        person[curr++] = per;
    }

        public void PrintAll()
    {
        foreach (var item in person)
        {
            item?.print();
        }
    }
}
public class program
{
    public static void Main()
    {
        var database = new database();


        Console.WriteLine("Enter option 1-add student 2-to add staff 3-to add person 4-to print all 0-to stop:");
        var option = Convert.ToInt32(Console.ReadLine());
        while (true)
        {
            switch (option)
            {
                case 0:
                    Console.WriteLine("Done");
                    return;
                case 1:
                    Console.Write("Name: ");
                    var name = Console.ReadLine();
                    Console.Write("Age: ");
                    var age = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Year: ");
                     var year = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Gpa: ");
                    var gpa = Convert.ToSingle(Console.ReadLine());
                    try
                    {
                        var student = new Student(name, age, year, gpa);
                        database.AddStudent(student);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);

                    }
                    Console.WriteLine(
                        "Enter option 1-add student 2-to add staff 3-to add person 4-to print all 0-to stop:");
                    option = Convert.ToInt32(Console.ReadLine());
                    break;
                case 2:
                    Console.Write("Name: ");
                    var name2 = Console.ReadLine();
                    Console.Write("Age: ");
                    var age2 = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Salary: ");
                    var salary = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Join Year: ");
                    var joinyear = Convert.ToInt32(Console.ReadLine());
                    try
                    {
                        var staff = new Staff(name2, age2, salary, joinyear);
                        database.AddStaff(staff);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);

                    }
                    Console.WriteLine("Enter option 1-add student 2-to add staff 3-to add person 4-to print all 0-to stop:");
                    option = Convert.ToInt32(Console.ReadLine());
                    break;
                case 3:
                    Console.Write("Name: ");
                    var name3 = Console.ReadLine();
                    Console.Write("Age: ");
                    var age3 = Convert.ToInt32(Console.ReadLine());
                    try
                    {
                        var person = new Person(name3,age3 );
                        database.AddPerson(person);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);

                    }

                    Console.WriteLine("Enter option 1-add student 2-to add staff 3-to add person 4-to print all 0-to stop:");
                    option = Convert.ToInt32(Console.ReadLine());

                    break;
                case 4:
                    database.PrintAll();
                    Console.WriteLine("Enter option 1-add student 2-to add staff 3-to add person 4-to print all 0-to stop:");
                    option = Convert.ToInt32(Console.ReadLine());
                    
                    break;
                
                default:
                    
                    return;
            } 
        }
    }
}
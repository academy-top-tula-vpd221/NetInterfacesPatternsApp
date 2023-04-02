
using System.Collections;
using System.Reflection;

Employee[] employees = 
    {
        new(){ Name = "Tom", Age = 35 },
        new(){ Name = "Bob", Age = 21 },
        new(){ Name = "Joe", Age = 45 },
        new(){ Name = "Sam", Age = 19 },
        new(){ Name = "Jim", Age = 27 },
        new(){ Name = "Leo", Age = 32 },
    };

foreach(Employee emp in employees) Console.WriteLine(emp);
Console.WriteLine();

Array.Sort(employees);

foreach (Employee emp in employees) Console.WriteLine(emp);


Group group = new()
{
    Students = new[]
    {
        "Bob", "Joe", "Sam", "Leo"
    }
};

foreach(var item in group)
    Console.WriteLine(item);



class Employee : ICloneable, IComparable
{
    public string Name { set; get; }
    public int Age { set; get; }

    //public Company Company { set; get; }

    public object Clone()
    {
        return MemberwiseClone();
        //return new Employee() { Name = Name, Age = Age }; //Company = new Company() { Title = Company.Title } };
    }

    public int CompareTo(object? obj)
    {
        //return this.Name.CompareTo((obj as Employee).Name);
        return this.Age.CompareTo((obj as Employee).Age);
    }

    public override string ToString()
    {
        return $"{Name} {Age}";
    }
}

class Company
{
    public string Title { set; get; }
}

class Group : IEnumerable
{
    //string[] students;
    public string[] Students { set; get; }

    public IEnumerator GetEnumerator()
    {
        return new GroupEnumerator(this);
    }
}

class GroupEnumerator : IEnumerator
{
    Group _group;
    int index;
    public GroupEnumerator(Group group)
    {
        _group = group;
        index = -1;
    }
    public object Current
    {
        get => _group.Students[index];
        set => _group.Students[index] = value.ToString();
    }

    public bool MoveNext()
    {
        if(index < _group.Students.Length - 1)
        {
            index++;
            return true;
        }
        return false;
    }

    public void Reset()
    {
        index = 0;
    }
}
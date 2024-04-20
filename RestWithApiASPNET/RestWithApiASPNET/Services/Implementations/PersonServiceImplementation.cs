using RestWithApiASPNET.Models;

namespace RestWithApiASPNET.Services.Implementations;

public class PersonServiceImplementation : IPersonService
{
    private volatile int count;

    public Person Create(Person person)
    {
        return person;
    }

    public void Delete(long id)
    {
        
    }

    public List<Person> FindAll()
    {
        List<Person> persons = new();
        for (int i = 0; i < 8; i++)
        {
            Person person = MockPerson(i);
            persons.Add(person);
        }
        return persons;
    }

    public Person FindById(long id)
    {
        return new Person { 
            Id = incrementAndGet(),
            FirstName = "Marco",
            LastName = "Antonio",
            Address = "Vera Cruz - Sao Paulo - Brasil",
            Gender = "Male"
        };
    }

    public Person Update(Person person)
    {
        return person;
    }

    private Person MockPerson(int i)
    {
        return new Person
        {
            Id = incrementAndGet(),
            FirstName = "Person Name" + i,
            LastName = "Person LastName" + i,
            Address = "Some Address" + i,
            Gender = "Male"
        };
    }

    private long incrementAndGet()
    {
        return Interlocked.Increment(ref count);
    }
}

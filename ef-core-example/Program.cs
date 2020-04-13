using ef_core_example.Entities;
using System;
using System.Linq;

namespace ef_core_example
{
    class Program
    {
        static void Main(string[] args)
        {
            Add();

            List();

            Edit();

            Delete();
        }

        static void Add()
        {
            using var db = new AppDbContext();
            var client = new Client
            {
                Name = "Paulo Francis",
                DOB = new DateTime(1988, 3, 6)
            };
            db.Client.Add(client);

            client = new Client
            {
                Name = "Tony Stark",
                DOB = new DateTime(1965, 4, 29)
            };
            db.Client.Add(client);

            db.SaveChanges();
        }

        static void Edit()
        {
            using var db = new AppDbContext();
            var client = db.Client.Where(x => x.Id == 1).First();
            client.Name = "Peter Park";
            db.Entry<Client>(client);
            db.SaveChanges();
        }

        static void List()
        {
            using var db = new AppDbContext();
            var clients = db.Client.ToList();

            foreach (var c in clients)
            {
                Console.WriteLine($"Id: {c.Id} - Name: {c.Name} - DOB: {c.DOB.ToShortDateString()}");
            }
        }

        static void Delete()
        {
            using var db = new AppDbContext();
            var client = db.Client.Where(x => x.Id == 2).First();
            db.Attach(client);
            db.Remove(client);
            db.SaveChanges();
        }
    }
}

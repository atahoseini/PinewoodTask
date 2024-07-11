using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinewoodTask.Core.Entities
{
    public static class CustomerData
    {
        public static List<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer
                {
                    FirstName = "Ata",
                    LastName = "Hoseini",
                    Phone = "07307646818",
                    AddressLine1 = "123 Main St",
                    AddressLine2 = "Apt 6",
                    AddressLine3 = "",
                    PostCode = "NG11 6TT",
                    City = "Nottingham",
                    Conty = "Greater London",
                    Country = "United Kingdom",
                    RegisterDate = DateTime.Now.AddDays(-10),
                    LastLoginDate = DateTime.Now.AddDays(-1)
                },
                new Customer
                {
                    FirstName = "Jane",
                    LastName = "Doe",
                    Phone = "07812345678",
                    AddressLine1 = "456 Elm St",
                    AddressLine2 = "Suite 5",
                    AddressLine3 = "",
                    PostCode = "DB11 7HP",
                    City = "Birmingham",
                    Conty = "West Midlands",
                    Country = "United Kingdom",
                    RegisterDate = DateTime.Now.AddDays(-20),
                    LastLoginDate = DateTime.Now.AddDays(-2)
                },
                new Customer
                {
                    FirstName = "Alex",
                    LastName = "Johnson",
                    Phone = "07309876543",
                    AddressLine1 = "789 Maple St",
                    AddressLine2 = "",
                    AddressLine3 = "",
                    PostCode = "NG11 8AB",
                    City = "Manchester",
                    Conty = "Greater Manchester",
                    Country = "United Kingdom",
                    RegisterDate = DateTime.Now.AddDays(-30),
                    LastLoginDate = DateTime.Now.AddDays(-3)
                },
                new Customer
                {
                    FirstName = "Emily",
                    LastName = "Williams",
                    Phone = "07823456789",
                    AddressLine1 = "321 Oak St",
                    AddressLine2 = "Apt 10",
                    AddressLine3 = "",
                    PostCode = "DB11 9CD",
                    City = "Liverpool",
                    Conty = "Merseyside",
                    Country = "United Kingdom",
                    RegisterDate = DateTime.Now.AddDays(-40),
                    LastLoginDate = DateTime.Now.AddDays(-4)
                },
                new Customer
                {
                    FirstName = "Michael",
                    LastName = "Brown",
                    Phone = "07311223344",
                    AddressLine1 = "654 Pine St",
                    AddressLine2 = "",
                    AddressLine3 = "",
                    PostCode = "NG11 1EF",
                    City = "Leeds",
                    Conty = "West Yorkshire",
                    Country = "United Kingdom",
                    RegisterDate = DateTime.Now.AddDays(-50),
                    LastLoginDate = DateTime.Now.AddDays(-5)
                },
                new Customer
                {
                    FirstName = "Sarah",
                    LastName = "Jones",
                    Phone = "07899887766",
                    AddressLine1 = "987 Birch St",
                    AddressLine2 = "Suite 3",
                    AddressLine3 = "",
                    PostCode = "DB11 2GH",
                    City = "Sheffield",
                    Conty = "South Yorkshire",
                    Country = "United Kingdom",
                    RegisterDate = DateTime.Now.AddDays(-60),
                    LastLoginDate = DateTime.Now.AddDays(-6)
                },
                new Customer
                {
                    FirstName = "David",
                    LastName = "Garcia",
                    Phone = "07322334455",
                    AddressLine1 = "159 Cedar St",
                    AddressLine2 = "Apt 2",
                    AddressLine3 = "",
                    PostCode = "NG11 3IJ",
                    City = "Bristol",
                    Conty = "Bristol",
                    Country = "United Kingdom",
                    RegisterDate = DateTime.Now.AddDays(-70),
                    LastLoginDate = DateTime.Now.AddDays(-7)
                },
                new Customer
                {
                    FirstName = "Anna",
                    LastName = "Miller",
                    Phone = "07877665544",
                    AddressLine1 = "753 Spruce St",
                    AddressLine2 = "",
                    AddressLine3 = "",
                    PostCode = "DB11 4KL",
                    City = "Newcastle",
                    Conty = "Tyne and Wear",
                    Country = "United Kingdom",
                    RegisterDate = DateTime.Now.AddDays(-80),
                    LastLoginDate = DateTime.Now.AddDays(-8)
                },
                new Customer
                {
                    FirstName = "James",
                    LastName = "Davis",
                    Phone = "07344556677",
                    AddressLine1 = "357 Ash St",
                    AddressLine2 = "Suite 7",
                    AddressLine3 = "",
                    PostCode = "NG11 5MN",
                    City = "Leicester",
                    Conty = "Leicestershire",
                    Country = "United Kingdom",
                    RegisterDate = DateTime.Now.AddDays(-90),
                    LastLoginDate = DateTime.Now.AddDays(-9)
                },
                new Customer
                {
                    FirstName = "Laura",
                    LastName = "Rodriguez",
                    Phone = "07866554433",
                    AddressLine1 = "951 Willow St",
                    AddressLine2 = "Apt 5",
                    AddressLine3 = "",
                    PostCode = "DB11 6OP",
                    City = "Nottingham",
                    Conty = "Nottinghamshire",
                    Country = "United Kingdom",
                    RegisterDate = DateTime.Now.AddDays(-100),
                    LastLoginDate = DateTime.Now.AddDays(-10)
                }
            };
        }
    }
}

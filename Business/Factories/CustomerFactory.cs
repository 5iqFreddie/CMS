using Business.Models;
using Data.Entities;

namespace Business.Factories;

public class CustomerFactory
{
    public static CustomerEntity? Create(CustomerRegistrationForm form) => form == null ? null : new()
    {
        CustomerName = form.CustomerName,
        Email = form.Email
    };


    public static Customer? Create(CustomerEntity entity)
    {
        if (entity == null)
        {
            return null;
        }

        var customer = new Customer()
        {
            Id = entity.Id,
            CustomerName = entity.CustomerName,
            Email = entity.Email,
            Projects = []
        };

        if (entity.Projects != null)
        {
           var projects = new List<Project>();


            foreach (var project in entity.Projects)
            {
                projects.Add(new Project()
                {
                    Id = project.Id,
                    Description = project.Description
                });


                customer.Projects = projects;
            }
        }

        return customer;
    }
}
using MediatR;
using ProjectSystem.Application.Common.Exceptions;
using ProjectSystem.Application.Interfaces;
using ProjectSystem.Domain;
using System.Collections.Generic;
using System.Linq;


namespace ProjectSystem.Application.ProjectCommand.DeleteInformationAboutProject
{
    public class GetCustomersHandler
        : IRequest<GetCustomersCommand>
    {

        private readonly ICustomersDbContext _dbContext;

        public GetCustomersHandler(ICustomersDbContext dbContext) =>
            _dbContext = dbContext;

        public List<CustomerViewModel> Handle(GetCustomersCommand request) 
        {
                var customers = _dbContext.Customer
                    .Where(c => c.Orders.Any(o => o.Date >= request.beginDate))
                    .Select(c => new
                    {
                        CustomerName = c.Name,
                        ManagerName = c.Manager.Name,
                        TotalAmount = c.Orders.Where(o => o.Date >= request.beginDate).Sum(o => o.Amount)
                    })
                    .Where(c => c.TotalAmount > request.sumAmount)
                    .Select(c => new CustomerViewModel
                    {
                        CustomerName = c.CustomerName,
                        ManagerName = c.ManagerName,
                        Amount = c.TotalAmount
                    })
                    .ToList();

                if (!customers.Any())
                    throw new NotFoundCustomersException();

                return customers;
        }

    }
}

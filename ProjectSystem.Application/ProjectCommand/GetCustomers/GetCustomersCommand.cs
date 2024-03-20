using MediatR;
using System;


namespace ProjectSystem.Application.ProjectCommand.DeleteInformationAboutProject
{
    public class GetCustomersCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public DateTime beginDate {get;set;}
        public int sumAmount { get; set; }
    }
}

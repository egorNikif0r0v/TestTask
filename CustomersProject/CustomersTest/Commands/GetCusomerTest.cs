using ProjectSystem.Application.ProjectCommand.DeleteInformationAboutProject;
using ProjectSystem.Application.Common.Exceptions;
using CustomersProjectTest.Common;


namespace CustomersProjectTest.CustomersTest.Commands
{
    public class CreateNoteCommandHandlerTests : TestCommandBase
    {
        [Fact]
        public void GetCustomers_Success()
        {
            
    

            using (var dbContext = CustomersFactory.CreateDbContext())
            {
                var handler = new GetCustomersHandler(dbContext);



                // Act
                var result = handler.Handle( new GetCustomersCommand() {
                        beginDate = new DateTime(2024, 3, 10),
                        sumAmount = 150
                    });

                // Assert

                Assert.Contains(result, c => c.CustomerName == "Customer 2" && c.ManagerName == "Manager 2" && c.Amount == 200);
                Assert.Contains(result, c => c.CustomerName == "Customer 3" && c.ManagerName == "Manager 1" && c.Amount == 300);
                Assert.Equal(2, result.Count);
            }
        }


        [Fact]
        public void GetCustomers_NotNull()
        {
            // Arrange
            using (var dbContext = CustomersFactory.CreateDbContext())
            {
                var handler = new GetCustomersHandler(dbContext);

                // Assert

                Assert.Throws<NotFoundCustomersException>(() =>
                handler.Handle(new GetCustomersCommand()
                {
                    beginDate = new DateTime(2024, 3, 10),
                    sumAmount = 400
                }
                ));

            }
        }

    }

}



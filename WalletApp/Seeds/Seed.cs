using WalletAppApi.Data;
using WalletAppApi.Models;

namespace WalletAppApi.Seeds
{
    public class Seed
    {
        private readonly AppDbContext dbContext;

        public Seed(AppDbContext appDbContext)
        {
            dbContext = appDbContext;
        }

        public void SeedDataContext()
        {
            if (!dbContext.TransactionDetails.Any())
            {
                var users = new List<User>()
                {
                    new User()
                    {
                        Email = "user#1@example.com",
                        Created = DateTime.Now.AddDays(-589),
                        UserName = "user#1"
                    },
                    new User()
                    {
                        Email = "user#2@example.com",
                        Created = DateTime.Now.AddDays(-456),
                        UserName = "user#2"
                    },
                    new User()
                    {
                        Email = "user#3@example.com",
                        Created = DateTime.Now.AddDays(-123),
                        UserName = "user#3"
                    },
                    new User()
                    {
                        Email = "user#4@example.com",
                        Created = DateTime.Now.AddDays(-4556),
                        UserName = "user#4"
                    }
                };

                var transactionLists = new List<TransactionList>() 
                { 
                    new TransactionList()
                    {
                        CardBalance = 120,
                        User = users[0],
                        UserId = 1,
                    },
                    new TransactionList()
                    {
                        CardBalance = 450,
                        User = users[1],
                        UserId = 2,
                    },
                    new TransactionList()
                    {
                        CardBalance = 432,
                        User = users[2],
                        UserId = 3,
                    },
                    new TransactionList()
                    {
                        CardBalance = 278,
                        User = users[3],
                        UserId = 4,
                    }
                };

                var transactionDetails = new List<TransactionDetail>()
                {
                    new TransactionDetail()
                    {
                        TransactionDate = DateTime.Now.AddDays(-356),
                        TransactionDescription = "Some desc",
                        TransactionType = TransactionType.Payment,
                        TransactionFee = 123,
                        TransactionInitializerUserId = 3,
                        TransactionInitializerUserName = "Jack",
                        TransactionListId = 1,
                        TransactionList = transactionLists[0],
                        TransactionName = "Visa",
                        UserId = 1,
                        User = users[0],
                        ImagePath = "/Images/Apple.png",
                    },
                    new TransactionDetail()
                    {
                        TransactionDate = DateTime.Now.AddDays(-350),
                        TransactionDescription = "Some desc #2",
                        TransactionType = TransactionType.Credit,
                        TransactionFee = 1222,
                        TransactionInitializerUserId = 3,
                        TransactionInitializerUserName = "Jack",
                        TransactionListId = 1,
                        TransactionList = transactionLists[0],
                        TransactionName = "Mastercard",
                        UserId = 1,
                        User = users[0],
                        ImagePath = "/Images/tesla.png",
                    },
                    new TransactionDetail()
                    {
                        TransactionDate = DateTime.Now.AddDays(-356),
                        TransactionDescription = "Some desc",
                        TransactionType = TransactionType.Payment,
                        TransactionFee = 332,
                        TransactionInitializerUserId = 2,
                        TransactionInitializerUserName = "Sam",
                        TransactionListId = 2,
                        TransactionList = transactionLists[1],
                        TransactionName = "Visa",
                        UserId = 2,
                        User = users[1],
                        ImagePath = "/Images/nasa.png",
                    },
                    new TransactionDetail()
                    {
                        TransactionDate = DateTime.Now.AddDays(-356),
                        TransactionDescription = "Some desc",
                        TransactionType = TransactionType.Payment,
                        TransactionFee = 123,
                        TransactionInitializerUserId = 1,
                        TransactionInitializerUserName = "Kevin",
                        TransactionListId = 2,
                        TransactionList = transactionLists[1],
                        TransactionName = "Visa",
                        UserId = 2,
                        User = users[1],
                        ImagePath = "/Images/Samsung.png",
                    },
                    new TransactionDetail()
                    {
                        TransactionDate = DateTime.Now.AddDays(-80),
                        TransactionDescription = "Some desc",
                        TransactionType = TransactionType.Payment,
                        TransactionFee = 123,
                        TransactionInitializerUserId = 4,
                        TransactionInitializerUserName = "Sam",
                        TransactionListId = 3,
                        TransactionList = transactionLists[2],
                        TransactionName = "Visa",
                        UserId = 3,
                        User = users[2],
                        ImagePath = "/Images/Apple.png",
                    },
                    new TransactionDetail()
                    {
                        TransactionDate = DateTime.Now.AddDays(-71),
                        TransactionDescription = "Some desc#32",
                        TransactionType = TransactionType.Payment,
                        TransactionFee = 89,
                        TransactionInitializerUserId = 3,
                        TransactionInitializerUserName = "Jack",
                        TransactionListId = 3,
                        TransactionList = transactionLists[2],
                        TransactionName = "Visa",
                        UserId = 3,
                        User = users[2],
                        ImagePath = "/Images/tesla.png",
                    },
                    new TransactionDetail()
                    {
                        TransactionDate = DateTime.Now.AddDays(-80),
                        TransactionDescription = "Some desc",
                        TransactionType = TransactionType.Credit,
                        TransactionFee = 56,
                        TransactionInitializerUserId = 4,
                        TransactionInitializerUserName = "Jack",
                        TransactionListId = 4,
                        TransactionList = transactionLists[3],
                        TransactionName = "Visa",
                        UserId = 4,
                        User = users[3],
                        ImagePath = "/Images/tesla.png",
                    },
                };
                dbContext.Users.AddRange(users);
                dbContext.TransactionLists.AddRange(transactionLists);
                dbContext.TransactionDetails.AddRange(transactionDetails);
                dbContext.SaveChanges();
            }
        }
    }
}

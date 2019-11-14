using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTransactions.DAL
{
    public class MoneyTransactionsDBInitializer : DropCreateDatabaseIfModelChanges<MoneyTransactionsContext>
    {
        protected override void Seed(MoneyTransactionsContext context)
        {
            base.Seed(context);

            // Accounts
            //context.Accounts.Add(new Entities.Account
            //{
            //    AccountID = Guid.Parse("64d579ce-827d-44db-9e54-c06b068d5ed9"),
            //    Email = "oswald42@yahoo.com",
            //    NickName = "Leonella",
            //    Password = "Leonella",
            //    Phone = "054891302798",
            //    UserName = "sitesea",
            //    RoleID = Guid.Parse("186b054d-f8dc-4617-b955-d4240aefd9e4")
            //});

            //context.Accounts.Add(new Entities.Account
            //{
            //    AccountID = Guid.Parse("2be034a9-f0e2-4acf-9f0a-548927344715"),
            //    Email = "sschamberger@gmail.com",
            //    NickName = "Leona",
            //    Password = "Leona",
            //    Phone = "091502793562",
            //    UserName = "swagger",
            //    RoleID = Guid.Parse("0c3ab0cc-6cac-4235-a9c0-94aedc2af6fa")
            //});

            //context.Accounts.Add(new Entities.Account
            //{
            //    AccountID = Guid.Parse("c098ffd7-e70a-48b8-9d40-46949789c04"),
            //    Email = "upredovic@howell.com",
            //    NickName = "Leonie",
            //    Password = "Leonie",
            //    Phone = "036314390539",
            //    UserName = "straggle",
            //    RoleID = Guid.Parse("0c3ab0cc-6cac-4235-a9c0-94aedc2af6fa")
            //});
            //context.Accounts.Add(new Entities.Account
            //{
            //    AccountID = Guid.Parse("086dd5f3-7bcf-4342-bd80-2ef2a667f6fe"),
            //    Email = "mertiewolf@hotmail.com",
            //    NickName = "Cosmie",
            //    Password = "Cosmie",
            //    Phone = "098222175521",
            //    UserName = "absorb",
            //    RoleID = Guid.Parse("0c3ab0cc-6cac-4235-a9c0-94aedc2af6fa")
            //});
            //context.Accounts.Add(new Entities.Account
            //{
            //    AccountID = Guid.Parse("7617f09b-6ed4-40ed-8bb1-fec58d866233"),
            //    Email = "briahomenick@hotmail.com",
            //    NickName = "Cosmella",
            //    Password = "Cosmella",
            //    Phone = "008101366606",
            //    UserName = "waltzr",
            //    RoleID = Guid.Parse("0c3ab0cc-6cac-4235-a9c0-94aedc2af6fa")
            //});


            //context.Accounts.Add(new Entities.Account
            //{
            //    AccountID = Guid.Parse("0cbbd18f-80c6-4e53-a6a2-47a1e0170dd4"),
            //    Email = "weberharmon@gmail.com",
            //    NickName = "Cosma",
            //    Password = "Cosma",
            //    Phone = "066259434878",
            //    UserName = "consist",
            //    RoleID = Guid.Parse("186b054d-f8dc-4617-b955-d4240aefd9e4")
            //});


            //context.Accounts.Add(new Entities.Account
            //{
            //    AccountID = Guid.Parse("f0a61699-c1a4-4d8d-935f-257b2b58915a"),
            //    Email = "dwehner@yahoo.com",
            //    NickName = "Mcdonie",
            //    Password = "Mcdonie",
            //    Phone = "059728350281",
            //    UserName = "gender",
            //    RoleID = Guid.Parse("0c3ab0cc-6cac-4235-a9c0-94aedc2af6fa")
            //});

            //context.SaveChanges();
        }

    }
}

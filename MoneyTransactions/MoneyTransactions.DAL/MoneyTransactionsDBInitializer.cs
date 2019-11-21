﻿using System;
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

            // Roles
            context.Roles.Add(new Entities.Role { RoleID = Guid.Parse("0c3ab0cc-6cac-4235-a9c0-94aedc2af6fa"), RoleName = "User", Description = "User role" });
            context.Roles.Add(new Entities.Role { RoleID = Guid.Parse("186b054d-f8dc-4617-b955-d4240aefd9e4"), RoleName = "Admin", Description = "Admin role" });

            // Accounts
            context.Accounts.Add(new Entities.Account { AccountID = Guid.Parse("64d579ce-827d-44db-9e54-c06b068d5ed9"), Email = "oswald42@yahoo.com", NickName = "Leonella", Password = "Leonella", Phone = "054891302798", UserName = "sitesea", RoleID = Guid.Parse("186b054d-f8dc-4617-b955-d4240aefd9e4") });
            context.Accounts.Add(new Entities.Account { AccountID = Guid.Parse("2be034a9-f0e2-4acf-9f0a-548927344715"), Email = "sschamberger@gmail.com", NickName = "Leona", Password = "Leona", Phone = "091502793562", UserName = "swagger", RoleID = Guid.Parse("0c3ab0cc-6cac-4235-a9c0-94aedc2af6fa") });
            context.Accounts.Add(new Entities.Account { AccountID = Guid.Parse("c098ffd7-e70a-48b8-9d40-46949789c048"), Email = "upredovic@howell.com", NickName = "Leonie", Password = "Leonie", Phone = "036314390539", UserName = "straggle", RoleID = Guid.Parse("0c3ab0cc-6cac-4235-a9c0-94aedc2af6fa") });
            context.Accounts.Add(new Entities.Account { AccountID = Guid.Parse("086dd5f3-7bcf-4342-bd80-2ef2a667f6fe"), Email = "mertiewolf@hotmail.com", NickName = "Cosmie", Password = "Cosmie", Phone = "098222175521", UserName = "absorb", RoleID = Guid.Parse("0c3ab0cc-6cac-4235-a9c0-94aedc2af6fa") });
            context.Accounts.Add(new Entities.Account { AccountID = Guid.Parse("7617f09b-6ed4-40ed-8bb1-fec58d866233"), Email = "briahomenick@hotmail.com", NickName = "Cosmella", Password = "Cosmella", Phone = "008101366606", UserName = "waltzr", RoleID = Guid.Parse("0c3ab0cc-6cac-4235-a9c0-94aedc2af6fa") });
            
            context.Accounts.Add(new Entities.Account { AccountID = Guid.Parse("0cbbd18f-80c6-4e53-a6a2-47a1e0170dd4"), Email = "weberharmon@gmail.com", NickName = "Cosma", Password = "Cosma", Phone = "066259434878", UserName = "consist", RoleID = Guid.Parse("186b054d-f8dc-4617-b955-d4240aefd9e4") });
            context.Accounts.Add(new Entities.Account { AccountID = Guid.Parse("f0a61699-c1a4-4d8d-935f-257b2b58915a"), Email = "dwehner@yahoo.com", NickName = "Mcdonie", Password = "Mcdonie", Phone = "059728350281", UserName = "gender", RoleID = Guid.Parse("0c3ab0cc-6cac-4235-a9c0-94aedc2af6fa") });
            context.Accounts.Add(new Entities.Account { AccountID = Guid.Parse("30534fe7-594c-416c-8f77-da87044595fa"), Email = "evans50@gmail.com", NickName = "Mcdona", Password = "Mcdona", Phone = "057964879320", UserName = "assistant", RoleID = Guid.Parse("0c3ab0cc-6cac-4235-a9c0-94aedc2af6fa") });
            context.Accounts.Add(new Entities.Account { AccountID = Guid.Parse("12f39e21-704e-4481-8b85-07d3cf74782a"), Email = "angelo.batz@windler.com", NickName = "Mcdonella", Password = "Mcdonella", Phone = "062627558471", UserName = "edgy", RoleID = Guid.Parse("0c3ab0cc-6cac-4235-a9c0-94aedc2af6fa") });
            context.Accounts.Add(new Entities.Account { AccountID = Guid.Parse("e3163d28-9ffb-48e2-bcfb-fce1303575f7"), Email = "jimmy51@gmail.com", NickName = "ElSeaEm", Password = "ElSeaEm", Phone = "084103724042", UserName = "dilber", RoleID = Guid.Parse("0c3ab0cc-6cac-4235-a9c0-94aedc2af6fa") });

            // Bank 
            context.Banks.Add(new Entities.Bank { BankID = Guid.Parse("7ea342be-247d-46ee-9ed9-786fdd2d1677"), BankName = "Tien Phong Bank" });
            context.Banks.Add(new Entities.Bank { BankID = Guid.Parse("0bc377b2-8c15-4652-b305-287a144a372c"), BankName = "DongA Bank" });
            context.Banks.Add(new Entities.Bank { BankID = Guid.Parse("1749ccc4-13de-4fbc-a4ea-4bc60a636cb5"), BankName = "Agribank Bank" });
            context.Banks.Add(new Entities.Bank { BankID = Guid.Parse("fe18ac45-38f1-48e4-b821-882b35a721fb"), BankName = "Vietcombank" });
            context.Banks.Add(new Entities.Bank { BankID = Guid.Parse("c087241a-9203-49b6-a54b-a7914da79301"), BankName = "Bac A Bank" });
            
            context.Banks.Add(new Entities.Bank { BankID = Guid.Parse("e0ebcbc9-c1f0-4ee6-ba7d-f3b9279e0bfd"), BankName = "Sacombank" });
            context.Banks.Add(new Entities.Bank { BankID = Guid.Parse("e9922c87-33f2-4e04-88d0-97468c40c972"), BankName = "Nam A Bank" });
            context.Banks.Add(new Entities.Bank { BankID = Guid.Parse("5c91bf3b-eaaa-4a08-9d68-2c705f51cc24"), BankName = "Viet A Bank" });
            context.Banks.Add(new Entities.Bank { BankID = Guid.Parse("9d7d8781-af81-4e48-8eaf-49955913f1e9"), BankName = "Bao Viet Bank" });
            context.Banks.Add(new Entities.Bank { BankID = Guid.Parse("0f0ac77e-423d-429f-b66d-4697e2d30402"), BankName = "	Viet Capital Bank" });


            // Account Bank Detail
            context.AccountBankDetails.Add(new Entities.AccountBankDetail { AccountBankDetailID = Guid.Parse("445bd139-05b4-4195-ab0b-aa305435977d"), AccountID = Guid.Parse("12F39E21-704E-4481-8B85-07D3CF74782A"), AccountNumber = "3140758212", BankID = Guid.Parse("0BC377B2-8C15-4652-B305-287A144A372C"), CardNumber = "4051263260183706", ExpiredDate = DateTime.Parse("2027-11-18 11:30:30.12345") });
            context.AccountBankDetails.Add(new Entities.AccountBankDetail { AccountBankDetailID = Guid.Parse("27a32f2a-9a2b-453d-ba1c-239b715794d5"), AccountID = Guid.Parse("F0A61699-C1A4-4D8D-935F-257B2B58915A"), AccountNumber = "2020688649", BankID = Guid.Parse("5C91BF3B-EAAA-4A08-9D68-2C705F51CC24"), CardNumber = "4559361279466323", ExpiredDate = DateTime.Parse("2029-07-16 11:30:30.12345") });
            context.AccountBankDetails.Add(new Entities.AccountBankDetail { AccountBankDetailID = Guid.Parse("a7c12aa8-9ee3-4b23-aaea-d89e3a6b734e"), AccountID = Guid.Parse("086DD5F3-7BCF-4342-BD80-2EF2A667F6FE"), AccountNumber = "6751618070", BankID = Guid.Parse("0F0AC77E-423D-429F-B66D-4697E2D30402"), CardNumber = "4284672591654624", ExpiredDate = DateTime.Parse("2023-02-10 11:30:30.12345") });
            context.AccountBankDetails.Add(new Entities.AccountBankDetail { AccountBankDetailID = Guid.Parse("e8a03d68-a9c2-45f0-a88e-21bab7a56d0a"), AccountID = Guid.Parse("C098FFD7-E70A-48B8-9D40-46949789C048"), AccountNumber = "4785170790", BankID = Guid.Parse("9D7D8781-AF81-4E48-8EAF-49955913F1E9"), CardNumber = "4991396106006864", ExpiredDate = DateTime.Parse("2025-10-19 11:30:30.12345") });
            context.AccountBankDetails.Add(new Entities.AccountBankDetail { AccountBankDetailID = Guid.Parse("b1af43a8-5206-4623-b5a9-4c522d98ee15"), AccountID = Guid.Parse("0CBBD18F-80C6-4E53-A6A2-47A1E0170DD4"), AccountNumber = "9254991120", BankID = Guid.Parse("1749CCC4-13DE-4FBC-A4EA-4BC60A636CB5"), CardNumber = "4705746545582650", ExpiredDate = DateTime.Parse("2028-08-30 11:30:30.12345") });
            
            context.AccountBankDetails.Add(new Entities.AccountBankDetail { AccountBankDetailID = Guid.Parse("bb431dba-abfe-4b20-ad04-1ac02965f7aa"), AccountID = Guid.Parse("2BE034A9-F0E2-4ACF-9F0A-548927344715"), AccountNumber = "6473230476", BankID = Guid.Parse("7EA342BE-247D-46EE-9ED9-786FDD2D1677"), CardNumber = "4029869625223216", ExpiredDate = DateTime.Parse("2025-02-28 11:30:30.12345") });
            context.AccountBankDetails.Add(new Entities.AccountBankDetail { AccountBankDetailID = Guid.Parse("56e5880e-58b9-423c-883e-052316c20ec1"), AccountID = Guid.Parse("64D579CE-827D-44DB-9E54-C06B068D5ED9"), AccountNumber = "8854336742", BankID = Guid.Parse("FE18AC45-38F1-48E4-B821-882B35A721FB"), CardNumber = "4644876626193343", ExpiredDate = DateTime.Parse("2028-12-12 11:30:30.12345") });
            context.AccountBankDetails.Add(new Entities.AccountBankDetail { AccountBankDetailID = Guid.Parse("ce9cbc6d-5856-4708-a833-6b09200e3873"), AccountID = Guid.Parse("30534FE7-594C-416C-8F77-DA87044595FA"), AccountNumber = "7266108938", BankID = Guid.Parse("E9922C87-33F2-4E04-88D0-97468C40C972"), CardNumber = "4499695445577460", ExpiredDate = DateTime.Parse("2022-05-12 11:30:30.12345") });
            context.AccountBankDetails.Add(new Entities.AccountBankDetail { AccountBankDetailID = Guid.Parse("09aeff6c-9fb5-4f16-8952-e262e70d1fef"), AccountID = Guid.Parse("E3163D28-9FFB-48E2-BCFB-FCE1303575F7"), AccountNumber = "8286982404", BankID = Guid.Parse("C087241A-9203-49B6-A54B-A7914DA79301"), CardNumber = "4282613370528177", ExpiredDate = DateTime.Parse("2026-08-19 11:30:30.12345") });
            context.AccountBankDetails.Add(new Entities.AccountBankDetail { AccountBankDetailID = Guid.Parse("45dc9b2e-16c2-43bb-8c24-eabd30432509"), AccountID = Guid.Parse("7617F09B-6ED4-40ED-8BB1-FEC58D866233"), AccountNumber = "1159609210", BankID = Guid.Parse("E0EBCBC9-C1F0-4EE6-BA7D-F3B9279E0BFD"), CardNumber = "4543729236541660", ExpiredDate = DateTime.Parse("2028-12-25 11:30:30.12345") });

            // Cryptocurrency
            context.CryptocurrencyStores.Add(new Entities.CryptocurrencyStore { CryptocurrencyStoreID = Guid.Parse("1dfecc5c-87fb-4c54-8375-000c4ceafe73"), MoneyType = "ETH", Description = "", FloorPrice = 4356389 });
            context.CryptocurrencyStores.Add(new Entities.CryptocurrencyStore { CryptocurrencyStoreID = Guid.Parse("9c5e0dd2-840a-42d9-bd31-0a7c31194ec8"), MoneyType = "BTC", Description = "", FloorPrice = 204029250 });
            context.CryptocurrencyStores.Add(new Entities.CryptocurrencyStore { CryptocurrencyStoreID = Guid.Parse("bcc2b73f-b219-43ce-bb6b-20621d2f1573"), MoneyType = "XRP", Description = "", FloorPrice = 6356 });






            // Wallet   

            context.Wallets.Add(new Entities.Wallet { WalletID = Guid.Parse("aae11c95-44d6-4c71-9bc1-07504e5fcc54"), WalletAddress = "1J2EgyS6ni3YysWxHW8Ge5azYXVgNZZsLv", BalanceAmount = 0.000000000m, BalanceAmountTransaction = 0.000000000m, AccountID = Guid.Parse("2be034a9-f0e2-4acf-9f0a-548927344715"), CryptocurrencyStoreID = Guid.Parse("1dfecc5c-87fb-4c54-8375-000c4ceafe73"), PrivateKey = "KwtytmrvMqwgG5Hd24NWTF8w8RfKvMY9dpo5ymSkkNXkaWtAYhZF" });
            context.Wallets.Add(new Entities.Wallet { WalletID = Guid.Parse("2893ad6a-e856-4ce4-bc2e-0a0bdd89a06b"), WalletAddress = "1AUysAaRkZheDvZvGZJZHA3LGSLCfsHwHt", BalanceAmount = 0.000000000m, BalanceAmountTransaction = 0.000000000m, AccountID = Guid.Parse("7617f09b-6ed4-40ed-8bb1-fec58d866233"), CryptocurrencyStoreID = Guid.Parse("1dfecc5c-87fb-4c54-8375-000c4ceafe73"), PrivateKey = "Ky4BJrqTvGoaF4AGmozALo8WsMcnfE42pw4W9NoPX9bnv9PQdxpu" });
            context.Wallets.Add(new Entities.Wallet { WalletID = Guid.Parse("a3eeb73c-9c53-4d00-8ec3-1772de65f03a"), WalletAddress = "14vuDzpTsMQtT7bw2L8qQ2u28Cv5Xw6sdu", BalanceAmount = 0.000000000m, BalanceAmountTransaction = 0.000000000m, AccountID = Guid.Parse("2be034a9-f0e2-4acf-9f0a-548927344715"), CryptocurrencyStoreID = Guid.Parse("9c5e0dd2-840a-42d9-bd31-0a7c31194ec8"), PrivateKey = "L2pXDuFErBdxuSjzvMCPgeMnWqjLewMyET9GRZ91d1sUFjQ88e4S" });
            context.Wallets.Add(new Entities.Wallet { WalletID = Guid.Parse("65213311-9616-422e-9c9d-1f33711836b2"), WalletAddress = "17nQyHkPk3LNZ5hStvL6R1mtQsDMHRgWfX", BalanceAmount = 0.000000000m, BalanceAmountTransaction = 0.000000000m, AccountID = Guid.Parse("30534fe7-594c-416c-8f77-da87044595fa"), CryptocurrencyStoreID = Guid.Parse("1dfecc5c-87fb-4c54-8375-000c4ceafe73"), PrivateKey = "L4rPu4w26H8MGV9rCMWfPnRpKRui8LzUaPZpZKtGz96MqvA1tJEB" });
            context.Wallets.Add(new Entities.Wallet { WalletID = Guid.Parse("4e0100cf-61eb-4e80-8293-2873d8bd8fd8"), WalletAddress = "1P1Ua8AXLXfywKJmyi9RM8XCjjtiZxiJqU", BalanceAmount = 0.000000000m, BalanceAmountTransaction = 0.000000000m, AccountID = Guid.Parse("64d579ce-827d-44db-9e54-c06b068d5ed9"), CryptocurrencyStoreID = Guid.Parse("1dfecc5c-87fb-4c54-8375-000c4ceafe73"), PrivateKey = "L29fZsbchponJHP6SjUxkB14JgjTyB4TafpiApnqgHRFWFyWrUt7" });
            
            context.Wallets.Add(new Entities.Wallet { WalletID = Guid.Parse("5a9b86f9-421f-45fb-9988-2c8571bce530"), WalletAddress = "1DD8yzn9rDiS5ksoYk4UUzJdqmRA7LrR3Y", BalanceAmount = 0.000000000m, BalanceAmountTransaction = 0.000000000m, AccountID = Guid.Parse("c098ffd7-e70a-48b8-9d40-46949789c048"), CryptocurrencyStoreID = Guid.Parse("1dfecc5c-87fb-4c54-8375-000c4ceafe73"), PrivateKey = "L5AsTdmvokqtHPCCFneBybEGo82mcJqp6RTipbzLAnQZ9ujRKzJn" });
            context.Wallets.Add(new Entities.Wallet { WalletID = Guid.Parse("30a8c22c-ec31-4af0-b753-2d300c6371ac"), WalletAddress = "1L42cAfuY7iTohhfSXyLbH5eZvcApN9Pbp", BalanceAmount = 0.000000000m, BalanceAmountTransaction = 0.000000000m, AccountID = Guid.Parse("0cbbd18f-80c6-4e53-a6a2-47a1e0170dd4"), CryptocurrencyStoreID = Guid.Parse("1dfecc5c-87fb-4c54-8375-000c4ceafe73"), PrivateKey = "KxAvkfRkJHoYdjtPDCC4yRZo6a6Zt5QUD3JzAZs1JNcM3RjQZjcd" });
            context.Wallets.Add(new Entities.Wallet { WalletID = Guid.Parse("3174bdd2-a4d5-493e-86d7-346f3ef299d3"), WalletAddress = "1JQfGoJvNUmYazs4BkkxqXRX2Jm9CtPPe2", BalanceAmount = 0.000000000m, BalanceAmountTransaction = 0.000000000m, AccountID = Guid.Parse("2be034a9-f0e2-4acf-9f0a-548927344715"), CryptocurrencyStoreID = Guid.Parse("bcc2b73f-b219-43ce-bb6b-20621d2f1573"), PrivateKey = "KzHXwDYcm24bMHygfYRX1xXf1ytDWSRYRA9vqdBvHAVtkdUAYZLB" });
            context.Wallets.Add(new Entities.Wallet { WalletID = Guid.Parse("c1fe5d6e-7fef-467f-99d4-3742985bc2ed"), WalletAddress = "1Euxpvp6BAc98Qr8k1EFkT1eCDaZYyEsVX", BalanceAmount = 0.000000000m, BalanceAmountTransaction = 0.000000000m, AccountID = Guid.Parse("f0a61699-c1a4-4d8d-935f-257b2b58915a"), CryptocurrencyStoreID = Guid.Parse("1dfecc5c-87fb-4c54-8375-000c4ceafe73"), PrivateKey = "L5isog71HjooGKNHMwFV8eNktBdTjbtw9ZKkWoCM5xVW1DGKx5cf" });
            context.Wallets.Add(new Entities.Wallet { WalletID = Guid.Parse("68a7ee99-70fe-422b-b550-3a6e7ea1583a"), WalletAddress = "1F37AvfAApBEm6wEt9Mrp6D5Fe3pvyRn9m", BalanceAmount = 0.000000000m, BalanceAmountTransaction = 0.000000000m, AccountID = Guid.Parse("086dd5f3-7bcf-4342-bd80-2ef2a667f6fe"), CryptocurrencyStoreID = Guid.Parse("1dfecc5c-87fb-4c54-8375-000c4ceafe73"), PrivateKey = "L3BM4xNcQ2h3sTdSzWYDviGmcfWm8Nb7YsrUiBpxsSAgmDaUaXW4" });
            
            context.Wallets.Add(new Entities.Wallet { WalletID = Guid.Parse("e9049161-cf3d-4e81-a7b9-4b1262440f0b"), WalletAddress = "145qcTBNFGep54L4wFGzzJFjC9j2VK8pME", BalanceAmount = 0.000000000m, BalanceAmountTransaction = 0.000000000m, AccountID = Guid.Parse("0cbbd18f-80c6-4e53-a6a2-47a1e0170dd4"), CryptocurrencyStoreID = Guid.Parse("9c5e0dd2-840a-42d9-bd31-0a7c31194ec8"), PrivateKey = "L2b6ZdafuPjP8ocbgXo6ZyauxaLbJvcrcpCyfPZ9zp1819vUXJ5o" });
            context.Wallets.Add(new Entities.Wallet { WalletID = Guid.Parse("57c459be-8230-4908-9f64-4e06c80ea214"), WalletAddress = "1CPheSGQGLX7M5ihybNhMTJyMvnz7sbzzi", BalanceAmount = 0.000000000m, BalanceAmountTransaction = 0.000000000m, AccountID = Guid.Parse("12f39e21-704e-4481-8b85-07d3cf74782a"), CryptocurrencyStoreID = Guid.Parse("1dfecc5c-87fb-4c54-8375-000c4ceafe73"), PrivateKey = "L3dfMGfEFP9ePTXhwjXZsSaRXM5HseRz9vvppoWqEeFuWsxdTPfi" });
            context.Wallets.Add(new Entities.Wallet { WalletID = Guid.Parse("396e38ee-2f1c-4824-b64d-5b1d8ceec25a"), WalletAddress = "15tdGahpZ5JnTpo3kGb4VfHh9NYnrpHziJ", BalanceAmount = 0.000000000m, BalanceAmountTransaction = 0.000000000m, AccountID = Guid.Parse("30534fe7-594c-416c-8f77-da87044595fa"), CryptocurrencyStoreID = Guid.Parse("9c5e0dd2-840a-42d9-bd31-0a7c31194ec8"), PrivateKey = "L2RCpvsPXgiSAov9q6BB7GQZkuqBkUpVYWPLRp9RpfUi99Pub5fb" });
            context.Wallets.Add(new Entities.Wallet { WalletID = Guid.Parse("15f71c0b-29c3-4cd5-a2f3-5bb0de41a4dc"), WalletAddress = "1AYRSeNvthdFPtA1vX2UpoKiPbgqvxJG3y", BalanceAmount = 0.000000000m, BalanceAmountTransaction = 0.000000000m, AccountID = Guid.Parse("7617f09b-6ed4-40ed-8bb1-fec58d866233"), CryptocurrencyStoreID = Guid.Parse("9c5e0dd2-840a-42d9-bd31-0a7c31194ec8"), PrivateKey = "L1T1CjPBDvdDJyRM1VZJSZ9BscXTBUNp9upb6SMh8HaVuyzUp8fD" });
            context.Wallets.Add(new Entities.Wallet { WalletID = Guid.Parse("c6092298-0cce-40c0-a9b3-5ee83d990a0a"), WalletAddress = "1CfB5J2Q1PHsXZ3wYPcGexgU577B1XYA3p", BalanceAmount = 0.000000000m, BalanceAmountTransaction = 0.000000000m, AccountID = Guid.Parse("30534fe7-594c-416c-8f77-da87044595fa"), CryptocurrencyStoreID = Guid.Parse("bcc2b73f-b219-43ce-bb6b-20621d2f1573"), PrivateKey = "L3D6TxJVGgLT1W57SuhzTcedbqdhdhFgakysJ7BpBTrJP6jGA4m7" });
            
            context.Wallets.Add(new Entities.Wallet { WalletID = Guid.Parse("7506f8ec-8e5f-485f-a0cc-64b6cdcfba2c"), WalletAddress = "1NS39p8rD8qARsdMamupDrmt4vJXB26btu", BalanceAmount = 0.000000000m, BalanceAmountTransaction = 0.000000000m, AccountID = Guid.Parse("12f39e21-704e-4481-8b85-07d3cf74782a"), CryptocurrencyStoreID = Guid.Parse("9c5e0dd2-840a-42d9-bd31-0a7c31194ec8"), PrivateKey = "L17xVL7xhiQ62YbrsyYVmrn8naDyLiLRra5PPYqJWdnCxZ1xAQFH" });
            context.Wallets.Add(new Entities.Wallet { WalletID = Guid.Parse("c9977ae2-60cf-45c1-a5ae-6e96bd9ea529"), WalletAddress = "1QAzBD7SoMoAiGiPqxU58bfAL4RvGtfHVE", BalanceAmount = 0.000000000m, BalanceAmountTransaction = 0.000000000m, AccountID = Guid.Parse("12f39e21-704e-4481-8b85-07d3cf74782a"), CryptocurrencyStoreID = Guid.Parse("bcc2b73f-b219-43ce-bb6b-20621d2f1573"), PrivateKey = "L3opwDRJ2zFckJwWtp6JxFhP5LxtNLoL6bfpYdrQP9DtEXMMruGR" });
            context.Wallets.Add(new Entities.Wallet { WalletID = Guid.Parse("9e5ef5f4-7c33-412c-af1d-700ab2fd83e4"), WalletAddress = "1Hf28szHfs2Dj15NQGkTYZWesQipXia9Bc", BalanceAmount = 0.000000000m, BalanceAmountTransaction = 0.000000000m, AccountID = Guid.Parse("c098ffd7-e70a-48b8-9d40-46949789c048"), CryptocurrencyStoreID = Guid.Parse("9c5e0dd2-840a-42d9-bd31-0a7c31194ec8"), PrivateKey = "L2VawoteyB3ErueJHDYZudwqwEq3XckYc5rfPRmGHz3SZic8UMJv" });
            context.Wallets.Add(new Entities.Wallet { WalletID = Guid.Parse("4a59ab14-2bd8-44b2-aaaf-76835eb8766a"), WalletAddress = "19x8kCQC94bCUYKeKpEFPo2QnUuXXJY4tG", BalanceAmount = 0.000000000m, BalanceAmountTransaction = 0.000000000m, AccountID = Guid.Parse("64d579ce-827d-44db-9e54-c06b068d5ed9"), CryptocurrencyStoreID = Guid.Parse("9c5e0dd2-840a-42d9-bd31-0a7c31194ec8"), PrivateKey = "L5j3YqYW8EQ8gemLBa45AM8pXxsrypLY4hP3Uf2zv4zUSso4PhCo" });
            context.Wallets.Add(new Entities.Wallet { WalletID = Guid.Parse("ebd1ee86-9647-40e8-9eda-7971e348ee8c"), WalletAddress = "1L4S2MPBeGDMy2Heqe78Y535N5AXFSwwYB", BalanceAmount = 0.000000000m, BalanceAmountTransaction = 0.000000000m, AccountID = Guid.Parse("0cbbd18f-80c6-4e53-a6a2-47a1e0170dd4"), CryptocurrencyStoreID = Guid.Parse("bcc2b73f-b219-43ce-bb6b-20621d2f1573"), PrivateKey = "L59sf9p7wr4bFR9hsxv9AAggWEqPAmRaTjGBXUwxycMfAxJ1SX7q" });
            
            context.Wallets.Add(new Entities.Wallet { WalletID = Guid.Parse("543be60d-313b-4b36-a80c-7c080a4e2e99"), WalletAddress = "1FYyxea33W7QFkUW7Z9XTrRNuXd1GRsUTK", BalanceAmount = 0.000000000m, BalanceAmountTransaction = 0.000000000m, AccountID = Guid.Parse("f0a61699-c1a4-4d8d-935f-257b2b58915a"), CryptocurrencyStoreID = Guid.Parse("9c5e0dd2-840a-42d9-bd31-0a7c31194ec8"), PrivateKey = "Ky53P7qc1TmpiqZNr514QunvtNUdCHit7UaFLAZGPajf1Pt27E6V" });
            context.Wallets.Add(new Entities.Wallet { WalletID = Guid.Parse("e362d70f-c3a5-4642-8098-886ba3b5652d"), WalletAddress = "1JXmFU2FP3kpd822v6XBDRowzJugasT7kS", BalanceAmount = 0.000000000m, BalanceAmountTransaction = 0.000000000m, AccountID = Guid.Parse("64d579ce-827d-44db-9e54-c06b068d5ed9"), CryptocurrencyStoreID = Guid.Parse("bcc2b73f-b219-43ce-bb6b-20621d2f1573"), PrivateKey = "L4t2zhMEuDrFGL6PAAbjgpuS4WjegBsZTuPZAHiSGMSvNSHQT8tD" });
            context.Wallets.Add(new Entities.Wallet { WalletID = Guid.Parse("a1fd30b8-ee4e-4f26-b799-894a9c5e9fd3"), WalletAddress = "1Ac8c4aD3W7pFDTpCSxYyLkUopXUrsx3LU", BalanceAmount = 0.000000000m, BalanceAmountTransaction = 0.000000000m, AccountID = Guid.Parse("c098ffd7-e70a-48b8-9d40-46949789c048"), CryptocurrencyStoreID = Guid.Parse("bcc2b73f-b219-43ce-bb6b-20621d2f1573"), PrivateKey = "KxTHEDDak5ztLQUc3WKzAu7oedNYsDhQGVZSk3oNf77MvgLuFMVz" });
            context.Wallets.Add(new Entities.Wallet { WalletID = Guid.Parse("9aa527a4-7a54-4b00-850d-9429fae169e6"), WalletAddress = "1HJ3f76K2gzW5unbh2eUZibaEin2WnRqwv", BalanceAmount = 0.000000000m, BalanceAmountTransaction = 0.000000000m, AccountID = Guid.Parse("e3163d28-9ffb-48e2-bcfb-fce1303575f7"), CryptocurrencyStoreID = Guid.Parse("1dfecc5c-87fb-4c54-8375-000c4ceafe73"), PrivateKey = "KyLiH6PopgkdYWaT8vwLvPVJ3dFiaRutnPrxajoFvYSLMiVPeVaa" });
            context.Wallets.Add(new Entities.Wallet { WalletID = Guid.Parse("1a448449-0bba-4ea1-a3c9-94cb3341f03c"), WalletAddress = "1CsyfwqqKPVA3PbjoNwoUnZfPdBw24a9ee", BalanceAmount = 0.000000000m, BalanceAmountTransaction = 0.000000000m, AccountID = Guid.Parse("086dd5f3-7bcf-4342-bd80-2ef2a667f6fe"), CryptocurrencyStoreID = Guid.Parse("9c5e0dd2-840a-42d9-bd31-0a7c31194ec8"), PrivateKey = "L5S79t5tJmSx4sW59HxBnVB7zsXCbnzwjd2wM3EubqWCeV3QbBWo" });
            
            context.Wallets.Add(new Entities.Wallet { WalletID = Guid.Parse("f5e67d91-5e4c-47ce-8b8d-a2f256ee3064"), WalletAddress = "1HJh5ipB9QdjPQRQUas1FftMKSyooqZ4pL", BalanceAmount = 0.000000000m, BalanceAmountTransaction = 0.000000000m, AccountID = Guid.Parse("e3163d28-9ffb-48e2-bcfb-fce1303575f7"), CryptocurrencyStoreID = Guid.Parse("9c5e0dd2-840a-42d9-bd31-0a7c31194ec8"), PrivateKey = "Kze9QUxLpwxPCcKnGgSS5Po4n3bAoRepwBGZpqoBfVYg7xWQSkBR" });
            context.Wallets.Add(new Entities.Wallet { WalletID = Guid.Parse("93b94127-07f7-4c7a-88db-a38f5300b501"), WalletAddress = "1K3AXJ7D4cfr9jBAV4NW11u7wLHGy2ywzw", BalanceAmount = 0.000000000m, BalanceAmountTransaction = 0.000000000m, AccountID = Guid.Parse("e3163d28-9ffb-48e2-bcfb-fce1303575f7"), CryptocurrencyStoreID = Guid.Parse("bcc2b73f-b219-43ce-bb6b-20621d2f1573"), PrivateKey = "KzKNy91FB4dpvdooTVsTaLaeTwXCf1EjimGpe6eR6MukS2jHoz99" });
            context.Wallets.Add(new Entities.Wallet { WalletID = Guid.Parse("fc06f9e7-49d2-4a8f-8c9d-b6462bf0a8d6"), WalletAddress = "1BHPrAen92GVkbVcdoRCsKvRL4zj2uByDc", BalanceAmount = 0.000000000m, BalanceAmountTransaction = 0.000000000m, AccountID = Guid.Parse("f0a61699-c1a4-4d8d-935f-257b2b58915a"), CryptocurrencyStoreID = Guid.Parse("bcc2b73f-b219-43ce-bb6b-20621d2f1573"), PrivateKey = "L4rK3aE8sfmeY2qFUD4XciY6y6uottLme14FHPj4XsgnPh1h4tJA" });
            context.Wallets.Add(new Entities.Wallet { WalletID = Guid.Parse("74a1c1ca-33d3-40ba-ab86-c122a8f20a1b"), WalletAddress = "1KfSZ8KZSrohk7d3HBnmb54S5vrKJBp69M", BalanceAmount = 0.000000000m, BalanceAmountTransaction = 0.000000000m, AccountID = Guid.Parse("7617f09b-6ed4-40ed-8bb1-fec58d866233"), CryptocurrencyStoreID = Guid.Parse("bcc2b73f-b219-43ce-bb6b-20621d2f1573"), PrivateKey = "L4TWa3Pcaq75Em4PQb7b6qaagH3LFtigcCbdkFDHHGxE8epCumk9" });
            context.Wallets.Add(new Entities.Wallet { WalletID = Guid.Parse("894b434c-f20f-4a82-853b-d5e67255e685"), WalletAddress = "17P9Utrp1mQME7FevRmrAf1QHXWqnwegNo", BalanceAmount = 0.000000000m, BalanceAmountTransaction = 0.000000000m, AccountID = Guid.Parse("086dd5f3-7bcf-4342-bd80-2ef2a667f6fe"), CryptocurrencyStoreID = Guid.Parse("bcc2b73f-b219-43ce-bb6b-20621d2f1573"), PrivateKey = "L5kA9uzzkbkLFPhtsMmfLNbsVyR4tVxQCS514aP4668PtHMKkcdw" });






            // Orders
            context.Orders.Add(new Entities.Order { Amount = 9.12343m, Price = 0, CreatedDate = DateTime.Parse("2019-09-12 03:15:30.12345"), ModifiedDate = DateTime.Parse("2019-09-12 03:15:30.12345"), OrderID = Guid.Parse("51e3fb71-c014-4bb1-a77c-38460e8f0ca5"), WalletID = Guid.Parse("4e0100cf-61eb-4e80-8293-2873d8bd8fd8"), OrderType = "Buy" });
            context.Orders.Add(new Entities.Order { Amount = 0.12411m, Price = 0, CreatedDate = DateTime.Parse("2019-08-22 22:01:30.12345"), ModifiedDate = DateTime.Parse("2019-08-22 22:01:30.12345"), OrderID = Guid.Parse("67600943-2897-45f6-bd2a-f014d2743ec1"), WalletID = Guid.Parse("a3eeb73c-9c53-4d00-8ec3-1772de65f03a"), OrderType = "Buy" });
            context.Orders.Add(new Entities.Order { Amount = 0.00228m, Price = 0, CreatedDate = DateTime.Parse("2019-11-13 23:19:30.12345"), ModifiedDate = DateTime.Parse("2019-11-13 23:19:30.12345"), OrderID = Guid.Parse("749161a8-f2a7-433d-b2b8-03d9d7b5e212"), WalletID = Guid.Parse("5a9b86f9-421f-45fb-9988-2c8571bce530"), OrderType = "Buy" });
            context.Orders.Add(new Entities.Order { Amount = 3.41345m, Price = 0, CreatedDate = DateTime.Parse("2019-03-09 01:05:30.12345"), ModifiedDate = DateTime.Parse("2019-03-09 01:05:30.12345"), OrderID = Guid.Parse("b2fcc381-c9e5-4732-a0d8-d3fdda5297d0"), WalletID = Guid.Parse("1a448449-0bba-4ea1-a3c9-94cb3341f03c"), OrderType = "Buy" });
            context.Orders.Add(new Entities.Order { Amount = 1.12232m, Price = 0, CreatedDate = DateTime.Parse("2019-02-22 07:11:30.12345"), ModifiedDate = DateTime.Parse("2019-02-22 07:11:30.12345"), OrderID = Guid.Parse("4b741272-eaa0-490c-bdcc-8e97d5245228"), WalletID = Guid.Parse("2893ad6a-e856-4ce4-bc2e-0a0bdd89a06b"), OrderType = "Buy" });

            context.Orders.Add(new Entities.Order { Amount = 3.49553m, Price = 0, CreatedDate = DateTime.Parse("2019-01-30 06:20:30.12345"), ModifiedDate = DateTime.Parse("2019-01-30 06:20:30.12345"), OrderID = Guid.Parse("4ac1767f-d5da-4051-bfe8-1de6484b1095"), WalletID = Guid.Parse("ebd1ee86-9647-40e8-9eda-7971e348ee8c"), OrderType = "Sell" });
            context.Orders.Add(new Entities.Order { Amount = 2.36815m, Price = 0, CreatedDate = DateTime.Parse("2019-06-10 20:03:30.12345"), ModifiedDate = DateTime.Parse("2019-06-10 20:03:30.12345"), OrderID = Guid.Parse("df377153-5165-4130-9329-b80eaf92031e"), WalletID = Guid.Parse("c1fe5d6e-7fef-467f-99d4-3742985bc2ed"), OrderType = "Sell" });
            context.Orders.Add(new Entities.Order { Amount = 4.84348m, Price = 0, CreatedDate = DateTime.Parse("2019-10-27 21:02:30.12345"), ModifiedDate = DateTime.Parse("2019-10-27 21:02:30.12345"), OrderID = Guid.Parse("e2c84406-fbc8-43ca-b6f0-918dbe8df608"), WalletID = Guid.Parse("65213311-9616-422e-9c9d-1f33711836b2"), OrderType = "Sell" });
            context.Orders.Add(new Entities.Order { Amount = 2.77118m, Price = 0, CreatedDate = DateTime.Parse("2019-08-30 06:17:30.12345"), ModifiedDate = DateTime.Parse("2019-08-30 06:17:30.12345"), OrderID = Guid.Parse("3fabc416-372c-4a07-b2cb-66984f344330"), WalletID = Guid.Parse("c9977ae2-60cf-45c1-a5ae-6e96bd9ea529"), OrderType = "Sell" });
            context.Orders.Add(new Entities.Order { Amount = 4.65678m, Price = 0, CreatedDate = DateTime.Parse("2019-12-18 10:10:30.12345"), ModifiedDate = DateTime.Parse("2019-12-18 10:10:30.12345"), OrderID = Guid.Parse("cc5f6c41-7bf8-4ed0-98d5-8c7af1d86574"), WalletID = Guid.Parse("93b94127-07f7-4c7a-88db-a38f5300b501"), OrderType = "Sell" });



            // Order Details
            context.OrderDetails.Add(new Entities.OrderDetail { Amount = 9.12343m, CreatedDate = DateTime.Parse("2019-11-13 23:19:30.12345"), WalletID = Guid.Parse("4e0100cf-61eb-4e80-8293-2873d8bd8fd8"), OrderDetailID = Guid.Parse("d02d3701-cf77-4407-9cfc-5d99199d9d28"), OrderID = Guid.Parse("749161A8-F2A7-433D-B2B8-03D9D7B5E212") });
            context.OrderDetails.Add(new Entities.OrderDetail { Amount = 0.12411m, CreatedDate = DateTime.Parse("2019-01-30 06:20:30.12345"), WalletID = Guid.Parse("a3eeb73c-9c53-4d00-8ec3-1772de65f03a"), OrderDetailID = Guid.Parse("17555c6a-08ce-4229-ac73-a8784cdac74c"), OrderID = Guid.Parse("4AC1767F-D5DA-4051-BFE8-1DE6484B1095") });
            context.OrderDetails.Add(new Entities.OrderDetail { Amount = 0.00228m, CreatedDate = DateTime.Parse("2019-09-12 03:15:30.12345"), WalletID = Guid.Parse("5a9b86f9-421f-45fb-9988-2c8571bce530"), OrderDetailID = Guid.Parse("e1ed3a03-349d-4cad-9e1d-9cf5796fec1a"), OrderID = Guid.Parse("51E3FB71-C014-4BB1-A77C-38460E8F0CA5") });
            context.OrderDetails.Add(new Entities.OrderDetail { Amount = 3.41345m, CreatedDate = DateTime.Parse("2019-08-30 06:17:30.12345"), WalletID = Guid.Parse("1a448449-0bba-4ea1-a3c9-94cb3341f03c"), OrderDetailID = Guid.Parse("55ad22ee-6f45-411a-8631-9739a816b5b1"), OrderID = Guid.Parse("3FABC416-372C-4A07-B2CB-66984F344330") });
            context.OrderDetails.Add(new Entities.OrderDetail { Amount = 1.12232m, CreatedDate = DateTime.Parse("2019-12-18 10:10:30.12345"), WalletID = Guid.Parse("2893ad6a-e856-4ce4-bc2e-0a0bdd89a06b"), OrderDetailID = Guid.Parse("f86ef758-ce78-406b-84b9-5b27f282ac93"), OrderID = Guid.Parse("CC5F6C41-7BF8-4ED0-98D5-8C7AF1D86574") });
            
            context.OrderDetails.Add(new Entities.OrderDetail { Amount = 3.49553m, CreatedDate = DateTime.Parse("2019-02-22 07:11:30.12345"), WalletID = Guid.Parse("ebd1ee86-9647-40e8-9eda-7971e348ee8c"), OrderDetailID = Guid.Parse("87c943cf-63a9-405d-be0b-a3388d37c450"), OrderID = Guid.Parse("4B741272-EAA0-490C-BDCC-8E97D5245228") });
            context.OrderDetails.Add(new Entities.OrderDetail { Amount = 2.36815m, CreatedDate = DateTime.Parse("2019-10-27 21:02:30.12345"), WalletID = Guid.Parse("c1fe5d6e-7fef-467f-99d4-3742985bc2ed"), OrderDetailID = Guid.Parse("c7a643e3-05e8-4095-bbc4-e4d2254134c3"), OrderID = Guid.Parse("E2C84406-FBC8-43CA-B6F0-918DBE8DF608") });
            context.OrderDetails.Add(new Entities.OrderDetail { Amount = 4.84348m, CreatedDate = DateTime.Parse("2019-06-10 20:03:30.12345"), WalletID = Guid.Parse("65213311-9616-422e-9c9d-1f33711836b2"), OrderDetailID = Guid.Parse("84b19d16-1e58-4ffa-8d9d-5efd64eedceb"), OrderID = Guid.Parse("DF377153-5165-4130-9329-B80EAF92031E") });
            context.OrderDetails.Add(new Entities.OrderDetail { Amount = 2.77118m, CreatedDate = DateTime.Parse("2019-03-09 01:05:30.12345"), WalletID = Guid.Parse("c9977ae2-60cf-45c1-a5ae-6e96bd9ea529"), OrderDetailID = Guid.Parse("197e0bce-49f7-4cca-9307-15d410154a9c"), OrderID = Guid.Parse("B2FCC381-C9E5-4732-A0D8-D3FDDA5297D0") });
            context.OrderDetails.Add(new Entities.OrderDetail { Amount = 4.65678m, CreatedDate = DateTime.Parse("2019-08-22 22:01:30.12345"), WalletID = Guid.Parse("93b94127-07f7-4c7a-88db-a38f5300b501"), OrderDetailID = Guid.Parse("6a285aae-f395-4fcf-92cc-74d9082d4c20"), OrderID = Guid.Parse("67600943-2897-45F6-BD2A-F014D2743EC1") });


            context.SaveChanges();
        }
    }
}

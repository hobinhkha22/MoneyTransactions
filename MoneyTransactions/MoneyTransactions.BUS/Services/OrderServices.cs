﻿using MoneyTransactions.Common;
using MoneyTransactions.DAL;
using MoneyTransactions.DAL.Implement;
using MoneyTransactions.Entities;
using NBitcoin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTransactions.BUS.Services
{
    public class OrderServices
    {
        private readonly OrderDataAccess orderDataAccess;
        private readonly WalletDataAccess walletDataAccess;
        private WalletServices walletServices;

        public OrderServices()
        {
            orderDataAccess = new OrderDataAccess();
            walletDataAccess = new WalletDataAccess();
            walletServices = new WalletServices();
        }

        [Obsolete]
        void CreateSellTransaction(Guid walletID, string privateKeySeller, decimal amountWantToSell)
        {
            BitcoinSecret SellerWallet;

            var getPrivateKeySeller = walletDataAccess.FindWalletByPrivateKey(privateKeySeller);
            if (getPrivateKeySeller != null)
            {
                SellerWallet = new BitcoinSecret(getPrivateKeySeller.PrivateKey);

                // tao 1 trans muon ban
                // so luong amountWantToSell.ToString() phai tru vao object
                // sau do luu tru
                Transaction SellerWalletFunding = new Transaction()
                {
                    Outputs =
                    {
                        new TxOut(amountWantToSell.ToString(), SellerWallet.GetAddress())
                    }
                };

                var subtract = getPrivateKeySeller.BalanceAmount - amountWantToSell;
                getPrivateKeySeller.BalanceAmountTransaction = subtract;

                // tao mot transaction voi order luu vao db -> Done
                Order newOrderForSeller = new Order();
                newOrderForSeller.OrderID = Guid.NewGuid();
                newOrderForSeller.WalletID = walletID;
                newOrderForSeller.Amount = amountWantToSell; // here
                newOrderForSeller.CreatedDate = DateTime.Now;
                newOrderForSeller.ModifiedDate = DateTime.Now;


                orderDataAccess.CreateOrder(newOrderForSeller);

            }
            else
            {
                throw new Exception("Can't get object");
            }
        }

        public List<Order> GetListOrder()
        {
            return orderDataAccess.GetListOrder();
        }

        public Order FindOrderByWalletIDAndAmount(Guid walletID, decimal amount)
        {
            return orderDataAccess.FindOrderByWalletIDAndAmount(walletID, amount);
        }

        public Order FindOrderByAccountIDAndAmount(Guid accountID, decimal amount)
        {
            return orderDataAccess.FindOrderByAccountIDAndAmount(accountID, amount);
        }

        public List<Order> ShowRecentTransaction()
        {
            return orderDataAccess.GetOrders();
        }

        [Obsolete]
        public void HandleTransaction(Guid Seller, Guid Buyer, decimal amountTransaction, Order order)
        {
            if (order.OrderType == OrderCommon.OrderSell) // Sell
            {
                // noi xay ra giao dich tai day
                var getBuyer = walletDataAccess.FindWalletByAccountID(Buyer);
                var getSeller = walletDataAccess.FindWalletByAccountID(Seller);

                BitcoinSecret buyerWallet = new BitcoinSecret(getBuyer.PrivateKey);
                BitcoinSecret sellerWallet = new BitcoinSecret(getSeller.PrivateKey);

                if (getBuyer != null && getSeller != null)
                {
                    // check balance amount enough to perform buy action
                    if (getBuyer.BalanceAmount > amountTransaction)
                    {
                        var buyerSubtract = getBuyer.BalanceAmount - amountTransaction;
                        // trich quy ra de mua
                        Transaction buyerFunding = new Transaction()
                        {
                            Outputs =   {
                            new TxOut(amountTransaction.ToString(), buyerWallet.GetAddress())
                        }
                        };

                        getBuyer.BalanceAmount = buyerSubtract; // trich xong roi add phan con lai vao balanaceamount

                        Coin[] buyerCoins = buyerFunding
                                            .Outputs
                                            .Select((o, i) => new Coin(new OutPoint(buyerFunding.GetHash(), i), o))
                                            .ToArray();

                        string totalToSend = "";
                        foreach (var item in buyerCoins)
                        {
                            totalToSend += item.TxOut.Value.ToString();
                        }

                        Money fee = new Money(100);

                        // construct transaction
                        // chuyen cho nguoi ban
                        TransactionBuilder txBuilder = new TransactionBuilder();
                        var tx = txBuilder
                            .AddCoins(buyerCoins)
                            .AddKeys(buyerWallet.PrivateKey)
                            .Send(sellerWallet.GetAddress(), totalToSend)
                            //.SendFees(Money.Coins(0.0001m))
                            .SetChange(buyerWallet.GetAddress())
                            .BuildTransaction(true);
                        //Assert(txBuilder.Verify(tx)); //check fully signed

                        // get coin from buyer to sent for seller
                        Coin[] sellerCoins = tx.Outputs.Select((o, i) => new Coin(new OutPoint(tx.GetHash(), i), o)).ToArray();

                        string totalSend = "";
                        foreach (var item in sellerCoins)
                        {
                            totalSend += item.TxOut.Value.ToString();
                        }

                        getSeller.BalanceAmount = getSeller.BalanceAmount + Decimal.Parse(totalSend);
                        getBuyer.BalanceAmount = getBuyer.BalanceAmount + getSeller.BalanceAmountTransaction;
                        getSeller.BalanceAmountTransaction = 0;

                        walletDataAccess.CreateWalletTransaction(getSeller, getBuyer);

                        // remove order transaction
                        orderDataAccess.RemoveOrder(order);
                    }
                }
            }
            else // buy
            {
                // noi xay ra giao dich tai day
                var getBuyer = walletDataAccess.FindWalletByAccountID(Buyer);
                var getSeller = walletDataAccess.FindWalletByAccountID(Seller);

                BitcoinSecret buyerWallet = new BitcoinSecret(getBuyer.PrivateKey);
                BitcoinSecret sellerWallet = new BitcoinSecret(getSeller.PrivateKey);

                if (getSeller != null && getBuyer != null)
                {
                    // check balance amount enough to perform buy action
                    if (getSeller.BalanceAmount > amountTransaction)
                    {
                        var buyerSubtract = getSeller.BalanceAmount - amountTransaction;
                        // trich quy ra de mua
                        Transaction buyerFunding = new Transaction()
                        {
                            Outputs =   {
                            new TxOut(amountTransaction.ToString(), buyerWallet.GetAddress())
                        }
                        };

                        getSeller.BalanceAmount = buyerSubtract; // trich xong roi add phan con lai vao balanaceamount

                        Coin[] buyerCoins = buyerFunding
                                            .Outputs
                                            .Select((o, i) => new Coin(new OutPoint(buyerFunding.GetHash(), i), o))
                                            .ToArray();

                        string totalToSend = "";
                        foreach (var item in buyerCoins)
                        {
                            totalToSend += item.TxOut.Value.ToString();
                        }

                        Money fee = new Money(100);

                        // construct transaction
                        // chuyen cho nguoi ban
                        TransactionBuilder txBuilder = new TransactionBuilder();
                        var tx = txBuilder
                            .AddCoins(buyerCoins)
                            .AddKeys(buyerWallet.PrivateKey)
                            .Send(sellerWallet.GetAddress(), totalToSend)
                            //.SendFees(Money.Coins(0.0001m))
                            .SetChange(buyerWallet.GetAddress())
                            .BuildTransaction(true);
                        //Assert(txBuilder.Verify(tx)); //check fully signed

                        // get coin from buyer to sent for seller
                        Coin[] sellerCoins = tx.Outputs.Select((o, i) => new Coin(new OutPoint(tx.GetHash(), i), o)).ToArray();

                        string totalSend = "";
                        foreach (var item in sellerCoins)
                        {
                            totalSend += item.TxOut.Value.ToString();
                        }

                        getBuyer.BalanceAmount = getBuyer.BalanceAmount + Decimal.Parse(totalSend);
                        getSeller.BalanceAmount = getSeller.BalanceAmount + getSeller.BalanceAmountTransaction;
                        getBuyer.BalanceAmountTransaction = 0;

                        walletDataAccess.CreateWalletTransaction(getSeller, getSeller);

                        // remove order transaction
                        orderDataAccess.RemoveOrder(order);
                    }
                }
            }
        }

        public void CreateBuyTransactionNoComplex(Guid Seller, Guid Buyer, decimal amountWantToBuy)
        {
            // noi xay ra giao dich tai day
            var getBuyer = walletDataAccess.FindWalletByAccountID(Buyer);
            var getSeller = walletDataAccess.FindWalletByAccountID(Seller);

            if (getBuyer != null && getSeller != null)
            {
                // check balance amount enough to perform buy action
                if (getBuyer.BalanceAmount > amountWantToBuy)
                {
                    var buyerSubtract = getBuyer.BalanceAmount - amountWantToBuy;
                    getBuyer.BalanceAmount = buyerSubtract;

                    // tru fee
                    var amountSellerGet = amountWantToBuy - ExchangeRateConstant.Fees;
                    getSeller.BalanceAmount += amountSellerGet;

                    walletDataAccess.CreateWalletTransaction(getSeller, getBuyer);

                    // remove order
                    var orderToRemove = orderDataAccess.FindOrderByWalletID(getSeller.WalletID); // find by walletId
                    if (orderToRemove != null)
                    {
                        orderDataAccess.RemoveOrder(orderToRemove);
                    }
                }
            }
        }

        public List<Order> GetOrdersByAmount(decimal amountSearch)
        {
            return orderDataAccess.GetOrdersByAmount(amountSearch);
        }

        public void CreateSellTransactionNoComplex(Guid Seller, Guid Buyer, decimal amountWantToBuy)
        {
            // noi xay ra giao dich tai day
            var getBuyer = walletDataAccess.FindWalletByAccountID(Buyer); // get wallet buyer
            var getSeller = walletDataAccess.FindWalletByAccountID(Seller); // get wallet seller

            if (getBuyer != null && getSeller != null)
            {
                // check balance amount enough to perform buy action
                if (getBuyer.BalanceAmount > amountWantToBuy)
                {
                    var buyerSubtract = getBuyer.BalanceAmount - amountWantToBuy;
                    getBuyer.BalanceAmount = buyerSubtract;

                    // tru fee
                    var amountSellerGet = amountWantToBuy - ExchangeRateConstant.Fees;
                    getSeller.BalanceAmount += amountSellerGet;

                    walletDataAccess.CreateWalletTransaction(getSeller, getBuyer);

                    // remove order
                    var orderToRemove = orderDataAccess.FindOrderByWalletID(getSeller.WalletID); // find by walletId
                    if (orderToRemove != null)
                    {
                        orderDataAccess.RemoveOrder(orderToRemove);
                    }
                }
            }
        }

        public void CreateOrderTransaction(Order order)
        {
            if (order != null)
            {
                orderDataAccess.CreateOrder(order);
            }
        }

        private void Assert(bool value)
        {
            if (!value)
                throw new Exception("Bug");
        }

    }
}

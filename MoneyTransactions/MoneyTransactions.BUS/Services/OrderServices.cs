using MoneyTransactions.Common;
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
        private CryptocurrencyStoreServices cryptocurrencyStoreServices;

        public OrderServices()
        {
            orderDataAccess = new OrderDataAccess();
            walletDataAccess = new WalletDataAccess();
            walletServices = new WalletServices();
            cryptocurrencyStoreServices = new CryptocurrencyStoreServices();
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

        public bool CreateBuyTransactionNoComplex(Guid Seller, Guid Buyer, decimal amountWantToBuy, Order order)
        {
            // getSeller dang qc ban 1 luong money
            // getBuyer muon mua
            if (order.OrderType == OrderCommon.OrderSell) // Sell
            {
                // noi xay ra giao dich tai day
                var getBuyer = walletDataAccess.FindWalletByMoneyType(Buyer, order.Wallet.CryptocurrencyStore.MoneyType);
                var getSeller = walletDataAccess.FindWalletByMoneyType(Seller, order.Wallet.CryptocurrencyStore.MoneyType);

                if (getBuyer != null && getSeller != null)
                {
                    // check balance amount enough to perform buy action                    
                    if (getBuyer.BalanceAmount > amountWantToBuy)
                    {

                        // nguoi mua se co 2 thu
                        // 1. cong bitcoin vao vi bitcoin
                        getBuyer.BalanceAmount += amountWantToBuy;

                        // 2. tru tien vnd vao buyer
                        var buyerVietNamDong = walletDataAccess.FindWalletByAccountAndMoneyType(Buyer, CryptoCurrencyCommon.VietnamDong);
                        buyerVietNamDong.BalanceAmount -= (amountWantToBuy * cryptocurrencyStoreServices.ShowFloorPrice(order.Wallet.CryptocurrencyStore.MoneyType));

                        // seller se duoc cong tien vnd vao vi
                        var sellerVietNamDong = walletDataAccess.FindWalletByAccountAndMoneyType(Seller, CryptoCurrencyCommon.VietnamDong);
                        sellerVietNamDong.BalanceAmount += (amountWantToBuy * cryptocurrencyStoreServices.ShowFloorPrice(order.Wallet.CryptocurrencyStore.MoneyType));

                        walletDataAccess.CreateWalletTransaction(sellerVietNamDong, buyerVietNamDong);
                        walletDataAccess.CreateWalletTransaction(getSeller, getBuyer);

                        // remove order                        
                        orderDataAccess.RemoveOrder(order);
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                return true;
            }
        }

        public List<Order> GetOrdersByAmount(decimal amountSearch)
        {
            return orderDataAccess.GetOrdersByAmount(amountSearch);
        }

        public bool CreateSellTransactionNoComplex(Guid Seller, Guid Buyer, decimal amountWantToSell, Order order)
        {
            // getBuyer dang qc mua 1 luong money
            // getSeller muon ban
            if (order.OrderType == OrderCommon.OrderBuy) // Buy
            {
                // noi xay ra giao dich tai day
                var getBuyer = walletDataAccess.FindWalletByMoneyType(Buyer, order.Wallet.CryptocurrencyStore.MoneyType);
                var getSeller = walletDataAccess.FindWalletByMoneyType(Seller, order.Wallet.CryptocurrencyStore.MoneyType);

                // check balance amount enough to perform buy action                    
                if (getSeller.BalanceAmount > amountWantToSell)
                {
                    // nguoi mua se co 2 thu
                    // 1. cong bitcoin vao vi bitcoin
                    getBuyer.BalanceAmount += amountWantToSell;
                    getSeller.BalanceAmount -= amountWantToSell;

                    // 2. tru tien vnd vao nguoi mua
                    var buyerVietNamDong = walletDataAccess.FindWalletByAccountAndMoneyType(Buyer, CryptoCurrencyCommon.VietnamDong);
                    buyerVietNamDong.BalanceAmount -= (amountWantToSell * cryptocurrencyStoreServices.ShowFloorPrice(order.Wallet.CryptocurrencyStore.MoneyType));

                    // seller se duoc cong vao tien vnd
                    var sellerVietNamDong = walletDataAccess.FindWalletByAccountAndMoneyType(Seller, CryptoCurrencyCommon.VietnamDong);
                    sellerVietNamDong.BalanceAmount += (amountWantToSell * cryptocurrencyStoreServices.ShowFloorPrice(order.Wallet.CryptocurrencyStore.MoneyType));

                    walletDataAccess.CreateWalletTransaction(sellerVietNamDong, buyerVietNamDong);
                    walletDataAccess.CreateWalletTransaction(getSeller, getBuyer);

                    // remove order                        
                    orderDataAccess.RemoveOrder(order);
                }
                else
                {
                    return false;
                }

                return true;
            }
            else
            {
                return false;
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

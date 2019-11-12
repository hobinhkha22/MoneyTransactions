using MoneyTransactions.BUS.Interface;
using MoneyTransactions.Common;
using MoneyTransactions.DAL;
using NBitcoin;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTransactions.BUS.Services
{
    public class OrderServices : IOrderServices
    {
        private readonly MoneyTransactionsDataContext db;
        private WalletServices walletServices;

        public OrderServices()
        {
            db = new MoneyTransactionsDataContext();
            walletServices = new WalletServices();
        }

        [Obsolete]
        void IOrderServices.CreateSellTransaction(Guid accountID, string privateKeySeller, decimal amountWantToSell)
        {
            BitcoinSecret SellerWallet;

            var getPrivateKeySeller = db.Wallets.FirstOrDefault(p => p.PrivateKey == privateKeySeller);
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
                newOrderForSeller.AccountID = accountID;
                newOrderForSeller.Amount = amountWantToSell; // here
                newOrderForSeller.AmountBought = 0;
                newOrderForSeller.CreatedDate = DateTimeOffset.Now;
                newOrderForSeller.ModifiedDate = DateTimeOffset.Now;
                newOrderForSeller.OrderType = OrderCommon.OrderSell;
                db.Orders.InsertOnSubmit(newOrderForSeller);
                db.SubmitChanges(); // change data
            }
            else
            {
                throw new Exception("Can't get object");
            }
        }

        public List<Order> ShowRecentTransaction()
        {
            return db.Orders.ToList();
        }

        [Obsolete]
        public void CreateBuyTransaction(Guid Seller, Guid Buyer, decimal amountWantToBuy)
        {
            // noi xay ra giao dich tai day
            var getBuyer = db.Wallets.FirstOrDefault(b => b.AccountID == Buyer);
            var getSeller = db.Wallets.FirstOrDefault(b => b.AccountID == Seller);

            BitcoinSecret buyerWallet = new BitcoinSecret(getBuyer.PrivateKey);
            BitcoinSecret sellerWallet = new BitcoinSecret(getSeller.PrivateKey);

            if (getBuyer != null && getSeller != null)
            {
                // check balance amount enough to perform buy action
                if (getBuyer.BalanceAmount > amountWantToBuy)
                {
                    var buyerSubtract = getBuyer.BalanceAmount - amountWantToBuy;
                    // trich quy ra de mua
                    Transaction buyerFunding = new Transaction()
                    {
                        Outputs =   {
                            new TxOut(buyerSubtract.ToString(), buyerWallet.GetAddress())
                        }
                    };

                    Coin[] buyerCoins = buyerFunding
                                        .Outputs
                                        .Select((o, i) => new Coin(new OutPoint(buyerFunding.GetHash(), i), o))
                                        .ToArray();

                    string totalToSend = "";
                    foreach (var item in buyerCoins)
                    {
                        totalToSend += item.TxOut.Value.ToString();
                    }

                    // construct transaction
                    TransactionBuilder txBuilder = new TransactionBuilder();
                    var tx = txBuilder
                        .AddCoins(buyerCoins)
                        .AddKeys(buyerWallet.PrivateKey)
                        .Send(sellerWallet.GetAddress(), totalToSend)
                        .SendFees("0.001")
                        .SetChange(buyerWallet.GetAddress())
                        .BuildTransaction(true);
                    Assert(txBuilder.Verify(tx)); //check fully signed

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

                    db.SubmitChanges();
                }
            }
        }
        private void Assert(bool value)
        {
            if (!value)
                throw new Exception("Bug");
        }

    }
}

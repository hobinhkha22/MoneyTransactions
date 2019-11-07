using MoneyTransactions.BUS.Interface;
using MoneyTransactions.BUS.Models;
using MoneyTransactions.DAL;
using NBitcoin;
using QBitNinja.Client;
using QBitNinja.Client.Models;
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

        public void CreateTransaction(Guid guid, decimal amount, decimal amountBought)
        {
            //var getAccountWallet = db.Wallets.FirstOrDefault(w => w.AccountID == guid);
            //var secret = new BitcoinSecret(getAccountWallet.PrivateKey);

            #region Consume transaction ID
            // Create a client
            QBitNinjaClient client = new QBitNinjaClient(Network.Main);
            // Parse transaction id to NBitcoin.uint256 so the client can eat it
            var transactionId = uint256.Parse("f13dc48fb035bbf0a6e989a26b3ecb57b84f85e0836e777d6edf60d87a4a2d94");
            // Query the transaction
            GetTransactionResponse transactionResponse = client.GetTransaction(transactionId).Result;
            #endregion

            #region transactionResponse is GetTransactionResponse

            NBitcoin.Transaction transaction = transactionResponse.Transaction;
            #endregion

            #region Put bitcoin into bitcoin address - this is output part
            List<ICoin> receivedCoins = transactionResponse.ReceivedCoins; // get coin
            foreach (var coin in receivedCoins)
            {
                Money amounts = coin.Amount as Money;

                Debug.WriteLine(amounts.ToDecimal(MoneyUnit.BTC)); // 100 milion satoshi
                var paymentScript = coin.TxOut.ScriptPubKey; // scriptpubkey giống như sổ đỏ
                Debug.WriteLine(paymentScript);  // It's the ScriptPubKey
                var address = paymentScript.GetDestinationAddress(Network.Main);
                Debug.WriteLine(address); // 1HfbwN6Lvma9eDsv7mdwp529tgiyfNr7jc                
            }
            #endregion

            #region Put bitcoin into bitcoin address  with NBitcoin.Transaction class - this is output part
            var outputs = transaction.Outputs;
            foreach (TxOut output in outputs)
            {
                Money amounts = output.Value;
                
                Debug.WriteLine(amounts.ToDecimal(MoneyUnit.BTC));
                var paymentScript = output.ScriptPubKey;                
                Console.WriteLine(paymentScript);  // It's the ScriptPubKey
                var address = paymentScript.GetDestinationAddress(Network.Main);
                Debug.WriteLine(address);                
            }
            #endregion

            #region input part - see previous part
            var inputs = transaction.Inputs;
            foreach (TxIn input in inputs)
            {
                OutPoint previousOutpoint = input.PrevOut;
                Debug.WriteLine(previousOutpoint.Hash); // hash of prev tx
                Debug.WriteLine(previousOutpoint.N); // idx of out from prev tx, that has been spent in the current tx                
            }
            #endregion

            #region create 21 bitcoin
            Money twentyOneBtc = new Money(21, MoneyUnit.BTC);
            var scriptPubKey = transaction.Outputs[0].ScriptPubKey;
            TxOut txOut = new TxOut(twentyOneBtc, scriptPubKey);
            #endregion

            #region Outpoint - including transactionId and its index
            OutPoint firstOutPoint = receivedCoins[0].Outpoint;
            Debug.WriteLine(firstOutPoint.Hash); // f13dc48fb035bbf0a6e989a26b3ecb57b84f85e0836e777d6edf60d87a4a2d94
            Debug.WriteLine(firstOutPoint.N); // 0
            #endregion

        }

        public List<DAL.Order> ShowRecentTransaction()
        {
            return db.Orders.ToList();
        }
    }
}

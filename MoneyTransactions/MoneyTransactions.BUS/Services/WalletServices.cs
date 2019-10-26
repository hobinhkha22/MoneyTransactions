using MoneyTransactions.BUS.Interface;
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
    public class WalletServices : IWallet
    {
        private readonly MoneyTransactionsDataContext db;


        public WalletServices()
        {
            db = new MoneyTransactionsDataContext();
        }

        public void CreateWallet(Guid AccountId)
        {
            Key privateKey = new Key(); // generate a random private key
            BitcoinSecret mainNetPrivateKey = privateKey.GetBitcoinSecret(Network.Main);  // get our private key for the mainnet            
                                                                                          //Debug.WriteLine(mainNetPrivateKey); // L5B67zvrndS5c71EjkrTJZ99UaoVbMUAK58GKdQUfYCpAa6jypvn            

            //BitcoinSecret bitcoinPrivateKey = privateKey.GetWif(Network.Main); // L5B67zvrndS5c71EjkrTJZ99UaoVbMUAK58GKdQUfYCpAa6jypvn
            //Key samePrivateKey = bitcoinPrivateKey.PrivateKey;

            PubKey publicKey = privateKey.PubKey;
            //BitcoinPubKeyAddress bitcoinPubicKey = publicKey.GetAddress(Network.Main); // 1PUYsjwfNmX64wS368ZR5FMouTtUmvtmTY

            Wallet wallet = new Wallet
            {
                AccountID = AccountId,
                WalletAddress = publicKey.GetAddress(Network.Main).ToString()
            };

            db.Wallets.InsertOnSubmit(wallet);
            db.SubmitChanges();
        }

        public bool UpdateWallet()
        {
            throw new NotImplementedException();
        }
    }
}

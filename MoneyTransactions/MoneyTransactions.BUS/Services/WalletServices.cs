using MoneyTransactions.BUS.Interface;
using NBitcoin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTransactions.BUS.Services
{
    public class WalletServices : IWallet
    {
        public void CreateWallet(Guid Id)
        {
            Key privateKey = new Key(); // generate a random private key
            BitcoinSecret mainNetPrivateKey = privateKey.GetBitcoinSecret(Network.Main);  // get our private key for the mainnet
            BitcoinSecret testNetPrivateKey = privateKey.GetBitcoinSecret(Network.TestNet);  // get our private key for the testnet
            Console.WriteLine(mainNetPrivateKey); // L5B67zvrndS5c71EjkrTJZ99UaoVbMUAK58GKdQUfYCpAa6jypvn
            Console.WriteLine(testNetPrivateKey); // cVY5auviDh8LmYUW8AfafseD6p6uFoZrP7GjS3rzAerpRKE9Wmuz

            bool WifIsBitcoinSecret = mainNetPrivateKey == privateKey.GetWif(Network.Main);
            Console.WriteLine(WifIsBitcoinSecret); // True


            BitcoinSecret bitcoinPrivateKey = privateKey.GetWif(Network.Main); // L5B67zvrndS5c71EjkrTJZ99UaoVbMUAK58GKdQUfYCpAa6jypvn
            Key samePrivateKey = bitcoinPrivateKey.PrivateKey;

            PubKey publicKey = privateKey.PubKey;
            BitcoinPubKeyAddress bitcoinPubicKey = publicKey.GetAddress(Network.Main); // 1PUYsjwfNmX64wS368ZR5FMouTtUmvtmTY
            //PubKey samePublicKey = bitcoinPubicKey.ItIsNotPossible;
        }

        public bool UpdateWallet()
        {
            throw new NotImplementedException();
        }
    }
}

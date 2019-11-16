using MoneyTransactions.Common;
using MoneyTransactions.DAL.Implement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTransactions.BUS.Services
{
    public class CryptocurrencyStoreServices
    {
        private readonly CryptocurrencyStoreDataAccess cryptocurrencyStoreDataAccess;

        public CryptocurrencyStoreServices()
        {
            cryptocurrencyStoreDataAccess = new CryptocurrencyStoreDataAccess();
        }

        public decimal ShowFloorPrice(string moneyType)
        {
            if (moneyType.ToLower() == CryptoCurrencyCommon.BitcointDescription.ToLower())
            {
                return cryptocurrencyStoreDataAccess.GetCryptocurrencyStoreByMoneyType(CryptoCurrencyCommon.Bitcoin).FloorPrice;
            }
            else if (moneyType.ToLower() == CryptoCurrencyCommon.EthereumDescription.ToLower())
            {
                return cryptocurrencyStoreDataAccess.GetCryptocurrencyStoreByMoneyType(CryptoCurrencyCommon.Ethereum).FloorPrice;
            }
            else if (moneyType.ToLower() == CryptoCurrencyCommon.RippleDescription.ToLower())
            {
                return cryptocurrencyStoreDataAccess.GetCryptocurrencyStoreByMoneyType(CryptoCurrencyCommon.Ripple).FloorPrice;
            }
            else
            {
                return cryptocurrencyStoreDataAccess.GetCryptocurrencyStoreByMoneyType(CryptoCurrencyCommon.VietnamDong).FloorPrice;
            }
        }
    }
}

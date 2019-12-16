using MoneyTransactions.Common;
using MoneyTransactions.DAL.Implement;
using MoneyTransactions.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyTransactions.BUS.Services
{
    public class BankServices
    {
        private BankDataAccess bankDataAccess;
        private WalletDataAccess WalletDataAccess;

        public BankServices()
        {
            bankDataAccess = new BankDataAccess();
            WalletDataAccess = new WalletDataAccess();
        }

        public bool NapTien(Wallet wallet, decimal luongNapTien)
        {
            // Scenario:
            // user trong muon nap tien tu bank ngoai vao
            // get object bank tu ngoai vao
            // va check so tien bank ngoai neu du yeu cau thi nap vao vi [findWallet]
            //var findAccountInside = acc acc(account.AccountID);
            var findWalletInside = WalletDataAccess.FindWalletByWalletID(wallet.WalletID);

            if (findWalletInside != null)
            {
                // check so tien bank ngoai
                //if (findWalletInside.BalanceAmount > luongNapTien)
                //{
                //findBankOutside.VietNamDong -= luongNapTien; // tru vao bank ngoai
                findWalletInside.BalanceAmount += luongNapTien; // cong vao wallet trong dua theo moneyType
                bankDataAccess.NapTien(wallet);

                return true;
            }
            else
            {
                return true;
            }
        }

        public bool RutTien(WalletOutside walletOutside, Wallet wallet, decimal luongRutTien, string moneyType)
        {
            // Scenario:
            // user trong muon rut tien tu trong wallet trong ra bank ngoai
            // get object wallet trong
            // get object bank ngoai de rut tien ra
            // va check so tien wallet trong co du de rut
            var findWalletOutSide = WalletDataAccess.FindWalletOutSideByWalletOutSideID(walletOutside.WalletOutsideID);
            var findWalletInside = WalletDataAccess.FindWalletByWalletID(wallet.WalletID);

            if (findWalletOutSide != null && findWalletInside != null)
            {
                if (findWalletInside.CryptocurrencyStore.MoneyType == CryptoCurrencyCommon.Bitcoin)
                {
                    if (findWalletInside.BalanceAmount > luongRutTien)
                    {
                        findWalletInside.BalanceAmount -= luongRutTien; // tru tien wallet trong
                        findWalletOutSide.BTC += luongRutTien; // cong vao bank ngoai
                        bankDataAccess.RutTien(findWalletOutSide, findWalletInside, findWalletInside.CryptocurrencyStore.MoneyType);

                        return true;
                    }
                }

                if (findWalletInside.CryptocurrencyStore.MoneyType == CryptoCurrencyCommon.Ethereum)
                {
                    findWalletInside.BalanceAmount -= luongRutTien; // tru tien wallet trong
                    findWalletOutSide.ETH += luongRutTien; // cong vao bank ngoai
                    bankDataAccess.RutTien(findWalletOutSide, findWalletInside, findWalletInside.CryptocurrencyStore.MoneyType);

                    return true;
                }

                if (findWalletInside.CryptocurrencyStore.MoneyType == CryptoCurrencyCommon.Ripple)
                {
                    findWalletInside.BalanceAmount -= luongRutTien; // tru tien wallet trong
                    findWalletOutSide.XRP += luongRutTien; // cong vao bank ngoai
                    bankDataAccess.RutTien(findWalletOutSide, findWalletInside, findWalletInside.CryptocurrencyStore.MoneyType);

                    return true;
                }

                if (findWalletInside.CryptocurrencyStore.MoneyType == CryptoCurrencyCommon.VietnamDong)
                {
                    findWalletInside.BalanceAmount -= luongRutTien; // tru tien wallet trong
                    findWalletOutSide.VND += luongRutTien; // cong vao bank ngoai
                    bankDataAccess.RutTien(findWalletOutSide, findWalletInside, findWalletInside.CryptocurrencyStore.MoneyType);

                    return true;
                }
            }

            return false;
        }

        public AccountBankDetail FindAccountBankDetailByAccountID(Guid accountID)
        {
            return bankDataAccess.FindAccountBankDetailByAccountID(accountID);
        }
    }
}

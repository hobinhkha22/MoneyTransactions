﻿using MoneyTransactions.DAL.Implement;
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

        public bool NapTien(Account account, Wallet wallet, decimal luongNapTien)
        {
            // Scenario:
            // user trong muon nap tien tu bank ngoai vao
            // get object bank tu ngoai vao
            // va check so tien bank ngoai neu du yeu cau thi nap vao vi [findWallet]
            var findBankOutside = bankDataAccess.FindBankOutside(account.AccountID);
            var findWalletInside = WalletDataAccess.FindWalletByWalletID(wallet.WalletID);

            if (findBankOutside != null && findWalletInside != null)
            {
                // check so tien bank ngoai
                if (findBankOutside.VietNamDong > luongNapTien)
                {
                    findBankOutside.VietNamDong -= luongNapTien; // tru vao bank ngoai
                    findWalletInside.BalanceAmount += luongNapTien; // cong vao wallet trong dua theo moneyType
                    bankDataAccess.NapTien(account, wallet, luongNapTien);

                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        public bool RutTien(Account account, Wallet wallet, decimal luongRutTien)
        {
            // Scenario:
            // user trong muon rut tien tu trong wallet trong ra bank ngoai
            // get object wallet trong
            // get object bank ngoai de rut tien ra
            // va check so tien wallet trong co du de rut
            var findBankOutside = bankDataAccess.FindBankOutside(account.AccountID);
            var findWalletInside = WalletDataAccess.FindWalletByWalletID(wallet.WalletID);

            if (findBankOutside != null && findWalletInside != null)
            {
                // check so tien bank ngoai
                if (findWalletInside.BalanceAmount > luongRutTien)
                {
                    findWalletInside.BalanceAmount -= luongRutTien; // tru tien wallet trong
                    findBankOutside.VietNamDong += luongRutTien; // cong vao bank ngoai
                    bankDataAccess.RutTien(account, wallet, luongRutTien);

                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        public AccountBankDetail FindAccountBankDetailByAccountID(Guid accountID)
        {
            return bankDataAccess.FindAccountBankDetailByAccountID(accountID);
        }
    }
}

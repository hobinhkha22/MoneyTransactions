rem 1. RoleData
sqlcmd -U sa -P hello@world22 -d MoneyTransactions -S BLUE -i "E:\HOC_DH\KI-CUOI-CUNG\DO-AN-TOT-NGHIEP\MoneyTransactions\MoneyTransactions\MoneyTransactions.Web\Data\RoleData.sql"

rem 2. Account
sqlcmd -U sa -P hello@world22 -d MoneyTransactions -S BLUE -i "E:\HOC_DH\KI-CUOI-CUNG\DO-AN-TOT-NGHIEP\MoneyTransactions\MoneyTransactions\MoneyTransactions.Web\Data\Account.sql"

rem 3. Bank
sqlcmd -U sa -P hello@world22 -d MoneyTransactions -S BLUE -i "E:\HOC_DH\KI-CUOI-CUNG\DO-AN-TOT-NGHIEP\MoneyTransactions\MoneyTransactions\MoneyTransactions.Web\Data\BankData.sql"

rem 4. AccountBankDetailData
sqlcmd -U sa -P hello@world22 -d MoneyTransactions -S BLUE -i "E:\HOC_DH\KI-CUOI-CUNG\DO-AN-TOT-NGHIEP\MoneyTransactions\MoneyTransactions\MoneyTransactions.Web\Data\AccountBankDetailData.sql"

rem 5. CryptoCurrencyStoreData
sqlcmd -U sa -P hello@world22 -d MoneyTransactions -S BLUE -i "E:\HOC_DH\KI-CUOI-CUNG\DO-AN-TOT-NGHIEP\MoneyTransactions\MoneyTransactions\MoneyTransactions.Web\Data\CryptoCurrencyStoreData.sql"

rem 6. WalletData
sqlcmd -U sa -P hello@world22 -d MoneyTransactions -S BLUE -i "E:\HOC_DH\KI-CUOI-CUNG\DO-AN-TOT-NGHIEP\MoneyTransactions\MoneyTransactions\MoneyTransactions.Web\Data\WalletData.sql"

rem 7. OrderData
sqlcmd -U sa -P hello@world22 -d MoneyTransactions -S BLUE -i "E:\HOC_DH\KI-CUOI-CUNG\DO-AN-TOT-NGHIEP\MoneyTransactions\MoneyTransactions\MoneyTransactions.Web\Data\OrderData.sql"

rem 8. OrderDetailData
sqlcmd -U sa -P hello@world22 -d MoneyTransactions -S BLUE -i "E:\HOC_DH\KI-CUOI-CUNG\DO-AN-TOT-NGHIEP\MoneyTransactions\MoneyTransactions\MoneyTransactions.Web\Data\OrderDetailData.sql"
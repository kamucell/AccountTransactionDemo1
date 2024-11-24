﻿using BankAccountManagementSystem.Audit;
using BankAccountManagementSystem.Exceptions;
using BankAccountManagementSystem.LockDown;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccountManagementSystem.Account
{
    public abstract class BaseAccount : IAccount
    {
        private bool _isLocked = false;
        protected int _accountNumber { get; }
        public int AccountNumber => _accountNumber;
        protected decimal _balance;
        private ITransactionAudit _transactionAudit;
        private   ILockDownManager _lockDownManager;

        public decimal Balance => _balance;
        
        public decimal OverdraftLimit { get; set; }

        public BaseAccount(int accountNumber )    {
            if (accountNumber <= 0)
                throw new BankAccountManagementSystemException("Account number is invalid");

            _accountNumber=accountNumber;
            
     
        }

        public void SetAudit(ITransactionAudit transactionAudit) =>            _transactionAudit = transactionAudit;
        public void SetLock(ILockDownManager lockDownManager) {
            _lockDownManager = lockDownManager;
            _lockDownManager.LockDownStarted += (sender,evnt)=>_isLocked=true;
            _lockDownManager.LockDownEnded += (sender, evnt) => _isLocked = false;
        }

        

        public   async Task<bool> IsRequestedAmountHighrThanZero(decimal requestedAmount) =>  (requestedAmount > 0);
 

        public async   Task DepositAsync(decimal amount)
        {
            if (_isLocked)
                throw new BankAccountManagementSystem.Exceptions.UnauthorizedAccountOperationException("Account has been locked");
                 
            if(!   await IsRequestedAmountHighrThanZero(amount)) 
                    throw new BankAccountManagementSystem.Exceptions.AmountLessThanZero();
              
            _balance += amount;
            await _transactionAudit.WriteTransactionAsync(new Transaction()
            {
                AccountId = _accountNumber,
                Amount = amount,
                Balance = _balance,
                TransactionType = TransactionType.Deposit,
            });

        }

        public async virtual Task WithdrawAsync(decimal amount)
        {
            if (_isLocked)
                throw new BankAccountManagementSystem.Exceptions.UnauthorizedAccountOperationException("Account has been locked");

            if (!await IsRequestedAmountHighrThanZero(amount))
                throw new BankAccountManagementSystem.Exceptions.AmountLessThanZero();

            _balance -= amount;
            await _transactionAudit?.WriteTransactionAsync(new Transaction()
            {
                AccountId = _accountNumber,
                Amount = amount,
                Balance = _balance,
                TransactionType = TransactionType.Withdraw,
            });
        }

       
    }
}

using CoreWCF;
using System.Collections.Generic;

namespace BankCoreWCF.Services
{
    [ServiceContract]
    public interface IBankService
    {
        [OperationContract]
        List<string> GetAccounts(string clientId);

        [OperationContract]
        List<string> GetTransactions(string accountId);

        [OperationContract]
        List<string> GetAllClients();

        [OperationContract]
        bool BlockAccount(string accountId);

        [OperationContract]
        bool UnblockAccount(string accountId);
    }

    public class BankService : IBankService
    {
        private static Dictionary<string, List<string>> clientAccounts = new Dictionary<string, List<string>>()
        {
            { "client1", new List<string>{ "acc1", "acc2" } },
            { "client2", new List<string>{ "acc3" } }
        };

        private static Dictionary<string, bool> accountStatus = new Dictionary<string, bool>()
        {
            { "acc1", true }, { "acc2", true }, { "acc3", true }
        };

        private static Dictionary<string, List<string>> transactions = new Dictionary<string, List<string>>()
        {
            { "acc1", new List<string>{ "deposit 100", "withdraw 50" } },
            { "acc2", new List<string>{ "deposit 200" } },
            { "acc3", new List<string>{ "deposit 300" } }
        };

        public List<string> GetAccounts(string clientId)
        {
            return clientAccounts.ContainsKey(clientId) ? clientAccounts[clientId] : new List<string>();
        }

        public List<string> GetTransactions(string accountId)
        {
            return transactions.ContainsKey(accountId) ? transactions[accountId] : new List<string>();
        }

        public List<string> GetAllClients()
        {
            return new List<string>(clientAccounts.Keys);
        }

        public bool BlockAccount(string accountId)
        {
            if (accountStatus.ContainsKey(accountId))
            {
                accountStatus[accountId] = false;
                return true;
            }
            return false;
        }

        public bool UnblockAccount(string accountId)
        {
            if (accountStatus.ContainsKey(accountId))
            {
                accountStatus[accountId] = true;
                return true;
            }
            return false;
        }
    }
}
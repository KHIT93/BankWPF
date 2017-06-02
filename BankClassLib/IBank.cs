using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Web;

namespace BankClassLib
{
    [ServiceContract]
    interface IBank
    {
        string Status();
        [WebInvoke(Method="POST", UriTemplate="CreateAccount", ResponseFormat=WebMessageFormat.Json, RequestFormat=WebMessageFormat.Json, BodyStyle=WebMessageBodyStyle.WrappedRequest)]
        [OperationContract]
        string CreateAccount(string name, AccountType accountType, double balance = 0);

        [WebInvoke(Method = "DELETE", UriTemplate = "DeleteAccount", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        string DeleteAccount(int accountNumber);

        [WebInvoke(Method = "PUT", UriTemplate = "PeformTransaction", ResponseFormat = WebMessageFormat.Json, RequestFormat=WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        [OperationContract]
        string Transaction(double amount, int accountNumber);

        [WebGet(UriTemplate = "AccountBalance/{accountNumber}", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        string BalanceFromString(string accountNumber);

        [WebGet(UriTemplate = "Account/{accountNumber}", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedResponse)]
        [OperationContract]
        Account GetAccountFromString(string accountNumber);

        [WebGet(UriTemplate = "Accounts", ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.WrappedResponse)]
        [OperationContract]
        List<Account> GetAccounts();

        [WebGet(UriTemplate = "AddInterest", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        string AddInterest();
    }
}

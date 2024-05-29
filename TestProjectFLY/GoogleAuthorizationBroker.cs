using Google.Apis.Auth.OAuth2;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectFLY
{
    public class GoogleAuthorizationBroker : IGoogleAuthorizationBroker
    {
        public Task<UserCredential> AuthorizeAsync(ClientSecrets clientSecrets, IEnumerable<string> scopes, string user, CancellationToken taskCancellationToken, IDataStore dataStore)
        {
            return GoogleWebAuthorizationBroker.AuthorizeAsync(clientSecrets, scopes, user, taskCancellationToken, dataStore);
        }
    }
}

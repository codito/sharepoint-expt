using System;
using System.Net;
using System.Security;
using Microsoft.SharePoint.Client;
using Microsoft.SharePoint.Client.Taxonomy;

namespace csom
{
    public class CsomExample
    {
        private readonly string remoteAddress;
        private ICredentials credentials;

        public CsomExample()
        {
            // TODO: Update setting based on target
            this.remoteAddress = "http://armahapa-srv";

            // TODO: Environment variables may be set based on target
            // var cred = new NetworkCredential(Environment.GetEnvironmentVariable("CSOM_USER"), Environment.GetEnvironmentVariable("CSOM_PASS"), Environment.GetEnvironmentVariable("CSOM_DOM"));
            // this.credentials = cred; // on-premise
            // this.credentials = new SharePointOnlineCredentials(Environment.GetEnvironmentVariable("CSOM_USER"), cred.SecurePassword);
            this.credentials = CredentialCache.DefaultNetworkCredentials;
        }

        public void GetTermSets()
        {
            // ClientContext wraps a server request
            // ClientContext.Load modifies the request to query specific data
            // ClientContext.ExecuteQuery actually sends the request to server
            using (var clientContext = new ClientContext(this.remoteAddress))
            {
                // Setup auth
                clientContext.AuthenticationMode = ClientAuthenticationMode.Default;
                clientContext.Credentials = this.credentials;

                var session = TaxonomySession.GetTaxonomySession(clientContext);
                var termStore = session.GetDefaultSiteCollectionTermStore();

                // Approach 1: query with Load and specific properties
                clientContext.Load(termStore, ts => ts.Name, ts => ts.Groups.Include(g => g.Name, g => g.TermSets.Include(t => t.Name, t => t.Terms.Include(i => i.Name))));
                clientContext.ExecuteQuery();

                foreach (var group in termStore.Groups)
                {
                    foreach (var ts in group.TermSets)
                    {
                        System.Console.WriteLine("Term Set: {0}", ts.Name);
                        foreach (var term in ts.Terms)
                        {
                            System.Console.WriteLine(" Term: {0}", term.Name);
                        }
                    }
                }
                System.Console.WriteLine("++");

                // Approach 2: query with method calls
                var termSetCollection = termStore.GetTermSetsByName("Keywords", 1033);
                var termSet = termSetCollection.GetByName("Keywords");
                var terms = termSet.GetAllTerms();
                clientContext.Load(terms);
                clientContext.ExecuteQuery();

                foreach (var term in terms)
                {
                   System.Console.WriteLine("Term: {0}", term.Name);
                }
            }
        }

        public void Demo()
        {
            System.Console.WriteLine("--- GetTermSets");
            this.GetTermSets();
        }
    }
}

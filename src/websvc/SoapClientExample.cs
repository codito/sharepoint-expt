using System;
using System.ServiceModel;
using schemas.microsoft.com.sharepoint.taxonomy.soap;

namespace websvc
{
    /// <summary>
    /// Example operations with SharePoint Soap service.
    /// Documentation is at https://msdn.microsoft.com/en-us/library/dd958731(v=office.12).aspx
    /// </summary>
    public class SoapClientExample
    {
        private readonly string remoteAddress;
        private readonly BasicHttpBinding binding;
        private readonly TaxonomywebserviceSoapClient client;
        private readonly string termStoreId;
        private readonly string termSetIds;
        private readonly string clientTimeStamps;
        private readonly string clientVersions;
        private readonly int englishLCID;

        public SoapClientExample()
        {
            // TODO: Update the settings based on target!
            this.remoteAddress = "http://armahapa-srv/_vti_bin/taxonomyclientservice.asmx";

            // TODO: Choose the right binding
            // 1. If your service is deployed on-premise
            this.binding = new BasicHttpBinding();
            this.binding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;
            this.binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Ntlm;

            // 2. If you're using an online endpoint
            // TODO

            var address = new EndpointAddress(this.remoteAddress);
            this.client = new TaxonomywebserviceSoapClient(this.binding, address);

            // 3. Fill in some parameters for termstore
            // sspId = Shared Service Ids; find these in Central Administration
            //  http://armahapa-srv:8080/_layouts/15/termstoremanager.aspx | "Unique Identifier" at the bottom of page
            // termSetIds can be found by navigating to a Term Set in Term Store Manager page and look at "Unique Identifier"
            this.termStoreId = "<sspIds><sspId>243c2fc0-072f-471e-b0a9-a0d7adac42e2</sspId></sspIds>";
            this.termSetIds = "<termSetIds><termSetId>8ed8c9ea-7052-4c1d-a4d7-b9c10bffea6f</termSetId></termSetIds>";
            this.clientTimeStamps = "<dateTimes><dateTime>1900-01-01T00:00:00</dateTime></dateTimes>";
            this.clientVersions = "<versions><version>0</version></versions>";
            this.englishLCID = 1033;
        }

        public void GetTermSets()
        {
            var termsets = this.client.GetTermSets(this.termStoreId, this.termSetIds, this.englishLCID, this.clientTimeStamps, this.clientVersions, out string timeStampXml);

            System.Console.WriteLine(termsets);
        }

        public void GetTermsByLabel(string startsWith)
        {
            var terms = this.client.GetTermsByLabel(startsWith, this.englishLCID, StringMatchOption.StartsWith, 10, termIds: string.Empty, addIfNotFound: false);

            System.Console.WriteLine(terms);
        }

        public void AddTerms()
        {
            // Left as an exercise
        }

        public void GetKeywordTermsByGuid()
        {
            // You can find these Ids from Term Store Manager page, expand the Keyword terms and click on any term
            // Look for "Unique Identifier" value
            var termIds = "<termIds><termId>97584556-149b-4c90-b9ae-060d29e446a4</termId></termIds>";
            var terms = this.client.GetKeywordTermsByGuids(termIds, this.englishLCID);

            System.Console.WriteLine(terms);
        }

        public void GetChildTermsInTermSet()
        {
            // Left as an exercise
        }

        public void GetChildTermsInTerm()
        {
            // Left as an exercise
        }

        public void Demo()
        {
            System.Console.WriteLine("--- GetTermSets demo");
            this.GetTermSets();

            System.Console.WriteLine("--- GetTermsByLabel demo");
            this.GetTermsByLabel("V");

            System.Console.WriteLine("--- GetKeywordTermsByGuid demo");
            this.GetKeywordTermsByGuid();
        }
    }
}

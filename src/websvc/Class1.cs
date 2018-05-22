using System;
using System.ServiceModel;

namespace websvc
{
    public class Class1
    {
        public static void GetTermSets()
        {
            var binding = new BasicHttpBinding(BasicHttpSecurityMode.Transport);
            var client = new TaxonomywebserviceSoapClient();
            var termsets = client.GetTermSets(string.Empty, string.Empty, 0, string.Empty, string.Empty, out string xml);
        }
    }
}

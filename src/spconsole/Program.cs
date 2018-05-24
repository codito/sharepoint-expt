using System;
using System.Net;
using System.Text;
using websvc;

namespace spconsole
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 1)
            {
                switch (args[0])
                {
                    case "websvc":
                        var soapClient = new SoapClientExample();
                        soapClient.Demo();
                        break;
                    case "csom":
                    default:
                        var csom = new csom.CsomExample();
                        csom.Demo();
                        break;
                }
            }
            else
            {
                System.Console.WriteLine("SPConsole runs a few demo scenarios for various sharepoint extensibility points.");
                System.Console.WriteLine("Usage: spconsole.exe (websvc|csom)");
            }
        }
    }
}

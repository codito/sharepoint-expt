using System;

using websvc;

namespace spconsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var soapClient = new SoapClientExample();
            soapClient.Demo();

            Console.WriteLine("Hello World!");
        }
    }
}

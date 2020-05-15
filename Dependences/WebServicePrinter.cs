using System;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using HappyDevops.Autofac.WcfClient.WcfContracts;

namespace HappyDevops.Autofac.WcfClient.Dependences
{
    public class WebServicePrinter
    {
        public IConsultaCFDIService Client { get; }

        public IClientChannel ClientChannel => Client as IClientChannel;

        public WebServicePrinter(IConsultaCFDIService client)
        {
            Client = client;
        }

        public void PrintOutput(string clientArguments)
        {
            IgnoreSslErrors();
            var result = Client.Consulta(clientArguments);
            Console.WriteLine("Response..");
            Console.WriteLine($"{nameof(result.CodigoEstatus)}: {result.CodigoEstatus}");
            Console.WriteLine($"{nameof(result.EsCancelable)}: {result.EsCancelable}");
            Console.WriteLine($"{nameof(result.Estado)}: {result.Estado}");
            Console.WriteLine($"{nameof(result.EstatusCancelacion)}: {result.EstatusCancelacion}");
            Console.WriteLine("End Response..");
        }

        private void IgnoreSslErrors()
        {
            ServicePointManager.ServerCertificateValidationCallback = Callback;
        }
        public static bool Callback(object sender,
            X509Certificate certificate,
            X509Chain chain,
            SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }     
    }
}

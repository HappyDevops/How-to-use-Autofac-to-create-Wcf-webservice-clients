using System;
using Autofac;
using HappyDevops.Autofac.WcfClient.Dependences;
using HappyDevops.Autofac.WcfClient.Extensions;
using HappyDevops.Autofac.WcfClient.WcfContracts;

namespace HappyDevops.Autofac.WcfClient
{
    public class Program
    {
        private const string FAKE_WEBSERVICE_ARGUMENTS = "invalid";
        private const string WEBSERVICE_ENDPOINT = "https://pruebacfdiconsultaqr.cloudapp.net/ConsultaCFDIService.svc";

        static void Main()
        {
            Console.WriteLine("Init...");

            var builder = new ContainerBuilder();
            builder.ComposeChannelFactory<IConsultaCFDIService>(WEBSERVICE_ENDPOINT)
                .ComposeChannel<IConsultaCFDIService>()
                .RegisterType<WebServicePrinter>();

            var container = builder.Build();

            Console.WriteLine("ContainerBuilder done...");

            Console.WriteLine();
            Console.WriteLine("Injected case...");
            ProcessCaseClientInjected(container);

            Console.WriteLine();
            Console.WriteLine("Standalone case...");
            ProcessCaseClientStandalone(container);
            Console.WriteLine("End...");
            Console.Read();
        }

        private static void ProcessCaseClientStandalone(IContainer container)
        {
            WebServicePrinter printer;
            using (var lifetime = container.BeginLifetimeScope())
            {
                var client = lifetime.Resolve<IConsultaCFDIService>();
                printer = new WebServicePrinter(client);
                PrintClientState(printer);
               
                printer.PrintOutput(FAKE_WEBSERVICE_ARGUMENTS);
                PrintClientState(printer);
            }

            PrintClientState(printer);
        }

        private static void ProcessCaseClientInjected(IContainer container)
        {
            WebServicePrinter printer;
            using (var lifetime = container.BeginLifetimeScope())
            {
                printer = lifetime.Resolve<WebServicePrinter>();
                PrintClientState(printer);
      
                printer.PrintOutput(FAKE_WEBSERVICE_ARGUMENTS);
                PrintClientState(printer);
            }

            PrintClientState(printer);
        }

        private static void PrintClientState(WebServicePrinter printer)
        {
            Console.WriteLine($"Client State: {printer.ClientChannel.State}");
        }
    }
}

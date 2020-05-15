using System;
using System.ServiceModel;
using Autofac;
using Autofac.Integration.Wcf;
using HappyDevops.Autofac.WcfClient.WcfContracts;

namespace HappyDevops.Autofac.WcfClient.Extensions
{
    public static class ContainerBuilderExtensions
    {
        public static ContainerBuilder ComposeChannelFactory<T>(this ContainerBuilder builder, string uri)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));
            if (uri == null) throw new ArgumentNullException(nameof(uri));

            builder
                .Register(c => new ChannelFactory<T>(
                    new BasicHttpsBinding(),
                    new EndpointAddress(uri)))
                .SingleInstance();

             return builder;
        }

        public static ContainerBuilder ComposeChannel<T>(this ContainerBuilder builder)
        {
            if (builder == null) throw new ArgumentNullException(nameof(builder));

            builder
                .Register(c => c.Resolve<ChannelFactory<T>>().CreateChannel())
                .As<IConsultaCFDIService>()
                .UseWcfSafeRelease();

            return builder;
        }

    }
}

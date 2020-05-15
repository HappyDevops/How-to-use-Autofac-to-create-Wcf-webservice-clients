using System.ServiceModel;

namespace HappyDevops.Autofac.WcfClient.WcfContracts
{
    [ServiceContract(ConfigurationName="SampleWebService")]
    public interface IConsultaCFDIService {
        
        [OperationContract(Action="http://tempuri.org/IConsultaCFDIService/Consulta", ReplyAction="http://tempuri.org/IConsultaCFDIService/ConsultaResponse")]
        Acuse Consulta(string expresionImpresa);
    }
}

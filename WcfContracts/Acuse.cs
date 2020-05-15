using System;
using System.Runtime.Serialization;

namespace HappyDevops.Autofac.WcfClient.WcfContracts
{
    [DataContract(Name="Acuse", Namespace="http://schemas.datacontract.org/2004/07/Sat.Cfdi.Negocio.ConsultaCfdi.Servicio")]
    [Serializable]
    public class Acuse  
    {
        [DataMember]
        public string CodigoEstatus { get; set; }
        
        [DataMember]
        public string EsCancelable { get; set; }
        
        [DataMember]
        public string Estado { get; set; }
        
        [DataMember]
        public string EstatusCancelacion { get; set; }
    }
}
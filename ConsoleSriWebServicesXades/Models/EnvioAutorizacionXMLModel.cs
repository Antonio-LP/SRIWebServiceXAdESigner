using System.Xml.Serialization;

namespace ConsoleSriWebServicesXades
{
    [XmlRoot("RespuestaAutorizacionComprobante")]
    public class RespuestaAutorizacion
    {
        [XmlElement("claveAccesoConsultada")]
        public string ClaveAcceso { get; set; } = null!;

        [XmlElement("estado")]
        public string Estado { get; set; } = null!;

        [XmlElement("numeroComprobantes")]
        public int NumeroComprobantes { get; set; }

        [XmlArray(ElementName = "autorizaciones")]
        [XmlArrayItem(typeof(Autorizacion), ElementName = "autorizacion")]
        public List<Autorizacion> Comprobantes { get; set; } = null!;
    }

    public class Autorizacion
    {
        [XmlElement("estado")]
        public string Estado { get; set; } = null!;

        [XmlElement("numeroAutorizacion")]
        public string NumeroAutorizacion { get; set; } = null!;

        [XmlElement("fechaAutorizacion")]
        public string FechaAutorizacion { get; set; } = null!;

        [XmlElement("ambiente")]
        public string Ambiente { get; set; } = null!;

        [XmlElement("comprobante")]

        public string Comprobante { get; set; } = null!;

        [XmlElement("comprobanteRetencion")]

        public string comprobanteRetencion { get; set; } = null!;

        [XmlArray(ElementName = "mensajes")]
        [XmlArrayItem(typeof(Mensajes), ElementName = "mensaje")]
        public List<Mensajes> Mensajes { get; set; } = null!;
    }

    public class Mensajes
    {
        [XmlElement("identificador")]
        public string Identificador { get; set; } = null!;

        [XmlElement("mensaje")]
        public string mensajes { get; set; } = null!;

        [XmlElement("informacionAdicional")]
        public string InformacionAdicional { get; set; } = null!;

        [XmlElement("tipo")]
        public string Tipo { get; set; } = null!;
    }

}

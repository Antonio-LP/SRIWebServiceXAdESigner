using System.Xml.Serialization;

namespace ConsoleSriWebServicesXades
{
    [XmlRoot("RespuestaRecepcionComprobante")]
    public class RespuestaRecepcion
    {
        [XmlElement("estado")]
        public string Estado { get; set; } = null!;

        [XmlArray(ElementName = "comprobantes")]
        [XmlArrayItem(typeof(Comprobante), ElementName = "comprobante")]
        public List<Comprobante> Comprobantes { get; set; } = null!;
    }

    public class Comprobante
    {
        [XmlElement("claveAcceso")]
        public string ClaveAcceso { get; set; } = null!;

        [XmlArray(ElementName = "mensajes")]
        [XmlArrayItem(typeof(Mensaje), ElementName = "mensaje")]
        public List<Mensaje> Mensajes { get; set; } = null!;
    }

    public class Mensaje
    {
        [XmlElement("identificador")]
        public string Identificador { get; set; } = null!;

        [XmlElement("mensaje")]
        public string mensaje { get; set; } = null!;

        [XmlElement("informacionAdicional")]
        public string InformacionAdicional { get; set; } = null!;

        [XmlElement("tipo")]
        public string Tipo { get; set; } = null!;
    }

}

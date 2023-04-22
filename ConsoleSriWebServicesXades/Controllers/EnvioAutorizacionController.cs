using System.Xml;
using System.Net;
using System.Xml.Linq;
using System.Text;

namespace ConsoleSriWebServicesXades
{
    public class ComprobanteElectronicoAutorizacion{

        string conexion;
        public ComprobanteElectronicoAutorizacion(string conexion) {
            this.conexion = conexion;
        }

        public async Task<RespuestaAutorizacion> AutorizacionComprobante(string claveAcceso)
        {
            RespuestaAutorizacion RespuestaAutorizacion = new RespuestaAutorizacion();
      
            var soapEnvelopeXml = new XmlDocument();
            soapEnvelopeXml.LoadXml(
                @"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:ec=""http://ec.gob.sri.ws.autorizacion"">
                   <soapenv:Header/>    
                    <soapenv:Body>
                    <ec:autorizacionComprobante>
                        <!--Optional:-->
                         <claveAccesoComprobante>" + claveAcceso + @"</claveAccesoComprobante>
                     </ec:autorizacionComprobante>
                   </soapenv:Body>
                </soapenv:Envelope>");

            string url = $"https://{conexion}.sri.gob.ec/comprobantes-electronicos-ws/AutorizacionComprobantesOffline?wsdl";

            using (HttpClient httpClient = new HttpClient())
            {
                var xmlContent = new StringContent(soapEnvelopeXml.OuterXml, Encoding.UTF8, "text/xml");
                var httpResponse = await httpClient.PostAsync(url, xmlContent);

                if (httpResponse.IsSuccessStatusCode)
                {
                    var response = await httpResponse.Content.ReadAsStringAsync();
                    var soapResult = XDocument.Parse(response);
                    var responseXml = soapResult.Descendants("RespuestaAutorizacionComprobante").ToList();

                    foreach (var xmlDoc in responseXml)
                    {
                        RespuestaAutorizacion = (RespuestaAutorizacion)Services.DesempaquetarDesdeXElement(xmlDoc, typeof(RespuestaAutorizacion));

                    }

                }

                }

            
            return RespuestaAutorizacion;
        }

      

    }
}

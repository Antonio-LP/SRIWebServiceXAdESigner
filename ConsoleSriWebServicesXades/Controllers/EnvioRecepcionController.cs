using System;
using System.IO;
using System.Xml;
using System.Net;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Linq;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Data.SqlTypes;
using System.Text;

namespace ConsoleSriWebServicesXades
{

    public class ComprobanteElectronicoRecepcion{
        string conexion;
        public ComprobanteElectronicoRecepcion(string conexion)
        {
            this.conexion = conexion;
        }
        public async Task<RespuestaRecepcion> RecepcionComprobanteAsync(String path)
        {
            var xmlByte = File.ReadAllBytes(path);

            RespuestaRecepcion resRecepcion = await RecepcionComprobanteWebAsync(Convert.ToBase64String(xmlByte));
           
            return resRecepcion;
        }

        public async Task<RespuestaRecepcion> RecepcionComprobanteWebAsync(string xml)
        {

            RespuestaRecepcion respuestaRecepcionPrueba = new RespuestaRecepcion();
            var soapEnvelopeXml = new XmlDocument();

            soapEnvelopeXml.LoadXml(
                @"<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:ec=""http://ec.gob.sri.ws.recepcion"">
            <soapenv:Header/>
            <soapenv:Body>
                <ec:validarComprobante>
                    <!--Optional:-->
                    <xml>" + xml + @"</xml>
                </ec:validarComprobante>
            </soapenv:Body>
        </soapenv:Envelope>"
            );

            string url = $"https://{conexion}.sri.gob.ec/comprobantes-electronicos-ws/RecepcionComprobantesOffline?wsdl";

            using (HttpClient httpClient = new HttpClient())
            {

                var xmlContent = new StringContent(soapEnvelopeXml.OuterXml, Encoding.UTF8, "text/xml");
                var httpResponse = await httpClient.PostAsync(url, xmlContent);


                if (httpResponse.IsSuccessStatusCode)
                {
                    var responseContent = await httpResponse.Content.ReadAsStringAsync();

                    var soapResult = XDocument.Parse(responseContent);

                    var responseXml = soapResult.Descendants("RespuestaRecepcionComprobante").ToList();
                    foreach (var xmlDoc in responseXml)
                    {
                        respuestaRecepcionPrueba = (RespuestaRecepcion)Services.DesempaquetarDesdeXElement(xmlDoc, typeof(RespuestaRecepcion));
                    }
                }
                else
                {
                    // manejar errores aquí
                }

                return respuestaRecepcionPrueba;
            }
        }

    }
}

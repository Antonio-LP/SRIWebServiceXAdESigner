using FirmaXadesNet.Crypto;
using FirmaXadesNet.Signature.Parameters;
using FirmaXadesNet;
using System.Xml.Linq;
using System.Xml;
using System.Xml.Serialization;


namespace ConsoleSriWebServicesXades
{
    public struct Connection
    {
        public const string Pruebas = "celcer";
        public const string Produccion = "cel";
    }

    public class Services
    {
        public void Firmar(string pathXml)
        {

            XadesService xadesService = new XadesService();
            SignatureParameters parametros = new SignatureParameters();

            // Política de firma de factura-e 3.1
            parametros.SignaturePolicyInfo = new SignaturePolicyInfo();
            parametros.SignaturePackaging = SignaturePackaging.ENVELOPED;
            parametros.DataFormat = new DataFormat();
            parametros.SignerRole = new SignerRole();

            using (parametros.Signer = new Signer(FirmaXadesNet.Utils.CertUtil.SelectCertificate()))
            {
                using (FileStream fs = new FileStream(pathXml, FileMode.Open))
                {
                    var docFirmado = xadesService.Sign(fs, parametros);

                    pathXml = pathXml.Replace(".xml", "Firmado.xml");
                    docFirmado.Save($@"{pathXml}");
                    Console.WriteLine("Fichero Firmado Correctamente.");

                }
            }

        }



        public async Task ConsultaEnvioDeComprobantes(string pathFlie, string typeConnection = Connection.Pruebas)
        {
            RespuestaRecepcion respuesta = await new ComprobanteElectronicoRecepcion(typeConnection).RecepcionComprobanteAsync(pathFlie);

            if (respuesta.Estado == "DEVUELTA")
            {
                Console.WriteLine($"{respuesta.Estado}, {respuesta.Comprobantes[0].ClaveAcceso}");
                Console.WriteLine($"{respuesta.Comprobantes[0].Mensajes[0].mensaje} : {respuesta.Comprobantes[0].Mensajes[0].InformacionAdicional}");
            }
            else
            {
                Console.WriteLine($"{respuesta.Estado}");
            }
        }

        public async Task ConsultaVerificacionDeComprobantes(string claveAccessoComprobante, string typeConnection = Connection.Pruebas)
        {
            RespuestaAutorizacion respuestaAutorizacion = await new ComprobanteElectronicoAutorizacion(typeConnection).AutorizacionComprobante(claveAccessoComprobante);
            string res = $"{respuestaAutorizacion.Comprobantes[0].Estado} \n";
            res += $"{respuestaAutorizacion.Comprobantes[0].Ambiente} \n";
            res += $"{respuestaAutorizacion.Comprobantes[0].FechaAutorizacion}";


            Console.WriteLine(res);

        }


        public static object DesempaquetarDesdeXElement(XElement xElement, Type type)
        {
            try
            {
                XmlReader xmlReader = xElement.CreateReader();
                XmlSerializer xmlSerializer = new XmlSerializer(type);
                var objectoDesempaquetadoXMl = xmlSerializer.Deserialize(xmlReader);
                xmlReader.Close();
                return objectoDesempaquetadoXMl ?? throw new Exception("El objeto es nulo");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return false;

        }
    }
}

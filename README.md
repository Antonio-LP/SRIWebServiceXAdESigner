# Aplicación de consola para consumir Web Services del SRI Ecuador y firmar con XAdES

Esta aplicación de consola ha sido desarrollada para consumir los Web Services del Servicio de Rentas Internas (SRI) de Ecuador y para firmar los documentos electrónicos utilizando el estándar XAdES.

### **Funcionalidades**
Las principales funcionalidades de la aplicación son:

* Conexión y autenticación con los Web Services del SRI Ecuador.
* Envío de documentos electrónicos (facturas, notas de crédito, notas de débito, etc.) al SRI para su validación y posterior autorización.
* Generación de firmas digitales en los documentos electrónicos utilizando el estándar XAdES.

### **Tecnologías utilizadas**
La aplicación ha sido desarrollada utilizando las siguientes tecnologías:

* .NET Core 7
* Visual Studio 2022
* Librerias Xades del Dpto. de Nuevas Tecnologías de la Concejalía de Urbanismo del Ayuntamiento de Cartagena:
    * BouncyCastle.Crypto.dll
    * FirmaXadesNet.dll
    * Microsoft.Xades.dll

>Puede compilarlas usted mismo si las necesita para otra version de .Net: [Xades.NetCore](https://github.com/pgiacomo69/Xades.NetCore "customtiele")
* Nuget Package
    * System.Security.Cryptography.Xml
    * System.Windows.Extensions

## **¿Cómo funciona?**

La aplicación se ejecuta desde *Program.cs* consta de tres funciones (Firmar, ConsultaEnvioDeComprobantes y ConsultaVerificacionDeComprobantes) el archivo *Services.cs* ejecutara cada funcion asincrona utilizando la clase HttpClient utilizando los parámetros proporcionados por el usuario para conectarse a los Web Services del SRI Ecuador, enviar documentos electrónicos y generar firmas digitales.

Para utilizar la aplicación, el usuario debe contar con:

1. Certificado digital: El certificado digital es utilizado para firmar digitalmente los documentos electrónicos y para autenticarse con los Web Services del SRI Ecuador.

    Endidates que lo emiten de acuerdo con el [SRI](https://www.sri.gob.ec/facturacion-electronica#informaci%C3%B3n "Facturación Electrónica")

    * Consejo de la Judicatura
    * ARGOSDATA Certificación de Información y Servicios Relacionados S.A.S.
    * Banco Central del Ecuador
    * Uanataca Ecuador S.A.

    Documento electrónico: El documento electrónico debe estar en formato XML y debe contener los datos de la transacción establecidos por la [Ficha Técnica de Comprobantes Electrónicos Esquema Off-line - Versión 2.24]("https://www.sri.gob.ec/o/sri-portlet-biblioteca-alfresco-internet/descargar/ba6330ae-9194-4090-9aff-4326655bbfa1/FICHA%20TE%cc%81CNICA%20COMPROBANTES%20ELECTRO%cc%81NICOS%20ESQUEMA%20OFFLINE%20Versio%cc%81n%202.24.pdf")

Una vez que se han proporcionado los parámetros necesarios, la aplicación se encarga de conectarse con los Web Services del SRI Ecuador, enviar el documento electrónico para su validación y autorización, generar la firma digital utilizando el estándar XAdES, y enviar el documento firmado al SRI para su verificación.


## **Pasos**
1. Instale su certificado en su computador (Clic para abrir el gif)

<p align="center"><a href="https://ibb.co/yFt46rN"><img src="https://i.ibb.co/nM9P7Fw/ezgif-com-video-to-gif.gif" alt="ezgif-com-video-to-gif" border="0"></a></p>

2. Al ejercutar el programa, para firmar deberemos elegir nuestro certificado (Clic para abrir el gif)
3. 
<p align="center"><a href="https://ibb.co/xFzgQdk"><img src="https://i.ibb.co/bbNvnD0/ezgif-com-video-to-gif-1.gif" alt="ezgif-com-video-to-gif-1" border="0"></a></p>

3. Puede comprobar la emision de su factura con la clave de Accesso en el portal web del SRI








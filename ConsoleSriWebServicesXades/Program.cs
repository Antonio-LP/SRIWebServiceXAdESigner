using ConsoleSriWebServicesXades;

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("--------------- Firma -----------------");
Console.ResetColor();
var servicios = new Services();
servicios.Firmar(@"MI\Ruta\A\Mi\Archivo\MiArchivo.xml");

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("--------------- Envío -----------------");
Console.ResetColor();
//Misma ruta, reemplazar 'MiArchivo.xml' por 'MiArchivoFirmado.xml'
await servicios.ConsultaEnvioDeComprobantes(@"MI\Ruta\A\Mi\Archivo\MiArchivoFirmado.xml");

Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine("--------------- Autorización -----------------");
Console.ResetColor();
//Según los requisitos del SRI, es necesario incluir una pausa de 3 segundos antes de realizar la consulta.
await Task.Delay(3000);
//Clave de Accesso 
await servicios.ConsultaVerificacionDeComprobantes("");




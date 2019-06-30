using System;
using System.Collections.Generic;
using System.Text;

namespace ProbandoEnvioCorreo
{
    class Program
    {

        static string correoReceptor;
        static string asuntoMensaje;
        static string contenidoMensaje;
        static string copia;

        static void Main(string[] args)
        {


            // ingreso de parametros
            Console.Write("Ingrese correo receptor: ");
            correoReceptor = Console.ReadLine(); // receptor
            Console.Write("Ingrese el asunto del mensaje: ");
            asuntoMensaje = Console.ReadLine(); // asunto del mensaje
            Console.Write("Ingrese el contenido del mensaje: ");
            contenidoMensaje = Console.ReadLine(); // contenido
            Console.Write("Ingrese la copia del mensaje: ");
            copia = Console.ReadLine(); // copia
            envioCorreo(correoReceptor, asuntoMensaje, contenidoMensaje, copia);


        } // fin main

        
        static void envioCorreo(string receptor, string asunto, string contenido, string copia)
        {
            // informacion
            System.Net.Mail.MailMessage mensaje = new System.Net.Mail.MailMessage();

            mensaje.To.Add(receptor); // receptor
            mensaje.Subject = asunto; // asunto del mensaje
            mensaje.SubjectEncoding = System.Text.Encoding.UTF8; // encoding para servidores
            mensaje.Bcc.Add(copia);


            mensaje.Body = contenido; // cuenrpo mensaje
            mensaje.BodyEncoding = System.Text.Encoding.UTF8;
            mensaje.IsBodyHtml = true;
            mensaje.From = new System.Net.Mail.MailAddress("leandro.valenzuela02@inacapmail.cl"); // mi correo 

            System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient(); // nuevo cliente smtp

            cliente.Credentials = new System.Net.NetworkCredential("leandro.valenzuela02@inacapmail.cl", ""); // correo y contraseña

            cliente.Port = 587; // puerto
            cliente.EnableSsl = true; // seguridad ssl

            cliente.Host = "SMTP.Office365.com"; // servidor de salida

            try
            {
                cliente.Send(mensaje);
                Console.WriteLine("Mensaje enviado!!");
                Console.ReadKey();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Maaal: " + ex);
                Console.ReadKey();
            }

        
        }


    } // fin class

} // fin namespace

using BackMonolegal.Models;
using BackMonolegal.Repositories;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Web.Http;

namespace BackMonolegal_1.Controllers
{
    public class InvoiceController : ApiController
    {
        private IInvoiceCollection db = new InvoiceCollection();
        // GET: api/Invoice
        public List<Invoice> Get()
        {
            List<Invoice> invoices = db.getAllInvoices();
            foreach (Invoice invoice in invoices)
            {
                if (invoice.State.Equals("primerrecordatorio") || invoice.State.Equals("segundorecordatorio"))
                {
                    sendEmail(invoice);
                    if (invoice.State.Equals("primerrecordatorio"))
                    {
                        invoice.State = "segundorecordatorio";
                    }
                    else if (invoice.State.Equals("segundorecordatorio"))
                    {
                        invoice.State = "desactivado";
                    }
                    db.UpdateInvoice(invoice); 
                }
            }
            return invoices;
        }

        protected void sendEmail(Invoice invoice)
        {
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("test1monolegal@gmail.com", "MonoTest0_1Legal");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.EnableSsl = true;

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("test1monolegal@gmail.com", "Cambio de Estado");
            mail.To.Add(new MailAddress(invoice.email));
            mail.Subject = "Cambio de Estado";
            mail.IsBodyHtml = true;
            mail.Body = getBodyState(invoice.State);

            smtp.Send(mail);
        }

        private string getBodyState(string state)
        {
            string body = "<body>" +
                "<h1>Se ha cambiado el estado </h1>" +
                "<p>Se le informa que su estado actual es " + state;
            if (state.Equals("primerrecordatorio")){
                body+=" y será cambiado a segundorecordatorio</p></body>";
            }else if (state.Equals("segundorecordatorio")){
                body += " y será cambiado a desactivado</p></body>";
            }
            return body;
        }
    }
}
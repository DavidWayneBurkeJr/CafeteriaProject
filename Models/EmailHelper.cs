using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace BatemanCafeteria.Models
{
    public class EmailHelper
    {
        public ErrorLogging errlogger = new ErrorLogging();

        public void sendEmail(string toAddress, string message, string subject, string toName)
        {
            try
            {
                MailMessage mail = new MailMessage("Batemandonotreply@gmail.com", toAddress);
                SmtpClient client = new SmtpClient();
                client.Host = "smtp.gmail.com";
                client.Port = 587;
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("Batemandonotreply@gmail.com", "capstoneCS490!");
                mail.Subject = subject;
                string htmlMessage = @"<html>
                                            <body>
                                                <div style='width: 100 %; height: 200px; position: relative; display: flex; flex-direction: row;'>
                                                              <div class='line-deco' style='flex-grow: 1;padding-top: 90px;'>
                                                        <div class='black-line' style='width: 100%;height: 5px;background: #000000;border-radius: 5px;display: inline-block;'>
                                                            <div class='green-line' style='width: 90%;background: #04954A;height: 4px;border-radius: 5px;margin-top: 10px;margin-right: auto;margin-left: auto;'></div>
                                                        </div>
                                                    </div>
                                                    <div class='logo' style='height: 200px;'>
                                                        <img src = 'cid:EmbeddedContent_1' style='width: auto; height: 100%;'>
                                                    </div >
                                                    <div class='line-deco' style='flex-grow: 1;padding-top: 90px;'>
                                                        <div class='black-line' style='width: 100%;height: 5px;background: #000000;border-radius: 5px;display: inline-block;'>
                                                            <div class='green-line' style='width: 90%;background: #04954A;height: 4px;border-radius: 5px;margin-top: 10px;margin-right: auto;margin-left: auto;'></div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class='email-body' style='margin-left: 80px;margin-right: 80px;'>
                                                    <div class='greeting' style='padding-bottom: 20px;'>Hello #customer-name#,</div>
                                                    <div class='message' style='text-indent: 50px;padding-bottom: 100px;'>
                                                        #body-message#
                                                    </div>
                                                    <div>Bateman Cafe</div>
                                                    <hr style = 'color: rgba(0,0,0,0.1);' >
                                                </ div >
                                            </ body >
                                            </html>";
                htmlMessage = htmlMessage.Replace("#customer-name#", toName);
                htmlMessage = htmlMessage.Replace("#body-message#", message);
                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(
                    htmlMessage,
                    Encoding.UTF8,
                    MediaTypeNames.Text.Html);

                AlternateView plainView = AlternateView.CreateAlternateViewFromString(
                    Regex.Replace(htmlMessage,
                    "<[^>]+?>",
                    string.Empty),
                    Encoding.UTF8,
                    MediaTypeNames.Text.Plain);
                string mediaType = "image/png";
                LinkedResource img = new LinkedResource(HttpContext.Current.Server.MapPath("~/Images/logo.png"));
                img.ContentId = "EmbeddedContent_1";
                img.ContentType.MediaType = mediaType;
                img.TransferEncoding = TransferEncoding.Base64;
                img.ContentType.Name = img.ContentId;
                img.ContentLink = new Uri("cid:" + img.ContentId);
                htmlView.LinkedResources.Add(img);
                mail.AlternateViews.Add(plainView);
                mail.AlternateViews.Add(htmlView);
                mail.IsBodyHtml = true;
                client.Send(mail);
            }
            catch (Exception e)
            {
                errlogger.log_error("batemanCaf", "ShoppingCart", "Checkout", e.Message);
            }

        }



    }
}
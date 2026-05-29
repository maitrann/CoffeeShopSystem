using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebMVC_CoffeeShopSystem.Utilities
{
    public class SendMailKit
    {
        public static void SendRegisSeller(string title, string mailTo, string phone, string address, string pass)
        {
            var email = new MimeMessage();

            email.From.Add(new MailboxAddress(GetSetting("MailFromName"), GetSetting("MailFromAddress")));
            email.To.Add(new MailboxAddress("Seller", mailTo));

            email.Subject = "Register Become As A Seller";
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = "<!DOCTYPE html>\r\n<html lang=\"en\" xmlns=\"http://www.w3.org/1999/xhtml\" xmlns:o=\"urn:schemas-microsoft-com:office:office\">\r\n<head>\r\n    <meta charset=\"UTF-8\">\r\n    <meta name=\"viewport\" content=\"width=device-width,initial-scale=1\">\r\n    <meta name=\"x-apple-disable-message-reformatting\">\r\n    <title></title>\r\n    <!--[if mso]>\r\n    <noscript>\r\n      <xml>\r\n        <o:OfficeDocumentSettings>\r\n          <o:PixelsPerInch>96</o:PixelsPerInch>\r\n        </o:OfficeDocumentSettings>\r\n      </xml>\r\n    </noscript>\r\n    <![endif]-->\r\n    <style>\r\n        table, td, div, h1, p {\r\n            font-family: Arial, sans-serif;\r\n        }\r\n    </style>\r\n</head>\r\n<body style=\"margin:0;padding:0;\">\r\n    <table role=\"presentation\" style=\"width:100%;border-collapse:collapse;border:0;border-spacing:0;background:#ffffff;\">\r\n        <tr>\r\n            <td align=\"center\" style=\"padding:0;\">\r\n                <table role=\"presentation\" style=\"width:602px;border-collapse:collapse;border:1px solid #cccccc;border-spacing:0;text-align:left;\">\r\n                    <tr>\r\n                        <td align=\"center\" style=\"padding:40px 0 30px 0;background:#70bbd9;\">\r\n                            <img src=\"https://assets.codepen.io/210284/h1.png\" alt=\"\" width=\"300\" style=\"height:auto;display:block;\" />\r\n                        </td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td style=\"padding:36px 30px 42px 30px;\">\r\n                            <table role=\"presentation\" style=\"width:100%;border-collapse:collapse;border:0;border-spacing:0;\">\r\n                                <tr>\r\n                                    <td style=\"padding:0 0 36px 0;color:#153643;\">\r\n                                        <h1 style=\"font-size:24px;margin:0 0 20px 0;font-family:Arial,sans-serif;\">Become As A Seller</h1>\r\n                                        <p style=\"margin:0 0 12px 0;font-size:16px;line-height:24px;font-family:Arial,sans-serif;\">Thank you for your interest in us. Congratulations, you have just registered to become a seller on the Cafena website. We are very excited about this partnership!</p>\r\n                                        " +
                "<strong style=\"margin:0 0 12px 0;font-size:16px;line-height:24px;font-family:Arial,sans-serif;\">Check your information here:</strong>\r\n  " +
                "<p style=\"margin:0 0 12px 0;font-size:16px;line-height:24px;font-family:Arial,sans-serif;\">Brand: " + title + "</p>\r\n  " +
                "<p style=\"margin:0 0 12px 0;font-size:16px;line-height:24px;font-family:Arial,sans-serif;\">Email: " + mailTo + "</p>\r\n   " +
                "<p style=\"margin:0 0 12px 0;font-size:16px;line-height:24px;font-family:Arial,sans-serif;\">Phone: " + phone + "</p>\r\n   " +
                "<p style=\"margin:0 0 12px 0;font-size:16px;line-height:24px;font-family:Arial,sans-serif;\">Address: " + address + "</p>\r\n " +
                "<p style=\"margin:0 0 12px 0;font-size:16px;line-height:24px;font-family:Arial,sans-serif;\">This is your default password: <strong>" + pass + "</strong>. Don't share your password.</p>\r\n\r\n                                        <p style=\"margin:0;font-size:16px;line-height:24px;font-family:Arial,sans-serif;\">\r\n                                            " +
                "<a href=\"#\" style=\"color:#ee4c50;text-decoration:underline;\">\r\n   Sign In Seller\r\n </a>\r\n                                        </p>\r\n                                        " +
                "<p style=\"margin:0 0 12px 0;font-size:16px;line-height:24px;font-family:Arial,sans-serif;\">If you need further support, please contact Cafena immediately: truongquachmaitran@gmail.com.</p>\r\n                                    </td>\r\n                                </tr>\r\n                            </table>\r\n                        </td>\r\n                    </tr>\r\n                    <tr>\r\n                        <td style=\"padding:30px;background:#ee4c50;\">\r\n                            <table role=\"presentation\" style=\"width:100%;border-collapse:collapse;border:0;border-spacing:0;font-size:9px;font-family:Arial,sans-serif;\">\r\n                                <tr>\r\n                                    <td style=\"padding:0;width:50%;\" align=\"left\">\r\n                                        <p style=\"margin:0;font-size:14px;line-height:16px;font-family:Arial,sans-serif;color:#ffffff;\">\r\n                                            &reg; Cafena 2024<br />\r\n                                        </p>\r\n                                    </td>\r\n                                </tr>\r\n                            </table>\r\n                        </td>\r\n                    </tr>\r\n                </table>\r\n            </td>\r\n        </tr>\r\n    </table>\r\n</body>\r\n</html>\r\n\r\n"
            };

            using (var smtp = new SmtpClient())
            {
                smtp.Connect(
                    GetSetting("SmtpHost"),
                    int.Parse(GetSetting("SmtpPort")),
                    bool.Parse(GetSetting("SmtpUseSsl")));

                // Note: only needed if the SMTP server requires authentication
                smtp.Authenticate(GetSetting("SmtpUsername"), GetSetting("SmtpPassword"));

                smtp.Send(email);
                smtp.Disconnect(true);
            }
        }

        private static string GetSetting(string key)
        {
            string value = ConfigurationManager.AppSettings[key];
            if (string.IsNullOrWhiteSpace(value) || value.StartsWith("__SET_", StringComparison.Ordinal))
            {
                throw new ConfigurationErrorsException("Missing appSetting: " + key);
            }

            return value;
        }
    }
}

using System;
using System.Net.Mail;
using System.Text;


namespace Legacy.Web.Templates.Pages
{
    public class EMail
    {
        /// <summary>
        /// Builds the content of the email body
        /// </summary>
        /// <returns></returns>
        internal static string BuildEmailContent()
        {
            const string SummaryStart = "<table>";
            const string SummaryEnd = "</table>";
            const string ContentStart = "<html>";
            const string ContentEnd = "</html>";
            const string LabelElementStart = "<tr><td><strong>";
            const string LabelElementEnd = "</strong></td>";
            const string ValueElementStart = "<td>";
            const string ValueElementEnd = "</td></tr>";
            const string LabelElementFullWidthStart = "<tr><td colspan=\"2\"><strong>";
            const string LabelElementFullWidthEnd = "</strong></td></tr>";
            const string ValueElementFullWidthStart = "<tr><td colspan=\"2\">";
            const string ValueElementFullWidthEnd = "</td></tr>";

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(ContentStart);
            stringBuilder.AppendLine(PropertyService.GetStringProperty(CurrentPage, "EmailHeader"));
            stringBuilder.AppendLine(SummaryStart);
            stringBuilder.AppendLine(LabelElementStart + GetLanguageString("/applicationform/county") + LabelElementEnd + ValueElementStart + Ddl_County.SelectedValue + ValueElementEnd);
            stringBuilder.AppendLine(LabelElementStart + GetLanguageString("/applicationform/municipality") + LabelElementEnd + ValueElementStart + Ddl_Municipality.SelectedItem + ValueElementEnd);
            stringBuilder.AppendLine(LabelElementStart + GetLanguageString("/applicationform/applicator") + LabelElementEnd + ValueElementStart + Txt_Applicator.Text + ValueElementEnd);
            stringBuilder.AppendLine(LabelElementStart + GetLanguageString("/applicationform/address") + LabelElementEnd + ValueElementStart + Txt_Address.Text + ValueElementEnd);
            stringBuilder.AppendLine(LabelElementStart + GetLanguageString("/applicationform/postcode") + " / " + GetLanguageString("/applicationform/postarea") + LabelElementEnd + ValueElementStart + Txt_PostCode.Text + " " + Txt_PostArea.Text + ValueElementEnd);
            stringBuilder.AppendLine(LabelElementStart + GetLanguageString("/applicationform/orgnobirthnumber") + LabelElementEnd + ValueElementStart + Txt_OrgNoBirthNumber.Text + ValueElementEnd);
            stringBuilder.AppendLine(LabelElementStart + GetLanguageString("/applicationform/contactperson") + LabelElementEnd + ValueElementStart + Txt_ContactPerson.Text + ValueElementEnd);
            stringBuilder.AppendLine(LabelElementStart + GetLanguageString("/applicationform/phone") + LabelElementEnd + ValueElementStart + Txt_Phone.Text + ValueElementEnd);
            stringBuilder.AppendLine(LabelElementStart + GetLanguageString("/applicationform/email") + LabelElementEnd + ValueElementStart + Txt_Email.Text + ValueElementEnd);
            stringBuilder.AppendLine(LabelElementFullWidthStart + GetLanguageString("/applicationform/description") + LabelElementFullWidthEnd + ValueElementFullWidthStart + Txt_Description.Text + ValueElementFullWidthEnd);
            stringBuilder.AppendLine(LabelElementFullWidthStart + GetLanguageString("/applicationform/financeplan") + LabelElementFullWidthEnd + ValueElementFullWidthStart + Txt_FinancePlan.Text + ValueElementFullWidthEnd);
            stringBuilder.AppendLine(LabelElementFullWidthStart + GetLanguageString("/applicationform/businessdescription") + LabelElementFullWidthEnd + ValueElementFullWidthStart + Txt_BusinessDescription.Text + ValueElementFullWidthEnd);
            stringBuilder.AppendLine(LabelElementStart + GetLanguageString("/applicationform/applicationAmount") + LabelElementEnd + ValueElementStart + Txt_ApplicationAmount.Text + ValueElementEnd);
            stringBuilder.AppendLine(SummaryEnd);
            stringBuilder.AppendLine(PropertyService.GetStringProperty(CurrentPage, "EmailFooter"));
            stringBuilder.AppendLine(ContentEnd);

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Builds the mail.
        /// </summary>
        /// <param name="toAddresses">To addresses.</param>
        /// <param name="subject">The subject.</param>
        /// <param name="content">The content.</param>
        /// <param name="fromAdress">From adress.</param>
        /// <param name="bccAddress">Bcc adress.</param>
        /// <param name="attachmentCol">The attachment col.</param>
        /// <returns></returns>
        internal static MailMessage BuildMail(string toAddresses, string subject, string content, string fromAdress, string bccAddress, Attachment[] attachmentCol)
        {
            //Receipents
            MailAddressCollection receipents = new MailAddressCollection();

            if (toAddresses.Contains(";"))
            {
                string[] addresses = toAddresses.Split(';');

                foreach (string s in addresses)
                {
                    if (!s.StartsWith(";"))
                    {
                        receipents.Add(s);
                    }
                }
            }
            else
            {
                receipents.Add(toAddresses);
            }

            //From
            MailAddress from = new MailAddress(fromAdress, fromAdress);
            MailMessage mail = new MailMessage();

            //To
            foreach (MailAddress attendee in receipents)
            {
                mail.To.Add(attendee);
            }

            mail.From = from;
            mail.Subject = subject;
            mail.Body = content;

            if (!string.IsNullOrEmpty(bccAddress))
            {
                mail.Bcc.Add(bccAddress);
            }

            //Attachment
            if (attachmentCol != null)
            {
                foreach (Attachment attachment in attachmentCol)
                {
                    if (attachment != null)
                    {
                        mail.Attachments.Add(attachment);
                    }
                }
            }

            return mail;
        }

        /// <summary>
        /// Sends an email with calendar event.
        /// </summary>
        /// <param name="mail">The mail.</param>
        /// <param name="isBodyHtml">if set to <c>true</c> [is body HTML].</param>
        /// <returns></returns>
        internal static bool SendMail(MailMessage mail, bool isBodyHtml)
        {
            SmtpClient smtp = new SmtpClient();
            mail.IsBodyHtml = isBodyHtml;
            bool retStatus = false;

            if (mail.To.Count > 0 && mail.From.ToString().Length > 0 && mail.Subject.Length > 0)
            {
                try
                {
                    bool ok = true;
                    foreach (MailAddress singleToAddress in mail.To)
                    {
                        if (!StringValidationUtil.IsValidEmailAddress(singleToAddress.Address))
                        {
                            ok = false;
                        }
                    }

                    if (ok)
                    {
                        //Send mail
                        smtp.Send(mail);
                        retStatus = true;
                    }

                    //Returns true if successful
                    return retStatus;

                }
                catch (Exception ex)
                {
                    return false;
                }
            }

            return false;
        }

    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Text;
using System.Web.UI.WebControls;
using Legacy.Core.PageTypes;
using Legacy.Core.Services;
using Legacy.Web.Templates.Base;
using Legacy.Web.Utilities;

namespace Legacy.Web.Templates.Pages
{
    public partial class ApplicationForm : TemplatePageBase<ApplicationFormPage>
    {
        protected List<ContactPerson> contactPersonList;
        protected string[] countyList = { "", "Nordland", "Nord Trøndelag", "Sør Trøndelag", "Møre og Romsdal", "Sogn og Fjordane", "Hordaland", "Rogaland", "Vest Agder" };

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!IsPostBack)
            {
                DataBind();
                PopulateCountyList();
            }
        }
        protected bool SendFormContentByEmail()
        {
            string subject = PropertyService.GetStringProperty(CurrentPage, "EmailSubject");
            string content = EMail.BuildEmailContent();
            string applicationReciever = GetEmailForMunicipality(Ddl_Municipality.SelectedValue);
            string applicationSender = Txt_Email.Text;

            MailMessage mailMessage = EMail.BuildMail(applicationSender, subject, content, applicationReciever, applicationReciever, GetAttachments());
            return EMail.SendMail(mailMessage, true);
        }

        #region Fill GUI controls
        /// <summary>
        /// Populates the County dropDownList
        /// </summary>
        protected void PopulateCountyList()
        {
            Ddl_County.DataSource = countyList;
            Ddl_County.DataBind();
        }

        /// <summary>
        /// Populate Ddl_Municipality with municipality from the given county
        /// </summary>
        /// <param name="county"></param>
        protected void PopulateMunicipalityList(string county)
        {
            if (contactPersonList == null || contactPersonList.Count == 0)
            {
                ContactPerson.PopulateContactPersonList(contactPersonList);
            }

            Ddl_Municipality.Items.Clear();
            Ddl_Municipality.Items.Add(new ListItem("", ""));

            foreach (ContactPerson contactPerson in contactPersonList)
            {
                if (contactPerson.County.Equals(county))
                {
                    if (contactPerson.Municipality == "mrHeroy")
                    {
                        Ddl_Municipality.Items.Add(new ListItem("Herøy", contactPerson.Municipality));
                    }
                    else
                    {
                        Ddl_Municipality.Items.Add(new ListItem(contactPerson.Municipality));
                    }
                    
                }
            }
        }

        /// <summary>
        /// Creates as many FileUpload controls as configured on the page.
        /// </summary>
        private void BuildDynamicControls()
        {
            if (pnlFileUpload.Visible)
            {
                //Create dummy datasource to display the correct number of FileUpload controls.
                if (!CurrentPage.Property["NumberOfFileUploads"].IsNull)
                {
                    int numberOfFiles = (int)CurrentPage.Property["NumberOfFileUploads"].Value;

                    if (numberOfFiles > 0)
                    {
                        List<int> list = new List<int>();
                        for (int i = 0; i < numberOfFiles; i++)
                        {
                            list.Add(i);
                        }

                        rptFileUpload.DataSource = list;
                        rptFileUpload.DataBind();
                    }
                }
            }
        }
        #endregion

        #region Events

        /// <summary>
        /// Attachement button clicked
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">e</param>
        protected void btnShowFileUpload_Click(object sender, EventArgs e)
        {
            pnlFileUpload.Visible = true;
            BuildDynamicControls();
            btnShowFileUpload.Visible = false;
        }

        /// <summary>
        /// Submit button clicked
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">e</param>
        protected void Btn_SubmitForm_Click(object sender, EventArgs e)
        {
            // Server side validation, if javascript is disabled
            Page.Validate();
            if (Page.IsValid)
            {
                if (SendFormContentByEmail())
                {
                    string receiptUrl = PropertyService.GetPageDataPropertyLinkUrl(CurrentPage, "FormReceiptPage");
                    Response.Redirect(receiptUrl);
                }
                else
                {
                    string errorUrl = PropertyService.GetPageDataPropertyLinkUrl(CurrentPage, "FormErrorPage");
                    Response.Redirect(errorUrl);
                }
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the Ddl_County control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Ddl_County_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Ddl_County.SelectedValue.Equals(string.Empty))
            {
                PopulateMunicipalityList(Ddl_County.SelectedValue);
            }
            else
            {
                Ddl_Municipality.Items.Clear();
                Ddl_Municipality.DataBind();
            }
        }

        #endregion

        #region Email handling
        private Attachment[] GetAttachments()
        {
            List<Attachment> attachmentList = new List<Attachment>();

            foreach (string postedInputName in Request.Files)
            {
                var postedFile = Request.Files[postedInputName];

                if (postedFile != null && postedFile.ContentLength > 0)
                {
                    string fileName = Path.GetFileName(postedFile.FileName);
                    if (fileName != string.Empty)
                    {
                        Attachment newAttachment = new Attachment(postedFile.InputStream, fileName, postedFile.ContentType);
                        attachmentList.Add(newAttachment);
                    }
                }
            }

            return attachmentList.ToArray();
        }

       

        /// <summary>
        /// Gets the email address or the contact person for provided municipality (kommune)
        /// </summary>
        /// <param name="municipality"></param>
        /// <returns></returns>
        protected string GetEmailForMunicipality(string municipality)
        {
            if (contactPersonList == null || contactPersonList.Count == 0)
            {
                ContactPerson.PopulateContactPersonList(contactPersonList);
            }

            foreach (ContactPerson contactPerson in contactPersonList)
            {
                if (contactPerson.Municipality.Equals(municipality, StringComparison.InvariantCultureIgnoreCase))
                {
                    return contactPerson.Email;
                }
            }

            return null;
        }

        #endregion

        #region Language handling
        /// <summary>
        /// Returns the current language string for a specified xml language file entry.
        /// </summary>
        /// <param name="xmlPath">The path to the string in the xml file.</param>
        /// <returns></returns>
        protected static string GetLanguageString(string xmlPath)
        {
            return EPiServer.Core.LanguageManager.Instance.Translate(xmlPath, GetCurrentLanguage());
        }

        /// <summary>
        /// Returns the current language as a two letter code (no or en for instance).
        /// </summary>
        /// <returns></returns>
        protected static string GetCurrentLanguage()
        {
            return EPiServer.Globalization.ContentLanguage.PreferredCulture.Name;
        }
        #endregion

        
    }

    
}
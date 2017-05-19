using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Configuration;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.IO;


namespace UAVBusiness.Common
{
    public class FlexiMail
    {
        #region Constructors-Destructors
        public FlexiMail()
        {
            //set defaults 
            myEmail = new System.Net.Mail.MailMessage();
            _MailBodyManualSupply = false;
        }
        //public void Dispose()
        //{
        //    base.Finalize();
        //    myEmail.Dispose();
        //}
        #endregion
        #region  Class Data
        private string _From;
        private string _FromName;
        private string _To;
        private string _ToList;
        private string _Subject;
        private string _CC;
        private string _CCList;
        private string _BCC;
        private string _TemplateDoc;
        private string[] _ArrValues;
        private string _BCCList;
        private bool _MailBodyManualSupply;
        private string _MailBody;
        private string _Attachment;
        private System.Net.Mail.MailMessage myEmail;

        #endregion
        #region Propertie
        public string From
        {
            set { _From = value; }
        }
        public string FromName
        {
            set { _FromName = value; }
        }
        public string To
        {
            set { _To = value; }
        }
        public string Subject
        {
            set { _Subject = value; }
        }
        public string CC
        {
            set { _CC = value; }
        }
        public string BCC
        {

            set { _BCC = value; }
            // set { _BCC = "sharma.vipin@dotsquares.com"; }
        }
        public bool MailBodyManualSupply
        {

            set { _MailBodyManualSupply = value; }
        }
        public string MailBody
        {
            set { _MailBody = value; }
        }
        public string EmailTemplateFileName
        {
            //FILE NAME OF TEMPLATE ( MUST RESIDE IN ../EMAILTEMPLAES/ FOLDER ) 
            set { _TemplateDoc = value; }
        }
        public string[] ValueArray
        {
            //ARRAY OF VALUES TO REPLACE VARS IN TEMPLATE 
            set { _ArrValues = value; }
        }

        public string AttachFile
        {
            set { _Attachment = value; }
        }

        #endregion
        #region SEND EMAIL

        public void Send()
        {
           
            try
            {
                myEmail.IsBodyHtml = true;

                //set mandatory properties 
                if (_From == "")
                {
                    _FromName = "";
                    _From = "";
                    myEmail.From = new MailAddress(_From, _FromName);
                }
                else
                {
                    if (_FromName == "")
                        _FromName = _From;
                    myEmail.From = new MailAddress(_From, _FromName);
                }
                myEmail.Subject = _Subject;

                //---Set recipients in To List 
                _ToList = _To.Replace(";", ",");
                if (_ToList != "")
                {
                    string[] arr = _ToList.Split(',');
                    myEmail.To.Clear();
                    if (arr.Length > 0)
                    {
                        foreach (string address in arr)
                        {
                            myEmail.To.Add(new MailAddress(address));
                        }
                    }
                    else
                    {
                        myEmail.To.Add(new MailAddress(_ToList));
                    }
                }

              
              

                //---Set recipients in CC List 
                _CCList = _CC.Replace(";", ",");
                if (_CCList != "")
                {
                    string[] arr = _CCList.Split(',');
                    myEmail.CC.Clear();
                    if (arr.Length > 0)
                    {
                        foreach (string address in arr)
                        {
                            myEmail.CC.Add(new MailAddress(address));
                        }
                    }
                    else
                    {
                        myEmail.CC.Add(new MailAddress(_CCList));
                    }
                }


            
               //---Set recipients in BCC List 
                _BCCList = _BCC.Replace(";", ",");
                if (_BCCList != "")
                {
                    string[] arr = _BCCList.Split(',');
                    myEmail.Bcc.Clear();
                    if (arr.Length > 0)
                    {
                        foreach (string address in arr)
                        {
                            myEmail.Bcc.Add(new MailAddress(address));
                        }
                    }
                    else
                    {
                        myEmail.Bcc.Add(new MailAddress(_BCCList));
                    }
                }
              
                //set mail body 
                if (_MailBodyManualSupply)
                {
                    myEmail.Body = _MailBody;
                }
                else
                {
                    myEmail.Body = GetHtml(_TemplateDoc);
                    // & GetHtml("EML_Footer.htm") 
                }

                // set attachment 
                if (!string.IsNullOrEmpty( _Attachment))
                {
                    Attachment objAttach = new Attachment(_Attachment);
                    myEmail.Attachments.Add(objAttach);
                }



                //Send mail 
                SmtpClient client = new SmtpClient();

                client.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                // client.Credentials = new System.Net.NetworkCredential("peter.rodic@gmail.com", "peter123");
                //SmtpClient client = new SmtpClient();
                ///  client.Credentials = new System.Net.NetworkCredential(ConfigurationSettings.AppSettings["gmailUserid"].ToString(), ConfigurationSettings.AppSettings["gmailpassword"].ToString());
                //client.Host = ConfigurationSettings.AppSettings["gmailSMTP"].ToString();
                //client.Port = Convert.ToInt32(ConfigurationSettings.AppSettings["gmailPort"].ToString()); ;
                client.EnableSsl = true;
                // client.UseDefaultCredentials = false;
                client.Timeout = 18000000;
                ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                client.Send(myEmail);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        #region GetHtml

        public string GetHtml(string argTemplateDocument)
        {
            int i;
            StreamReader filePtr;
            string fileData = "";
            filePtr = File.OpenText(argTemplateDocument);
            //filePtr = File.OpenText(HttpContext.Current.Server.MapPath(ConfigurationSettings.AppSettings["EMLPath"]) + "/" + argTemplateDocument);
            fileData = filePtr.ReadToEnd();

            if ((_ArrValues == null))
            {
                //return fileData;
            }
            else
            {
                for (i = _ArrValues.GetLowerBound(0); i <= _ArrValues.GetUpperBound(0); i++)
                {
                    fileData = fileData.Replace("@v" + i.ToString() + "@", (string)_ArrValues[i]);
                }
                //return fileData;
            }

            filePtr.Close();
            filePtr = null;
            return fileData;
        }

        public string SetValues(string Body)
        {
            int i;
            // StreamReader filePtr;
            string fileData = Body;
            //filePtr = File.OpenText(argTemplateDocument);
            //filePtr = File.OpenText(HttpContext.Current.Server.MapPath(ConfigurationSettings.AppSettings["EMLPath"]) + "/" + argTemplateDocument);
            // fileData = filePtr.ReadToEnd();

            if ((_ArrValues == null))
            {
                //return fileData;
            }
            else
            {
                for (i = _ArrValues.GetLowerBound(0); i <= _ArrValues.GetUpperBound(0); i++)
                {
                    fileData = fileData.Replace("@v" + i.ToString() + "@", (string)_ArrValues[i]);
                }
                //return fileData;
            }

            //filePtr.Close();
            //filePtr = null;
            return fileData;
        }
        #endregion
    }
}


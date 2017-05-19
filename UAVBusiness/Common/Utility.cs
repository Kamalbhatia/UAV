using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Drawing;
using System.Collections;
using System.Globalization;
using UAVBusiness.Common;



namespace UAVBusiness.Common
{
    public static class Utility
    {
        public static DateTime ConvertddMMyyyyToDatetime(string ddMMyyyydateString)
        {
            string[] formate = ddMMyyyydateString.ToString().Split('/');
            string newdate = formate[1] + "/" + formate[0] + "/" + formate[2];
            return Convert.ToDateTime(newdate);
        }
        public static string ConvertDatetimeToddMMyyyy(DateTime? objDateTime)
        {
            if (objDateTime.HasValue)
                return objDateTime.Value.ToString("dd/MM/yyyy");
            else
                return "N/A";
        }

         public static bool SendMailWithTemplate(string emailFrom, string FromName, string emailTo, string emailCC, string emailBCC, string emailsubject, string templateFileName, string[] val)
        {
            bool result = false;
            try
            {
                FlexiMail objmail = new FlexiMail();
                objmail.From = emailFrom;
                objmail.To = emailTo;
                objmail.CC = emailCC;
                objmail.BCC = emailBCC;
                objmail.FromName = FromName;
                objmail.MailBodyManualSupply = false;
                objmail.Subject = emailsubject; ;
                objmail.EmailTemplateFileName =  HttpContext.Current.Server.MapPath("~/Template/" + templateFileName + "");
                objmail.ValueArray = val;
                objmail.Send();
                result = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }

        public static bool SendMail(string emailFrom, string FromName, string emailTo, string emailCC, string emailBCC, string emailsubject, string emailbody, string[] val, string AttachFile)
        {
            bool result = false;
            try
            {
                FlexiMail objmail = new FlexiMail();
                objmail.From = emailFrom;
                objmail.To = emailTo;
                objmail.CC = emailCC;
                objmail.BCC = emailBCC;
                objmail.FromName = FromName;
                objmail.Subject = emailsubject;
                objmail.MailBodyManualSupply = true;
                objmail.AttachFile = AttachFile;
                objmail.ValueArray = val;
           
                objmail.MailBody = objmail.SetValues(emailbody);
                objmail.Send();
                result = true;
            }
            catch (Exception ex)
            {
                //result = false;
                //string inputdata = "false";
                //ErrorLogBusiness objerrorlog = new ErrorLogBusiness();
                //objerrorlog.InsertErrorLog("CustomerSignUpMail", inputdata, ex.Message);
                throw ex;
            }
            return result;
        }

        public static string GetHtml(string argTemplateDocument)
        {
            return System.IO.File.ReadAllText(argTemplateDocument);
        }

    



        //public Image byteArrayToImage(byte[] byteArrayIn)
        //{
        //    MemoryStream ms = new MemoryStream(byteArrayIn);
        //    Image returnImage = Image.FromStream(ms);
        //    return returnImage;

        //}
    }
}




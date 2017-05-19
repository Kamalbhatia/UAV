using UAVBusiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace UAVBusiness.Common
{


    public class TResponse
    {
        public object ResponsePacket { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }
    }

    public static class ResponseMessage
    {
        public static string success = "Success";
        public static string fail = "Fail";

        //MEMBERSHIP
        public static string DuplicateUserName = "User name already exists. Please enter a different user name.";
        public static string DuplicateEmail = "An email for that e-mail address already exists. Please enter a different e-mail address.";
        public static string InvalidPassword = "The password provided is invalid. Please enter a valid password value.";
        public static string InvalidEmail = "The e-mail address provided is invalid. Please check the value and try again.";
        public static string InvalidQuestion = "The password retrieval question provided is invalid. Please check the value and try again.";
        public static string InvalidAnswer = "The password retrieval answer provided is invalid. Please check the value and try again.";
        public static string InvalidUserName = "User name already exists. Please enter a different user name.";
        public static string ProviderError = "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
        public static string UserRejected = "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
        public static string EmployerUpdated = "Employer detail successfully updated";
        public static string DefaultError = "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
        public static string ItemNotFound = "Item for you requested is either deleted or invalid";
        public static string TokenNotFound = "Token does not exist";
        public static string InvalidEmailPassword = "Invalid email and password";
    }

    public static class ResponseStaus
    {
        public static int warning = -1;
        public static int ok = 200;
        public static int error = 201;
        public static int invalidSession = 202;
        public static int sessionExpire = 203;
        public static int notAjaxRequest = 204;
        public static int companyUserRedirect = 205;
        public static int badRequest = 400;
        public static int unauthorized = 401;
        public static int notFound = 404;
    }










}



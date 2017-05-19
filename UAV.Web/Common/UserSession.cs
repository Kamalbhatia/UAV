using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UAV.Web.Common
{
    public static class UserSession
    {
        public static string UserType { get; set; }
        public static long UserId { get; set; }
        public static string UserName { get; set; }
        public static string UserEmail { get; set; }
    }
}
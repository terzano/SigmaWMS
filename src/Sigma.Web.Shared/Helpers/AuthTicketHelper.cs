using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using FormsAuthenticationExtensions;
using Sigma.Domain.Identity;

namespace Sigma.Web.Helpers
{
    public class AuthTicketHelper
    {
        public static NameValueCollection GetStructuredUserData(IPrincipal user)
        {
            var ticketData = ((FormsIdentity)user.Identity).Ticket.GetStructuredUserData();
            return ticketData;
        }

        public static string GetStructuredUserData(IPrincipal user, string keyName)
        {
            var ticketData = GetStructuredUserData(user);
            return ticketData[keyName];
        }

        public static string GetStructuredUserData(IPrincipal user, TicketUserData keyName)
        {
            var ticketData = GetStructuredUserData(user);
            return ticketData[keyName.ToString()];
        }

        public static bool AuthTicketExists(IPrincipal user)
        {
            var ticketData = GetStructuredUserData(user);
            return (ticketData != null);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using HwaDualFactorAuth_Netv48.Models;
using System.Globalization;
using System.Text.RegularExpressions;
using PhoneNumbers;

namespace HwaDualFactorAuth_Netv48.Account
{
    public partial class AddPhoneNumber : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListItem l1 = new ListItem("----Select Country Code----", "none");
                ddlCountry.Items.Add(l1);
                ddlCountry.Items.Add(new ListItem("United States", "+1"));
                ddlCountry.Items.Add(new ListItem("Canada", "+1"));
                ddlCountry.Items.Add(new ListItem("India", "+91"));
            }
        }
        protected bool IsValidPhoneNumber(string phoneNumber)
        {
            if (ddlCountry.SelectedValue.Contains("none"))
            {
                lblphone.Visible = true;
                lblphone.Text = "Please select Country code..";
                return false;
            }
            // Regex to check valid phone number.
            string pattern = @"^[+]{1}(?:[0-9\\-\\(\\)\\/" +
                              "\\.]\\s?){6,15}[0-9]{1}$";

            // If the phone number is empty return false
            if (string.IsNullOrEmpty(phoneNumber))
            {
                return false;
            }

            // Return true if the phone number
            // matched the Regex
            if (Regex.IsMatch(phoneNumber, pattern))
            {
                return true;
            }
            else
            {
                return false;
            }            
        }
      
        protected void PhoneNumber_Click(object sender, EventArgs e)
        {                  
            if (!IsValidPhoneNumber(PhoneNumber.Text.Trim()))
            {
                lblphone.Visible = true;
                lblphone.Text = "Invalid Phone Number..";
                return;
            }
           
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
           
            var code = manager.GenerateChangePhoneNumberToken(User.Identity.GetUserId(), (ddlCountry.SelectedValue + PhoneNumber.Text.Trim()));
            
            if (manager.SmsService != null)
            {
                var message = new IdentityMessage
                {
                    Destination =  PhoneNumber.Text,
                    Body = "Your security code is " + code
                };
                manager.SmsService.Send(message);
            }

            Response.Redirect("/Account/VerifyPhoneNumber?PhoneNumber=" + HttpUtility.UrlEncode(PhoneNumber.Text));
        }
    }
}
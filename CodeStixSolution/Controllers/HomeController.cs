using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CodeStixSolution.Models;
using CodeStixSolution.DAL;
using System.IO;
using System.Configuration;

namespace CodeStixSolution.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Feedback(GeneralModol vmGeneral)
        {

            GeneralBTO objGeneral = new GeneralBTO();
            int returnValue = 0;

            objGeneral.CommenterName = vmGeneral.CommentBTO.CommenterName;
            objGeneral.Email = vmGeneral.CommentBTO.Email;
            objGeneral.PhoneNumber = vmGeneral.CommentBTO.PhoneNumber;
            objGeneral.Comments = vmGeneral.CommentBTO.Comments;

            bool varEmailSent = false;


            // StringBuilder sbBodyMessage = new StringBuilder();
            string varFromDisplayName = string.Empty;
            string varToDisplayName = string.Empty;
            string varFromEmail = string.Empty;
            string varToEmail = string.Empty;
            string varSubject = string.Empty;
            string varBody = string.Empty;
            string varToBcc = string.Empty;
            string varToCC = string.Empty;
            string varName = string.Empty;
            string varPhone = string.Empty;

            string varAddress = string.Empty;
            string varEmailDetails = string.Empty;
            string varErrorMessage_Email = string.Empty;


            #region :: Email Code Goes Here..

            varSubject = "Feedback Message";
            varFromDisplayName = ConfigurationManager.AppSettings["FromDisplayName"]; // Here It Be Godaddy SecureServernetemailAccount 
            varToDisplayName = ConfigurationManager.AppSettings["ToDisplayName"]; // Here It Is Our Clients Email Id.Like fizutourtravel@gmail.com,xyz@yahoo.com,etc...
            varFromEmail = objGeneral.Email.ToString().Trim(); // Here U Can Add Main Email Id From Which Email is Sent To Our Client's Email Id (Indirectly from Our Relay Hosting Server::as Port No ::25);       
            varToEmail = "arifsahara@gmail.com";
            varName = objGeneral.CommenterName.Replace("'", "''");
            varPhone = objGeneral.PhoneNumber.Replace("'", "''");
            varBody = objGeneral.Comments.Replace("'", "''");

            varEmailDetails = "<B>" + " Name :" + varName +
                "<BR>" + "<B>" + " Email Id :" + varFromEmail +
                "<BR>" + "<B>" + " Phone :" + varPhone +
                "<BR>" + "<B>" + " Message :" + varBody + "<BR>";
            varEmailSent = MailHelper.SendMailMessage(varFromDisplayName, varToDisplayName, varFromEmail, varToEmail, varToBcc, varToCC, varSubject, varEmailDetails.ToString());


            //return varEmailSent;
            #endregion

            //returnValue = News.Product_ContactToPurchase_New(objGeneral);

            return RedirectToAction("Contact");
        }

    }
}

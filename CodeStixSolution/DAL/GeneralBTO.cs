using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeStixSolution.DAL
{
    public class GeneralBTO
    {

        public string ContactNo { get; set; }
        public string MobileNo { get; set; }
        public string EmailAddress { get; set; }


        #region Property Definitions

        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "Name is required")]
        [StringLength(55)]
        public string CommenterName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "Address is required")]
        [StringLength(500)]
        public string Address { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "Phone Number is required")]
        [StringLength(25)]
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Invalid Email Format")]
        [StringLength(55)]
        public string Email { get; set; }
        /// <summary>
        /// 
        /// </summary>  
        [Required(ErrorMessage = "Comments is required")]
        [StringLength(500)]
        public string Comments { get; set; }
        /// <summary>
        /// 
        /// </summary>      
        public string StatusError { get; set; }



        #endregion

    }
}
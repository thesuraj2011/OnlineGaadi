using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineGaadi.Models
{
    public class DriverRegistrationProp
    {
        [Required(ErrorMessage = "Please enter Full Name")]
        [Display(Name = "Full Name")]
        [StringLength(150)]
        public string DriverName { get; set; }

        [Required(ErrorMessage = "Please enter Mobile Number")]
        [Display(Name = "Mobile Number")]
        [StringLength(15)]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "Please enter Vehicle Number")]
        [Display(Name = "Vehicle Number")]
        [StringLength(15)]
        public string VehicleNumber { get; set; }

        [Required(ErrorMessage = "Please enter Your Location")]
        [Display(Name = "Your Location")]
        [StringLength(30)]
        public string PickupLocation { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [Display(Name = "Password")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm password")]
        [Display(Name = "Confirm Password")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

    }
}

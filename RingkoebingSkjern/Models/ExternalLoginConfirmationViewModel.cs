using System.ComponentModel.DataAnnotations;

namespace RingkoebingSkjern.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
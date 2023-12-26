using System.ComponentModel.DataAnnotations;

namespace BookAPI.Models
{
    public class SignUpModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        
        [Required,EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [MinLength(8, ErrorMessage = "Length of password should be atleat 8 ")]
        //[RegularExpression("")]
        public string Password {  get; set; }
        [Required]
        [Compare("Password",ErrorMessage ="Password don't match")]
        public string ConfirmPassword {  get; set; }
        
    }
}

using System.ComponentModel.DataAnnotations;

namespace TARge25Shop.Models.Email
{
    public class EmailViewModel
    {

        [Required]
        public string To { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public List<IFormFile> Attachments { get; set; } = new List<IFormFile>();
   


     }
}

using System.ComponentModel.DataAnnotations;

namespace ServicesPlatform.DTOs.Writable
{
    public class  PlatformCreateDTOW
    {
        
        [Required]
        public string Name { get; set; }
         [Required]
        public string Publisher { get; set; }
         [Required]
        public string Cost { get; set; }
    }
}
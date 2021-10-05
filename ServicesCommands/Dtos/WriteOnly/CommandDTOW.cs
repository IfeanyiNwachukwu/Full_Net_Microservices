using System.ComponentModel.DataAnnotations;

namespace ServicesCommands.Dtos.WriteOnly
{
    public class CommandDTOW
    {
       [Required]
        public string HowTo { get; set; }
        [Required]
        public string CommandLine { get; set; }
    }
}
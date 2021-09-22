using System.ComponentModel.DataAnnotations;

namespace CommandsService.Models
{
    public class Command
    {

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string HowTo { get; set; }

        [Required]
        public string CommandLine { get; set; }

        [Required]
        public int PlatformID { get; set; }
        public Platform Platform { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace CamCecilCom.Models
{
    public class User
    {
        [Key]
        public string Id { get; set; }
        public string Username { get; set; }
    }
}

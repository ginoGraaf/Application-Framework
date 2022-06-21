using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SetupApplication.models
{
    public class UserModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Passowrd { get; set; }
        public string Email     { get; set; }

    }
}

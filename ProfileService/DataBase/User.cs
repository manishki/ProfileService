using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProfileService.DataBase
{
    [Table("Users")]
    public class User
    {
        [Key]
        [Column("user_id")]
        public Guid Id { get; set; }
        public string Name  { get; set; }
        public string EmailId { get; set; }
        public string Password { get; set; }
        public string ImageUrl { get; set; }
        public string ContectNumber { get; set; }

        public override string ToString()
        {
            return Id.ToString();
        }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        [Index(IsUnique = true)]
        [StringLength(450)]
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
    }
}

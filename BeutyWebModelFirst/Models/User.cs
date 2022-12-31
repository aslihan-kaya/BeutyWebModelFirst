using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BeutyWebModelFirst.Models
{
    public class User
    {
        [Required]
        public string MemberName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string MemberPassword { get; set; }
    }
}
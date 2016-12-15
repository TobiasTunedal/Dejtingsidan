using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dejtingsida.Models
{
    public class PersonInformationModel
    {
        [Key]
        public virtual int PersonID { get; set; }

        [Required]
        public virtual string Förnamn { get; set; }
        [Required]
        public virtual string Efternamn { get; set; }
        [Required]
        public virtual int  Ålder { get; set; }
        [Required]
        public virtual string Stad { get; set; }
        [Required]
        [StringLength(250, MinimumLength = 3)]
        public virtual string Fakta { get; set; }
    }
}
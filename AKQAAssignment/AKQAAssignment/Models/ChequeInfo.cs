using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AKQAAssignment.Models
{
    public class ChequeInfo
    {
        public ChequeInfo()
        {
            AmountInWords = string.Empty;
        }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter name for cheque")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(AllowEmptyStrings =false)]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }

        public string AmountInWords { get; set; }

    }
}
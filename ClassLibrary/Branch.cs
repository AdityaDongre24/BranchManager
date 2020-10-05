using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ClassLibrary
{
    public class Branch
    {
        public int Id { get; set; }

        [Required]
        public string BranchName { get; set; }

        [Required]
        public string IFSCCode { get; set; }

        [Required]
        public int Bank { get; set; }

        [Required]
        public int District { get; set; }

        [Required]
        public int State { get; set; }

    }
}

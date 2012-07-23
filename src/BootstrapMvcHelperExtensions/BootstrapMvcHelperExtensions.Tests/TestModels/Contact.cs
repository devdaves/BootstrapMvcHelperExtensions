namespace BootstrapMvcHelperExtensions.Tests.TestModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.ComponentModel.DataAnnotations;

    public class Contact
    {
        public int Id { get; set; }

        [Display(Name="First Name")]
        [Required]
        public string FirstName { get; set; }
    }
}

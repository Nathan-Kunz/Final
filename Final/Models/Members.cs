using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Final.Models
{
    public partial class Members
    {
        public long MemberId { get; set; }
        public string MbrFirstName { get; set; }
        public string MbrLastName { get; set; }
        public string MbrPhoneNumber { get; set; }
        public string Gender { get; set; }
    }
}

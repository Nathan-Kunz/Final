using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Final.Models
{
    public partial class Entertainers
    {
        public long EntertainerId { get; set; }
        public string EntStageName { get; set; }
        public string EntSsn { get; set; }
        public string EntStreetAddress { get; set; }
        public string EntCity { get; set; }
        public string EntState { get; set; }
        public string EntZipCode { get; set; }
        public string EntPhoneNumber { get; set; }
        public string EntWebPage { get; set; }
        public string EntEmailAddress { get; set; }
        public string DateEntered { get; set; }
    }
}

using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Final.Models
{
    public partial class Engagements
    {
        public long EngagementNumber { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string StartTime { get; set; }
        public string StopTime { get; set; }
        public byte[] ContractPrice { get; set; }
        public long? CustomerId { get; set; }
        public long? AgentId { get; set; }
        public long? EntertainerId { get; set; }
    }
}

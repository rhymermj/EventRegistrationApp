//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EventRegistrationApplication.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Event
    {
        public string EventName { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
        public string Date { get; set; }
        public Nullable<double> TicketFee { get; set; }
    }
}

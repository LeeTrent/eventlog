
using System;
using System.ComponentModel.DataAnnotations;

namespace lmsextreg.Models
{
    public class EventType
    {   
        ////////////////////////////////////////////////////////////
        // EventTypeID:
        // Primary-key (auto-generated)
        ////////////////////////////////////////////////////////////        
        [Required]
        public int EventTypeID { get; set; }

        [Required]
        [Display(Name = "Event Type Code")]
        public string EventTypeCode { get; set; }
        
        [Required]
        [Display(Name = "Event Type")]
        public string EventTypeLabel { get; set; }      
    }
}
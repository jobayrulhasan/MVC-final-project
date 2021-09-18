//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinalPorjectDatabaseFirst3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class ScheduleDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ScheduleDetail()
        {
            this.BookingDetails = new HashSet<BookingDetail>();
        }
        [DisplayName("Schedule Details No.")]
        public int ScheduleDetailsId { get; set; }
        [DisplayName("Seat Number")]
        public string SeatNo { get; set; }
        public Nullable<int> BusId { get; set; }
        public Nullable<int> ScheduleId { get; set; }
        public string ScheduleStatus { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
        public virtual Bus Bus { get; set; }
        public virtual Schedule Schedule { get; set; }
    }
}

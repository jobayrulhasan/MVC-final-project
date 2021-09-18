
namespace FinalPorjectDatabaseFirst3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class Schedule
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Schedule()
        {
            this.BookingDetails = new HashSet<BookingDetail>();
            this.ScheduleDetails = new HashSet<ScheduleDetail>();
        }
        [DisplayName("Schedule")]
        public int ScheduleId { get; set; }
        [DisplayName("Departure Time")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public Nullable<System.DateTime> DepartureTime { get; set; }
        [DisplayName("Arrival Time")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public Nullable<System.DateTime> ArrivalTime { get; set; }
        public Nullable<int> RouteId { get; set; }
        [DisplayName("Actula Departure Time")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public DateTime ActualDepartureTime { get; set; }
        [DisplayName("Actual Arrival Time")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd HH:mm}")]
        public Nullable<System.DateTime> ActualArrivalTime { get; set; }
        [DisplayName("Schedule Cancel")]
        public Nullable<bool> ScheduleCancel { get; set; }
        [DisplayName("Bus Status")]
        public string BusStatus { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
        public virtual Route Route { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ScheduleDetail> ScheduleDetails { get; set; }
    }
}

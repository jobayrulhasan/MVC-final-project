
namespace FinalPorjectDatabaseFirst3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class Route
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Route()
        {
            this.Schedules = new HashSet<Schedule>();
        }
    
        public int RouteId { get; set; }
        [DisplayName("Route Name")]
        public string RouteName { get; set; }
        [DisplayName("Start Point")]
        public string StartPoint { get; set; }
        [DisplayName("End Point")]
        public string EndPoint { get; set; }
        public Nullable<int> BusId { get; set; }
        [DisplayName("Unit Price")]
        public Nullable<decimal> UnitPrice { get; set; }
    
        public virtual Bus Bus { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Real_State_project.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class projects
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public projects()
        {
            this.feedback = new HashSet<feedback>();
            this.hiringRequest = new HashSet<hiringRequest>();
            this.projectdetails = new HashSet<projectdetails>();
            this.projectRequest = new HashSet<projectRequest>();
            this.projectteams = new HashSet<projectteams>();
        }
    
        public int id { get; set; }
        public string titel { get; set; }
        public string description { get; set; }
        public Nullable<int> customerid { get; set; }
        public byte[] time_ { get; set; }
        public Nullable<int> statusid { get; set; }
        public Nullable<int> progressstatus { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<feedback> feedback { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<hiringRequest> hiringRequest { get; set; }
        public virtual progress progress { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<projectdetails> projectdetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<projectRequest> projectRequest { get; set; }
        public virtual users users { get; set; }
        public virtual status status { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<projectteams> projectteams { get; set; }
    }
}

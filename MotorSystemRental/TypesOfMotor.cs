//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MotorSystemRental
{
    using System;
    using System.Collections.Generic;
    
    public partial class TypesOfMotor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TypesOfMotor()
        {
            this.MotorRentalRecords = new HashSet<MotorRentalRecord>();
        }
    
        public int id { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public string vin { get; set; }
        public Nullable<int> year { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MotorRentalRecord> MotorRentalRecords { get; set; }
    }
}

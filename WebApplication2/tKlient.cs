//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication2
{
    using System;
    using System.Collections.Generic;
    
    public partial class tKlient
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tKlient()
        {
            this.tBron_nomera = new HashSet<tBron_nomera>();
        }
    
        public string Imya { get; set; }
        public string Familiya { get; set; }
        public int ID_Klient { get; set; }
        public System.DateTime Data_zaseleniya { get; set; }
        public System.DateTime Data_viseleniya { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tBron_nomera> tBron_nomera { get; set; }
    }
}

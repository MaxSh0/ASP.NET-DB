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
    
    public partial class tBron_nomera
    {
        public int ID_Nomer { get; set; }
        public Nullable<int> ID_Rabotnika { get; set; }
        public int ID_Klient { get; set; }
        public System.DateTime Data_zaseleniya { get; set; }
        public System.DateTime Data_viseleniya { get; set; }
    
        public virtual tKlient tKlient { get; set; }
        public virtual tNomer tNomer { get; set; }
        public virtual tSotrudnik tSotrudnik { get; set; }
    }
}

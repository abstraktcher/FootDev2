//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FootDev2.AppData
{
    using System;
    using System.Collections.Generic;
    
    public partial class StatusOfLanguage
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StatusOfLanguage()
        {
            this.LanguageToPlayer = new HashSet<LanguageToPlayer>();
        }
    
        public byte IdStatus { get; set; }
        public string StatusName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LanguageToPlayer> LanguageToPlayer { get; set; }
    }
}
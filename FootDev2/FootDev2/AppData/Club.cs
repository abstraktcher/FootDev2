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
    
    public partial class Club
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Club()
        {
            this.TrainToTeam = new HashSet<TrainToTeam>();
        }
    
        public int IdClub { get; set; }
        public string ClubName { get; set; }
        public byte[] LogoClub { get; set; }
        public Nullable<int> IdCoach { get; set; }
    
        public virtual Personnel Personnel { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrainToTeam> TrainToTeam { get; set; }
    }
}

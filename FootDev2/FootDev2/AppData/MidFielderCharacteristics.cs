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
    
    public partial class MidFielderCharacteristics
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MidFielderCharacteristics()
        {
            this.PlayerToMFCharacteristics = new HashSet<PlayerToMFCharacteristics>();
        }
    
        public int IdMDFChar { get; set; }
        public byte DribblingMF { get; set; }
        public byte PaceMF { get; set; }
        public byte LongShotsMF { get; set; }
        public byte PenaltyMF { get; set; }
        public byte PassingMF { get; set; }
        public byte CornersMF { get; set; }
        public byte AgilityMF { get; set; }
        public byte MarkingMF { get; set; }
        public byte FitnessMF { get; set; }
        public byte ConcentrationMF { get; set; }
        public byte HeightMF { get; set; }
        public byte WeightMF { get; set; }
        public byte LeadershipMF { get; set; }
        public byte StaminaMF { get; set; }
        public byte FreeKickMF { get; set; }
        public byte StrengthMF { get; set; }
        public byte TechniqueMF { get; set; }
        public byte TeamWorkMF { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlayerToMFCharacteristics> PlayerToMFCharacteristics { get; set; }
    }
}

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
    
    public partial class Injuries
    {
        public int IdPlayer { get; set; }
        public string Fullname { get; set; }
        public Nullable<byte> Age { get; set; }
        public string InjuryName { get; set; }
        public Nullable<System.DateTime> DateOfInjury { get; set; }
        public Nullable<System.DateTime> DateOfRecovery { get; set; }
        public string Treatment { get; set; }
    }
}

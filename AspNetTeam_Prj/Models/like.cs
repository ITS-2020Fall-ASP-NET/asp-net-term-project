//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AspNetTeam_Prj.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class like
    {
        public int like_id { get; set; }
        public int user_id { get; set; }
        public int item_id { get; set; }
    
        public virtual User User { get; set; }
    }
}
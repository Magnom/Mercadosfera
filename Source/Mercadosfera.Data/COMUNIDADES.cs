//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Mercadosfera.Data
{
    using System;
    using System.Collections.Generic;
     using System.Runtime.Serialization;
    [Serializable]
[DataContract] public partial class COMUNIDADES
    {
        public COMUNIDADES()
        {
            this.LOCALIDADES = new HashSet<LOCALIDADES>();
        }
    
        [DataMember] public int ID { get; set; }
        [DataMember] public Nullable<int> IdPais { get; set; }
        [DataMember] public string Descripcion { get; set; }
        [DataMember] public string Create_id { get; set; }
        [DataMember] public Nullable<System.DateTime> Create_dt { get; set; }
        [DataMember] public string Update_id { get; set; }
        [DataMember] public Nullable<System.DateTime> Update_dt { get; set; }
        [DataMember] public string Delete_id { get; set; }
        [DataMember] public Nullable<System.DateTime> Delete_dt { get; set; }
        [DataMember] public string Url { get; set; }
    
        [DataMember] public virtual PAISES PAISES { get; set; }
        [DataMember] public virtual ICollection<LOCALIDADES> LOCALIDADES { get; set; }
    }
}

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
[DataContract] public partial class VENDEDORES
    {
        [DataMember] public string OrchardId { get; set; }
        [DataMember] public Nullable<int> Estado { get; set; }
        [DataMember] public string Nombre { get; set; }
        [DataMember] public string Direccion { get; set; }
        [DataMember] public int TipoCuenta { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace UPMSForEfashion.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class user
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string RealName { get; set; }
        public string UserPwd { get; set; }
        public Nullable<bool> Sex { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Address { get; set; }
        public string Comment { get; set; }
        public bool IsDeleted { get; set; }
        public System.DateTime CreateTime { get; set; }
        public System.DateTime UpdateTime { get; set; }
        public string UserCode { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HotelManagement
{
    using System;
    using System.Collections.Generic;
    
    public partial class webpages_Roles
    {
        public webpages_Roles()
        {
            this.webpages_UsersInRoles = new HashSet<webpages_UsersInRoles>();
            this.webpages_UsersInRoles1 = new HashSet<webpages_UsersInRoles>();
            this.webpages_UsersInRoles2 = new HashSet<webpages_UsersInRoles>();
        }
    
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    
        public virtual ICollection<webpages_UsersInRoles> webpages_UsersInRoles { get; set; }
        public virtual ICollection<webpages_UsersInRoles> webpages_UsersInRoles1 { get; set; }
        public virtual ICollection<webpages_UsersInRoles> webpages_UsersInRoles2 { get; set; }
    }
}

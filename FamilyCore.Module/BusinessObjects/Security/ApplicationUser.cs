using System.Collections.ObjectModel;
using System.ComponentModel;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Security;
using DevExpress.Persistent.BaseImpl.EF.PermissionPolicy;

namespace FamilyCore.Module.BusinessObjects;

[DefaultProperty(nameof(UserName))]
public class ApplicationUser : PermissionPolicyUser {
    public ApplicationUser() : base() {
    }

    public virtual string FirstName { get; set; }
    public virtual string LastName { get; set; }
    public virtual string MainPhone { get; set; }
    public virtual string Extension { get; set; }
}

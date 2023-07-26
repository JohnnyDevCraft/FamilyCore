using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using FamilyCore.Module.Constants;
using FamilyCore.Module.Enumerations;

namespace FamilyCore.Module.BusinessObjects.Contacts;

public class PayeeContact : BaseObject
{
    public virtual string FirstName { get; set; }
    public virtual string LastName { get; set; }
    public virtual string Email { get; set; }
    public virtual string OfficePhone { get; set; }
    public virtual string OfficeExtension { get; set; }
    public virtual string FaxLine { get; set; }
    public virtual string CellPhone { get; set; }
    public virtual string JobTitle { get; set; }

    public virtual Payee Payee { get; set; }
}
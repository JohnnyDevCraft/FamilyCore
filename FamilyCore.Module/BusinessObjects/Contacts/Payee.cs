using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DevExpress.ExpressApp.DC;
using FamilyCore.Module.BusinessObjects.Shared;
using FamilyCore.Module.Constants;
using FamilyCore.Module.Enumerations;

namespace FamilyCore.Module.BusinessObjects.Contacts;

public class Payee : BaseObject
{
    public virtual string FirstName { get; set; }
    public virtual string LastName { get; set; }
    public virtual string CompanyName { get; set; }
    public virtual PayeeType Type { get; set; }
    
    public virtual Address BillingAddress { get; set; }
    public virtual Address ShippingAddress { get; set; }
    public virtual string MainPhone { get; set; }
    public virtual string Extension { get; set; }
    public virtual string Fax { get; set; }
    public virtual string Email { get; set; }
    public virtual string Website { get; set; }
    
    [FieldSize(FieldSizeAttribute.Unlimited)]
    public virtual string Notes { get; set; }
    
    public virtual string TaxId { get; set; }

    public virtual IList<PayeeContact> PayeeContacts { get; set; } = new ObservableCollection<PayeeContact>();
    
}
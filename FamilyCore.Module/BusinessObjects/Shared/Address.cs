using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using FamilyCore.Module.Constants;
using FamilyCore.Module.Enumerations;

namespace FamilyCore.Module.BusinessObjects.Shared;

public class Address : BaseObject
{
    public virtual string AddressLine1 { get; set; }
    public virtual string AddressLine2 { get; set; }
    public virtual string City { get; set; }
    public virtual string State { get; set; }
    public virtual string ZipCode { get; set; }
}
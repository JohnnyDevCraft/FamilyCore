using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DevExpress.ExpressApp.DC;
using FamilyCore.Module.BusinessObjects.Contacts;
using FamilyCore.Module.Constants;
using FamilyCore.Module.Enumerations;

namespace FamilyCore.Module.BusinessObjects.Accounting;

public class CommLog : BaseObject
{
    public virtual Account Account { get; set; }
    public virtual PayeeContact Contact { get; set; }
    public virtual DateTime Date { get; set; }
    public virtual string Subject { get; set; }
    
    [FieldSize(FieldSizeAttribute.Unlimited)]
    public virtual string Notes { get; set; }

    [ImageEditor]
    [VisibleInListView(false)]
    [FieldSize(FieldSizeAttribute.Unlimited)]
    public virtual Byte[] Image { get; set; }
}
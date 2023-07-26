using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using DevExpress.ExpressApp.DC;
using FamilyCore.Module.Constants;
using FamilyCore.Module.Enumerations;

namespace FamilyCore.Module.BusinessObjects.Accounting;

public class Transaction : BaseObject
{
    public virtual Account FromAccount { get; set; }
    public virtual Account ToAccount { get; set; }

    public virtual decimal Amount { get; set; }
    public virtual DateTime TransactionDate { get; set; }
    public virtual string Description { get; set; }
    public virtual string ReferenceNumber { get; set; }
    
    [FieldSize(FieldSizeAttribute.Unlimited)]
    public virtual string Notes { get; set; }
    
    public virtual bool? IsReconciled { get; set; }
    public virtual DateTime? ReconciledDate { get; set; }
    public virtual string ReconciledNotes { get; set; }
    
    public virtual TransactionType Type { get; set; }

    [FieldSize(FieldSizeAttribute.Unlimited)]
    [ImageEditor]
    [VisibleInListView(false)]
    public virtual Byte[] Image { get; set; }
}
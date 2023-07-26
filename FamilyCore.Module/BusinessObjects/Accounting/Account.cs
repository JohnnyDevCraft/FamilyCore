using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Xpo;
using FamilyCore.Module.BusinessObjects.Contacts;
using FamilyCore.Module.Enumerations;

namespace FamilyCore.Module.BusinessObjects.Accounting;

public class Account : BaseObject
{
    public virtual string AccountName { get; set; }
    public virtual string Description { get; set; }
    public virtual AccountType Type { get; set; }
    public virtual string AccountNumber { get; set; }
    public virtual string RoutingNumber { get; set; }

    public virtual Payee HeldWith { get; set; }
    [DataSourceProperty("HeldWith.PayeeContacts")]
    public virtual PayeeContact MainContact { get; set; }

    public virtual DateTime? DateOpened { get; set; }
    public virtual DateTime? DateClosed { get; set; }

    public virtual decimal? OpeningAmount { get; set; }

    
    public virtual Payee OriginalCreditor { get; set; }
    
    [DataSourceCriteria("Type = 7")]
    public virtual Payee CurrentCreditor { get; set; }
    public virtual string OriginalId { get; set; }
    public virtual DateTime? OriginDate { get; set; }
    public virtual decimal? DebtInterestRate { get; set; }
    public virtual decimal? OriginalAmount { get; set; }
    public virtual DebtType BadDebtType { get; set; }
    public virtual DateTime? DateServed { get; set; }
    public virtual string CaseNumber { get; set; }
    
    [DataSourceCriteria("Type = 6")]
    public virtual Payee ProsecutingAttorney { get; set; }
    
    public virtual DateTime? DateFiled { get; set; }
    public virtual DateTime? CourtDate { get; set; }
    public virtual DateTime? DateJudgement { get; set; }
    public virtual DateTime? DateSettled { get; set; }
    
    [DataSourceCriteria("Type = 5")]
    public virtual Payee CourtFiledIn { get; set; }

    public virtual decimal? CreditLimit { get; set; }
    public virtual DateTime? NextStatement { get; set; }
    public virtual DateTime? NextPaymentDue { get; set; }
    public virtual decimal? MinimumPayment { get; set; }

    [DataSourceProperty("CurrentCreditor.PayeeContacts")]
    public virtual PayeeContact AccountManager { get; set; }
    public virtual bool AutoNotify { get; set; }

    [NotMapped]
    public decimal Balance => OpeningAmount??0.00M + 
        (Credits.Sum(x => x.Amount) - Debits.Sum(x => x.Amount));

    public virtual IList<Transaction> Credits { get; set; } = new ObservableCollection<Transaction>();
    public virtual IList<Transaction> Debits { get; set; } = new ObservableCollection<Transaction>();

    public virtual IList<CommLog> CommLogs { get; set; } = new ObservableCollection<CommLog>();

    public override void OnSaving()
    {
        base.OnSaving();
        
        if (CurrentCreditor != null)
        {
            HeldWith = CurrentCreditor;
        }
    }
}
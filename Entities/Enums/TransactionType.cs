using System.ComponentModel;

namespace SMJRegisterAPI.Entities.Enums;

public enum TransactionType
{
    [Description("Ingreso")]
    Income=1,
        
    [Description("Egreso")]
    Outcome
}
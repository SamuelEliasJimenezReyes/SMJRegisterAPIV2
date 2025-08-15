using System.ComponentModel;

namespace SMJRegisterAPIV2.Entities.Enums;

public enum TransactionType
{
    [Description("Ingreso")]
    Income=1,
        
    [Description("Egreso")]
    Outcome
}
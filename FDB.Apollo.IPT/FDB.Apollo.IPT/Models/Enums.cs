using System.ComponentModel.DataAnnotations;

namespace FDB.Apollo.IPT.Service.Models
{
    public enum DbContextLocale : short
    {
        None = 0,
        Working = 1,
        Published = 2
    }

    public enum ValidationSeverity : short
    {
        Warning = 1,
        Error = 2,
        Information = 3
    }

    public enum ValidationLocale : short
    {
        Working = 1,
        Published = 2
    }

    public enum FDBWipStatus : short
    {
        Unknown = 0,
        Published = 1,
        Submitted = 2,
        CheckedOut = 3,
        Protected = 4,
    }

    public enum ChangeType : short
    {
        //Add
        A = 1,
        //Change
        C = 2,
        //Delete
        D = 3,
        //Publish
        P = 4,
        //Revert
        R = 5
    }
}

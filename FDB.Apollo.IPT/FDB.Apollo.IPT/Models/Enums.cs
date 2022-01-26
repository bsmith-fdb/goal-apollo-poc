namespace FDB.Apollo.IPT.Service.Models
{
    public static class ExtensionMethods
    {
        public static string DisplayText(this FDBWipStatus status)
        {
            switch (status)
            {
                case FDBWipStatus.Published:
                    return "Published";
                case FDBWipStatus.Submitted:
                    return "Submitted";
                case FDBWipStatus.CheckedOut:
                    return "Checked Out";
                default:
                    return "Unknown";
            }
        }

        public static char GetChar(this ChangeType changeType)
        {
            switch (changeType)
            {
                case ChangeType.Add:
                    return 'A';
                case ChangeType.Change:
                    return 'C';
                case ChangeType.Delete:
                    return 'D';
                case ChangeType.Publish:
                    return 'P';
                case ChangeType.Revert:
                    return 'R';
                default:
                    return '\0';
            }
        }
    }
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
        Add = 1,
        Change = 2,
        Delete = 3,
        Publish = 4,
        Revert = 5
    }
}

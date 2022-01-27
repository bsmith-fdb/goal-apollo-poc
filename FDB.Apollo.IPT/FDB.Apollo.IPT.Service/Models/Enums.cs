using System.Text.Json.Serialization;

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
                case FDBWipStatus.Protected:
                    return "Protected";
                default:
                    throw new ArgumentOutOfRangeException(nameof(status));
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
                    throw new ArgumentOutOfRangeException(nameof(changeType));
            }
        }
    }

    [JsonConverter(typeof(JsonStringEnumConverter))]
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

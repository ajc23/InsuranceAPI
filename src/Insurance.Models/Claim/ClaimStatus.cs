using System.ComponentModel;

namespace Insurance.Models.Claim
{
    public enum ClaimStatus
    {
        [Description("Open")]
        Open,
        [Description("Pending")]
        Pending,
        [Description("Closed")]
        Closed
    }
}

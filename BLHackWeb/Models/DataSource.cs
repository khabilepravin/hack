using System.Collections.Generic;

namespace BLHackWeb.Models
{
    public static class DataSource
    {
        public static List<SubscriptionItem> subscriptionItems = new List<SubscriptionItem>()
        {
            new SubscriptionItem { Id = "1", Name = "Personal Injury", CommentaryFileName = "FULL COMMENTARY - PERSONAL INJURY (NSW).pdf" },
            new SubscriptionItem { Id = "2", Name = "Mortgages", CommentaryFileName = "" }
        };
    }
}

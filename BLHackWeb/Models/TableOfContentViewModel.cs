using PdfLib;
using System.Collections.Generic;

namespace BLHackWeb.Models
{
    public class TableOfContentViewModel
    {
        public SubscriptionItem Subscription { get; set; }
        public IEnumerable<ContentItem> TableOfContents { get; set; }
    }
}

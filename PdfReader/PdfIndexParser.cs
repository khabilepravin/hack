using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;

namespace PdfLib
{
    public class PdfIndexParser
    {
        public static IEnumerable<ContentItem> GetTableOfContents(string input)
        {
            List<ContentItem> contentItems = null;

            if (string.IsNullOrWhiteSpace(input) == false)
            {
                if (input.Contains("Contents"))
                {
                    var contentStuff = input.Substring((input.IndexOf("Contents") + "Contents".Length));

                    var lines = contentStuff.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var line in lines)
                    {
                        if (string.IsNullOrWhiteSpace(line) == false && line.Contains(".."))
                        {
                            var contentItem = new ContentItem();
                            contentItem.Title = line.Substring(0, line.IndexOf("."));
                            contentItem.PageNumber = Convert.ToInt32(line.Substring(line.LastIndexOf(".") + 1));

                            if (contentItems == null) { contentItems = new List<ContentItem>(); }

                            contentItems.Add(contentItem);
                        }
                    }
                }
            }

            return contentItems;
        }

        public static string GetContentPagesText(string pdfFilePath, int numberOfIndexPages)
        {
            using (PdfReader reader = new PdfReader(pdfFilePath))
            {
                string text = string.Empty;
                for (int page = 1; page <= numberOfIndexPages; page++)
                {
                    text += PdfTextExtractor.GetTextFromPage(reader, page);
                }
                reader.Close();

                return text;
            }
        }

        public static string ReadThePage(string pdfFilePath, int pageNumber)
        {
            using (PdfReader reader = new PdfReader(pdfFilePath))
            {
                return PdfTextExtractor.GetTextFromPage(reader, pageNumber);
            }
        }
    }
}

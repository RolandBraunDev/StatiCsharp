using StatiCSharp.Interfaces;

namespace StatiCSharp
{
    public partial class WebsiteManager : IWebsiteManager
    {
        private void MakeTagLists()
        {
            // Collect all available tags
            List<string> tags = new List<string>();
            foreach (ISection currentSection in Website.Sections)
            {
                foreach (IItem currentItem in currentSection.Items)
                {
                    foreach (string tag in currentItem.Tags)
                    {
                        // Check if tag is already in list. If not, add it
                        if (!tags.Contains(tag)) { tags.Add(tag); }
                    }
                }
            }

            // Make a taglist for each tag
            foreach (string tag in tags)
            {
                List<IItem> itemsWithCurrentTag = new();
                // Collect all items with the current tag
                foreach (ISection currentSection in Website.Sections)
                {
                    foreach (IItem item in currentSection.Items)
                    {
                        if (item.Tags.Contains(tag))
                        {
                            itemsWithCurrentTag.Add(item);
                        }
                    }
                }
                // Write tags sites to files
                IItem tagPage = new Item();
                tagPage.Title = $"{tag} | {Website.Name}";
                string body = HtmlFactory.MakeTagListHtml(itemsWithCurrentTag, tag);
                string head = HtmlFactory.MakeHeadHtml();
                string page = AddLeadingHtmlCode(Website, tagPage, head, body);

                // Create directory, if it does not excist
                string path = Directory.CreateDirectory(Path.Combine(Output, "tag", tag)).ToString();

                if (this.PathDirectory.Contains(path))
                {
                    Console.WriteLine($"WARNING: The path {path} is allready in use. Change the path in meta data to avoid duplicates.");
                }

                WriteFile(path: path, filename: "index.html", content: page, gitMode: GitMode);

                PathDirectory.Add(path);
            }
        }
    }
}

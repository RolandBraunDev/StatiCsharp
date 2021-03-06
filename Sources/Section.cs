using StatiCSharp.Interfaces;


namespace StatiCSharp
{
    internal class Section : ISection
    {
        private string sectionName = string.Empty;
        public string SectionName
        {
            get { return sectionName; }
            set { sectionName = value; }
        }

        private List<IItem> items = new List<IItem>();
        public List<IItem> Items
        {
            get { return items; }
        }

        private string title = string.Empty;
        public string Title
        {
            get { return this.title; }
            set { this.title = value; }
        }

        private string description = string.Empty;
        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }

        private string author = "";
        public string Author
        {
            get { return this.author; }
            set { this.author = value; }
        }

        private DateOnly date = DateOnly.FromDateTime(DateTime.Now);
        public DateOnly Date
        {
            get { return this.date; }
            set { this.date = value; }
        }

        private DateOnly dateLastModified = DateOnly.FromDateTime(DateTime.Now);
        public DateOnly DateLastModified
        {
            get { return this.dateLastModified; }
            set { this.dateLastModified = value; }
        }

        private string path = string.Empty;
        public string Path
        {
            get { return this.path; }
            set { this.path = value; }
        }

        public string Url
        {
            get
            {
                string x = string.Empty;
                if (this.path == string.Empty)
                {
                    x = this.markdownFileName.Substring(0, markdownFileName.LastIndexOf(".md")).Replace(" ", "-").Trim();
                }
                else
                {
                    x = this.path;
                }
                return $"/{this.sectionName}";
            }
        }

        private string hierarchy = string.Empty;
        public string Hierarchy
        {
            get { return this.hierarchy; }
            set { this.hierarchy = value; }
        }

        private string markdownFileName = string.Empty;
        public string MarkdownFileName
        {
            get { return this.markdownFileName; }
            set { this.markdownFileName = value; }
        }

        private string markdownFilePath = string.Empty;
        public string MarkdownFilePath
        {
            get { return markdownFilePath; }
            set { this.markdownFilePath = value; }
        }

        private List<string> tags = new List<string>();
        public List<string> Tags
        {
            get { return this.tags; }
            set { this.tags = value; }
        }

        private string content = string.Empty;
        public string Content
        {
            get { return this.content; }
            set { this.content = value; }
        }

        private void SortItems()
        {
            System.Console.WriteLine("Whould sort");
        }

        public void AddItem(IItem item)
        {
            this.items.Add(item);
            this.items.OrderByDescending(x => x.Date);
        }
    }
}

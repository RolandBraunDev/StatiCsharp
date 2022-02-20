﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StatiCsharp.Interfaces;

namespace StatiCsharp
{
    public partial class Website: IWebsite
    {
        /// <summary>
        /// Creates and writes the items (not sections or pages) of the website with the given HtmlFactory.
        /// </summary>
        /// <param name="HtmlFactory"></param>
        public void MakeItems(IHtmlFactory HtmlFactory)
        {
            foreach (ISection currentSection in this.Sections)
            {
                foreach (IItem site in currentSection.Items)
                {
                    string body = HtmlFactory.MakeItemHtml(site);
                    string page = AddLeadingHtmlCode(this, site, body);
                    string itemPath = (site.Path != string.Empty) ? site.Path : site.MarkdownFileName;
                    string path = Directory.CreateDirectory(Path.Combine(output, currentSection.SectionName, itemPath)).ToString();
                    File.WriteAllText(Path.Combine(path, "index.html"), page);
                }
            }
        }
    }
}

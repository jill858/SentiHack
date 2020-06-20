using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentiHackMVC.Models
{
    public class News
    {
        private string sourceType;
        private string author;
        private string link;
        private string title;
        private string description;
        private string content;
        private string words;
        private DateTime publishDate;
        private int minDifference;

        private List<News> newsList;

        public List<News> NewsList
        {
            set
            {
                newsList = value;
            }
            get
            {
                return newsList;
            }
        }

        public string SourceType
        {
            set
            {
                this.sourceType = value;
            }
            get
            {
                return sourceType;
            }
        }

        public string Author
        {
            set
            {
                this.author = value;
            }
            get
            {
                return author;
            }
        }

        public string Link
        {
            set
            {
                this.link = value;
            }
            get
            {
                return link;
            }
        }

        public string Title
        {
            set
            {
                this.title = value;
            }
            get
            {
                return title;
            }
        }

        public string Description
        {
            set
            {
                this.description = value;
            }
            get
            {
                return description;
            }
        }

        public string Content
        {
            set
            {
                this.content = value;
            }
            get
            {
                return content;
            }
        }

        public DateTime PublishDate
        {
            set
            {
                this.publishDate = value;
            }
            get
            {
                return publishDate;
            }
        }

        public string Words
        {
            set
            {
                this.words = value;
            }
            get
            {
                return words;
            }
        }

        public int MinDifference { get; set; }


        public News()
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PepperSearch
{
    public class Scrapper
    {
        public ScrapedData ScrapedData { get; private set; }

        public Scrapper()
        {
            this.ScrapedData = new ScrapedData();
        }

        public void ScrapData()
        {

        }

        private List<string> ScrapTitles()
        {
            return null;
        }

        private List<string> ScrapScores()
        {
            return null;
        }
    }
}

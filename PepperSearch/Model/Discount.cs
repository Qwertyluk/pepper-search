using System.ComponentModel;

namespace PepperSearch
{
    /// <summary>
    /// Represents discount model data that is scrapped from the website.
    /// </summary>
    public class Discount : INotifyPropertyChanged
    {
        private string title;
        private string link;
        private decimal actualPrice;
        private decimal previousPrice;
        private decimal value;
        private int score;
        private string description;


        /// <summary>
        /// The title of the discount.
        /// </summary>
        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                this.title = value;
                this.OnPropertyChanged("Title");
            }
        }

        /// <summary>
        /// The link of the discount.
        /// </summary>
        public string Link
        {
            get
            {
                return this.link;
            }
            set
            {
                this.link = value;
                this.OnPropertyChanged("Link");
            }
        }

        /// <summary>
        /// Actual price of the product.
        /// </summary>
        public decimal ActualPrice
        {
            get
            {
                return this.actualPrice;
            }
            set
            {
                this.actualPrice = value;
                this.OnPropertyChanged("ActualPrice");
            }
        }

        /// <summary>
        /// Previous price of the product.
        /// </summary>
        public decimal PreviousPrice
        {
            get
            {
                return this.previousPrice;
            }
            set
            {
                this.previousPrice = value;
                this.OnPropertyChanged("PreviousPrice");
            }
        }

        /// <summary>
        /// The value of the discount.
        /// </summary>
        public decimal Value
        {
            get
            {
                return this.value;
            }
            set
            {
                this.value = value;
                this.OnPropertyChanged("Value");
            }
        }

        /// <summary>
        /// The score of the discount.
        /// </summary>
        public int Score
        {
            get
            {
                return this.score;
            }
            set
            {
                this.score = value;
                this.OnPropertyChanged("Score");
            }
        }
        /// <summary>
        /// The description of the discount.
        /// </summary>
        public string Description
        {
            get
            {
                return this.description;
            }

            set
            {
                this.description = value;
                OnPropertyChanged("Description");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

namespace PepperSearch
{
    /// <summary>
    /// Represents discount model data that is scrapped from the website.
    /// </summary>
    public class Discount
    {
        /// <summary>
        /// The title of the discount.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// The link of the discount.
        /// </summary>
        public string Link { get; set; }
        /// <summary>
        /// Actual price of the product.
        /// </summary>
        public decimal ActualPrice { get; set; }
        /// <summary>
        /// Previous price of the product.
        /// </summary>
        public decimal PreviousPrice { get; set; }
        /// <summary>
        /// The value of the discount.
        /// </summary>
        public decimal Value { get; set; }
        /// <summary>
        /// The score of the discount.
        /// </summary>
        public int Score { get; set; }
        /// <summary>
        /// The description of the discount.
        /// </summary>
        public string Description { get; set; }
    }
}

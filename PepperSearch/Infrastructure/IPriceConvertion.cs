namespace PepperSearch
{
    /// <summary>
    /// An interface that provides methods for a price convertion.
    /// </summary>
    public interface IPriceConvertion
    {
        /// <summary>
        /// Converts a price from a string type to a decimal type.
        /// </summary>
        /// <param name="price">The price to be converted.</param>
        /// <returns>Decimal value of the price.</returns>
        decimal ConvertPrice(string price);
    }
}

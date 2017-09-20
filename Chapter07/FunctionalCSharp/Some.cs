namespace FunctionalCSharp
{
    /// <summary>
    /// Inherited class representing option with value
    /// </summary>
    public class Some<T> : Option<T>
    {
        public Some(T value)
            : base(OptionType.Some)
        {
            this.Value = value;
        }

        /// <summary>
        /// Returns value carried by the option
        /// </summary>
        public T Value { get; private set; }
    }
}
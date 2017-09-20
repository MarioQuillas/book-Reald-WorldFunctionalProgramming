namespace FunctionalCSharp
{
    /// <summary>
    /// Inherited class representing empty option
    /// </summary>
    public class None<T> : Option<T>
    {
        public None()
            : base(OptionType.None)
        {
        }
    }
}
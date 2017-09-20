namespace FunctionalCSharp
{
    /// <summary>
    /// Utility class for creating options
    /// </summary>
    public static class OptionUtility
    {
        /// <summary>
        /// Creates an empty option
        /// </summary>
        public static Option<T> None<T>()
        {
            return new None<T>();
        }

        /// <summary>
        /// Creates option with a value. This method can be
        /// used without type parameters thanks to C# type inference
        /// </summary>
        public static Option<T> Some<T>(T value)
        {
            return new Some<T>(value);
        }
    }

    // --------------------------------------------------------------------------
    // Functional Programming in .NET - Chapter 3, 5 and 6
    // --------------------------------------------------------------------------
    // NOTE: This library contains several useful classes for functional
    // programming in C# that we implemented in chapter 3, 5 and 6 and that we'll
    // extend and use later in the book. Each secion is marked with a reference
    // to a code listing or section in the book where it was discussed.
    // --------------------------------------------------------------------------

    // --------------------------------------------------------------------------
    // Section 5.3.1: Implementing option type in C#

    // Listing 5.9 Generic option type using classes (C#)

    /// <summary>
    /// Represents option value that can be either 'None' or 'Some(v)'
    /// </summary>
    public abstract class Option<T>
    {
        private OptionType tag;

        /// <summary>
        /// Creates the option type and takes the type of the 
        /// created option as an argument.
        /// </summary>
        protected Option(OptionType tag)
        {
            this.tag = tag;
        }

        /// <summary>
        /// Specifies alternative represented by this instance
        /// </summary>
        public OptionType Tag
        {
            get
            {
                return this.tag;
            }
        }

        // Listing 5.10 "Pattern matching" methods for Option class (C#)

        /// <summary>
        /// Matches 'None' alternative
        /// </summary>
        /// <returns>Returns true when succeeds</returns>
        public bool MatchNone()
        {
            return this.Tag == OptionType.None;
        }

        /// <summary>
        /// Matches 'Some' alternative
        /// </summary>
        /// <param name="value">When succeeds sets this parameter to the carried value</param>
        /// <returns>Returns true when succeeds</returns>
        public bool MatchSome(out T value)
        {
            if (this.Tag == OptionType.Some) value = ((Some<T>)this).Value;
            else value = default(T);
            return this.Tag == OptionType.Some;
        }
    }

    // --------------------------------------------------------------------------
    // Section 6.3.2: Working with option type

    // Listing 6.12: Implementing bind and map
}
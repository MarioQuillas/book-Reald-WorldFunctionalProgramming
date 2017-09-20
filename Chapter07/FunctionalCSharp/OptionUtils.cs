namespace FunctionalCSharp
{
    using System;

    /// <summary>
    /// Contains utility methods for working with option values
    /// </summary>
    public static class OptionUtils
    {
        /// <summary>
        /// If the 'opt' argument contains a value, the function 'f' is called 
        /// with this value as an argument and the result is returned.
        /// </summary>
        public static Option<R> Bind<T, R>(this Option<T> opt, Func<T, Option<R>> f)
        {
            T value1;
            if (opt.MatchSome(out value1)) return f(value1); // Just call the function
            else return OptionUtility.None<R>();
        }

        /// <summary>
        /// If the 'opt' argument contains a value, the value is processed 
        /// using 'f' function and is wrapend into a 'Some' constructor.
        /// </summary>
        public static Option<R> Map<T, R>(this Option<T> opt, Func<T, R> f)
        {
            T value1;
            if (opt.MatchSome(out value1)) return OptionUtility.Some(f(value1)); // Call the function & wrap the result
            else return OptionUtility.None<R>();
        }
    }
}
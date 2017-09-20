namespace FunctionalCSharp
{
    using System;

    public static class TupleExtensions
    {
        // --------------------------------------------------------------------------
        // Section 6.2.1: Methods for working with tuples in C#

        // Listing 6.6 Extension methods for working with tuples

        /// <summary>
        /// Applies given function to the first element of the tuple 
        /// and returns a tuple containing new value as the first element and 
        /// the unchanged second element
        /// </summary>
        public static Tuple<B, C> MapFirst<A, B, C>(this Tuple<A, C> t, Func<A, B> f)
        {
            return Tuple.Create(f(t.Item1), t.Item2);
        }

        /// <summary>
        /// Applies given function to the second element of the tuple 
        /// and returns a tuple containing new value as the second element and 
        /// the unchanged first element
        /// </summary>
        public static Tuple<C, B> MapSecond<A, B, C>(this Tuple<C, A> t, Func<A, B> f)
        {
            return Tuple.Create(t.Item1, f(t.Item2));
        }

        // Listing 3.9: Incrementing population of a city in C#

        /// <summary>
        /// Returns a tuple with the first element set to the specified value.
        /// </summary>
        /// <param name="nsnd">A new value for the first element</param>
        /// <returns>A new tuple with modified first element</returns>
        public static Tuple<T1, T2> WithItem1<T1, T2>(this Tuple<T1, T2> tuple, T1 newItem1)
        {
            return Tuple.Create(newItem1, tuple.Item2);
        }

        /// <summary>
        /// Returns a tuple with the second element set to the specified value.
        /// </summary>
        /// <param name="nsnd">A new value for the second element</param>
        /// <returns>A new tuple with modified second element</returns>
        public static Tuple<T1, T2> WithItem2<T1, T2>(this Tuple<T1, T2> tuple, T2 newItem2)
        {
            return Tuple.Create(tuple.Item1, newItem2);
        }
    }
}
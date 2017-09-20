namespace FunctionalCSharp
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Utility class for constructing lists
    /// </summary>
    public static class FuncListUtility
    {
        public static FuncList<T> Concat<T>(this FuncList<FuncList<T>> concat)
        {
            var el = concat;
            List<T> elements = new List<T>();
            while (!el.IsEmpty)
            {
                var nested = el.Head;
                while (!nested.IsEmpty)
                {
                    elements.Add(nested.Head);
                    nested = nested.Tail;
                }

                el = el.Tail;
            }

            FuncList<T> ret = Empty<T>();
            for (int i = 0; i < elements.Count; i++) ret = Cons(elements[i], ret);
            return ret;
        }

        /// <summary>
        /// Creates a cons cell storing an element of the list.
        /// This method can be used without specifying generic 
        /// type parameters thanks to the C# type inference.
        /// </summary>
        public static FuncList<T> Cons<T>(T head, FuncList<T> tail)
        {
            return new FuncList<T>(head, tail);
        }

        /// <summary>
        /// Creates an empty list
        /// </summary>
        public static FuncList<T> Empty<T>()
        {
            return new FuncList<T>();
        }

        public static void Iter<T>(this FuncList<T> source, Action<T> f)
        {
            if (!source.IsEmpty)
            {
                f(source.Head);
                Iter(source.Tail, f);
            }
        }

        public static FuncList<R> Select<T, R>(this FuncList<T> source, Func<T, R> f)
        {
            if (source.IsEmpty) return Empty<R>();
            else return Cons(f(source.Head), Select(source.Tail, f));
        }

        public static FuncList<R> Select<T, R>(this FuncList<T> source, Func<T, int, R> f)
        {
            return SelectUtil(source, 0, f);
        }

        public static FuncList<T> ToFuncList<T>(this IEnumerable<T> seq)
        {
            FuncList<T> ret = Empty<T>();
            foreach (var el in seq.Reverse()) ret = Cons(el, ret);
            return ret;
        }

        private static FuncList<R> SelectUtil<T, R>(this FuncList<T> source, int i, Func<T, int, R> f)
        {
            if (source.IsEmpty) return Empty<R>();
            else return Cons(f(source.Head, i), SelectUtil(source.Tail, i + 1, f));
        }
    }
}
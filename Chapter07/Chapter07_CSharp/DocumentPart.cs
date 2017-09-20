namespace Chapter07_CSharp
{
    using System;

    abstract class DocumentPart
    {
        public abstract T Accept<T>(DocumentPartVisitor<T> visitor, T state);

        public abstract T Aggregate<T>(Func<T, DocumentPart, T> f, T state);
    }
}
namespace Chapter07_CSharp
{
    using System;

    class TextPart : DocumentPart
    {
        public TextPart(TextContent text)
        {
            this.Text = text;
        }

        public TextContent Text { get; private set; }

        public override T Accept<T>(DocumentPartVisitor<T> visitor, T state)
        {
            return visitor.VisitTextPart(this, state);
        }

        public override T Aggregate<T>(Func<T, DocumentPart, T> f, T state)
        {
            return f(state, this);
        }
    }
}
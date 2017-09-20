namespace Chapter07_CSharp
{
    using System;

    class TitledPart : DocumentPart
    {
        public TitledPart(TextContent text, DocumentPart body)
        {
            this.Text = text;
            this.Body = body;
        }

        public DocumentPart Body { get; private set; }

        public TextContent Text { get; private set; }

        public override T Accept<T>(DocumentPartVisitor<T> visitor, T state)
        {
            return visitor.VisitTitledPart(this, state);
        }

        public override T Aggregate<T>(Func<T, DocumentPart, T> f, T state)
        {
            return this.Body.Aggregate(f, f(state, this));
        }
    }
}
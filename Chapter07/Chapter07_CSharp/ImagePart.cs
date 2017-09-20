namespace Chapter07_CSharp
{
    using System;

    class ImagePart : DocumentPart
    {
        public ImagePart(string url)
        {
            this.Url = url;
        }

        public string Url { get; private set; }

        public override T Accept<T>(DocumentPartVisitor<T> visitor, T state)
        {
            return visitor.VisitImagePart(this, state);
        }

        public override T Aggregate<T>(Func<T, DocumentPart, T> f, T state)
        {
            return f(state, this);
        }
    }
}
namespace Chapter07_CSharp
{
    abstract class DocumentPartVisitor<T>
    {
        public abstract T VisitImagePart(ImagePart part, T state);

        public abstract T VisitSplitPart(SplitPart part, T state);

        public abstract T VisitTextPart(TextPart part, T state);

        public abstract T VisitTitledPart(TitledPart part, T state);
    }
}
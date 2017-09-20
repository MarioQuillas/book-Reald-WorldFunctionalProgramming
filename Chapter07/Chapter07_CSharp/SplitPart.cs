namespace Chapter07_CSharp
{
    using System;
    using System.Linq;
    using System.Windows.Forms;

    using FunctionalCSharp;

    class SplitPart : DocumentPart
    {
        public SplitPart(Orientation orientation, FuncList<DocumentPart> parts)
        {
            this.Orientation = orientation;
            this.Parts = parts;
        }

        public Orientation Orientation { get; private set; }

        public FuncList<DocumentPart> Parts { get; private set; }

        public override T Accept<T>(DocumentPartVisitor<T> visitor, T state)
        {
            return visitor.VisitSplitPart(this, state);
        }

        public override T Aggregate<T>(Func<T, DocumentPart, T> f, T state)
        {
            T nstate = f(state, this);
            return this.Parts.Aggregate(nstate, (st, part) => part.Aggregate(f, st));
        }
    }
}
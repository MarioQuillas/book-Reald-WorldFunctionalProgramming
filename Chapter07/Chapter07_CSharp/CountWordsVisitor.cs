namespace Chapter07_CSharp
{
    using System.Linq;

    class CountWordsVisitor : DocumentPartVisitor<int>
    {
        public override int VisitImagePart(ImagePart part, int state)
        {
            return state;
        }

        public override int VisitSplitPart(SplitPart part, int state)
        {
            // Aggregate the count over all subparts
            return part.Parts.Aggregate(
                state,
                (count, p) =>

                    // Count words in each part
                        p.Accept(this, count));
        }

        public override int VisitTextPart(TextPart part, int state)
        {
            return part.Text.Text.Split(' ').Length + state;
        }

        public override int VisitTitledPart(TitledPart part, int state)
        {
            // Recursively count words of the body
            return part.Text.Text.Split(' ').Length + part.Body.Accept(this, state);
        }
    }
}
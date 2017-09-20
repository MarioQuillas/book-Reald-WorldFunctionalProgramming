namespace Chapter07_CSharp
{
    using System.Drawing;
    using System.Windows.Forms;

    using FunctionalCSharp;

    class DocumentToScreen : DocumentPartVisitor<TranslationState>
    {
        public override TranslationState VisitImagePart(ImagePart part, TranslationState ctx)
        {
            ctx.Result = FuncList.Cons(new ImageElement(part.Url, ctx.Rect), FuncList.Empty<ScreenElement>());
            return ctx;
        }

        public override TranslationState VisitSplitPart(SplitPart part, TranslationState ctx)
        {
            if (part.Orientation == Orientation.Vertical)
            {
                var height = ctx.Rect.Height / part.Parts.Count;
                ctx.Result = part.Parts.Select(
                    (p, i) =>
                        {
                            var rc = new RectangleF(ctx.Rect.Left, ctx.Rect.Top + i * height, ctx.Rect.Width, height);
                            return p.Accept(this, new TranslationState { Rect = rc }).Result;
                        }).Concat();
            }
            else
            {
                var width = ctx.Rect.Width / part.Parts.Count;
                ctx.Result = part.Parts.Select(
                    (p, i) =>
                        {
                            var rc = new RectangleF(ctx.Rect.Left + i * width, ctx.Rect.Top, width, ctx.Rect.Height);
                            return p.Accept(this, new TranslationState { Rect = rc }).Result;
                        }).Concat();
            }

            return ctx;
        }

        public override TranslationState VisitTextPart(TextPart part, TranslationState ctx)
        {
            ctx.Result = FuncList.Cons(new TextElement(part.Text, ctx.Rect), FuncList.Empty<ScreenElement>());
            return ctx;
        }

        public override TranslationState VisitTitledPart(TitledPart part, TranslationState ctx)
        {
            var rc = new RectangleF(ctx.Rect.Left, ctx.Rect.Top + 35.0f, ctx.Rect.Width, ctx.Rect.Height - 35.0f);
            var bodyElements = part.Body.Accept(this, new TranslationState { Rect = rc }).Result;
            var titleRc = new RectangleF(ctx.Rect.Left, ctx.Rect.Top, ctx.Rect.Width, 35.0f);
            ctx.Result = FuncList.Cons(new TextElement(part.Text, titleRc), bodyElements);
            return ctx;
        }
    }
}
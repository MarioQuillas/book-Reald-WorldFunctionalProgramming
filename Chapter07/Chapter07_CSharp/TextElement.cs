namespace Chapter07_CSharp
{
    using System.Drawing;

    class TextElement : ScreenElement
    {
        public TextElement(TextContent text, RectangleF rect)
        {
            this.Text = text;
            this.Rect = rect;
        }

        public RectangleF Rect { get; private set; }

        public TextContent Text { get; private set; }

        public override void DrawPart(Graphics gr)
        {
            gr.DrawString(this.Text.Text, this.Text.Font, Brushes.Black, this.Rect);
        }
    }
}
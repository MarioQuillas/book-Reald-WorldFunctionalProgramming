namespace Chapter07_CSharp
{
    using System.Drawing;

    class TextContent
    {
        public TextContent(string text, Font font)
        {
            this.Text = text;
            this.Font = font;
        }

        public Font Font { get; private set; }

        public string Text { get; private set; }
    }
}
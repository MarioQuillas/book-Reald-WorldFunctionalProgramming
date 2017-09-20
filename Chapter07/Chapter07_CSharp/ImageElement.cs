namespace Chapter07_CSharp
{
    using System.Drawing;

    class ImageElement : ScreenElement
    {
        public ImageElement(string path, RectangleF rect)
        {
            this.Path = path;
            this.Rect = rect;
        }

        public string Path { get; private set; }

        public RectangleF Rect { get; private set; }

        public override void DrawPart(Graphics gr)
        {
            var bmp = new Bitmap(this.Path);
            float wspace = this.Rect.Width / 10.0f, hspace = this.Rect.Height / 10.0f;
            var rc = new RectangleF(
                this.Rect.Left + wspace,
                this.Rect.Top + hspace,
                this.Rect.Width - 2 * wspace,
                this.Rect.Height - 2 * hspace);
            gr.DrawImage(bmp, rc);
        }
    }
}
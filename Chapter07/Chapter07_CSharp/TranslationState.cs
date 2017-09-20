namespace Chapter07_CSharp
{
    using System.Drawing;

    using FunctionalCSharp;

    class TranslationState
    {
        public RectangleF Rect { get; set; }

        public FuncList<ScreenElement> Result { get; set; }
    }
}
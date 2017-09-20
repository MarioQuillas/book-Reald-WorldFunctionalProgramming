// --------------------------------------------------------------------------
// Functional Programming in .NET - Chapter 7
// --------------------------------------------------------------------------
// This file contains the object oriented implementation of 
// the document drawing application.
// NOTE: This isn't fully commented yet. 
// --------------------------------------------------------------------------

namespace Chapter07_CSharp
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    using FunctionalCSharp;

    // --------------------------------------------------------------------------
    // Section 7.5.2 Adding functions using visitor 

    // Listing 7.17 Counting words in the document using Visitor (C#)
    static class Program
    {
        static Bitmap DrawImage(int wid, int hgt, float space, Action<Graphics> f)
        {
            var bmp = new Bitmap(wid, hgt);
            var gr = Graphics.FromImage(bmp);
            gr.FillRectangle(Brushes.White, new Rectangle(new Point(0, 0), new Size(wid, hgt)));
            gr.TranslateTransform(space, space);
            f(gr);
            gr.Dispose();
            return bmp;
        }

        [STAThread]
        static void Main()
        {
            // Load document and convert it to flat representation (using visitor)
            var doc = XmlLoader.LoadDocument("..\\..\\document.xml");
            var screenParts = doc.Accept(
                new DocumentToScreenVisitor(),
                new TranslationState { Rect = new RectangleF(0.0f, 0.0f, 520.0f, 630.0f) }).Result;

            // Show the main form with the document
            var main = new Form
                           {
                               Text = "Document",
                               ClientSize = new Size(570, 680),
                               BackgroundImage = DrawImage(
                                   570,
                                   680,
                                   20.0f,
                                   (gr) => screenParts.Iter((part) => part.DrawPart(gr)))
                           };

            // Run the word-counting visitor and display the result
            int count = doc.Accept(new CountWordsVisitor(), 0);
            MessageBox.Show("Count of the words in the document:" + count.ToString());

            Application.Run(main);
        }
    }
}
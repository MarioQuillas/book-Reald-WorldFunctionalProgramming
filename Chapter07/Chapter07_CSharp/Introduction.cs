// --------------------------------------------------------------------------
// Functional Programming in .NET - Chapter 7
// --------------------------------------------------------------------------
// This file contains code samples that are not related to the primary
// example of the chapter (document drawing application).
// --------------------------------------------------------------------------

namespace Chapter07_CSharp_Introduction
{
    // --------------------------------------------------------------------------
    // Section 7.1.2 Functional data structures in C#

    // Listing 7.3 Immutable 'Rect' type (C#)
    class Rect
    {
        private readonly float height;

        // Readonly properties of the type
        private readonly float left;

        private readonly float top;

        private readonly float width;

        // Construct the value
        public Rect(float left, float top, float width, float height)
        {
            this.left = left;
            this.top = top;
            this.width = width;
            this.height = height;
        }

        public float Height
        {
            get
            {
                return this.height;
            }
        }

        public float Left
        {
            get
            {
                return this.left;
            }
        }

        public float Top
        {
            get
            {
                return this.top;
            }
        }

        public float Width
        {
            get
            {
                return this.width;
            }
        }

        public Rect WithHeight(float height)
        {
            return new Rect(this.Left, this.Top, this.Width, height);
        }

        // Returns 'Rect' with modified 'Left' property
        public Rect WithLeft(float left)
        {
            // Create a copy of the object
            return new Rect(left, this.Top, this.Width, this.Height);
        }

        // Other 'With' methods are similar...
        public Rect WithTop(float top)
        {
            return new Rect(this.Left, top, this.Width, this.Height);
        }

        public Rect WithWidth(float width)
        {
            return new Rect(this.Left, this.Top, width, this.Height);
        }
    }

    // Working with immutable types
    class Demo
    {
        static void IntroMain()
        {
            Rect rc = new Rect(0.0f, 0.0f, 100.0f, 100.0f);
            var moved = rc.WithLeft(10.0f).WithTop(10.0f);
        }
    }
}
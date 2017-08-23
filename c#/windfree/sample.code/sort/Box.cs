using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sample.Quiz.compare
{
    class Box : IComparable<Box>
    {
        private int length;
        private int width;
        private int height;

        public Box(int l, int w, int h)
        {
            this.length = l;
            this.width = w;
            this.height = h;
        }

        public int Length
        {
            get { return length; }
            set { this.length = value; }
        }
        public int Width
        {
            get { return width; }
            set { this.width = value; }
        }

        public int Height
        {
            get { return height; }
            set { this.height = value; }
        }



        public int CompareTo(Box other)
        {
            if(this.length.CompareTo(other.length) != 0)
            {
                return this.length.CompareTo(other.length);
            }

            if (this.width.CompareTo(other.width) != 0)
            {
                return this.width.CompareTo(other.width);
            }

            if (this.height.CompareTo(other.height) != 0)
            {
                return this.height.CompareTo(other.height);
            }

            return 0;

        }
    }
}

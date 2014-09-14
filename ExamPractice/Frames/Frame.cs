namespace Frames
{
    public struct Frame
    {
        public Frame(int w, int h) : this()
        {
            this.Width = w;
            this.Height = h;
        }

        public int Width { get; set; }

        public int Height { get; set; }

        public override string ToString()
        {
            return string.Format("({0}, {1})", this.Width, this.Height);
        }
    }
}
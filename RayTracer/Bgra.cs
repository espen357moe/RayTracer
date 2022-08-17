namespace RayTracer
{
    /// <summary>
    /// This struct represents the values for each of the color channels plus the alpha (transparency) channel
    /// </summary>
    public struct Bgra
    {
        public byte Blue;
        public byte Green;
        public byte Red;
        public byte Alpha;

        public Bgra(byte blue, byte green, byte red, byte alpha)
        {
            Blue = blue;
            Green = green;
            Red = red;
            Alpha = alpha;
        }
    }
}
using System.Numerics;

namespace RayTracer
{
    public class PointLight
    {
        public Vector3 Position;

        public PointLight(Vector3 position)
        {
            Position = position;
        }
    }
}
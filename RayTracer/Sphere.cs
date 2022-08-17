using System.Numerics;

namespace RayTracer
{
    public class Sphere
    {
        public float Radius { get; }
        public Vector3 Position { get; set; }

        public Sphere(float radius, Vector3 position)
        {
            Radius = radius;
            Position = position;
        }

        /// <summary>
        /// Stole this from an example on the web, don't really know what the variables represent
        /// </summary>
        /// <param name="ray"></param>
        /// <returns></returns>
        public Hit? Intersect(in Ray ray)
        {
            Vector3 L = Position - ray.Origin;
            var tca = Vector3.Dot(L, ray.Direction);
            var d2 = Vector3.Dot(L, L) - tca * tca;
            
            if (d2 > Radius * Radius)
            {
                return null;
            }
            
            var thc = MathF.Sqrt(Radius * Radius - d2);
            var t0 = tca - thc;
            var t1 = tca + thc;
            
            if (t0 < 0)
            {
                t0 = t1;
            }
            
            if (t0 < 0)
            {
                return null;
            }
            
            return new Hit(ray.Origin * t0, Vector3.Normalize(ray.Origin * t0 - Position));
        }
    }
}

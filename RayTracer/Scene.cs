using System.Numerics;

namespace RayTracer
{
    public class Scene
    {
        public readonly List<Sphere> _spheres;
        public readonly List<PointLight> _lights;

        public Scene()
        {
            _spheres = new()
            {
                new Sphere(5, new Vector3(0f, 0f, 5f))
            };

            _lights = new()
            {
                new PointLight(new Vector3(-1f, 1f, 0f))
            };
        }

        public Vector4 TraceRay(Ray ray)
        {
            foreach (var sphere in _spheres)
            {
                var hit = sphere.Intersect(ray);

                if (hit != null)
                {   
                    // Calculate the intensity of each color channel where the ray hits the sphere
                    var intensity = 1-MathF.Max(0, Vector3.Dot(Vector3.Normalize(hit.IntersectionPoint - _lights[0].Position), hit.Normal));
                    return new Vector4(intensity, intensity, intensity, 1);
                }
            }

            return new Vector4(0, 0, 0, 1);
        }
    }
}
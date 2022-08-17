using System.Numerics;
using System.Runtime.InteropServices;

namespace RayTracer
{
    public partial class Form1 : Form
    {
        private GCHandle _handle { get; set; }
        private Bgra[]? _backbuffer { get; set; }
        private Bitmap? _bitmap { get; set; }
        private int _width { get; set; }
        private int _height { get; set; }
        private readonly Scene _scene;

        public Form1()
        {
            _scene = new Scene();
            InitializeComponent();
            Resize(ClientSize.Width, ClientSize.Height);            
        }

        private void SetPixel(int xCoord, int yCoord, Color color)
        {
            _backbuffer![yCoord * _width + xCoord] = new Bgra(color.B, color.G, color.R, 255);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            RenderFrame();
            e.Graphics.DrawImage(_bitmap!, 0, 0);
        }

        protected override void OnResizeEnd(EventArgs e)
        {
            Resize(ClientSize.Width, ClientSize.Height);
            Invalidate();
        }

        private void RenderFrame()
        {
            _scene._spheres[0].Position += new Vector3(0f, 0f, 0.1f);

            // Iterate through the scanlines
            for (int y = 0; y < _height; y++)
            {
                // Iterate through each pixel on the current scanline
                for (int x = 0; x < _width; x++)
                {                    
                    // Origin is at the camera position
                    var origin = new Vector3(-1f, 0f, 0f);
                    
                    // Direction
                    var direction = new Vector3(x, y, 1f);
                    Vector3 normalizationArea = new Vector3(_width, _height, 1);

                    var dir = Vector3.Normalize(direction / normalizationArea - new Vector3(0.5f, 0.5f, 0f)); 
                        
                    var color = _scene.TraceRay(new Ray(origin, dir));
                    var c = Color.FromArgb(
                                255, 
                                (int)(color.X * 255), 
                                (int)(color.Y * 255), 
                                (int)(color.Z * 255)
                            );

                    SetPixel(x, y, c);                    
                }
            }
        }

        private void Resize(int width, int height)
        {
            if (_bitmap != null)
            {
                _bitmap.Dispose();
                _handle.Free();
            }

            _width = width > 0 ? width : 1;
            _height = height > 0 ? height : 1;
            _backbuffer = new Bgra[_width * _height];
            _handle = GCHandle.Alloc(_backbuffer, GCHandleType.Pinned);
            _bitmap = new Bitmap(_width, _height, _width * 4, System.Drawing.Imaging.PixelFormat.Format32bppPArgb, _handle.AddrOfPinnedObject());
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}
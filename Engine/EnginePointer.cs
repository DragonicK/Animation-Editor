using System.Drawing;

namespace Animation_Editor.Engine {
    public sealed class EnginePointer {
        /// <summary>
        /// Objeto selecionado na lista.
        /// </summary>
        public Bitmap Image { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public int OffsetY { get; set; }
        public int OffsetX { get; set; }

        public Rectangle ScreenRectangle {
            get {
                return new Rectangle(X + OffsetX, Y + OffsetY, Width, Height);
            }
        }

        /// <summary>
        /// Índice do objeto selecionado.
        /// </summary>
        public int ObjectIndex { get; set; }

        public EnginePointer() {
            Image = new Bitmap(1, 1);
        }
    }
}
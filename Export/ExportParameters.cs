using System.Drawing;

namespace Animation_Editor.Export {
    public struct ExportParameters {
        public int BackBufferWidth { get; set; }
        public int BackBufferHeight { get; set; }
        public int MaxFramePerLineX { get; set; }
    }
}
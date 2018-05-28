using System;
using System.Drawing;

namespace Animation_Editor.Anim {
    [Serializable]
    public sealed class BitmapObject {
        public string Name { get; set; }
        public Bitmap Image { get; set; }
    }
}
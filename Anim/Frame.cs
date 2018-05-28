using System;
using System.Drawing;

namespace Animation_Editor.Anim {
    [Serializable]
    public sealed class Frame {
        private int _transparency;

        public string Name { get; set; }
        public Bitmap Image { get; set; }
        public Rectangle ScreenRect { get; set; }
        public Rectangle SourceRect { get; set; }

        public int Transparency {
            get {
                return _transparency;
            }
            set {
                _transparency = value;

                if (_transparency > 100) { 
                    _transparency = 100;
                }       
            }
        }

        public Frame() {
            Name = string.Empty;
            Image = new Bitmap(1, 1);
            _transparency = 100;
        }
    }
}
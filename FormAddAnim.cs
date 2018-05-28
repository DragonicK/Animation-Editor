using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Animation_Editor.Anim;
using Animation_Editor.Common;

namespace Animation_Editor {
    public partial class FormAddAnim : Form {
        /// <summary>
        /// Referência para a lista de objetos.
        /// </summary>
        List<BitmapObject> objectList;

        /// <summary>
        /// Referência da animação.
        /// </summary>
        Animation animation;

        /// <summary>
        /// Imagem da animação.
        /// </summary>
        Bitmap imageAnimation;
        Font font;

        Color colorKey;
        bool selectedColor;

        int frameCount;
        int frameWidth;
        int frameHeight;

        /// <summary>
        /// Indica que uma animação será criada a partir do arquivo.
        /// </summary>
        bool createAnimation;
        int positionX;
        int positionY;

        public FormAddAnim() {
            InitializeComponent();

            font = new Font("Tahoma", 9f, FontStyle.Regular);

            TextWidth.KeyPress += TextBox_KeyPress;
            TextHeight.KeyPress += TextBox_KeyPress;
            TextFrameCount.KeyPress += TextBox_KeyPress;

            TextX.KeyPress += TextBox_KeyPress;
            TextY.KeyPress += TextBox_KeyPress;
        }

        public void Show(List<BitmapObject> objectList, Animation animation, string file, string safeName) {
            this.objectList = objectList;
            this.animation = animation;

            imageAnimation = new Bitmap(file);
            TextName.Text = GetFileName(safeName);

            PictureAnimation.BackgroundImage = imageAnimation;

            ChangeLanguage();

            ShowDialog();
        }

        private void ParseAnimation() {
            var frame = new Bitmap(frameWidth, frameHeight);
            var graphics = Graphics.FromImage(frame);

            var line = 0;
            var column = 0;
            var framePerLine = imageAnimation.Width / frameWidth; 

            if (selectedColor) {
                imageAnimation.MakeTransparent(colorKey);
            }

            // Remove todos os frames para criar uma nova animação.
            if (createAnimation) {
                animation.RemoveAll();
                animation.IncrementFrame(frameCount);
                animation.FrameIndex = 0;
                animation.ClipArea = new Rectangle(positionX, positionY, frameWidth, frameHeight);
            }
                        
            for (var index = 0; index < frameCount; index++) {

                DrawImage(graphics, line, column);

                // Adiciona os arquivos na lista de objetos.
                AddObject(frame, $"{TextName.Text}_{index}");

                // Adiciona cada frame na animação.
                if (createAnimation) {
                    AddFrame($"{TextName.Text}_{index}", frame, index);
                }

                line++;
                if (line >= framePerLine) {
                    line = 0;
                    column++;
                }
            }

            Program.MainForm.UpdateListObject();
            Program.MainForm.StartPlay();
            Program.MainForm.UpdateListFrame();

            Close();
        }

        /// <summary>
        /// Adiciona um novo frame na primeira camada.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="image"></param>
        private void AddFrame(string name, Bitmap image, int index) {
            const int LayerIndex = 0;      

            var frame = new Frame() {
                Name = name,
                Image = new Bitmap(image),
                ScreenRect = new Rectangle(positionX, positionY, frameWidth, frameHeight),
                SourceRect = new Rectangle(0, 0, frameWidth, frameHeight)
             };

            animation.FrameIndex = index;
            animation.Add(LayerIndex, frame);
        }

        /// <summary>
        /// Adiciona um novo objeto na lista.
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="name"></param>
        private void AddObject(Bitmap bitmap, string name) {
            var imgObject = new BitmapObject() {
                Image = new Bitmap(bitmap),
                Name = name
            };

            objectList.Add(imgObject);
        }

        private void DrawImage(Graphics graphics, int line, int column) {
            var source = new Rectangle {
                X = line * frameWidth,
                Y = column * frameHeight,
                Width = frameWidth,
                Height = frameHeight
            };

            var screen = new Rectangle {
                X = 0,
                Y = 0,
                Width = frameWidth,
                Height = frameHeight
            };
   
            graphics.Clear(Color.Transparent);
            graphics.DrawImage(imageAnimation, screen, source, GraphicsUnit.Pixel);           
        }

        /// <summary>
        /// Obtém o nome do arquivo sem o caminho.
        /// </summary>
        /// <param name="safeName"></param>
        /// <returns></returns>
        private string GetFileName(string safeName) {
            // Índice do nome do arquivo.
            const int NameIndex = 0;

            var name = safeName.Split('.');
            return name[NameIndex];
        }

        private void ButtonAdd_Click(object sender, EventArgs e) {
            ParseAnimation();
        }

        private void PictureAnimation_Paint(object sender, PaintEventArgs e) {
            e.Graphics.DrawString("32px", font, Brushes.White, 0, 10);
            e.Graphics.DrawString("64px", font, Brushes.White, 0, 42);
            e.Graphics.DrawString("96px", font, Brushes.White, 0, 74);
            e.Graphics.DrawString("128px", font, Brushes.White, 0, 106);
            e.Graphics.DrawString("160px", font, Brushes.White, 0, 138);
            e.Graphics.DrawString("192px", font, Brushes.White, 0, 170);

            e.Graphics.DrawRectangle(Pens.Coral, new Rectangle(0, 0, 32, 32));
            e.Graphics.DrawRectangle(Pens.Coral, new Rectangle(0, 0, 64, 64));
            e.Graphics.DrawRectangle(Pens.Coral, new Rectangle(0, 0, 96, 96));
            e.Graphics.DrawRectangle(Pens.Coral, new Rectangle(0, 0, 128, 128));
            e.Graphics.DrawRectangle(Pens.Coral, new Rectangle(0, 0, 160, 160));
            e.Graphics.DrawRectangle(Pens.Coral, new Rectangle(0, 0, 191, 191));
        }

        private void TextFrameCount_TextChanged(object sender, EventArgs e) {
            if (TextFrameCount.Text.Length == 0) {
                frameCount = 0;
            }
            else {
                frameCount = int.Parse(TextFrameCount.Text);
            }
        }

        private void TextWidth_TextChanged(object sender, EventArgs e) {
            if (TextWidth.Text.Length == 0) {
                frameWidth = 0;
            } 
            else {
                frameWidth = int.Parse(TextWidth.Text);
            }           
        }

        private void TextHeight_TextChanged(object sender, EventArgs e) {
            if (TextHeight.Text.Length == 0) {
                frameHeight = 0;
            }
            else {
                frameHeight = int.Parse(TextHeight.Text);
            }        
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs  e) {
            if ((Keys)e.KeyChar == Keys.Back) {
                return;
            }

            if (!char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            }
        }

        private void ChangeLanguage() {
            Text = Language.GetLanguageText("AddAnimationForm", "Title");
            LabelName.Text = Language.GetLanguageText("ObjectMenu", "Object");
            LabelFrameCount.Text = Language.GetLanguageText("AnimationForm", "Count");
            LabelWidth.Text = Language.FrameText + " " + Language.WidthText;
            LabelHeight.Text = Language.FrameText + " " + Language.HeightText;
            CheckCreateAnimation.Text = Language.GetLanguageText("AnimationForm", "CreateNew");

            ButtonAdd.Text = Language.GetLanguageText("ObjectMenu", "Add");
        }

        private void CheckCreateAnimation_CheckedChanged(object sender, EventArgs e) {
            createAnimation = CheckCreateAnimation.Checked;

            TextX.Enabled = createAnimation;
            TextY.Enabled = createAnimation;
        }

        private void TextX_TextChanged(object sender, EventArgs e) {
            if (TextX.Text.Length == 0) {
                positionX = 0;
            }
            else {
                positionX = int.Parse(TextX.Text);
            }      
        }

        private void TextY_TextChanged(object sender, EventArgs e) {
            if (TextY.Text.Length == 0) {
                positionY = 0;
            }
            else {
                positionY = int.Parse(TextY.Text);
            }            
        }

        private void LabelColorKey_Click(object sender, EventArgs e) {
            var dialog = new ColorDialog() {
                AnyColor = true,
                AllowFullOpen = true,
                FullOpen = true
            };

            var result = dialog.ShowDialog();

            if (result == DialogResult.OK) {
                colorKey = dialog.Color;
                LabelColorKey.BackColor = colorKey;
                selectedColor = true;
            }
        }
    }
}
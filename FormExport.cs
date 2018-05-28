using System;
using System.Drawing;
using System.Windows.Forms;
using Animation_Editor.Anim;
using Animation_Editor.Export;
using Animation_Editor.Common;

namespace Animation_Editor {
    public partial class FormExport : Form {
        /// <summary>
        /// Tamanho da tela de desenho.
        /// </summary>
        Size backBufferSize;
        
        /// <summary>
        /// Referência da lista de animação.
        /// </summary>
        Animation animation;
        int animationID = 0;

        public FormExport() {
            InitializeComponent();
        }

        public void Show(Animation animation, Size backBufferSize) {
            this.backBufferSize = backBufferSize;
            this.animation = animation;

            ChangeLanguage();

            LabelFrameCount.Text = $"{Language.FrameCount} : {animation.FrameCount}";
            LabelWidth.Text = $"{Language.WidthText} : {animation.ClipArea.Width}";
            LabelHeight.Text = $"{Language.HeightText} : {animation.ClipArea.Height}";

            ShowDialog();
        }

        private void ButtonExport_Click(object sender, EventArgs e) {
            var dialog = new SaveFileDialog() {
                InitialDirectory = Application.StartupPath + @"\Animation",
                Filter = "Animation Files (*.anim)|*.anim",
            };

            var result = dialog.ShowDialog();

            if (result == DialogResult.OK) {

                var parameters = new ExportParameters {
                    BackBufferWidth = backBufferSize.Width,
                    BackBufferHeight = backBufferSize.Height,
                    MaxFramePerLineX = 0
                };

                var export = new AnimationExport(parameters);
                export.ExportObject(dialog.FileName, animationID, animation);

                Close();
            }
        }

        /// <summary>
        /// Altera o ID quando o textbox for alterado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextAnimationID_TextChanged(object sender, EventArgs e) {
            if (TextAnimationID.Text.Length == 0) {
                animationID = 0;
            }
            else {
                animationID = int.Parse(TextAnimationID.Text.Trim());
            }
        }

        /// <summary>
        /// Não permite letras no textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextAnimationID_KeyPress(object sender, KeyPressEventArgs e) {
            if ((Keys)e.KeyChar == Keys.Back) {
                return;
            }

            if (!char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            }
        }

        private void ChangeLanguage() {
            Text = Language.GetLanguageText("AnimationForm", "Title");
            LabelAnimID.Text  = Language.GetLanguageText("AnimationForm", "AnimID");
        }
    }
}
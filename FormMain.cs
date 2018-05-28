using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Security;
using System.Windows.Forms;
using Animation_Editor.Engine;
using Animation_Editor.Anim;
using Animation_Editor.Common;
using Animation_Editor.Export;

namespace Animation_Editor {
    public partial class FormMain : Form {

        #region Peek Message

        [SuppressUnmanagedCodeSecurity]
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool PeekMessage(out Message msg, IntPtr hWnd, uint messageFilterMin, uint messageFilterMax, uint flags);

        [StructLayout(LayoutKind.Sequential)]
        public struct Message {
            public IntPtr hWnd;
            public IntPtr msg;
            public IntPtr wParam;
            public IntPtr lParam;
            public uint time;
            public Point p;
        }

        public void OnApplicationIdle(object sender, EventArgs e) {
            // DrawAnimation();
        }

        private bool AppStillIdle {
            get {
                return !PeekMessage(out Message msg, IntPtr.Zero, 0, 0, 0);
            }
        }

        #endregion

        private Animation animation = new Animation();

        /// <summary>
        /// Lista de objetos (imagens).
        /// </summary>

        private List<BitmapObject> objectList = new List<BitmapObject>();

        /// <summary>
        /// Camada selecionada.
        /// </summary>
        private int selectedLayerIndex = 0;

        /// <summary>
        /// Indice do item selecionado na lista de frames.
        /// </summary>
        private int selectedItemIndex = -1;

        private int selectedObjectIndex = -1;

        /// <summary>
        /// Métodos de desenho.
        /// </summary>
        private EngineCore engine;

        /// <summary>
        /// Posição do mouse na tela.
        /// </summary>
        private Point mousePosition;

        /// <summary>
        /// Posição fixa do objeto.
        /// </summary>
        private int fixedX;
        private int fixedY;
        private bool fixedObject;

        /// <summary>
        /// Coloca a thread para dormir.
        /// </summary>
        private bool limitLoop = true;

        private bool gameRunning = true;

        public FormMain() {
            InitializeComponent();

            TextFrameItemX.KeyPress += TextBox_KeyPress;
            TextFrameItemY.KeyPress += TextBox_KeyPress;
            TextFrameItemHeight.KeyPress += TextBox_KeyPress;
            TextFrameItemWidth.KeyPress += TextBox_KeyPress;
            TextFrameItemTransp.KeyPress += TextBox_KeyPress;
        }

        public void InitializeEngine() {
            Directory.CreateDirectory($"{Environment.CurrentDirectory}/Object");
            Directory.CreateDirectory($"{Environment.CurrentDirectory}/Animation");
            Directory.CreateDirectory($"{Environment.CurrentDirectory}/Project");
            Directory.CreateDirectory($"{Environment.CurrentDirectory}/Export");

            var engineParameters = new EngineParameters {
                Handle = PictureAnimation.Handle,
                Width = PictureAnimation.Width,
                Height = PictureAnimation.Height
            };

            var fontParameters = new EngineFontParameters {
                Name = "Tahoma",
                Size = 9f,
                Style = FontStyle.Regular
            };

            engine = new EngineCore(engineParameters, fontParameters);

            UpdateClipArea();

            AddLanguages();
        }

        public void StartPlay() {
            engine.EditMode = false;
            MenuPlay.Checked = true;

            animation.FrameIndex = 0;
            UpdateFrameLabel();
            EnableOrDisableEditMode();
        }

        private void SaveProject() {
            if (animation.FrameCount > 0) {

                var dialog = new SaveFileDialog() {
                    InitialDirectory = Application.StartupPath + @"\Project\",
                    Filter = "Project Files (*.proj)|*.proj",
                };

                var result = dialog.ShowDialog();

                if (result == DialogResult.OK) {
                    var file = new FileStream(dialog.FileName, FileMode.Create);
                    var binary = new BinaryFormatter();

                    binary.Serialize(file, animation);
                    binary.Serialize(file, objectList);

                    file.Close();
                }
            }
        }

        private void OpenProject() {
            var dialog = new OpenFileDialog() {
                InitialDirectory = Application.StartupPath + @"\Project\",
                Filter = "Project Files (*.proj)|*.proj",
                FilterIndex = 1
            };

            var result = dialog.ShowDialog();

            if (result == DialogResult.OK) {
                var file = new FileStream(dialog.FileName, FileMode.Open);
                var binary = new BinaryFormatter();

                animation = (Animation)binary.Deserialize(file);
                objectList = (List<BitmapObject>)binary.Deserialize(file);

                file.Close();
            }

            ChangeScrollBarValues();

            UpdateFrameLabel();
            UpdateClipArea();
            UpdateListFrame();
            UpdateListObject();
        }

        private void DrawAnimation() {
            while (gameRunning) {
                Application.DoEvents();

                engine.Draw(animation);

                if (limitLoop) {
                    Thread.Sleep(1);
                }
            }

            Application.Exit();
        }

        #region Menu File

        private void MenuOpenProject_Click(object sender, EventArgs e) {
            OpenProject();
        }

        private void MenuSaveProject_Click(object sender, EventArgs e) {
            SaveProject();
        }

        private void MenuExportImage_Click(object sender, EventArgs e) {
            if (animation.FrameCount > 0) {

                var dialog = new SaveFileDialog() {
                    InitialDirectory = Application.StartupPath + @"\Animation",
                    Filter = "PNG Files (*.png)|*.png",
                    FilterIndex = 1
                };

                var result = dialog.ShowDialog();

                if (result == DialogResult.OK) {

                    var exportParameters = new ExportParameters {
                        BackBufferHeight = PictureAnimation.Height,
                        BackBufferWidth = PictureAnimation.Width,
                        MaxFramePerLineX = 5,
                    };

                    var export = new AnimationExport(exportParameters);
                    export.ExportPng(dialog.FileName, animation);
                }
            }
        }

        private void MenuExportObject_Click(object sender, EventArgs e) {
            if (animation.FrameCount > 0) {
                var form = new FormExport();
                form.Show(animation, PictureAnimation.Size);
            }
        }

        private void MenuExit_Click(object sender, EventArgs e) {
            gameRunning = false;
        }

        #endregion

        #region Menu Object

        private void MenuClearObject_Click(object sender, EventArgs e) {
            DestroySelectedObject();

            objectList.Clear();

            UpdateListObject();
        }

        private void MenuCloseObjectPointer_Click(object sender, EventArgs e) {
            DestroySelectedObject();
        }

        private void MenuAddObject_Click(object sender, EventArgs e) {
            var dialog = new OpenFileDialog {
                InitialDirectory = Application.StartupPath + @"\Object",
                Filter = "PNG Files (*.png)|*.png",
                Multiselect = true
            };

            var result = dialog.ShowDialog();

            if (result == DialogResult.OK) {
                AddObject(dialog.FileNames, dialog.SafeFileNames);

                UpdateListObject();
            }
        }

        private void MenuAddAnimation_Click(object sender, EventArgs e) {
            var dialog = new OpenFileDialog {
                InitialDirectory = Application.StartupPath + @"\Object",
                Filter = "PNG Files (*.png)|*.png",
                Multiselect = false
            };

            var result = dialog.ShowDialog();

            if (result == DialogResult.OK) {
                var form = new FormAddAnim();
                form.Show(objectList, animation, dialog.FileName, dialog.SafeFileName);
            }
        }

        #endregion

        #region Menu Animation
        private void MenuPlay_Click(object sender, EventArgs e) {
            engine.EditMode = !MenuPlay.Checked;

            if (!engine.EditMode) {
                DestroySelectedObject();
            }

            animation.FrameIndex = 0;
            UpdateFrameLabel();
            EnableOrDisableEditMode();
        }

        private void MenuLimitLoop_Click(object sender, EventArgs e) {
            limitLoop = MenuLimitLoop.Checked;
        }
        #endregion

        #region Menu Layer
        private void MenuGrid_Click(object sender, EventArgs e) {
            engine.GridVisible = MenuGrid.Checked;
        }

        private void MenuShowPreviousFrame_Click(object sender, EventArgs e) {
            engine.ShowPreviousFrame = MenuShowPreviousFrame.Checked;
        }

        private void MenuShowNextFrame_Click(object sender, EventArgs e) {
            engine.ShowNextFrame = MenuShowNextFrame.Checked;
        }

        private void MenuLayer1_Click(object sender, EventArgs e) {
            engine.SetLayerVisibility(0, MenuLayer1.Checked);
        }

        private void MenuLayer2_Click(object sender, EventArgs e) {
            engine.SetLayerVisibility(1, MenuLayer2.Checked);
        }

        private void MenuLayer3_Click(object sender, EventArgs e) {
            engine.SetLayerVisibility(2, MenuLayer3.Checked);
        }
        #endregion

        #region Layer Buttons

        private void ButtonLayer1_Click(object sender, EventArgs e) {
            selectedLayerIndex = 0;
            UpdateListFrame();
        }

        private void ButtonLayer2_Click(object sender, EventArgs e) {
            selectedLayerIndex = 1;
            UpdateListFrame();
        }

        private void ButtonLayer3_Click(object sender, EventArgs e) {
            selectedLayerIndex = 2;
            UpdateListFrame();
        }

        private void ButtonRemoveAll_Click(object sender, EventArgs e) {
            if (animation.FrameCount > 0) {
                animation.Clear(0);
                animation.Clear(1);
                animation.Clear(2);
            }

            ListFrame.Items.Clear();

        }

        #endregion

        #region Frame List

        /// <summary>
        /// Exibe os frames da camada selecionada.
        /// </summary>
        public void UpdateListFrame() {
            if (animation.FrameCount > 0) {

                ListFrame.BeginUpdate();

                ListFrame.Items.Clear();

                var count = animation.Count(animation.FrameIndex, selectedLayerIndex);

                for (var index = 0; index < count; index++) {
                    ListFrame.Items.Add(animation[animation.FrameIndex, selectedLayerIndex, index].Name);
                }

                ListFrame.EndUpdate();
            }
        }

        /// <summary>
        /// Seleciona o item na lista e altera o índice.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListFrame_MouseClick(object sender, MouseEventArgs e) {
            if (!PanelItemProperties.Visible) {
                var index = ListFrame.SelectedIndex;

                if (index >= 0) {
                    engine.SelectedFrameObject = animation[selectedLayerIndex, index].ScreenRect;
                    selectedItemIndex = index;
                }
            }
        }

        /// <summary>
        /// Exibe o menu de contexto.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListFrame_MouseDown(object sender, MouseEventArgs e) {
            if (ListFrame.Items.Count > 0) {

                if (selectedItemIndex >= 0) {
                    if (e.Button == MouseButtons.Right) {
                        ContextMenuFrame.Show(ListFrame, e.X, e.Y);
                    }
                }

            }
        }

        #endregion

        #region Frame Item Properties 

        private Rectangle GetFrameItemScreenRectangle() {
            return animation[selectedLayerIndex, selectedItemIndex].ScreenRect;
        }

        private void SetFramePropertiesValueFromFrame(int index) {
            var frame = animation[selectedLayerIndex, index];

            TextFrameItemName.Text = frame.Name;
            TextFrameItemX.Text = frame.ScreenRect.X.ToString();
            TextFrameItemY.Text = frame.ScreenRect.Y.ToString();
            TextFrameItemWidth.Text = frame.ScreenRect.Width.ToString();
            TextFrameItemHeight.Text = frame.ScreenRect.Height.ToString();
            TextFrameItemTransp.Text = frame.Transparency.ToString();
        }

        private void TextFrameItemName_TextChanged(object sender, EventArgs e) {
            animation[selectedLayerIndex, selectedItemIndex].Name = TextFrameItemName.Text.Trim();
            ListFrame.Items[selectedItemIndex] = TextFrameItemName.Text.Trim();
        }

        private void TextFrameItemX_TextChanged(object sender, EventArgs e) {
            var x = 0;

            if (TextFrameItemX.Text.Length > 0) {
                x = int.Parse(TextFrameItemX.Text);
            }

            var rect = GetFrameItemScreenRectangle();
            rect.X = x;

            animation[selectedLayerIndex, selectedItemIndex].ScreenRect = rect;
            // Altera o retângulo do frame selecionado.
            engine.SelectedFrameObject = rect;
        }

        private void TextFrameItemY_TextChanged(object sender, EventArgs e) {
            var y = 0;
            if (TextFrameItemY.Text.Length > 0) {
                y = int.Parse(TextFrameItemY.Text);
            }
           
            var rect = GetFrameItemScreenRectangle();
            rect.Y = y;

            animation[selectedLayerIndex, selectedItemIndex].ScreenRect = rect;
            // Altera o retângulo do frame selecionado.
            engine.SelectedFrameObject = rect;
        }

        private void TextFrameItemWidth_TextChanged(object sender, EventArgs e) {
            var width = 0;

            if (TextFrameItemWidth.Text.Length == 0) {
                width = int.Parse(TextFrameItemWidth.Text);
            }

            var rect = GetFrameItemScreenRectangle();
            rect.Width = width;

            animation[selectedLayerIndex, selectedItemIndex].ScreenRect = rect;
            // Altera o retângulo do frame selecionado.
            engine.SelectedFrameObject = rect;
        }

        private void TextFrameItemHeight_TextChanged(object sender, EventArgs e) {
            var height = 0;

            if (TextFrameItemHeight.Text.Length == 0) {
                height = int.Parse(TextFrameItemHeight.Text);
            }

            var rect = GetFrameItemScreenRectangle();
            rect.Height = height;

            animation[selectedLayerIndex, selectedItemIndex].ScreenRect = rect;
            // Altera o retângulo do frame selecionado.
            engine.SelectedFrameObject = rect;
        }

        private void TextFrameItemTransp_TextChanged(object sender, EventArgs e) {
            var value = 0;

            if (TextFrameItemTransp.Text.Length == 0) {
                value = int.Parse(TextFrameItemTransp.Text);
            }

            if (value < 0) {
                value = 0;
            }
            else if (value > 100) {
                value = 100;
                TextFrameItemTransp.Text = "100";
            }

            animation[selectedLayerIndex, selectedItemIndex].Transparency = value;
        }

        private void ButtonCloseFrameProperties_Click(object sender, EventArgs e) {
            PanelItemProperties.Visible = false;
        }


        #endregion

        #region Context Menu Frame

        private void MenuExportFrameItem_Click(object sender, EventArgs e) {
            if (selectedItemIndex > 0) {
                var dialog = new SaveFileDialog() {
                    InitialDirectory = Application.StartupPath + @"\Export",
                    Filter = "Png Files (*.png)|*.png",
                    FilterIndex = 1
                };

                var result = dialog.ShowDialog();

                if (result == DialogResult.OK) {
                    var frame = animation[selectedLayerIndex, selectedItemIndex];
                    frame.Image.Save(dialog.FileName);
                }
            }
        }

        private void MenuMoveUp_Click(object sender, EventArgs e) {
            // Obtém o índice do frame selecionado.
            var index = ListFrame.SelectedIndex;

            // Se o objeto não estiver no topo da lista.
            if (index > 0) {
                var frame = animation[selectedLayerIndex, index];

                // Remove o frame.
                animation.RemoveLayerFrame(selectedLayerIndex, index);
                // Insere uma posição acima do original.
                animation.Insert(selectedLayerIndex, index - 1, frame);

                // Atualiza o novo índice.
                selectedItemIndex = -1;

                UpdateListFrame();
            }

        }

        private void MenuMoveDown_Click(object sender, EventArgs e) {
            var index = ListFrame.SelectedIndex;

            // Se o item não for o último da lista.
            if (index >= 0 && index < animation.Count(selectedLayerIndex) - 1) {
                var frame = animation[selectedLayerIndex, index];

                animation.RemoveLayerFrame(selectedLayerIndex, index);

                // Como o item foi removido.
                // Verifica se ultrapassou a quantidade de items adicionados.
                // Caso verdadeiro, insere novamente para ir para a última posição.
                if (index + 1 >= animation.Count(selectedLayerIndex)) {
                    animation.Add(selectedLayerIndex, (frame));
                }
                else {
                    // Caso contrário, insere na posição especificada.
                    animation.Insert(selectedLayerIndex, index + 1, frame);
                }

                // Atualiza o novo índice.
                selectedItemIndex = -1;

                UpdateListFrame();
            }
        }

        private void MenuRemoveItem_Click(object sender, EventArgs e) {
            if (selectedItemIndex >= 0) {
                engine.SelectedFrameObject = new Rectangle(0, 0, 0, 0);
                animation.RemoveLayerFrame(selectedLayerIndex, selectedItemIndex);

                // Atualiza o novo índice.
                selectedItemIndex = -1;

                UpdateListFrame();
            }
        }

        private void MenuClearFrames_Click(object sender, EventArgs e) {
            if (animation.FrameCount > 0) {
                animation.Clear(selectedLayerIndex);
            }

            ListFrame.Items.Clear();
        }

        private void MenuProperties_Click(object sender, EventArgs e) {
            // Somente permite que as propriedades sejam alteradas quando o formulário estiver invisível.
            if (!PanelItemProperties.Visible) {
                if (selectedItemIndex >= 0) {
                    SetFramePropertiesValueFromFrame(selectedItemIndex);
                    PanelItemProperties.Visible = true;
                }
            }
        }

        #endregion

        #region Context Menu Object
        private void MenuExportObjectFromList_Click(object sender, EventArgs e) {
            if (selectedObjectIndex >= 0) {
                var dialog = new SaveFileDialog() {
                    InitialDirectory = Application.StartupPath + @"\Export",
                    Filter = "Png Files (*.png)|*.png",
                    FilterIndex = 1
                };

                var result = dialog.ShowDialog();

                if (result == DialogResult.OK) {
                    objectList[selectedObjectIndex].Image.Save(dialog.FileName);
                }
            }
        }

        private void MenuRemoveObject_Click(object sender, EventArgs e) {
            if (selectedObjectIndex >= 0) {

                if (engine.SelectedObject != null) {
                    if (selectedObjectIndex == engine.SelectedObject.ObjectIndex) {
                        DestroySelectedObject();
                    }
                }

                objectList.RemoveAt(selectedObjectIndex);

                selectedObjectIndex = -1;

                UpdateListObject();
            }
        }

        private void MenuRemoveAllObject_Click(object sender, EventArgs e) {
            DestroySelectedObject();

            objectList.Clear();

            UpdateListObject();
        }

        private void MenuSetColorKey_Click(object sender, EventArgs e) {
            if (selectedObjectIndex >= 0) {

                var dialog = new ColorDialog() {
                    AnyColor = true,
                    AllowFullOpen = true,
                    FullOpen = true
                };

                var result = dialog.ShowDialog();

                if (result == DialogResult.OK) {
                    objectList[selectedObjectIndex].Image.MakeTransparent(dialog.Color);
                }
            }
        }

        #endregion

        #region Frame Buttons
        private void UpdateFrameLabel() {
            var text = (animation.FrameCount == 0) ? "0" : (animation.FrameIndex + 1).ToString();

            LabelFrame.Text = $"{Language.FrameText}: {text} / {animation.FrameCount}";
        }

        private void CheckFixObject_CheckedChanged(object sender, EventArgs e) {
            fixedObject = CheckFixObject.Checked;
        }

        private void TextFrameRate_TextChanged(object sender, EventArgs e) {
            var frameRate = 0;

            if (TextFrameRate.Text.Length == 0) {
                frameRate = int.Parse(TextFrameRate.Text); 
            }

            animation.FrameRateTime = frameRate;
        }

        private void TextPositionX_TextChanged(object sender, EventArgs e) {
            if (TextPositionX.Text.Length == 0) {
                fixedX = 0;
            }
            else {
                fixedX = int.Parse(TextPositionX.Text);
            }      
        }

        private void TextPositionY_TextChanged(object sender, EventArgs e) {
            if (TextPositionY.Text.Length == 0) {
                fixedY = 0;
            }
            else {
                fixedY = int.Parse(TextPositionY.Text);
            }
        }

        private void TextFrameRate_KeyPress(object sender, KeyPressEventArgs e) {
            if ((Keys)e.KeyChar == Keys.Back) {
                return;
            }

            if (!char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            }
        }

        private void TextPositionX_KeyPress(object sender, KeyPressEventArgs e) {
            if ((Keys)e.KeyChar == Keys.Back) {
                return;
            }

            if (!char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            }
        }

        private void TextPositionY_KeyPress(object sender, KeyPressEventArgs e) {
            if ((Keys)e.KeyChar == Keys.Back) {
                return;
            }

            if (!char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            }
        }

        private void ButtonAddFrame_Click(object sender, EventArgs e) {
            animation.IncrementFrame();
            UpdateFrameLabel();
        }

        private void ButtonRemoveAt_Click(object sender, EventArgs e) {
            animation.RemoveFrame(animation.FrameIndex);
            engine.SelectedFrameObject = new Rectangle(0, 0, 0, 0);

            UpdateListFrame();
            UpdateFrameLabel();
        }

        private void ButtonRemoveLast_Click(object sender, EventArgs e) {
            if (animation.FrameIndex >= animation.FrameCount - 1) {
                animation.FrameIndex--;
            }

            animation.RemoveFrame(animation.FrameCount - 1);
            engine.SelectedFrameObject = new Rectangle(0, 0, 0, 0);

            UpdateListFrame();
            UpdateFrameLabel();
        }

        private void ButtonClearFrames_click(object sender, EventArgs e) {
            animation.RemoveAll();
            engine.SelectedFrameObject = new Rectangle(0, 0, 0, 0);

            UpdateListFrame();
            UpdateFrameLabel();
        }

        private void ButtonPrevious_Click(object sender, EventArgs e) {
            if (animation.MovePrevious()) {

                UpdateListFrame();

                UpdateFrameLabel();
            }
        }

        private void ButtonNext_Click(object sender, EventArgs e) {
            if (animation.MoveNext()) {

                UpdateListFrame();
                UpdateFrameLabel();

                engine.SelectedFrameObject = new Rectangle(0, 0, 0, 0);
            }
        }

        private void ButtonMoveToStart_Click(object sender, EventArgs e) {
            animation.FrameIndex = 0;

            UpdateListFrame();
            UpdateFrameLabel();
        }

        private void ButtonMoveToLast_Click(object sender, EventArgs e) {
            animation.FrameIndex = animation.FrameCount - 1;

            UpdateListFrame();
            UpdateFrameLabel();
        }
        #endregion

        #region Picture Animation

        private void PictureAnimation_MouseMove(object sender, MouseEventArgs e) {
            mousePosition = PictureAnimation.PointToClient(MousePosition);

            if (engine.SelectedObject != null) {
                engine.SelectedObject.X = mousePosition.X;
                engine.SelectedObject.Y = mousePosition.Y;

                UpdateLabelOffsetAndMousePosition();
            }
        }

        private void PictureAnimation_MouseClick(object sender, MouseEventArgs e) {
            if (CanAddFrame()) {

                if (e.Button == MouseButtons.Left) {
                    if (fixedObject) {
                        engine.SelectedObject.X = fixedX;
                        engine.SelectedObject.Y = fixedY;
                    }

                    Frame frame = new Frame() {
                        Image = new Bitmap(engine.SelectedObject.Image),
                        ScreenRect = engine.SelectedObject.ScreenRectangle,
                        Name = objectList[engine.SelectedObject.ObjectIndex].Name,
                        Transparency = byte.MaxValue,
                    };

                    frame.SourceRect = new Rectangle(0, 0, frame.ScreenRect.Width, frame.ScreenRect.Height);

                    animation.Add(selectedLayerIndex, frame);

                    UpdateListFrame();
                }

                if (e.Button == MouseButtons.Right) {
                    DestroySelectedObject();
                    UpdateLabelOffsetAndMousePosition();
                }

            }
        }

        /// <summary>
        /// Verifica se há as condições necessárias para adiciona um frame.
        /// </summary>
        /// <returns></returns>
        private bool CanAddFrame() {
            if (engine.SelectedObject != null) {
                if (engine.EditMode) {
                    if (animation.FrameCount > 0) {
                        return true;
                    }
                }
            }

            return false;
        }

        #endregion

        #region Object List

        /// <summary>
        /// Seleciona o item na lista e altera o índice.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListObject_MouseClick(object sender, MouseEventArgs e) {
            selectedObjectIndex = ListObject.SelectedIndex;
        }

        /// <summary>
        /// Seleciona o objeto na lista.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListObject_DoubleClick(object sender, EventArgs e) {
            if (animation.FrameCount > 0) {
                var index = ListObject.SelectedIndex;

                if (index >= 0) {
                    engine.SelectedObject = new EnginePointer {
                        Image = objectList[index].Image,
                        Width = objectList[index].Image.Width,
                        Height = objectList[index].Image.Height,
                        ObjectIndex = index
                    };
                }
            }
        }

        /// <summary>
        /// Exibe o menu de contexto.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListObject_MouseDown(object sender, MouseEventArgs e) {
            if (ListObject.Items.Count > 0) {

                if (selectedObjectIndex >= 0) {
                    if (e.Button == MouseButtons.Right) {
                        ContextMenuObject.Show(ListObject, e.X, e.Y);
                    }
                }

            }
        }

        /// <summary>
        /// Atualiza a lista de objetos.
        /// </summary>
        public void UpdateListObject() {
            ListObject.BeginUpdate();

            ListObject.Items.Clear();

            for (var index = 0; index < objectList.Count; index++) {
                ListObject.Items.Add(objectList[index].Name);
            }

            ListObject.EndUpdate();
        }

        /// <summary>
        /// Adiciona as imagens selecionadas na lista.
        /// </summary>
        /// <param name="fileNames"></param>
        /// <param name="safeNames"></param>
        private void AddObject(string[] fileNames, string[] safeNames) {
            var length = fileNames.Length;

            for (var index = 0; index < length; index++) {
                var obj = new BitmapObject {
                    Name = GetFileName(safeNames[index]),
                    Image = new Bitmap(fileNames[index])
                };

                objectList.Add(obj);

                Application.DoEvents();
            }
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

        #endregion

        #region Scroll Bar
        private void ScrollBarPositionY_Scroll(object sender, ScrollEventArgs e) {
            UpdateClipArea();
        }

        private void ScrollBarPositionX_Scroll(object sender, ScrollEventArgs e) {
            UpdateClipArea();
        }

        private void ScrollBarWidth_Scroll(object sender, ScrollEventArgs e) {
            UpdateClipArea();
        }

        private void ScrollBarHeight_Scroll(object sender, ScrollEventArgs e) {
            UpdateClipArea();
        }

        private void UpdateClipArea() {
            var rect = new Rectangle {
                X = ScrollBarPositionX.Value,
                Y = ScrollBarPositionY.Value,
                Width = ScrollBarWidth.Value,
                Height = ScrollBarHeight.Value
            };

            // Define a area de recorte.
            animation.ClipArea = rect;

            LabelStatus.Text = $"{Language.ClipAreaText} X: {ScrollBarPositionX.Value} Y: {ScrollBarPositionY.Value} {Language.WidthText}: {ScrollBarWidth.Value} {Language.HeightText}: {ScrollBarHeight.Value}";
        }

        private void ChangeScrollBarValues() {
            ScrollBarPositionX.Value = animation.ClipArea.X;
            ScrollBarPositionY.Value = animation.ClipArea.Y;
            ScrollBarWidth.Value = animation.ClipArea.Width;
            ScrollBarHeight.Value = animation.ClipArea.Height;
        }
        #endregion

        #region Language 
        private void AddLanguages() {
            var languages = Language.GetLanguages();

            for (var n = 0; n < languages.Length; n++) {
                MenuLanguage.DropDownItems.Add(languages[n]);
                MenuLanguage.DropDownItems[n].Click += MenuLanguageItem_Click;
            }

            ChangeLanguage(Language.GetConfigString("Current"));
        }

        private void MenuLanguageItem_Click(object sender, EventArgs e) {
            var language = ((ToolStripDropDownItem)sender).Text;

            ChangeLanguage(language.Trim());
        }

        private void ChangeLanguage(string language) {
            Language.CurrentLanguage = language;
            Language.WriteConfig("Current", language);

            MenuFile.Text = Language.GetLanguageText("FileMenu", "File");
            MenuOpenProject.Text = Language.GetLanguageText("FileMenu", "OpenProject");
            MenuSaveProject.Text = Language.GetLanguageText("FileMenu", "SaveProject");
            MenuExport.Text = Language.GetLanguageText("FileMenu", "Export");
            MenuExportImage.Text = Language.GetLanguageText("FileMenu", "ExportImage");
            MenuExportObject.Text = Language.GetLanguageText("FileMenu", "ExportObject");
            MenuExit.Text = Language.GetLanguageText("FileMenu", "Quit");

            MenuLayer.Text = Language.GetLanguageText("LayerMenu", "Layer");
            MenuGrid.Text = Language.GetLanguageText("LayerMenu", "Grid");
            MenuShowPreviousFrame.Text = Language.GetLanguageText("LayerMenu", "ShowPrevious");
            MenuShowNextFrame.Text = Language.GetLanguageText("LayerMenu", "ShowNext");
            MenuLayer1.Text = Language.GetLanguageText("LayerMenu", "Layer1");
            MenuLayer2.Text = Language.GetLanguageText("LayerMenu", "Layer2");
            MenuLayer3.Text = Language.GetLanguageText("LayerMenu", "Layer3");

            ButtonLayer1.Text = MenuLayer1.Text;
            ButtonLayer2.Text = MenuLayer2.Text;
            ButtonLayer3.Text = MenuLayer3.Text;

            MenuAnimation.Text = Language.GetLanguageText("AnimMenu", "Animation");
            MenuPlay.Text = Language.GetLanguageText("AnimMenu", "Play");
            MenuLimitLoop.Text = Language.GetLanguageText("AnimMenu", "LimitLoop");

            MenuObject.Text = Language.GetLanguageText("ObjectMenu", "Object");
            MenuAdd.Text = Language.GetLanguageText("ObjectMenu", "Add");

            MenuAddObject.Text = Language.GetLanguageText("ObjectMenu", "AddFrame");
            MenuAddAnimation.Text = Language.GetLanguageText("ObjectMenu", "AddAnimation");

            MenuClearObject.Text = Language.GetLanguageText("ObjectMenu", "ClearList");
            MenuCloseObjectPointer.Text = Language.GetLanguageText("ObjectMenu", "ClosePointer");
            LabelListObject.Text = Language.GetLanguageText("ObjectMenu", "ObjectList");

            MenuLanguage.Text = Language.GetLanguageText("LanguageMenu", "Language");

            Language.WidthText = Language.GetLanguageText("LabelClipArea", "Width");
            Language.HeightText = Language.GetLanguageText("LabelClipArea", "Height");
            Language.ClipAreaText = Language.GetLanguageText("LabelClipArea", "ClipArea");

            Language.MoveUpText = Language.GetLanguageText("LayerList", "MoveUp");
            Language.MoveDownText = Language.GetLanguageText("LayerList", "MoveDown");

            CheckFixObject.Text = Language.GetLanguageText("Frame", "Fix");
            LabelFrameRateTime.Text = Language.GetLanguageText("Frame", "FrameTime");
            ButtonMoveToLast.Text = Language.GetLanguageText("Frame", "Last");
            ButtonMoveToStart.Text = Language.GetLanguageText("Frame", "First");
            ButtonAddFrame.Text = Language.GetLanguageText("Frame", "Add");
            ButtonRemoveAt.Text = Language.GetLanguageText("Frame", "RemoveThis");
            ButtonRemoveLast.Text = Language.GetLanguageText("Frame", "RemoveLast");
            ButtonRemoveAll.Text = Language.GetLanguageText("Frame", "ClearLayer");
            ButtonClearFrames.Text = Language.GetLanguageText("Frame", "RemoveAll");

            // Context Menu.
            MenuExportFrameItem.Text = MenuExport.Text;
            MenuMoveUp.Text = Language.MoveUpText;
            MenuMoveDown.Text = Language.MoveDownText;
            MenuRemoveItem.Text = Language.GetLanguageText("ContextMenu", "Remove");
            MenuClearFrames.Text = Language.GetLanguageText("ObjectMenu", "ClearList");
            MenuProperties.Text = Language.GetLanguageText("ContextMenu", "Property");

            LabelFrameItemTransp.Text = Language.GetLanguageText("ContextMenu", "Transparency");
            LabelFrameItemWidth.Text = Language.WidthText;
            LabelFrameItemHeight.Text = Language.HeightText;
            LabelFrameItemName.Text = Language.GetLanguageText("ContextMenu", "Name");
            ButtonCloseFrameProperties.Text = Language.GetLanguageText("ContextMenu", "Close");

            MenuExportObjectFromList.Text = MenuExport.Text;
            MenuRemoveObject.Text = Language.GetLanguageText("ContextMenu", "Remove");
            MenuRemoveAllObject.Text = Language.GetLanguageText("ObjectMenu", "ClearList");

            Language.FrameText = Language.GetLanguageText("Frame", "Frame");
            Language.MouseText = Language.GetLanguageText("Frame", "Mouse");

            Language.MessageTitle = Language.GetLanguageText("Message", "MsgTitle");
            Language.MessageText = Language.GetLanguageText("Message", "Msg");
            Language.FrameCount = Language.GetLanguageText("AnimationForm", "Count");

            Text = Language.GetLanguageText("Window", "Title");
            MenuShortcut.Text = Language.GetLanguageText("Window", "Shortcut");

            UpdateFrameLabel();
            UpdateClipArea();
        }
        #endregion

        private void FormMain_KeyDown(object sender, KeyEventArgs e) {
            if (engine.SelectedObject != null) {
                switch (e.KeyCode) {
                    case Keys.W:
                        engine.SelectedObject.OffsetY++;
                        break;
                    case Keys.S:
                        engine.SelectedObject.OffsetY--;
                        break;
                    case Keys.A:
                        engine.SelectedObject.OffsetX--;
                        break;
                    case Keys.D:
                        engine.SelectedObject.OffsetX++;
                        break;
                    case Keys.ShiftKey:
                        engine.SelectedObject = null;
                        break;
                }
            }

            if (e.KeyCode == Keys.ControlKey) {
                if (engine.SelectedObject != null) {
                    engine.SelectedObject.OffsetX = 0;
                    engine.SelectedObject.OffsetY = 0;
                }

                engine.SelectedFrameObject = new Rectangle(0, 0, 0, 0);
            }
            else if (e.KeyCode == Keys.Z) {
                if (animation.MovePrevious()) {

                    UpdateListFrame();

                    UpdateFrameLabel();
                }
            }
            else if (e.KeyCode == Keys.C) {
                if (animation.MoveNext()) {

                    UpdateListFrame();

                    UpdateFrameLabel();
                }
            }      

            if (engine.SelectedObject != null) {
                UpdateLabelOffsetAndMousePosition();
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e) {
            gameRunning = false;
            engine.Exit();
        }

        private void FormMain_Load(object sender, EventArgs e) {
            Show();

            DrawAnimation();
        }

        /// <summary>
        /// Permite que apenas números sejam inseridos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_KeyPress(object sender, KeyPressEventArgs e) {
            if ((Keys)e.KeyChar == Keys.Back) {
                return;
            }

            if (!char.IsDigit(e.KeyChar)) {
                e.Handled = true;
            }
        }

        private void UpdateLabelOffsetAndMousePosition() {
            if (engine.SelectedObject != null) {
                LabelOffset.Text = $"{Language.MouseText} X : {mousePosition.X} Y: {mousePosition.Y} Pointer OffsetX : {engine.SelectedObject.OffsetX} OffsetY : {engine.SelectedObject.OffsetY}";
            }
            else {
                LabelOffset.Text = $"{Language.MouseText} X : 0 Y: 0 Pointer OffsetX : 0 OffsetY : 0";
            } 
        }

        private void DestroySelectedObject() {
            engine.SelectedObject = null;
            UpdateLabelOffsetAndMousePosition();
        }

        private void EnableOrDisableEditMode() {
            var value = engine.EditMode;
            ButtonMoveToStart.Enabled = value;
            ButtonAddFrame.Enabled = value;
            ButtonRemoveAt.Enabled = value;
            ButtonRemoveLast.Enabled = value;
            ButtonClearFrames.Enabled = value;
            ButtonMoveToLast.Enabled = value;
            ButtonNext.Enabled = value;
            ButtonPrevious.Enabled = value;
            ListFrame.Enabled = value;
            ListObject.Enabled = value;
            ButtonRemoveAll.Enabled = value;
            ButtonLayer1.Enabled = value;
            ButtonLayer2.Enabled = value;
            ButtonLayer3.Enabled = value;
        }
    }
}
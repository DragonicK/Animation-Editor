namespace Animation_Editor
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.ListObject = new System.Windows.Forms.ListBox();
            this.PictureAnimation = new System.Windows.Forms.PictureBox();
            this.ListFrame = new System.Windows.Forms.ListBox();
            this.ButtonMoveToLast = new System.Windows.Forms.Button();
            this.ButtonMoveToStart = new System.Windows.Forms.Button();
            this.ButtonNext = new System.Windows.Forms.Button();
            this.ButtonPrevious = new System.Windows.Forms.Button();
            this.ButtonAddFrame = new System.Windows.Forms.Button();
            this.ButtonRemoveAt = new System.Windows.Forms.Button();
            this.ButtonRemoveLast = new System.Windows.Forms.Button();
            this.ButtonClearFrames = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuOpenProject = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSaveProject = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuExport = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuExportImage = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuExportObject = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuLayer = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuGrid = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuShowPreviousFrame = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuShowNextFrame = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuLayer1 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuLayer2 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuLayer3 = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAnimation = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuPlay = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuLimitLoop = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuObject = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAddObject = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuAddAnimation = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuClearObject = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuCloseObjectPointer = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuShortcut = new System.Windows.Forms.ToolStripMenuItem();
            this.ButtonLayer1 = new System.Windows.Forms.Button();
            this.ButtonLayer2 = new System.Windows.Forms.Button();
            this.ButtonLayer3 = new System.Windows.Forms.Button();
            this.ButtonRemoveAll = new System.Windows.Forms.Button();
            this.ScrollBarPositionX = new System.Windows.Forms.HScrollBar();
            this.ScrollBarWidth = new System.Windows.Forms.HScrollBar();
            this.ScrollBarHeight = new System.Windows.Forms.VScrollBar();
            this.ScrollBarPositionY = new System.Windows.Forms.VScrollBar();
            this.LabelListObject = new System.Windows.Forms.Label();
            this.LabelFrame = new System.Windows.Forms.Label();
            this.CheckFixObject = new System.Windows.Forms.CheckBox();
            this.TextPositionX = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TextPositionY = new System.Windows.Forms.TextBox();
            this.LabelStatus = new System.Windows.Forms.Label();
            this.TextFrameRate = new System.Windows.Forms.TextBox();
            this.LabelFrameRateTime = new System.Windows.Forms.Label();
            this.ContextMenuFrame = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuExportFrameItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuMoveUp = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuMoveDown = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuRemoveItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuClearFrames = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.LabelOffset = new System.Windows.Forms.Label();
            this.ContextMenuObject = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.MenuExportObjectFromList = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuRemoveObject = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuRemoveAllObject = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSetColorKey = new System.Windows.Forms.ToolStripMenuItem();
            this.PanelItemProperties = new System.Windows.Forms.Panel();
            this.TextFrameItemName = new System.Windows.Forms.TextBox();
            this.LabelFrameItemName = new System.Windows.Forms.Label();
            this.ButtonCloseFrameProperties = new System.Windows.Forms.Button();
            this.TextFrameItemTransp = new System.Windows.Forms.TextBox();
            this.LabelFrameItemHeight = new System.Windows.Forms.Label();
            this.LabelFrameItemTransp = new System.Windows.Forms.Label();
            this.TextFrameItemHeight = new System.Windows.Forms.TextBox();
            this.LabelFrameItemWidth = new System.Windows.Forms.Label();
            this.TextFrameItemWidth = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TextFrameItemY = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TextFrameItemX = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.PictureAnimation)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.ContextMenuFrame.SuspendLayout();
            this.ContextMenuObject.SuspendLayout();
            this.PanelItemProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListObject
            // 
            this.ListObject.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListObject.FormattingEnabled = true;
            this.ListObject.ItemHeight = 14;
            this.ListObject.Location = new System.Drawing.Point(12, 57);
            this.ListObject.Name = "ListObject";
            this.ListObject.ScrollAlwaysVisible = true;
            this.ListObject.Size = new System.Drawing.Size(123, 452);
            this.ListObject.TabIndex = 0;
            this.ListObject.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListObject_MouseClick);
            this.ListObject.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListObject_DoubleClick);
            this.ListObject.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ListObject_MouseDown);
            // 
            // PictureAnimation
            // 
            this.PictureAnimation.BackColor = System.Drawing.Color.Black;
            this.PictureAnimation.Location = new System.Drawing.Point(187, 172);
            this.PictureAnimation.Name = "PictureAnimation";
            this.PictureAnimation.Size = new System.Drawing.Size(416, 295);
            this.PictureAnimation.TabIndex = 1;
            this.PictureAnimation.TabStop = false;
            this.PictureAnimation.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureAnimation_MouseClick);
            this.PictureAnimation.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureAnimation_MouseMove);
            // 
            // ListFrame
            // 
            this.ListFrame.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListFrame.ItemHeight = 14;
            this.ListFrame.Location = new System.Drawing.Point(652, 157);
            this.ListFrame.Name = "ListFrame";
            this.ListFrame.ScrollAlwaysVisible = true;
            this.ListFrame.Size = new System.Drawing.Size(120, 354);
            this.ListFrame.TabIndex = 2;
            this.ListFrame.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListFrame_MouseClick);
            this.ListFrame.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ListFrame_MouseDown);
            // 
            // ButtonMoveToLast
            // 
            this.ButtonMoveToLast.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonMoveToLast.Location = new System.Drawing.Point(546, 63);
            this.ButtonMoveToLast.Name = "ButtonMoveToLast";
            this.ButtonMoveToLast.Size = new System.Drawing.Size(92, 21);
            this.ButtonMoveToLast.TabIndex = 3;
            this.ButtonMoveToLast.Text = "Último";
            this.ButtonMoveToLast.UseVisualStyleBackColor = true;
            this.ButtonMoveToLast.Click += new System.EventHandler(this.ButtonMoveToLast_Click);
            // 
            // ButtonMoveToStart
            // 
            this.ButtonMoveToStart.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonMoveToStart.Location = new System.Drawing.Point(141, 66);
            this.ButtonMoveToStart.Name = "ButtonMoveToStart";
            this.ButtonMoveToStart.Size = new System.Drawing.Size(92, 21);
            this.ButtonMoveToStart.TabIndex = 4;
            this.ButtonMoveToStart.Text = "Primeiro";
            this.ButtonMoveToStart.UseVisualStyleBackColor = true;
            this.ButtonMoveToStart.Click += new System.EventHandler(this.ButtonMoveToStart_Click);
            // 
            // ButtonNext
            // 
            this.ButtonNext.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonNext.Location = new System.Drawing.Point(469, 64);
            this.ButtonNext.Name = "ButtonNext";
            this.ButtonNext.Size = new System.Drawing.Size(50, 21);
            this.ButtonNext.TabIndex = 5;
            this.ButtonNext.Text = ">";
            this.ButtonNext.UseVisualStyleBackColor = true;
            this.ButtonNext.Click += new System.EventHandler(this.ButtonNext_Click);
            // 
            // ButtonPrevious
            // 
            this.ButtonPrevious.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonPrevious.Location = new System.Drawing.Point(255, 66);
            this.ButtonPrevious.Name = "ButtonPrevious";
            this.ButtonPrevious.Size = new System.Drawing.Size(50, 21);
            this.ButtonPrevious.TabIndex = 6;
            this.ButtonPrevious.Text = "<";
            this.ButtonPrevious.UseVisualStyleBackColor = true;
            this.ButtonPrevious.Click += new System.EventHandler(this.ButtonPrevious_Click);
            // 
            // ButtonAddFrame
            // 
            this.ButtonAddFrame.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonAddFrame.Location = new System.Drawing.Point(141, 90);
            this.ButtonAddFrame.Name = "ButtonAddFrame";
            this.ButtonAddFrame.Size = new System.Drawing.Size(115, 21);
            this.ButtonAddFrame.TabIndex = 7;
            this.ButtonAddFrame.Text = "Adicionar";
            this.ButtonAddFrame.UseVisualStyleBackColor = true;
            this.ButtonAddFrame.Click += new System.EventHandler(this.ButtonAddFrame_Click);
            // 
            // ButtonRemoveAt
            // 
            this.ButtonRemoveAt.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonRemoveAt.Location = new System.Drawing.Point(262, 90);
            this.ButtonRemoveAt.Name = "ButtonRemoveAt";
            this.ButtonRemoveAt.Size = new System.Drawing.Size(115, 21);
            this.ButtonRemoveAt.TabIndex = 8;
            this.ButtonRemoveAt.Text = "Remover Este";
            this.ButtonRemoveAt.UseVisualStyleBackColor = true;
            this.ButtonRemoveAt.Click += new System.EventHandler(this.ButtonRemoveAt_Click);
            // 
            // ButtonRemoveLast
            // 
            this.ButtonRemoveLast.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonRemoveLast.Location = new System.Drawing.Point(402, 90);
            this.ButtonRemoveLast.Name = "ButtonRemoveLast";
            this.ButtonRemoveLast.Size = new System.Drawing.Size(115, 21);
            this.ButtonRemoveLast.TabIndex = 9;
            this.ButtonRemoveLast.Text = "Remover Último";
            this.ButtonRemoveLast.UseVisualStyleBackColor = true;
            this.ButtonRemoveLast.Click += new System.EventHandler(this.ButtonRemoveLast_Click);
            // 
            // ButtonClearFrames
            // 
            this.ButtonClearFrames.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonClearFrames.Location = new System.Drawing.Point(523, 90);
            this.ButtonClearFrames.Name = "ButtonClearFrames";
            this.ButtonClearFrames.Size = new System.Drawing.Size(115, 21);
            this.ButtonClearFrames.TabIndex = 10;
            this.ButtonClearFrames.Text = "Remover Todos";
            this.ButtonClearFrames.UseVisualStyleBackColor = true;
            this.ButtonClearFrames.Click += new System.EventHandler(this.ButtonClearFrames_click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFile,
            this.MenuLayer,
            this.MenuAnimation,
            this.MenuObject,
            this.MenuLanguage,
            this.MenuShortcut});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuFile
            // 
            this.MenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuOpenProject,
            this.MenuSaveProject,
            this.MenuExport,
            this.MenuExit});
            this.MenuFile.Name = "MenuFile";
            this.MenuFile.Size = new System.Drawing.Size(61, 20);
            this.MenuFile.Text = "Arquivo";
            // 
            // MenuOpenProject
            // 
            this.MenuOpenProject.Name = "MenuOpenProject";
            this.MenuOpenProject.Size = new System.Drawing.Size(146, 22);
            this.MenuOpenProject.Text = "Abrir Projeto";
            this.MenuOpenProject.Click += new System.EventHandler(this.MenuOpenProject_Click);
            // 
            // MenuSaveProject
            // 
            this.MenuSaveProject.Name = "MenuSaveProject";
            this.MenuSaveProject.Size = new System.Drawing.Size(146, 22);
            this.MenuSaveProject.Text = "Salvar Projeto";
            this.MenuSaveProject.Click += new System.EventHandler(this.MenuSaveProject_Click);
            // 
            // MenuExport
            // 
            this.MenuExport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuExportImage,
            this.MenuExportObject});
            this.MenuExport.Name = "MenuExport";
            this.MenuExport.Size = new System.Drawing.Size(146, 22);
            this.MenuExport.Text = "Exportar";
            // 
            // MenuExportImage
            // 
            this.MenuExportImage.Name = "MenuExportImage";
            this.MenuExportImage.Size = new System.Drawing.Size(109, 22);
            this.MenuExportImage.Text = "Image";
            this.MenuExportImage.Click += new System.EventHandler(this.MenuExportImage_Click);
            // 
            // MenuExportObject
            // 
            this.MenuExportObject.Name = "MenuExportObject";
            this.MenuExportObject.Size = new System.Drawing.Size(109, 22);
            this.MenuExportObject.Text = "Object";
            this.MenuExportObject.Click += new System.EventHandler(this.MenuExportObject_Click);
            // 
            // MenuExit
            // 
            this.MenuExit.Name = "MenuExit";
            this.MenuExit.Size = new System.Drawing.Size(146, 22);
            this.MenuExit.Text = "Sair";
            this.MenuExit.Click += new System.EventHandler(this.MenuExit_Click);
            // 
            // MenuLayer
            // 
            this.MenuLayer.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuGrid,
            this.MenuShowPreviousFrame,
            this.MenuShowNextFrame,
            this.MenuLayer1,
            this.MenuLayer2,
            this.MenuLayer3});
            this.MenuLayer.Name = "MenuLayer";
            this.MenuLayer.Size = new System.Drawing.Size(61, 20);
            this.MenuLayer.Text = "Camada";
            // 
            // MenuGrid
            // 
            this.MenuGrid.Checked = true;
            this.MenuGrid.CheckOnClick = true;
            this.MenuGrid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MenuGrid.Name = "MenuGrid";
            this.MenuGrid.Size = new System.Drawing.Size(208, 22);
            this.MenuGrid.Text = "Grade";
            this.MenuGrid.Click += new System.EventHandler(this.MenuGrid_Click);
            // 
            // MenuShowPreviousFrame
            // 
            this.MenuShowPreviousFrame.Checked = true;
            this.MenuShowPreviousFrame.CheckOnClick = true;
            this.MenuShowPreviousFrame.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MenuShowPreviousFrame.Name = "MenuShowPreviousFrame";
            this.MenuShowPreviousFrame.Size = new System.Drawing.Size(208, 22);
            this.MenuShowPreviousFrame.Text = "Mostrar Quadro Anterior";
            this.MenuShowPreviousFrame.Click += new System.EventHandler(this.MenuShowPreviousFrame_Click);
            // 
            // MenuShowNextFrame
            // 
            this.MenuShowNextFrame.Checked = true;
            this.MenuShowNextFrame.CheckOnClick = true;
            this.MenuShowNextFrame.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MenuShowNextFrame.Name = "MenuShowNextFrame";
            this.MenuShowNextFrame.Size = new System.Drawing.Size(208, 22);
            this.MenuShowNextFrame.Text = "Mostrar Quadro Posterior";
            this.MenuShowNextFrame.Click += new System.EventHandler(this.MenuShowNextFrame_Click);
            // 
            // MenuLayer1
            // 
            this.MenuLayer1.Checked = true;
            this.MenuLayer1.CheckOnClick = true;
            this.MenuLayer1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MenuLayer1.Name = "MenuLayer1";
            this.MenuLayer1.Size = new System.Drawing.Size(208, 22);
            this.MenuLayer1.Text = "Camada 1";
            this.MenuLayer1.Click += new System.EventHandler(this.MenuLayer1_Click);
            // 
            // MenuLayer2
            // 
            this.MenuLayer2.Checked = true;
            this.MenuLayer2.CheckOnClick = true;
            this.MenuLayer2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MenuLayer2.Name = "MenuLayer2";
            this.MenuLayer2.Size = new System.Drawing.Size(208, 22);
            this.MenuLayer2.Text = "Camada 2";
            this.MenuLayer2.Click += new System.EventHandler(this.MenuLayer2_Click);
            // 
            // MenuLayer3
            // 
            this.MenuLayer3.Checked = true;
            this.MenuLayer3.CheckOnClick = true;
            this.MenuLayer3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MenuLayer3.Name = "MenuLayer3";
            this.MenuLayer3.Size = new System.Drawing.Size(208, 22);
            this.MenuLayer3.Text = "Camada 3";
            this.MenuLayer3.Click += new System.EventHandler(this.MenuLayer3_Click);
            // 
            // MenuAnimation
            // 
            this.MenuAnimation.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuPlay,
            this.MenuLimitLoop});
            this.MenuAnimation.Name = "MenuAnimation";
            this.MenuAnimation.Size = new System.Drawing.Size(72, 20);
            this.MenuAnimation.Text = "Animação";
            // 
            // MenuPlay
            // 
            this.MenuPlay.CheckOnClick = true;
            this.MenuPlay.Name = "MenuPlay";
            this.MenuPlay.Size = new System.Drawing.Size(140, 22);
            this.MenuPlay.Text = "Play";
            this.MenuPlay.Click += new System.EventHandler(this.MenuPlay_Click);
            // 
            // MenuLimitLoop
            // 
            this.MenuLimitLoop.Checked = true;
            this.MenuLimitLoop.CheckOnClick = true;
            this.MenuLimitLoop.CheckState = System.Windows.Forms.CheckState.Checked;
            this.MenuLimitLoop.Name = "MenuLimitLoop";
            this.MenuLimitLoop.Size = new System.Drawing.Size(140, 22);
            this.MenuLimitLoop.Text = "Limitar Loop";
            this.MenuLimitLoop.Click += new System.EventHandler(this.MenuLimitLoop_Click);
            // 
            // MenuObject
            // 
            this.MenuObject.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuAdd,
            this.MenuClearObject,
            this.MenuCloseObjectPointer});
            this.MenuObject.Name = "MenuObject";
            this.MenuObject.Size = new System.Drawing.Size(60, 20);
            this.MenuObject.Text = "Objetos";
            // 
            // MenuAdd
            // 
            this.MenuAdd.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuAddObject,
            this.MenuAddAnimation});
            this.MenuAdd.Name = "MenuAdd";
            this.MenuAdd.Size = new System.Drawing.Size(157, 22);
            this.MenuAdd.Text = "Adicionar";
            // 
            // MenuAddObject
            // 
            this.MenuAddObject.Name = "MenuAddObject";
            this.MenuAddObject.Size = new System.Drawing.Size(127, 22);
            this.MenuAddObject.Text = "Quadro";
            this.MenuAddObject.Click += new System.EventHandler(this.MenuAddObject_Click);
            // 
            // MenuAddAnimation
            // 
            this.MenuAddAnimation.Name = "MenuAddAnimation";
            this.MenuAddAnimation.Size = new System.Drawing.Size(127, 22);
            this.MenuAddAnimation.Text = "Animação";
            this.MenuAddAnimation.Click += new System.EventHandler(this.MenuAddAnimation_Click);
            // 
            // MenuClearObject
            // 
            this.MenuClearObject.Name = "MenuClearObject";
            this.MenuClearObject.Size = new System.Drawing.Size(157, 22);
            this.MenuClearObject.Text = "Limpar Lista";
            this.MenuClearObject.Click += new System.EventHandler(this.MenuClearObject_Click);
            // 
            // MenuCloseObjectPointer
            // 
            this.MenuCloseObjectPointer.Name = "MenuCloseObjectPointer";
            this.MenuCloseObjectPointer.Size = new System.Drawing.Size(157, 22);
            this.MenuCloseObjectPointer.Text = "Fechar Ponteiro";
            this.MenuCloseObjectPointer.Click += new System.EventHandler(this.MenuCloseObjectPointer_Click);
            // 
            // MenuLanguage
            // 
            this.MenuLanguage.Name = "MenuLanguage";
            this.MenuLanguage.Size = new System.Drawing.Size(55, 20);
            this.MenuLanguage.Text = "Idioma";
            // 
            // MenuShortcut
            // 
            this.MenuShortcut.Name = "MenuShortcut";
            this.MenuShortcut.Size = new System.Drawing.Size(54, 20);
            this.MenuShortcut.Text = "Atalho";
            // 
            // ButtonLayer1
            // 
            this.ButtonLayer1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonLayer1.Location = new System.Drawing.Point(652, 36);
            this.ButtonLayer1.Name = "ButtonLayer1";
            this.ButtonLayer1.Size = new System.Drawing.Size(120, 21);
            this.ButtonLayer1.TabIndex = 12;
            this.ButtonLayer1.Text = "Camada 1";
            this.ButtonLayer1.UseVisualStyleBackColor = true;
            this.ButtonLayer1.Click += new System.EventHandler(this.ButtonLayer1_Click);
            // 
            // ButtonLayer2
            // 
            this.ButtonLayer2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonLayer2.Location = new System.Drawing.Point(652, 63);
            this.ButtonLayer2.Name = "ButtonLayer2";
            this.ButtonLayer2.Size = new System.Drawing.Size(120, 21);
            this.ButtonLayer2.TabIndex = 13;
            this.ButtonLayer2.Text = "Camada 2";
            this.ButtonLayer2.UseVisualStyleBackColor = true;
            this.ButtonLayer2.Click += new System.EventHandler(this.ButtonLayer2_Click);
            // 
            // ButtonLayer3
            // 
            this.ButtonLayer3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonLayer3.Location = new System.Drawing.Point(652, 90);
            this.ButtonLayer3.Name = "ButtonLayer3";
            this.ButtonLayer3.Size = new System.Drawing.Size(120, 21);
            this.ButtonLayer3.TabIndex = 14;
            this.ButtonLayer3.Text = "Camada 3";
            this.ButtonLayer3.UseVisualStyleBackColor = true;
            this.ButtonLayer3.Click += new System.EventHandler(this.ButtonLayer3_Click);
            // 
            // ButtonRemoveAll
            // 
            this.ButtonRemoveAll.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonRemoveAll.Location = new System.Drawing.Point(652, 115);
            this.ButtonRemoveAll.Name = "ButtonRemoveAll";
            this.ButtonRemoveAll.Size = new System.Drawing.Size(120, 21);
            this.ButtonRemoveAll.TabIndex = 16;
            this.ButtonRemoveAll.Text = "Limpar Camadas";
            this.ButtonRemoveAll.UseVisualStyleBackColor = true;
            this.ButtonRemoveAll.Click += new System.EventHandler(this.ButtonRemoveAll_Click);
            // 
            // ScrollBarPositionX
            // 
            this.ScrollBarPositionX.Location = new System.Drawing.Point(187, 145);
            this.ScrollBarPositionX.Maximum = 425;
            this.ScrollBarPositionX.Name = "ScrollBarPositionX";
            this.ScrollBarPositionX.Size = new System.Drawing.Size(420, 17);
            this.ScrollBarPositionX.TabIndex = 20;
            this.ScrollBarPositionX.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScrollBarPositionX_Scroll);
            // 
            // ScrollBarWidth
            // 
            this.ScrollBarWidth.Location = new System.Drawing.Point(187, 482);
            this.ScrollBarWidth.Maximum = 425;
            this.ScrollBarWidth.Name = "ScrollBarWidth";
            this.ScrollBarWidth.Size = new System.Drawing.Size(420, 17);
            this.ScrollBarWidth.TabIndex = 21;
            this.ScrollBarWidth.Value = 192;
            this.ScrollBarWidth.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScrollBarWidth_Scroll);
            // 
            // ScrollBarHeight
            // 
            this.ScrollBarHeight.Location = new System.Drawing.Point(626, 172);
            this.ScrollBarHeight.Maximum = 329;
            this.ScrollBarHeight.Name = "ScrollBarHeight";
            this.ScrollBarHeight.Size = new System.Drawing.Size(17, 281);
            this.ScrollBarHeight.TabIndex = 22;
            this.ScrollBarHeight.Value = 192;
            this.ScrollBarHeight.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScrollBarHeight_Scroll);
            // 
            // ScrollBarPositionY
            // 
            this.ScrollBarPositionY.Location = new System.Drawing.Point(151, 172);
            this.ScrollBarPositionY.Maximum = 329;
            this.ScrollBarPositionY.Name = "ScrollBarPositionY";
            this.ScrollBarPositionY.Size = new System.Drawing.Size(20, 281);
            this.ScrollBarPositionY.TabIndex = 23;
            this.ScrollBarPositionY.Scroll += new System.Windows.Forms.ScrollEventHandler(this.ScrollBarPositionY_Scroll);
            // 
            // LabelListObject
            // 
            this.LabelListObject.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelListObject.Location = new System.Drawing.Point(12, 35);
            this.LabelListObject.Name = "LabelListObject";
            this.LabelListObject.Size = new System.Drawing.Size(123, 16);
            this.LabelListObject.TabIndex = 24;
            this.LabelListObject.Text = "Lista de Objetos";
            this.LabelListObject.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LabelFrame
            // 
            this.LabelFrame.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelFrame.Location = new System.Drawing.Point(311, 67);
            this.LabelFrame.Name = "LabelFrame";
            this.LabelFrame.Size = new System.Drawing.Size(152, 18);
            this.LabelFrame.TabIndex = 25;
            this.LabelFrame.Text = "Quadro: 0 / 0";
            this.LabelFrame.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CheckFixObject
            // 
            this.CheckFixObject.AutoSize = true;
            this.CheckFixObject.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CheckFixObject.Location = new System.Drawing.Point(146, 36);
            this.CheckFixObject.Name = "CheckFixObject";
            this.CheckFixObject.Size = new System.Drawing.Size(50, 18);
            this.CheckFixObject.TabIndex = 26;
            this.CheckFixObject.Text = "Fixar";
            this.CheckFixObject.UseVisualStyleBackColor = true;
            this.CheckFixObject.CheckedChanged += new System.EventHandler(this.CheckFixObject_CheckedChanged);
            // 
            // TextPositionX
            // 
            this.TextPositionX.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextPositionX.Location = new System.Drawing.Point(221, 34);
            this.TextPositionX.Name = "TextPositionX";
            this.TextPositionX.Size = new System.Drawing.Size(42, 22);
            this.TextPositionX.TabIndex = 27;
            this.TextPositionX.Text = "0";
            this.TextPositionX.TextChanged += new System.EventHandler(this.TextPositionX_TextChanged);
            this.TextPositionX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextPositionX_KeyPress);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(202, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(19, 16);
            this.label3.TabIndex = 28;
            this.label3.Text = "X";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(269, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 16);
            this.label4.TabIndex = 30;
            this.label4.Text = "Y";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TextPositionY
            // 
            this.TextPositionY.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextPositionY.Location = new System.Drawing.Point(294, 34);
            this.TextPositionY.Name = "TextPositionY";
            this.TextPositionY.Size = new System.Drawing.Size(42, 22);
            this.TextPositionY.TabIndex = 29;
            this.TextPositionY.Text = "0";
            this.TextPositionY.TextChanged += new System.EventHandler(this.TextPositionY_TextChanged);
            this.TextPositionY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextPositionY_KeyPress);
            // 
            // LabelStatus
            // 
            this.LabelStatus.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelStatus.Location = new System.Drawing.Point(184, 499);
            this.LabelStatus.Name = "LabelStatus";
            this.LabelStatus.Size = new System.Drawing.Size(419, 16);
            this.LabelStatus.TabIndex = 31;
            this.LabelStatus.Text = "Área de Recorte X: 0 Y: 0 Comprimento: 0 Altura: 0";
            this.LabelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TextFrameRate
            // 
            this.TextFrameRate.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextFrameRate.Location = new System.Drawing.Point(596, 33);
            this.TextFrameRate.Name = "TextFrameRate";
            this.TextFrameRate.Size = new System.Drawing.Size(42, 22);
            this.TextFrameRate.TabIndex = 32;
            this.TextFrameRate.Text = "60";
            this.TextFrameRate.TextChanged += new System.EventHandler(this.TextFrameRate_TextChanged);
            this.TextFrameRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextFrameRate_KeyPress);
            // 
            // LabelFrameRateTime
            // 
            this.LabelFrameRateTime.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelFrameRateTime.Location = new System.Drawing.Point(480, 35);
            this.LabelFrameRateTime.Name = "LabelFrameRateTime";
            this.LabelFrameRateTime.Size = new System.Drawing.Size(110, 16);
            this.LabelFrameRateTime.TabIndex = 33;
            this.LabelFrameRateTime.Text = "Tempo do Quadro";
            this.LabelFrameRateTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ContextMenuFrame
            // 
            this.ContextMenuFrame.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuExportFrameItem,
            this.MenuMoveUp,
            this.MenuMoveDown,
            this.MenuRemoveItem,
            this.MenuClearFrames,
            this.MenuProperties});
            this.ContextMenuFrame.Name = "MenuStrip";
            this.ContextMenuFrame.Size = new System.Drawing.Size(139, 136);
            // 
            // MenuExportFrameItem
            // 
            this.MenuExportFrameItem.Name = "MenuExportFrameItem";
            this.MenuExportFrameItem.Size = new System.Drawing.Size(138, 22);
            this.MenuExportFrameItem.Text = "Export";
            this.MenuExportFrameItem.Click += new System.EventHandler(this.MenuExportFrameItem_Click);
            // 
            // MenuMoveUp
            // 
            this.MenuMoveUp.Name = "MenuMoveUp";
            this.MenuMoveUp.Size = new System.Drawing.Size(138, 22);
            this.MenuMoveUp.Text = "Move Up";
            this.MenuMoveUp.Click += new System.EventHandler(this.MenuMoveUp_Click);
            // 
            // MenuMoveDown
            // 
            this.MenuMoveDown.Name = "MenuMoveDown";
            this.MenuMoveDown.Size = new System.Drawing.Size(138, 22);
            this.MenuMoveDown.Text = "Move Down";
            this.MenuMoveDown.Click += new System.EventHandler(this.MenuMoveDown_Click);
            // 
            // MenuRemoveItem
            // 
            this.MenuRemoveItem.Name = "MenuRemoveItem";
            this.MenuRemoveItem.Size = new System.Drawing.Size(138, 22);
            this.MenuRemoveItem.Text = "Remove";
            this.MenuRemoveItem.Click += new System.EventHandler(this.MenuRemoveItem_Click);
            // 
            // MenuClearFrames
            // 
            this.MenuClearFrames.Name = "MenuClearFrames";
            this.MenuClearFrames.Size = new System.Drawing.Size(138, 22);
            this.MenuClearFrames.Text = "Clear List";
            this.MenuClearFrames.Click += new System.EventHandler(this.MenuClearFrames_Click);
            // 
            // MenuProperties
            // 
            this.MenuProperties.Name = "MenuProperties";
            this.MenuProperties.Size = new System.Drawing.Size(138, 22);
            this.MenuProperties.Text = "Properties";
            this.MenuProperties.Click += new System.EventHandler(this.MenuProperties_Click);
            // 
            // LabelOffset
            // 
            this.LabelOffset.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelOffset.Location = new System.Drawing.Point(188, 129);
            this.LabelOffset.Name = "LabelOffset";
            this.LabelOffset.Size = new System.Drawing.Size(419, 16);
            this.LabelOffset.TabIndex = 34;
            this.LabelOffset.Text = "Mouse X : 0 Y : 0 Pointer OffsetX : 0 OffsetY : 0";
            this.LabelOffset.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ContextMenuObject
            // 
            this.ContextMenuObject.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuExportObjectFromList,
            this.MenuRemoveObject,
            this.MenuRemoveAllObject,
            this.MenuSetColorKey});
            this.ContextMenuObject.Name = "ContextMenuObject";
            this.ContextMenuObject.Size = new System.Drawing.Size(153, 114);
            // 
            // MenuExportObjectFromList
            // 
            this.MenuExportObjectFromList.Name = "MenuExportObjectFromList";
            this.MenuExportObjectFromList.Size = new System.Drawing.Size(152, 22);
            this.MenuExportObjectFromList.Text = "Export";
            this.MenuExportObjectFromList.Click += new System.EventHandler(this.MenuExportObjectFromList_Click);
            // 
            // MenuRemoveObject
            // 
            this.MenuRemoveObject.Name = "MenuRemoveObject";
            this.MenuRemoveObject.Size = new System.Drawing.Size(152, 22);
            this.MenuRemoveObject.Text = "Remove";
            this.MenuRemoveObject.Click += new System.EventHandler(this.MenuRemoveObject_Click);
            // 
            // MenuRemoveAllObject
            // 
            this.MenuRemoveAllObject.Name = "MenuRemoveAllObject";
            this.MenuRemoveAllObject.Size = new System.Drawing.Size(152, 22);
            this.MenuRemoveAllObject.Text = "Clear List";
            this.MenuRemoveAllObject.Click += new System.EventHandler(this.MenuRemoveAllObject_Click);
            // 
            // MenuSetColorKey
            // 
            this.MenuSetColorKey.Name = "MenuSetColorKey";
            this.MenuSetColorKey.Size = new System.Drawing.Size(152, 22);
            this.MenuSetColorKey.Text = "ColorKey";
            this.MenuSetColorKey.Click += new System.EventHandler(this.MenuSetColorKey_Click);
            // 
            // PanelItemProperties
            // 
            this.PanelItemProperties.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelItemProperties.Controls.Add(this.TextFrameItemName);
            this.PanelItemProperties.Controls.Add(this.LabelFrameItemName);
            this.PanelItemProperties.Controls.Add(this.ButtonCloseFrameProperties);
            this.PanelItemProperties.Controls.Add(this.TextFrameItemTransp);
            this.PanelItemProperties.Controls.Add(this.LabelFrameItemHeight);
            this.PanelItemProperties.Controls.Add(this.LabelFrameItemTransp);
            this.PanelItemProperties.Controls.Add(this.TextFrameItemHeight);
            this.PanelItemProperties.Controls.Add(this.LabelFrameItemWidth);
            this.PanelItemProperties.Controls.Add(this.TextFrameItemWidth);
            this.PanelItemProperties.Controls.Add(this.label5);
            this.PanelItemProperties.Controls.Add(this.TextFrameItemY);
            this.PanelItemProperties.Controls.Add(this.label2);
            this.PanelItemProperties.Controls.Add(this.TextFrameItemX);
            this.PanelItemProperties.Location = new System.Drawing.Point(604, 145);
            this.PanelItemProperties.Name = "PanelItemProperties";
            this.PanelItemProperties.Size = new System.Drawing.Size(179, 233);
            this.PanelItemProperties.TabIndex = 37;
            this.PanelItemProperties.Visible = false;
            // 
            // TextFrameItemName
            // 
            this.TextFrameItemName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextFrameItemName.Location = new System.Drawing.Point(13, 33);
            this.TextFrameItemName.Name = "TextFrameItemName";
            this.TextFrameItemName.Size = new System.Drawing.Size(151, 22);
            this.TextFrameItemName.TabIndex = 46;
            this.TextFrameItemName.Text = "0";
            this.TextFrameItemName.TextChanged += new System.EventHandler(this.TextFrameItemName_TextChanged);
            // 
            // LabelFrameItemName
            // 
            this.LabelFrameItemName.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelFrameItemName.Location = new System.Drawing.Point(10, 14);
            this.LabelFrameItemName.Name = "LabelFrameItemName";
            this.LabelFrameItemName.Size = new System.Drawing.Size(102, 16);
            this.LabelFrameItemName.TabIndex = 45;
            this.LabelFrameItemName.Text = "Nome";
            this.LabelFrameItemName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ButtonCloseFrameProperties
            // 
            this.ButtonCloseFrameProperties.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonCloseFrameProperties.Location = new System.Drawing.Point(13, 193);
            this.ButtonCloseFrameProperties.Name = "ButtonCloseFrameProperties";
            this.ButtonCloseFrameProperties.Size = new System.Drawing.Size(151, 20);
            this.ButtonCloseFrameProperties.TabIndex = 44;
            this.ButtonCloseFrameProperties.Text = "Fechar";
            this.ButtonCloseFrameProperties.UseVisualStyleBackColor = true;
            this.ButtonCloseFrameProperties.Click += new System.EventHandler(this.ButtonCloseFrameProperties_Click);
            // 
            // TextFrameItemTransp
            // 
            this.TextFrameItemTransp.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextFrameItemTransp.Location = new System.Drawing.Point(13, 165);
            this.TextFrameItemTransp.Name = "TextFrameItemTransp";
            this.TextFrameItemTransp.Size = new System.Drawing.Size(151, 22);
            this.TextFrameItemTransp.TabIndex = 43;
            this.TextFrameItemTransp.Text = "0";
            this.TextFrameItemTransp.TextChanged += new System.EventHandler(this.TextFrameItemTransp_TextChanged);
            // 
            // LabelFrameItemHeight
            // 
            this.LabelFrameItemHeight.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelFrameItemHeight.Location = new System.Drawing.Point(97, 102);
            this.LabelFrameItemHeight.Name = "LabelFrameItemHeight";
            this.LabelFrameItemHeight.Size = new System.Drawing.Size(66, 16);
            this.LabelFrameItemHeight.TabIndex = 42;
            this.LabelFrameItemHeight.Text = "Altura";
            this.LabelFrameItemHeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LabelFrameItemTransp
            // 
            this.LabelFrameItemTransp.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelFrameItemTransp.Location = new System.Drawing.Point(12, 146);
            this.LabelFrameItemTransp.Name = "LabelFrameItemTransp";
            this.LabelFrameItemTransp.Size = new System.Drawing.Size(102, 16);
            this.LabelFrameItemTransp.TabIndex = 41;
            this.LabelFrameItemTransp.Text = "Transparência";
            this.LabelFrameItemTransp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TextFrameItemHeight
            // 
            this.TextFrameItemHeight.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextFrameItemHeight.Location = new System.Drawing.Point(100, 121);
            this.TextFrameItemHeight.Name = "TextFrameItemHeight";
            this.TextFrameItemHeight.Size = new System.Drawing.Size(63, 22);
            this.TextFrameItemHeight.TabIndex = 40;
            this.TextFrameItemHeight.Text = "0";
            this.TextFrameItemHeight.TextChanged += new System.EventHandler(this.TextFrameItemHeight_TextChanged);
            // 
            // LabelFrameItemWidth
            // 
            this.LabelFrameItemWidth.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelFrameItemWidth.Location = new System.Drawing.Point(12, 102);
            this.LabelFrameItemWidth.Name = "LabelFrameItemWidth";
            this.LabelFrameItemWidth.Size = new System.Drawing.Size(88, 16);
            this.LabelFrameItemWidth.TabIndex = 39;
            this.LabelFrameItemWidth.Text = "Comprimento";
            this.LabelFrameItemWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TextFrameItemWidth
            // 
            this.TextFrameItemWidth.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextFrameItemWidth.Location = new System.Drawing.Point(13, 121);
            this.TextFrameItemWidth.Name = "TextFrameItemWidth";
            this.TextFrameItemWidth.Size = new System.Drawing.Size(63, 22);
            this.TextFrameItemWidth.TabIndex = 38;
            this.TextFrameItemWidth.Text = "0";
            this.TextFrameItemWidth.TextChanged += new System.EventHandler(this.TextFrameItemWidth_TextChanged);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(97, 58);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 16);
            this.label5.TabIndex = 37;
            this.label5.Text = "Y";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TextFrameItemY
            // 
            this.TextFrameItemY.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextFrameItemY.Location = new System.Drawing.Point(100, 77);
            this.TextFrameItemY.Name = "TextFrameItemY";
            this.TextFrameItemY.Size = new System.Drawing.Size(63, 22);
            this.TextFrameItemY.TabIndex = 36;
            this.TextFrameItemY.Text = "0";
            this.TextFrameItemY.TextChanged += new System.EventHandler(this.TextFrameItemY_TextChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 16);
            this.label2.TabIndex = 35;
            this.label2.Text = "X ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TextFrameItemX
            // 
            this.TextFrameItemX.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextFrameItemX.Location = new System.Drawing.Point(13, 77);
            this.TextFrameItemX.Name = "TextFrameItemX";
            this.TextFrameItemX.Size = new System.Drawing.Size(63, 22);
            this.TextFrameItemX.TabIndex = 33;
            this.TextFrameItemX.Text = "0";
            this.TextFrameItemX.TextChanged += new System.EventHandler(this.TextFrameItemX_TextChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 531);
            this.Controls.Add(this.PanelItemProperties);
            this.Controls.Add(this.LabelOffset);
            this.Controls.Add(this.LabelFrameRateTime);
            this.Controls.Add(this.TextFrameRate);
            this.Controls.Add(this.LabelStatus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TextPositionY);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TextPositionX);
            this.Controls.Add(this.CheckFixObject);
            this.Controls.Add(this.LabelFrame);
            this.Controls.Add(this.LabelListObject);
            this.Controls.Add(this.ScrollBarPositionY);
            this.Controls.Add(this.ScrollBarHeight);
            this.Controls.Add(this.ScrollBarWidth);
            this.Controls.Add(this.ScrollBarPositionX);
            this.Controls.Add(this.ButtonRemoveAll);
            this.Controls.Add(this.ButtonLayer3);
            this.Controls.Add(this.ButtonLayer2);
            this.Controls.Add(this.ButtonLayer1);
            this.Controls.Add(this.ButtonClearFrames);
            this.Controls.Add(this.ButtonRemoveLast);
            this.Controls.Add(this.ButtonRemoveAt);
            this.Controls.Add(this.ButtonAddFrame);
            this.Controls.Add(this.ButtonPrevious);
            this.Controls.Add(this.ButtonNext);
            this.Controls.Add(this.ButtonMoveToStart);
            this.Controls.Add(this.ButtonMoveToLast);
            this.Controls.Add(this.ListFrame);
            this.Controls.Add(this.PictureAnimation);
            this.Controls.Add(this.ListObject);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editor de Animação";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.PictureAnimation)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ContextMenuFrame.ResumeLayout(false);
            this.ContextMenuObject.ResumeLayout(false);
            this.PanelItemProperties.ResumeLayout(false);
            this.PanelItemProperties.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox ListObject;
        private System.Windows.Forms.PictureBox PictureAnimation;
        private System.Windows.Forms.ListBox ListFrame;
        private System.Windows.Forms.Button ButtonMoveToLast;
        private System.Windows.Forms.Button ButtonMoveToStart;
        private System.Windows.Forms.Button ButtonNext;
        private System.Windows.Forms.Button ButtonPrevious;
        private System.Windows.Forms.Button ButtonAddFrame;
        private System.Windows.Forms.Button ButtonRemoveAt;
        private System.Windows.Forms.Button ButtonRemoveLast;
        private System.Windows.Forms.Button ButtonClearFrames;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Button ButtonLayer1;
        private System.Windows.Forms.Button ButtonLayer2;
        private System.Windows.Forms.Button ButtonLayer3;
        private System.Windows.Forms.Button ButtonRemoveAll;
        private System.Windows.Forms.ToolStripMenuItem MenuFile;
        private System.Windows.Forms.ToolStripMenuItem MenuLayer;
        private System.Windows.Forms.ToolStripMenuItem MenuAnimation;
        private System.Windows.Forms.ToolStripMenuItem MenuObject;
        private System.Windows.Forms.HScrollBar ScrollBarPositionX;
        private System.Windows.Forms.HScrollBar ScrollBarWidth;
        private System.Windows.Forms.VScrollBar ScrollBarHeight;
        private System.Windows.Forms.VScrollBar ScrollBarPositionY;
        private System.Windows.Forms.Label LabelListObject;
        private System.Windows.Forms.Label LabelFrame;
        private System.Windows.Forms.ToolStripMenuItem MenuSaveProject;
        private System.Windows.Forms.ToolStripMenuItem MenuOpenProject;
        private System.Windows.Forms.ToolStripMenuItem MenuExport;
        private System.Windows.Forms.ToolStripMenuItem MenuExit;
        private System.Windows.Forms.ToolStripMenuItem MenuGrid;
        private System.Windows.Forms.ToolStripMenuItem MenuShowPreviousFrame;
        private System.Windows.Forms.ToolStripMenuItem MenuShowNextFrame;
        private System.Windows.Forms.CheckBox CheckFixObject;
        private System.Windows.Forms.TextBox TextPositionX;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TextPositionY;
        private System.Windows.Forms.ToolStripMenuItem MenuPlay;
        private System.Windows.Forms.ToolStripMenuItem MenuAdd;
        private System.Windows.Forms.ToolStripMenuItem MenuClearObject;
        private System.Windows.Forms.ToolStripMenuItem MenuCloseObjectPointer;
        private System.Windows.Forms.ToolStripMenuItem MenuLayer1;
        private System.Windows.Forms.ToolStripMenuItem MenuLayer2;
        private System.Windows.Forms.ToolStripMenuItem MenuLayer3;
        private System.Windows.Forms.Label LabelStatus;
        private System.Windows.Forms.TextBox TextFrameRate;
        private System.Windows.Forms.Label LabelFrameRateTime;
        private System.Windows.Forms.ToolStripMenuItem MenuLanguage;
        private System.Windows.Forms.ToolStripMenuItem MenuLimitLoop;
        private System.Windows.Forms.ToolStripMenuItem MenuExportImage;
        private System.Windows.Forms.ToolStripMenuItem MenuExportObject;
        private System.Windows.Forms.ToolStripMenuItem MenuAddObject;
        private System.Windows.Forms.ToolStripMenuItem MenuAddAnimation;
        private System.Windows.Forms.ContextMenuStrip ContextMenuFrame;
        private System.Windows.Forms.ToolStripMenuItem MenuShortcut;
        private System.Windows.Forms.Label LabelOffset;
        private System.Windows.Forms.ToolStripMenuItem MenuMoveUp;
        private System.Windows.Forms.ToolStripMenuItem MenuMoveDown;
        private System.Windows.Forms.ToolStripMenuItem MenuRemoveItem;
        private System.Windows.Forms.ToolStripMenuItem MenuProperties;
        private System.Windows.Forms.ToolStripMenuItem MenuExportFrameItem;
        private System.Windows.Forms.ContextMenuStrip ContextMenuObject;
        private System.Windows.Forms.ToolStripMenuItem MenuExportObjectFromList;
        private System.Windows.Forms.ToolStripMenuItem MenuRemoveObject;
        private System.Windows.Forms.Panel PanelItemProperties;
        private System.Windows.Forms.Button ButtonCloseFrameProperties;
        private System.Windows.Forms.TextBox TextFrameItemTransp;
        private System.Windows.Forms.Label LabelFrameItemHeight;
        private System.Windows.Forms.Label LabelFrameItemTransp;
        private System.Windows.Forms.TextBox TextFrameItemHeight;
        private System.Windows.Forms.Label LabelFrameItemWidth;
        private System.Windows.Forms.TextBox TextFrameItemWidth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TextFrameItemY;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TextFrameItemX;
        private System.Windows.Forms.TextBox TextFrameItemName;
        private System.Windows.Forms.Label LabelFrameItemName;
        private System.Windows.Forms.ToolStripMenuItem MenuRemoveAllObject;
        private System.Windows.Forms.ToolStripMenuItem MenuClearFrames;
        private System.Windows.Forms.ToolStripMenuItem MenuSetColorKey;
    }
}


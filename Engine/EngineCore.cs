using System;
using System.Drawing;
using System.Drawing.Imaging;
using Animation_Editor.Anim;
using Animation_Editor.Common;

namespace Animation_Editor.Engine {
    public sealed class EngineCore {
        /// <summary>
        /// Ativa ou desativa o modo de edição.
        /// </summary>
        public bool EditMode { get; set; }
        /// <summary>
        /// Ativa ou desativa o desenho do grid.
        /// </summary>
        public bool GridVisible { get; set; }

        public bool ShowPreviousFrame { get; set; }

        public bool ShowNextFrame { get; set; }

        /// <summary>
        /// Ativa ou desativa a visibilidade da camada.
        /// </summary>
        private bool[] layerVisible = new bool[Constants.MaxLayer];

        /// <summary>
        /// Comprimento do controle.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Altura do controle.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Objecto selecionado na lista.
        /// </summary>
        public EnginePointer SelectedObject { get; set; }

        /// <summary>
        /// Objeto selecionado na lista de frames.
        /// </summary>
        public Rectangle SelectedFrameObject { get; set; }

        /// <summary>
        /// TickCount de animação.
        /// </summary>
        private int animTick;
         
        /// <summary>
        /// Ponteiro do controle de exibição.
        /// </summary>
        IntPtr controlHwnd;

        /// <summary>
        /// Pen para o retângulo do frame posterior.
        /// </summary>
        Pen penNext;

        /// <summary>
        /// Pen para o retângulo do frame anterior.
        /// </summary>
        Pen penPrevious;

        /// <summary>
        /// Pen para a area de recorte.
        /// </summary>
        Pen penClipArea;

        /// <summary>
        /// Pen para o item selecionado na lista de frame.
        /// </summary>
        Pen penSelectedFrame;

        /// <summary>
        /// Atributos para transparência.
        /// </summary>
        ImageAttributes imageAttributes;

        /// <summary>
        /// Quantidade máxima de linha horizontal.
        /// </summary>
        private const int MaxGridLineX = 13;
        
        /// <summary>
        /// Quantidade máxima de linha vertical.
        /// </summary>
        private const int MaxGridLineY = 10;

        /// <summary>
        /// Distância entre as linhas.
        /// </summary>
        private const int LineDistanceSize = 32;

        Graphics gBackBuffer;
        Graphics gRender;
        private Bitmap backBuffer;
        private Font font;
        public int fps;
        private int fpsTick;
        private int fpsCount;
        private PointF fpsPoint;
        private PointF offsetPoint;

        public EngineCore(EngineParameters engineParameters, EngineFontParameters engineFontParameters) {
            Width = engineParameters.Width;
            Height = engineParameters.Height;
            controlHwnd = engineParameters.Handle;

            font = new Font(engineFontParameters.Name, engineFontParameters.Size, engineFontParameters.Style);
     
            fpsPoint = new PointF(Width - 60, 5);
            offsetPoint = new PointF(Width - 120, 20);

            backBuffer = new Bitmap(engineParameters.Width, engineParameters.Height);

            gBackBuffer = Graphics.FromImage(backBuffer);
            gRender = Graphics.FromHwnd(controlHwnd);

            penNext = new Pen(new SolidBrush(Color.FromArgb(90, Color.Yellow)));
            penPrevious = new Pen(new SolidBrush(Color.FromArgb(90, Color.LimeGreen)));
            penClipArea = new Pen(new SolidBrush(Color.Coral), 2);
            penSelectedFrame = new Pen(new SolidBrush(Color.Red), 3);

             float[][] ptArray = {
                new float[] { 1, 0, 0, 0, 0 },
                new float[] { 0, 1, 0, 0, 0 },
                new float[] { 0, 0, 1, 0, 0 },
                new float[] { 0, 0, 0, 0.2F, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            };

            // Define os atributos de imagem para transparência.
            ColorMatrix matrix = new ColorMatrix(ptArray);
            imageAttributes = new ImageAttributes();
            imageAttributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            SetLayerVisibility(0, true);
            SetLayerVisibility(1, true);
            SetLayerVisibility(2, true);
            GridVisible = true;
            EditMode = true;
            ShowNextFrame = true;
            ShowPreviousFrame = true;
        }

        public void Exit() {
            controlHwnd = IntPtr.Zero;
        }

        /// <summary>
        /// Altera a visibilidade da camada.
        /// </summary>
        /// <param name="layerIndex"></param>
        /// <param name="value"></param>
        public void SetLayerVisibility(int layerIndex, bool value) {
            if (layerIndex < Constants.MaxLayer) {
                layerVisible[layerIndex] = value;
            }
        }

        public void Draw(Animation animation) {
            gBackBuffer.Clear(Color.Black);

            if (EditMode) {
                if (ShowPreviousFrame) {
                    DrawPreviousFrame(gBackBuffer, animation);
                }

                DrawCurrentFrame(gBackBuffer, animation);

                if (ShowNextFrame) {
                    DrawNextFrame(gBackBuffer, animation);
                }

                DrawSelectedFrameObject(gBackBuffer);
                DrawSelectedObject(gBackBuffer);
                DrawGrid(gBackBuffer);

                DrawClipArea(gBackBuffer, animation.ClipArea);
            }
            else {
                DrawAnimation(gBackBuffer, animation);
            }

            DrawFPS(gBackBuffer);

            if (controlHwnd != IntPtr.Zero) {
                gRender.DrawImage(backBuffer, 0, 0, Width, Height);
            }
          
            CalculateFPS();
        }

        /// <summary>
        /// Desenha a area de recorte da animação.
        /// </summary>
        /// <param name="graphics"></param>
        private void DrawClipArea(Graphics graphics, Rectangle clipArea) {
            graphics.DrawRectangle(penClipArea, clipArea);        
        }

        /// <summary>
        /// Desenha o objeto selecionado na tela.
        /// </summary>
        /// <param name="graphics"></param>
        private void DrawSelectedObject(Graphics graphics) {
            if (SelectedObject != null) {
                var source = new Rectangle(0, 0, SelectedObject.Width, SelectedObject.Height);
                
                graphics.DrawImage(SelectedObject.Image, SelectedObject.ScreenRectangle, source, GraphicsUnit.Pixel);
                graphics.DrawRectangle(Pens.White, SelectedObject.ScreenRectangle);
            }
        }

        /// <summary>
        /// Desenha o retângulo em volta do objeto selecionado no frame.
        /// </summary>
        /// <param name="graphics"></param>
        private void DrawSelectedFrameObject(Graphics graphics) {
            graphics.DrawRectangle(penSelectedFrame, SelectedFrameObject);
        }
    
        /// <summary>
        /// Desenha a animação completa.
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="animation"></param>
        private void DrawAnimation(Graphics graphics, Animation animation) {
            if (animation.FrameCount > 0) {

                if (Environment.TickCount >= animTick + animation.FrameRateTime) {
                    animTick = Environment.TickCount;
                    animation.FrameIndex++;

                    if (animation.FrameIndex > (animation.FrameCount - 1)) {
                        animation.FrameIndex = 0;
                    }
                }

                for (var layerIndex = 0; layerIndex < Constants.MaxLayer; layerIndex++) {
                    DrawListImage(graphics, animation, animation.FrameIndex, layerIndex);
                }
            }
        }

        /// <summary>
        /// Desenha todos os itens do atual frame selecionado.
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="animation"></param>
        private void DrawCurrentFrame(Graphics graphics, Animation animation) {
            // LayerIndex se refere às camadas.
            for (var layerIndex = 0; layerIndex < Constants.MaxLayer; layerIndex++) {

                if (layerVisible[layerIndex]) {

                    DrawListImage(graphics, animation, animation.FrameIndex, layerIndex);
                }
            }
        }
 
        /// <summary>
        /// Desenha todos os itens do frame selecionado.
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="frameIndex"></param>
        /// <param name="layerIndex"></param>
        private void DrawListImage(Graphics graphics, Animation animation, int frameIndex, int layerIndex) {
            // Count é a quantidade de frames na camada.
            var count = animation.Count(frameIndex, layerIndex);

            for (var index = 0; index < count; index++) {
                // FrameIndex é o frame atual que está sendo processado.
                DrawImage(graphics, animation[frameIndex, layerIndex, index]);
            }
        }
         
        /// <summary>
        /// Desenha o frame selecionado.
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="frame"></param>
        private void DrawImage(Graphics graphics, Frame frame) {
            graphics.DrawImage(frame.Image, frame.ScreenRect, 0, 0, frame.SourceRect.Width, frame.SourceRect.Height, GraphicsUnit.Pixel, GetImageAttributes(frame.Transparency));
        }

        #region Previous & Next 

        /// <summary>
        /// Desenha com transparência os itens do frame anterior.
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="animation"></param>
        private void DrawPreviousFrame(Graphics graphics, Animation animation) {
            if (animation.FrameCount > 1) {
                // FrameIndex é o frame atual que está sendo processado.

                var frameIndex = animation.FrameIndex;

                // Somente desenha se houver algum frame para desenhar.
                if (frameIndex > 0) {
                    frameIndex--;

                    for (var layerIndex = 0; layerIndex < Constants.MaxLayer; layerIndex++) {

                        if (layerVisible[layerIndex]) {

                            // Count é a quantidade de frames na camada.
                            var count = animation.Count(frameIndex, layerIndex);

                            for (var index = 0; index < count; index++) {
                                DrawListImageWithPrivateAttribute(graphics, animation, penPrevious, frameIndex, layerIndex);
                            }
                        }
                    }

                }
            }
        }

        /// <summary>
        /// Desenha com transparência os itens do frame posterior.
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="animation"></param>
        private void DrawNextFrame(Graphics graphics, Animation animation) {
            if (animation.FrameCount > 0) {
                // FrameIndex é o frame atual que está sendo processado.
                var frameIndex = animation.FrameIndex + 1;

                if (frameIndex < animation.FrameCount) {

                    // LayerIndex se refere às camadas.
                    for (var layerIndex = 0; layerIndex < Constants.MaxLayer; layerIndex++) {
                        if (layerVisible[layerIndex]) {
                            DrawListImageWithPrivateAttribute(graphics, animation, penNext, frameIndex, layerIndex);
                        }
                    }

                }
            }
        }

        /// <summary>
        /// Desenha todos os itens do frame selecionado com transparência e com bordas.
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="animation"></param>
        /// <param name="pen"></param>
        /// <param name="frameIndex"></param>
        /// <param name="layerIndex"></param>
        private void DrawListImageWithPrivateAttribute(Graphics graphics, Animation animation, Pen pen, int frameIndex, int layerIndex) {
            // Count é a quantidade de itens na camada.
            var count = animation.Count(frameIndex, layerIndex);

            for (var index = 0; index < count; index++) {
                DrawImageWithPrivateAttribute(graphics, animation[frameIndex, layerIndex, index], pen);
            }
        }

        /// <summary>
        /// Desenha a imagem com os atributos de transparência e com bordas..
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="frame"></param>
        /// <param name="pen"></param>
        private void DrawImageWithPrivateAttribute(Graphics graphics, Frame frame, Pen pen) {
            graphics.DrawImage(frame.Image, frame.ScreenRect, 0, 0, frame.SourceRect.Width, frame.SourceRect.Height, GraphicsUnit.Pixel, imageAttributes);
            graphics.DrawRectangle(pen, frame.ScreenRect);
        }

        #endregion

        /// <summary>
        /// Desenha as linhas de grade.
        /// </summary>
        /// <param name="graphics"></param>
        private void DrawGrid(Graphics graphics) {
            if (GridVisible) {
                for (int x = 0; x < MaxGridLineX; x++) {
                    graphics.DrawLine(Pens.AliceBlue, x * LineDistanceSize, 0, x * LineDistanceSize, Height);
                }

                for (int y = 0; y < MaxGridLineY; y++) {
                    graphics.DrawLine(Pens.AliceBlue, 0, y * LineDistanceSize, Width, y * LineDistanceSize);
                }
            }
        }

        private void DrawFPS(Graphics graphics) {
            graphics.DrawString($"FPS: {fps}", font, Brushes.Coral, fpsPoint);
        }

        private void CalculateFPS() {
            if (Environment.TickCount >= fpsTick + 1000) {
                fps = fpsCount;
                fpsTick = Environment.TickCount;
                fpsCount = 0;
            }

            fpsCount++;
        }

        private ImageAttributes GetImageAttributes(int transparency) {
            float alphaPercentage = 0;

            if (transparency > 0) {
                alphaPercentage = (float)transparency / 100;
            }

            float[][] ptArray = {
                new float[] { 1, 0, 0, 0, 0 },
                new float[] { 0, 1, 0, 0, 0 },
                new float[] { 0, 0, 1, 0, 0 },
                new float[] { 0, 0, 0, alphaPercentage, 0 },
                new float[] { 0, 0, 0, 0, 1 }
            };

            // Define os atributos de imagem para transparência.
            ColorMatrix matrix = new ColorMatrix(ptArray);
            var imageAttributes = new ImageAttributes();
            imageAttributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

            return imageAttributes;
        }
    }
}
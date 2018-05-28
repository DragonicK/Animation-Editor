using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;
using Animation_Editor.Common;
using Animation_Editor.Anim;
// using Gif.Components;

namespace Animation_Editor.Export {
    public sealed class AnimationExport {
        public int BackBufferWidth { get; set; }
        public int BackBufferHeight { get; set; }

        /// <summary>
        /// Quantidade máxima de frames na horizontal.
        /// </summary>
        public int MaxFramePerLineX { get; set; }

        public AnimationExport(ExportParameters parameters) {
            BackBufferWidth = parameters.BackBufferWidth;
            BackBufferHeight = parameters.BackBufferHeight;
            MaxFramePerLineX = parameters.MaxFramePerLineX;
        }

        /// <summary>
        /// Exporta a animação no formato de imagem.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="animation"></param>
        public void ExportPng(string path, Animation animation) {  
            // Se houver menos frames do que o esperado.
            if (MaxFramePerLineX > animation.FrameCount) {
                // Define a quantidade de frames horizontalmente pela quantidade total de frames.
                MaxFramePerLineX = animation.FrameCount;
            }

            // Define o comprimento total da animação.
            var width = MaxFramePerLineX * animation.ClipArea.Width;
            // Define a altura total da animação.
            var height = GetMaxFramePerLineY(animation.FrameCount) * animation.ClipArea.Height;

            var line = 0;
            var column = 0;

            var backBuffer = new Bitmap(BackBufferWidth, BackBufferHeight);
            var animationImage = new Bitmap(width, height);

            var gBackBufer = Graphics.FromImage(backBuffer);
            var gAnimation = Graphics.FromImage(animationImage);

            for (var frameIndex = 0; frameIndex < animation.FrameCount; frameIndex++) {
                gBackBufer.Clear(Color.Transparent);
                DrawFrame(gBackBufer, animation, frameIndex);

                var screenRect = new Rectangle(line * animation.ClipArea.Width, column * animation.ClipArea.Height, animation.ClipArea.Width, animation.ClipArea.Height);

                // Desenha o frame no bitmap de animação.
                gAnimation.DrawImage(backBuffer, screenRect, animation.ClipArea, GraphicsUnit.Pixel);

                line++;
                if (line >= MaxFramePerLineX) {
                    line = 0;
                    column++;
                }
            }

            animationImage.Save(path);   

            gBackBufer.Dispose();
            gAnimation.Dispose();
            backBuffer.Dispose();
            animationImage.Dispose();
        }

        public void ExportGif(string path, Animation animation) {
            //var bufferList = CreateAnimationBuffer(animation);

            //var enconder = new AnimatedGifEncoder();
            //enconder.Start(path);
            //enconder.SetDelay(animation.FrameRateTime);
            //enconder.SetQuality(1);
            //// Sempre repetir = 0.
            //// Nunca repetir = -1.
            //enconder.SetRepeat(0);

            //for (var index = 0; index < animation.FrameCount; index++) {
            //    enconder.AddFrame(Image.FromStream(bufferList[index]));
            //}

            //enconder.Finish(); 
        }

        /// <summary>
        /// Exporta a animação no formato de objeto.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="animationID"></param>
        /// <param name="animation"></param>
        public void ExportObject(string path, int animationID, Animation animation) {
            var bufferList = CreateAnimationBuffer(animation);

            using (FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write)) {
                using (BinaryWriter writer = new BinaryWriter(file)) {
                    writer.Write(animationID);
                    writer.Write(animation.FrameCount);
                    writer.Write(animation.ClipArea.Width);
                    writer.Write(animation.ClipArea.Height);

                    for(var index = 0; index < animation.FrameCount; index++) {
                        writer.Write(bufferList[index].Length);
                        writer.Write(bufferList[index].ToArray());
                    }

                    writer.Close();
                }

                file.Close();
            }
        }

        /// <summary>
        /// Cria uma lista com os dados em bytes de cada imagem.
        /// </summary>
        /// <param name="animation"></param>
        /// <returns></returns>
        private List<MemoryStream> CreateAnimationBuffer(Animation animation) {
            var width = animation.ClipArea.Width;
            var height = animation.ClipArea.Height;
            var bufferList = new List<MemoryStream>();

            var backBuffer = new Bitmap(BackBufferWidth, BackBufferHeight);
            var animationImage = new Bitmap(width, height);

            var gBackBufer = Graphics.FromImage(backBuffer);
            var gAnimation = Graphics.FromImage(animationImage);

            for (var frameIndex = 0; frameIndex < animation.FrameCount; frameIndex++) {
                gBackBufer.Clear(Color.Transparent);
                DrawFrame(gBackBufer, animation, frameIndex);

                // Desenha o frame no bitmap de animação.
                gAnimation.Clear(Color.Transparent);
                gAnimation.DrawImage(backBuffer, 0, 0, animation.ClipArea, GraphicsUnit.Pixel);

                // Adiciona a imagem em um stream.
                bufferList.Add(new MemoryStream());

                var imgToSave = new Bitmap(animationImage);
                imgToSave.Save(bufferList[frameIndex], ImageFormat.Png);
            }

            gBackBufer.Dispose();
            gAnimation.Dispose();
            backBuffer.Dispose();
            animationImage.Dispose();

            return bufferList;
        }

        /// <summary>
        /// Obtém a quantidade máxima de colunas.
        /// </summary>
        /// <param name="frameCount"></param>
        /// <returns></returns>
        private int GetMaxFramePerLineY(int frameCount) {
            var resultValue = frameCount / MaxFramePerLineX;
            var resultMod = frameCount % MaxFramePerLineX;

            if (resultMod > 0) {
                resultValue++;
            }

            return resultValue;
        }

        /// <summary>
        /// Desenha o frame selecionado.
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="animation"></param>
        /// <param name="frameIndex"></param>
        private void DrawFrame(Graphics graphics, Animation animation, int frameIndex) {
            for (var layerIndex = 0; layerIndex < Constants.MaxLayer; layerIndex++) {
                DrawListImage(graphics, animation, frameIndex, layerIndex);
            }
        }

        /// <summary>
        /// Desenha todos os itens de um frame.
        /// </summary>
        /// <param name="graphics"></param>
        /// <param name="animation"></param>
        /// <param name="frameIndex"></param>
        /// <param name="layerIndex"></param>
        private void DrawListImage(Graphics graphics, Animation animation, int frameIndex, int layerIndex) {
            // Count é a quantidade de frames na camada.
            var count = animation.Count(frameIndex, layerIndex);

            for (var index = 0; index < count; index++) {
                // FrameIndex é o frame atual que está sendo processado.
                graphics.DrawImage(animation[frameIndex, layerIndex, index].Image, animation[frameIndex, layerIndex, index].ScreenRect);
            }
        }
    }
}
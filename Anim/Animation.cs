using System;
using System.Drawing;
using System.Collections.Generic;
using Animation_Editor.Common;

namespace Animation_Editor.Anim {
    [Serializable]
    public sealed class Animation {
        /// <summary>
        /// Tempo de cada frame de animação.
        /// </summary>
        public int FrameRateTime { get; set; }
        
        /// <summary>
        /// Frame atual.
        /// </summary>
        public int FrameIndex { get; set; }

        /// <summary>
        /// Area selecionada do backbuffer.
        /// </summary>
        public Rectangle ClipArea { get; set; }

        public int FrameCount {
            get {
                return layer.Count;
            }
        }

        public Frame this [int frameIndex, int layerIndex, int index] {
            get {
                return layer[frameIndex][layerIndex, index];
            }

            set {
                 layer[frameIndex][layerIndex, index] = value;
            }
        }

        public Frame this [int layerIndex, int index] {
            get {
                return layer[FrameIndex][layerIndex, index];
            }
            set {
                layer[FrameIndex][layerIndex, index] = value;
            }
        }

        public List<Layer> layer;

        public Animation() {
            layer = new List<Layer>();
            FrameRateTime = 60; 
        }

        /// <summary>
        /// Adiciona um novo frame na camada.
        /// </summary>
        /// <param name="layerIndex"></param>
        /// <param name="frame"></param>
        public void Add(int layerIndex, Frame frame) {
            if (layerIndex < Constants.MaxLayer) {
                layer[FrameIndex].Add(layerIndex, frame);
            }
        }

        /// <summary>
        /// Aumenta a quantidade de frames.
        /// </summary>
        public void IncrementFrame(int count = 1) {
            for (var n = 0; n < count; n++) {
                layer.Add(new Layer());
            }
        }
        
        /// <summary>
        /// Insere um frame na camada e índice especificado.
        /// </summary>
        /// <param name="layerIndex"></param>
        /// <param name="frameIndex"></param>
        /// <param name="frame"></param>
        public void Insert(int layerIndex, int index, Frame frame) {
            if (layerIndex < Constants.MaxLayer) {

                var count = Count(layerIndex);

                if (index < count) {
                    layer[FrameIndex].Insert(layerIndex, index, frame);
                }
            }
        }

        /// <summary>
        /// Remove todos os frames de uma camada.
        /// </summary>
        /// <param name="layerIndex"></param>
        public void Clear(int layerIndex) {
            if (layerIndex < Constants.MaxLayer) {
                layer[FrameIndex].Clear(layerIndex);              
            }
        }

        /// <summary>
        /// Obtém a quantidade de itens em uma camada.
        /// </summary>
        /// <param name="layerIndex"></param>
        /// <returns></returns>
        public int Count(int layerIndex) {
            if (FrameCount > 0) {
                if (layerIndex < Constants.MaxLayer) {
                    return layer[FrameIndex].Count(layerIndex);
                }
            }

            return 0;
        }

        /// <summary>
        /// Obtém a quantidade de itens em uma camada.
        /// </summary>
        /// <param name="frameIndex"></param>
        /// <param name="layerIndex"></param>
        /// <returns></returns>
        public int Count(int frameIndex, int layerIndex) {
            if (FrameCount > 0) {
                if (layerIndex < Constants.MaxLayer) {
                    return layer[frameIndex].Count(layerIndex);
                }
            }

            return 0;
        }

        public bool MoveNext() {
            if (FrameIndex < (FrameCount - 1)) {
                FrameIndex++;

                return true;
            }

            return false;
        }

        public bool MovePrevious() {
            if (FrameIndex > 0) {
                FrameIndex--;

                return true;
            }

            return false;
        }

        /// <summary>
        /// Remove um único frame da animação.
        /// </summary>
        /// <param name="layerIndex"></param>
        /// <param name="index"></param>
        public void RemoveLayerFrame(int layerIndex, int index) {
            if (FrameCount > 0) {
                layer[FrameIndex].RemoveAt(layerIndex, index);
            }
        }

        /// <summary>
        /// Remove um frame.
        /// </summary>
        /// <param name="index"></param>
        public void RemoveFrame(int index) {
            if (FrameCount > 0) {
                if (index < FrameCount) {

                    // Primeiro, modifica para evitar erros.
                    // O FrameIndex precisa ser alterado para a posição certa.
                    // No momento em que o frame é removido, uma tentativa de acesso fora do índice pode acontecer.
                    if (FrameIndex == index) {
                        FrameIndex = index - 1;
                    }
                    // Em seguida, é removido.
                    layer.RemoveAt(index);             
                }
            }
        }

        /// <summary>
        /// Remove todos frames da animação.
        /// </summary>
        public void RemoveAll() {
            layer.Clear();

            FrameIndex = 0;
        }
    }
}
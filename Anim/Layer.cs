using System;
using System.Collections.Generic;
using Animation_Editor.Common;

namespace Animation_Editor.Anim {
    [Serializable]
    public sealed class Layer {
        private List<Frame>[] layer = new List<Frame>[Constants.MaxLayer];

        public Frame this[int layerIndex, int index] {
            get {
                return layer[layerIndex][index];
            }

            set {
                layer[layerIndex][index] = value;
            }
        }

        public Layer() {
            for (var layerIndex = 0; layerIndex < Constants.MaxLayer; layerIndex++) {
                layer[layerIndex] = new List<Frame>();
            }
        }

        /// <summary>
        /// Adiciona um novo frame na camada.
        /// </summary>
        /// <param name="layerIndex"></param>
        /// <param name="frame"></param>
        public void Add(int layerIndex, Frame frame) {
            layer[layerIndex].Add(frame);
        }

        /// <summary>
        /// Obtém a quantidade de frames da camada.
        /// </summary>
        /// <param name="layerIndex"></param>
        /// <returns></returns>
        public int Count(int layerIndex) {
            return layer[layerIndex].Count;
        }

        /// <summary>
        /// Remove todos os frames de uma camada.
        /// </summary>
        /// <param name="layerIndex"></param>
        public void Clear(int layerIndex) {
            layer[layerIndex].Clear();
        }

        /// <summary>
        /// Insere um frame no índice especificado.
        /// </summary>
        /// <param name="layerIndex"></param>
        /// <param name="index"></param>
        /// <param name="frame"></param>
        public void Insert(int layerIndex, int index, Frame frame) {
            layer[layerIndex].Insert(index, frame);
        }

        /// <summary>
        /// Remove um item indicado pelo índice.
        /// </summary>
        /// <param name="layerIndex"></param>
        /// <param name="index"></param>
        public void RemoveAt(int layerIndex, int index) {
            layer[layerIndex].RemoveAt(index);
        }
    }
}
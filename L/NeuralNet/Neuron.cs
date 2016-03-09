using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LCore.NeuralNet
    {
    class Neuron
        {
        public double[] InputWeights { get; set; }

        public double BaseOffset { get; set; }

        public enum OutputCurveType
            {

            }

        public OutputCurveType OutputCurve { get; set; }

        public double Evaluate(double[] Inputs)
            {
            double Out = BaseOffset;

            for (int i = 0; i < Inputs.Length; i++)
                {
                Out += Inputs[i] * InputWeights[i];
                }

            return Out;
            }
        }
    }

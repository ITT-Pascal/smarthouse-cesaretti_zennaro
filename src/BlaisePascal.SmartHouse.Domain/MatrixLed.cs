using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlaisePascal.SmartHouse.Domain.Asbtraction;

//namespace BlaisePascal.SmartHouse.Domain
//{
//    public class MatrixLed
//    {
//        // TODO: complete class
//        private readonly AbstractLamp[,] matrix;
//        public int Rows { get; }
//        public int Cols { get; }
//        public MatrixLed(int rows, int cols, AbstractLamp prototype)
//        {
//            if (rows <= 0 || cols <= 0)
//                throw new ArgumentException("rows and cols cannot be negative");
//            Rows = rows;
//            Cols = cols;
//            matrix = new AbstractLamp[Rows, Cols];
//            for (int r = 0; r < rows; r++)
//                for (int c = 0; c < cols; c++)
//                    matrix[r, c] = CloneLamp(prototype);
//        }
//    }
//}

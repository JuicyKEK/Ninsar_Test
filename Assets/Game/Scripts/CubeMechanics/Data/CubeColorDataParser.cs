using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Scripts.CubeMechanics.Controllers.Data
{
    public class CubeColorDataParser : ICubeColorDataParser
    {
        public CubeColorData ParseTextToMatrix(string fileText)
        {
            int[][] matrix = ParseMatrix(fileText);
            
            return new CubeColorData(matrix[0].Length, matrix.Length, matrix);
        }

        private int[][] ParseMatrix(string fileText)
        {
            string[] lines = fileText.Split(
                new[] { "\r\n", "\n" },
                StringSplitOptions.RemoveEmptyEntries);
            
            var rows = new List<int[]>(lines.Length);
            
            int expectedWidth = lines[0].Length;

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i].Trim();
                int[] row = ParseLine(line, i);
                
                if (row.Length != expectedWidth)
                {
                    Debug.LogError(
                        $"Строка {i} имеет длину {row.Length}, ожидалось {expectedWidth}. Матрица должна быть прямоугольной.");
                    return null;
                }

                rows.Add(row);
            }

            return rows.ToArray();
        }

        private int[] ParseLine(string line, int lineIndex)
        {
            var row = new int[line.Length];

            for (int i = 0; i < line.Length; i++)
            {
                char ch = line[i];

                if (!char.IsDigit(ch))
                {
                    throw new FormatException(
                        $"Недопустимый символ '{ch}' в строке {lineIndex}, позиция {i}. Ожидалась цифра.");
                }

                row[i] = ch - '0';
            }

            return row;
        }
    }
}
// Copyright 2022 Robert Heffernan
//
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software
// without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit
// persons to whom the Software is furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
// PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT
// OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace AmongUsExtractor
{
    class Sus
    {
        private readonly char[][,] susGuys =
        [
            new char[,]
            {
                { 'x', 'a', 'a', 'a' },
                { 'a', 'a', 'b', 'c' },
                { 'a', 'a', 'a', 'a' },
                { 'x', 'a', 'x', 'a' }
            },

            new char[,]
            {
                { 'x', 'a', 'a', 'a', 'a', 'a', 'x' },
                { 'a', 'a', 'b', 'c', 'b', 'a', 'a' },
                { 'a', 'a', 'a', 'a', 'a', 'a', 'a' },
                { 'x', 'a', 'x', 'a', 'x', 'a', 'x' }
            },

            new char[,]
            {
                { 'x', 'a', 'a', 'a' },
                { 'a', 'a', 'b', 'c' },
                { 'a', 'a', 'a', 'a' },
                { 'x', 'a', 'a', 'a' },
                { 'x', 'a', 'x', 'a' }
            },

            new char[,]
            {
                { 'x', 'a', 'c', 'a' },
                { 'a', 'c', 'b', 'b' },
                { 'c', 'a', 'c', 'a' },
                { 'x', 'c', 'x', 'c' }
            },

            new char[,]
            {
                { 'x', 'a', 'c', 'a' },
                { 'a', 'c', 'b', 'b' },
                { 'c', 'a', 'c', 'a' },
                { 'x', 'c', 'a', 'c' },
                { 'x', 'a', 'x', 'a' }
            },

            new char[,]
            {
                { 'x', 'a', 'a', 'a' },
                { 'c', 'c', 'b', 'b' },
                { 'a', 'a', 'a', 'a' },
                { 'x', 'c', 'c', 'c' },
                { 'x', 'a', 'x', 'a' }
            },

            new char[,]
            {
                { 'x', 'a', 'a', 'a' },
                { 'c', 'a', 'b', 'b' },
                { 'c', 'a', 'a', 'a' },
                { 'x', 'a', 'x', 'a' }
            },

            new char[,]
            {
                { 'x', 'a', 'a', 'a', 'a' },
                { 'a', 'a', 'a', 'b', 'c' },
                { 'a', 'a', 'a', 'a', 'a' },
                { 'x', 'a', 'x', 'x', 'a' }
            },

            new char[,]
            {
                { 'x', 'a', 'a', 'a', 'a' },
                { 'c', 'c', 'c', 'b', 'b' },
                { 'a', 'a', 'a', 'a', 'a' },
                { 'x', 'c', 'x', 'x', 'c' }
            },

            new char[,]
            {
                { 'x', 'a', 'a', 'a' },
                { 'c', 'c', 'b', 'b' },
                { 'a', 'a', 'a', 'a' },
                { 'x', 'c', 'x', 'c' }
            },

            new char[,]
            {
                { 'x', 'c', 'a', 'c' },
                { 'a', 'c', 'b', 'b' },
                { 'a', 'c', 'a', 'c' },
                { 'x', 'c', 'x', 'c' }
            },

            new char[,]
            {
                { 'a', 'a', 'a', 'a' },
                { 'a', 'b', 'c', 'a' },
                { 'a', 'a', 'a', 'a' },
                { 'a', 'x', 'x', 'a' }
            },

            new char[,]
            {
                { 'a', 'a', 'a', 'a' },
                { 'c', 'b', 'b', 'c' },
                { 'a', 'a', 'a', 'a' },
                { 'c', 'x', 'x', 'c' }
            },

            new char[,]
            {
                { 'a', 'c', 'a', 'c' },
                { 'c', 'b', 'b', 'a' },
                { 'a', 'c', 'a', 'c' },
                { 'c', 'x', 'x', 'a' }
            },

            new char[,]
            {
                { 'x', 'c', 'a', 'c', 'a' },
                { 'c', 'a', 'c', 'b', 'b' },
                { 'a', 'c', 'a', 'c', 'a' },
                { 'x', 'a', 'x', 'x', 'c' }
            },

            new char[,]
            { 
                { 'x', 'a', 'a', 'a', 'a', 'a' },
                { 'a', 'a', 'a', 'b', 'c', 'a' },
                { 'a', 'a', 'a', 'a', 'a', 'a' },
                { 'a', 'a', 'a', 'a', 'a', 'a' },
                { 'x', 'a', 'x', 'x', 'x', 'a' },
            },

            new char[,]
            {
                { 'x', 'a', 'a', 'a', 'a', 'a' },
                { 'c', 'c', 'c', 'b', 'b', 'c' },
                { 'a', 'a', 'a', 'a', 'a', 'a' },
                { 'c', 'c', 'c', 'c', 'c', 'c' },
                { 'x', 'a', 'x', 'x', 'x', 'a' }
            },

            new char[,]
            {
                { 'x', 'a', 'c', 'a', 'c', 'a' },
                { 'a', 'c', 'a', 'b', 'b', 'c' },
                { 'c', 'a', 'c', 'a', 'c', 'a' },
                { 'a', 'c', 'a', 'c', 'a', 'c' },
                { 'x', 'a', 'x', 'x', 'x', 'a' }
            },

            new char[,]
            {
                { 'x', 'a', 'a'},
                { 'a', 'b', 'c'},
                { 'a', 'x', 'a'}
            },

            new char[,]
            {
                { 'x', 'a', 'a', 'a' },
                { 'a', 'a', 'b', 'c' },
                { 'a', 'a', 'a', 'x' },
                { 'a', 'x', 'a', 'x' }
            },

            new char[,]
            {
                { 'x', 'a', 'c', 'a' },
                { 'a', 'c', 'b', 'b' },
                { 'c', 'a', 'c', 'x' },
                { 'a', 'x', 'a', 'x' }
            },

            new char[,]
            {
                { 'x', 'x', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'x', 'x' },
                { 'x', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'x' },
                { 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'b', 'c', 'a' },
                { 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a' },
                { 'a', 'x', 'a', 'x', 'a', 'x', 'a', 'x', 'a', 'x', 'a' }
            },

            new char[,]
            {
                { 'x', 'x', 'a', 'c', 'a', 'c', 'a', 'c', 'a', 'x', 'x' },
                { 'x', 'a', 'c', 'a', 'c', 'a', 'c', 'a', 'c', 'a', 'x' },
                { 'a', 'c', 'a', 'c', 'a', 'c', 'a', 'c', 'b', 'b', 'a' },
                { 'a', 'c', 'a', 'c', 'a', 'c', 'a', 'c', 'a', 'c', 'a' },
                { 'a', 'x', 'a', 'x', 'a', 'x', 'a', 'x', 'a', 'x', 'a' }
            },

            new char[,]
            {
                { 'x', 'x', 'x', 'x', 'x', 'a', 'x', 'a' },
                { 'x', 'x', 'x', 'x', 'x', 'a', 'a', 'a' },
                { 'x', 'x', 'x', 'x', 'a', 'a', 'b', 'c' },
                { 'x', 'x', 'a', 'a', 'a', 'a', 'a', 'a' },
                { 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'x' }
            },

            new char[,]
            {
                { 'x', 'x', 'x', 'x', 'x', 'a', 'x', 'a' },
                { 'x', 'x', 'x', 'x', 'x', 'c', 'a', 'c' },
                { 'x', 'x', 'x', 'x', 'c', 'a', 'b', 'b' },
                { 'x', 'x', 'a', 'c', 'a', 'c', 'a', 'c' },
                { 'c', 'a', 'c', 'a', 'c', 'a', 'c', 'x' }
            },

            new char[,]
            {
                { 'x', 'x', 'a', 'a', 'a', 'x', 'x' },
                { 'x', 'a', 'a', 'a', 'a', 'a', 'x' },
                { 'a', 'a', 'a', 'a', 'b', 'c', 'a' },
                { 'a', 'a', 'a', 'a', 'a', 'a', 'a' },
                { 'a', 'x', 'a', 'x', 'a', 'x', 'a' }
            },

            new char[,]
            {
                { 'x', 'x', 'a', 'c', 'a', 'x', 'x' },
                { 'x', 'a', 'c', 'a', 'c', 'a', 'x' },
                { 'a', 'c', 'a', 'c', 'b', 'b', 'a' },
                { 'a', 'c', 'a', 'c', 'a', 'c', 'a' },
                { 'a', 'x', 'a', 'x', 'a', 'x', 'a' }
            },

            new char[,]
            {
                { 'x', 'x', 'a', 'c', 'a', 'c', 'a', 'x', 'x' },
                { 'x', 'a', 'c', 'a', 'c', 'a', 'c', 'a', 'x' },
                { 'a', 'c', 'a', 'c', 'a', 'c', 'b', 'b', 'a' },
                { 'a', 'c', 'a', 'c', 'a', 'c', 'a', 'c', 'a' },
                { 'a', 'x', 'a', 'x', 'a', 'x', 'a', 'x', 'a' }
            },

            new char[,]
            {
                { 'x', 'x', 'a', 'a', 'a', 'a', 'a', 'x', 'x' },
                { 'x', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'x' },
                { 'a', 'a', 'a', 'a', 'a', 'a', 'b', 'c', 'a' },
                { 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a' },
                { 'a', 'x', 'a', 'x', 'a', 'x', 'a', 'x', 'a' }
            },

            new char[,]
            {
                { 'x', 'a', 'a', 'a' },
                { 'a', 'a', 'b', 'c' },
                { 'a', 'a', 'a', 'a' },
                { 'x', 'a', 'a', 'a' },
                { 'x', 'a', 'a', 'a' },
                { 'x', 'a', 'x', 'a' },
            },

            new char[,]
            {
                { 'x', 'a', 'a', 'a' },
                { 'a', 'a', 'b', 'c' },
                { 'a', 'a', 'a', 'a' },
                { 'x', 'a', 'a', 'a' },
                { 'x', 'a', 'a', 'a' },
                { 'x', 'a', 'a', 'a' },
                { 'x', 'a', 'x', 'a' },
            },

            new char[,]
            {
                { 'x', 'a', 'a', 'a' },
                { 'c', 'c', 'b', 'b' },
                { 'a', 'a', 'a', 'a' },
                { 'x', 'c', 'c', 'c' },
                { 'x', 'a', 'a', 'a' },
                { 'x', 'c', 'c', 'c' },
                { 'x', 'a', 'x', 'a' },
            },

            new char[,]
            {
                { 'x', 'a', 'a', 'a' },
                { 'c', 'c', 'b', 'b' },
                { 'a', 'a', 'a', 'a' },
                { 'x', 'c', 'c', 'c' },
                { 'x', 'a', 'a', 'a' },
                { 'x', 'c', 'x', 'c' },
            },

            new char[,]
            {
                { 'x', 'a', 'c', 'a' },
                { 'a', 'c', 'b', 'b' },
                { 'c', 'a', 'c', 'a' },
                { 'x', 'c', 'a', 'c' },
                { 'x', 'a', 'c', 'a' },
                { 'x', 'c', 'x', 'c' },
            },

            new char[,]
            {
                { 'x', 'a', 'c', 'a' },
                { 'a', 'c', 'b', 'b' },
                { 'c', 'a', 'c', 'a' },
                { 'x', 'c', 'a', 'c' },
                { 'x', 'a', 'c', 'a' },
                { 'x', 'c', 'a', 'c' },
                { 'x', 'a', 'x', 'a' }
            },

            new char[,]
            {
                { 'x', 'a', 'a', 'a' },
                { 'a', 'a', 'b', 'c' },
                { 'a', 'a', 'a', 'a' },
                { 'a', 'a', 'a', 'a' },
                { 'a', 'a', 'x', 'a' },
                { 'a', 'a', 'a', 'a' },
                { 'x', 'a', 'x', 'a' }
            },

            new char[,]
            {
                { 'x', 'a', 'a', 'a', 'a', 'a', 'a' },
                { 'c', 'c', 'c', 'c', 'c', 'b', 'b' },
                { 'a', 'a', 'a', 'a', 'a', 'a', 'a' },
                { 'x', 'c', 'x', 'x', 'x', 'x', 'c' }
            },

            new char[,]
            {
                { 'x', 'a', 'a', 'a', 'a', 'a' },
                { 'c', 'c', 'c', 'c', 'b', 'b' },
                { 'a', 'a', 'a', 'a', 'a', 'a' },
                { 'x', 'c', 'x', 'x', 'x', 'c' }
            },

            new char[,]
            {
                { 'x', 'c', 'a', 'c', 'a', 'c' },
                { 'c', 'a', 'c', 'a', 'b', 'b' },
                { 'a', 'c', 'a', 'c', 'a', 'c' },
                { 'x', 'a', 'x', 'x', 'x', 'a' }
            },

            new char[,]
            {
                { 'x', 'a', 'a', 'a', 'a', 'a', 'a' },
                { 'a', 'a', 'a', 'a', 'a', 'b', 'c' },
                { 'a', 'a', 'a', 'a', 'a', 'a', 'a' },
                { 'x', 'a', 'x', 'x', 'x', 'x', 'a' }
            },

            new char[,]
            {
                { 'x', 'b', 'x', 'b' },
                { 'x', 'x', 'c', 'x' },
                { 'a', 'a', 'a', 'a' },
                { 'a', 'a', 'a', 'a' },
                { 'x', 'a', 'x', 'a' }
            },

            new char[,]
            {
                { 'x', 'b', 'x', 'b' },
                { 'x', 'x', 'b', 'x' },
                { 'c', 'a', 'c', 'a' },
                { 'a', 'c', 'a', 'c' },
                { 'x', 'a', 'x', 'a' }
            },

            new char[,]
            {
                { 'x', 'x', 'x', 'a', 'x', 'x' },
                { 'a', 'x', 'a', 'a', 'a', 'a' },
                { 'x', 'a', 'a', 'a', 'b', 'c' },
                { 'a', 'x', 'a', 'a', 'a', 'a' }
            },

            new char[,]
            {
                { 'x', 'x', 'x', 'a', 'x', 'x' },
                { 'a', 'x', 'a', 'c', 'a', 'c' },
                { 'x', 'a', 'c', 'a', 'b', 'b' },
                { 'a', 'x', 'a', 'c', 'a', 'c' }
            },

            new char[,]
            {
                { 'x', 'x', 'x', 'c', 'x', 'x' },
                { 'a', 'x', 'a', 'a', 'a', 'a' },
                { 'x', 'c', 'c', 'c', 'b', 'b' },
                { 'a', 'x', 'a', 'a', 'a', 'a' }
            },

            new char[,]
            {
                { 'x', 'x', 'x', 'a', 'a', 'a'},
                { 'x', 'x', 'a', 'a', 'b', 'c'},
                { 'a', 'x', 'a', 'a', 'a', 'a'},
                { 'x', 'a', 'a', 'a', 'a', 'x'}
            },

            new char[,]
            {
                { 'x', 'x', 'x', 'a', 'c', 'a'},
                { 'x', 'x', 'a', 'c', 'b', 'b'},
                { 'c', 'x', 'c', 'a', 'c', 'a'},
                { 'x', 'c', 'a', 'c', 'a', 'x'}
            },

            new char[,]
            {
                { 'x', 'a', 'a', 'x', 'x' },
                { 'a', 'b', 'c', 'a', 'x' },
                { 'a', 'a', 'a', 'a', 'x' },
                { 'a', 'a', 'a', 'a', 'x' },
                { 'a', 'x', 'x', 'a', 'x' },
                { 'a', 'a', 'x', 'a', 'a' }
            },

            // new char[,]
            // {
            //     { 'x', 'x', 'x', 'a', 'a', 'a', 'x', 'x' },
            //     { 'x', 'x', 'a', 'x', 'x', 'x', 'a', 'x' },
            //     { 'x', 'a', 'x', 'x', 'x', 'x', 'x', 'x' },
            //     { 'x', 'a', 'x', 'x', 'a', 'a', 'a', 'x' },
            //     { 'a', 'x', 'x', 'a', 'x', 'x', 'x', 'a' },
            //     { 'a', 'x', 'x', 'x', 'a', 'a', 'a', 'x' },
            //     { 'a', 'x', 'x', 'x', 'x', 'x', 'a', 'x' },
            //     { 'a', 'x', 'x', 'a', 'x', 'x', 'a', 'x' },
            //     { 'x', 'a', 'a', 'x', 'a', 'a', 'x', 'x' }
            // }

            // it's monotone so it won't work

            new char[,]
            {
                { 'x', 'x', 'a', 'a', 'a', 'x', 'x' },
                { 'x', 'a', 'b', 'b', 'c', 'a', 'x' },
                { 'x', 'a', 'a', 'a', 'a', 'a', 'x' },
                { 'x', 'a', 'a', 'a', 'a', 'a', 'x' },
                { 'a', 'x', 'a', 'x', 'a', 'x', 'a' },
                { 'a', 'x', 'a', 'x', 'a', 'x', 'a' },
            },

            new char[,]
            {
                { 'x', 'x', 'a', 'c', 'a', 'x', 'x' },
                { 'x', 'a', 'b', 'b', 'b', 'a', 'x' },
                { 'x', 'a', 'c', 'a', 'c', 'a', 'x' },
                { 'x', 'a', 'c', 'a', 'c', 'a', 'x' },
                { 'a', 'x', 'a', 'x', 'a', 'x', 'a' },
                { 'a', 'x', 'a', 'x', 'a', 'x', 'a' },
            },

            new char[,]
            {
                { 'x', 'x', 'x', 'a', 'x', 'x', 'x' },
                { 'x', 'x', 'a', 'a', 'a', 'x', 'x' },
                { 'x', 'a', 'a', 'a', 'a', 'a', 'x' },
                { 'x', 'a', 'a', 'a', 'a', 'a', 'x' },
                { 'a', 'a', 'a', 'a', 'a', 'a', 'a' },
                { 'a', 'a', 'a', 'a', 'b', 'b', 'c' },
                { 'a', 'a', 'a', 'a', 'a', 'a', 'a' },
                { 'x', 'a', 'a', 'a', 'a', 'a', 'x' },
                { 'x', 'x', 'a', 'x', 'a', 'x', 'x' }
            }
        ];

        private HashSet<char[,]> allGuys = new HashSet<char[,]>();

        private Bitmap alteredBitmap;

        private readonly string _imagePath;
        private byte[,] place;
        private int placeCols;
        private int placeRows;
        private List<int> palette = new List<int>();
        public Sus(string imagePath)
        {
            _imagePath = imagePath;
        }

        public void FindSus()
        {
            BuildGuyList();
            ParseImage();

            int susGuys = 0;
            double pc = 100.0D / allGuys.Count;
            double tpc = 0.0D;
            foreach(char[,] guy in allGuys)
            {
                susGuys += ScanForSus(guy);

                tpc += pc;
                Console.WriteLine($"{tpc}%");
            }

            WriteImage();
            Console.WriteLine($"{susGuys} Sus Guys");
        }

        private void BuildGuyList()
        {
            foreach (char[,] guy in susGuys)
            {
                char[,] tempGuy;

                tempGuy = guy;
                for (int i = 0; i < 4; i++)
                {
                    allGuys.Add(tempGuy);
                    tempGuy = RotateGuyCCW(tempGuy);
                }
                
                // symmetry check
                if (guy != MirrorGuy(guy))
                {
                    tempGuy = MirrorGuy(guy);
                    for (int i = 0; i < 4; i++)
                    {
                        allGuys.Add(tempGuy);
                        tempGuy = RotateGuyCCW(tempGuy);
                    }
                }

                // scaling takes why too long and why more resources to find
                // regardless if we have multi-threading and AOT shit.
                // also it's completely useless, they are already big enough
                // to find them manually.
                // 
                // it's possible to use them but mathematically speaking
                // we make 24 total variation of one susGuy.
                // 32 * 24 = 768 of all possible variance.
                // this is a big number to consider, it may be okay
                // if we use lower level language like rust or c++.
                // right now 256 should be reasonable, as again
                // to find scaled guy u can use your eyes.

                // tempGuy = ScaleGuy(guy, 2);
                // for (int i = 0; i < 4; i++)
                // {
                //     allGuys.Add(tempGuy);
                //     tempGuy = RotateGuyCCW(tempGuy);
                // }
                
                // if (guy != MirrorGuy(guy))
                // {
                //     tempGuy = MirrorGuy(ScaleGuy(guy, 2));
                //     for (int i = 0; i < 4; i++)
                //     {
                //         allGuys.Add(tempGuy);
                //         tempGuy = RotateGuyCCW(tempGuy);
                //     }
                // }

                // tempGuy = ScaleGuy(guy, 3);
                // for (int i = 0; i < 4; i++)
                // {
                //     allGuys.Add(tempGuy);
                //     tempGuy = RotateGuyCCW(tempGuy);
                // }

                // if (guy != MirrorGuy(guy))
                // {
                //     tempGuy = MirrorGuy(ScaleGuy(guy, 3));
                //     for (int i = 0; i < 4; i++)
                //     {
                //         allGuys.Add(tempGuy);
                //         tempGuy = RotateGuyCCW(tempGuy);
                //     }
                // }
            }
        }

        private HashSet<Tuple<int, int>> foundAt = new HashSet<Tuple<int, int>>();

        private int ScanForSus(char[,] sus)
        {
            int matches = 0;
            int rows = sus.GetLength(0);
            int cols = sus.GetLength(1);

            var options = new ParallelOptions 
            { 
                MaxDegreeOfParallelism = Environment.ProcessorCount 
            };

            object lockObj = new object();

            Parallel.For(0, placeRows - rows, options, (row) =>
            {
                var localMatches = new List<Tuple<int, int>>();

                for (int col = 0; col < placeCols - cols; col++)
                {
                    if (CellMatches(ExtractCell(row, col, rows, cols), sus, rows, cols))
                    {
                        localMatches.Add(new Tuple<int, int>(row, col));
                    }
                }

                if (localMatches.Count > 0)
                {
                    lock (lockObj)
                    {
                        foreach (var match in localMatches)
                        {
                            foundAt.Add(match);
                            UpdateBitmap(sus, match.Item1, match.Item2);
                            matches++;
                        }
                    }
                }
            });

            return matches;
        }



        private void UpdateBitmap(char[,] sus, int ofsRow, int ofsCol)
        {
            int rows = sus.GetLength(0);
            int cols = sus.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if(sus[row, col] != 'x')
                    {
                        Color pixelValue = alteredBitmap.GetPixel(ofsCol + col, ofsRow + row);
                        int argb = pixelValue.ToArgb();
                        byte[] channels = BitConverter.GetBytes(argb);
                        channels[3] = 0xFF;

                        alteredBitmap.SetPixel(ofsCol + col, ofsRow + row, Color.FromArgb(BitConverter.ToInt32(channels)));
                    }
                }
            }
        }

        private bool CellMatches(byte[,] cell, char[,] sus, int rows, int cols)
        {
            Dictionary<char, byte> dict = new Dictionary<char, byte>();

            foreach (char c in new char[] { 'a', 'b', 'c', 'x' })
            {
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if(sus[row, col] == c)
                        {
                            if (c != 'x')
                            {
                                if (dict.ContainsKey(c))
                                {
                                    if (dict[c] != cell[row, col])
                                        return false;
                                }
                                else
                                {
                                    dict[c] = cell[row, col];
                                }
                            }
                            else
                            {
                                if (dict.ContainsKey('a') && dict.ContainsKey('b') && dict.ContainsKey('c'))
                                {
                                    if (dict['a'] == cell[row, col] || dict['b'] == cell[row, col] || dict['c'] == cell[row, col])
                                        return false;

                                    if (dict['a'] == dict['b'] || dict['a'] == dict['c'])
                                        return false;
                                }
                                else
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }
            }

            return true;
        }

        private byte[,] ExtractCell(int ofsRow, int ofsCol, int rows, int cols)
        {
            byte[,] cell = new byte[rows, cols];
            for(int row = 0; row < rows; row++)
            {
                for(int col = 0; col < cols; col++)
                {
                    cell[row, col] = place[ofsRow + row, ofsCol + col];
                }
            }

            return cell;
        }

        private char[,] RotateGuyCCW(char[,] guy)
        {
            char[,] newGuy = new char[guy.GetLength(1), guy.GetLength(0)];
            int newCol, newRow = 0;
            for (int oldCol = guy.GetLength(1) - 1; oldCol >= 0; oldCol--)
            {
                newCol = 0;
                for (int oldRow = 0; oldRow < guy.GetLength(0); oldRow++)
                {
                    newGuy[newRow, newCol] = guy[oldRow, oldCol];
                    newCol++;
                }
                newRow++;
            }

            return newGuy;
        }

        public char[,] ScaleGuy(char[,] guy, int scaleFactor)
        {
            if (scaleFactor <= 0)
                throw new ArgumentException("Scale factor must be positive", nameof(scaleFactor));

            int originalRows = guy.GetLength(0);
            int originalCols = guy.GetLength(1);
            int newRows = originalRows * scaleFactor;
            int newCols = originalCols * scaleFactor;

            char[,] scaled = new char[newRows, newCols];

            for (int i = 0; i < newRows; i++)
            {
                for (int j = 0; j < newCols; j++)
                {
                    scaled[i, j] = guy[i / scaleFactor, j / scaleFactor];
                }
            }

            return scaled;
        }


        private char[,] MirrorGuy(char[,] guy)
        {
            int rows = guy.GetLength(0);
            int cols = guy.GetLength(1);

            char[,] newGuy = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    newGuy[rows - 1 - row, col] = guy[row, col];
                }
            }

            return newGuy;
        }

        private void WriteImage()
        {
            alteredBitmap.Save(Path.Combine(Path.GetDirectoryName(_imagePath), "altered.png"));

            using(FileStream fs = File.OpenWrite(Path.Combine(Path.GetDirectoryName(_imagePath), "locations.csv")))
            {
                using (TextWriter tw = new StreamWriter(fs))
                {
                    tw.WriteLine("No, X, Y");
                    int i = 1;
                    foreach(var kvp in foundAt)
                    {
                        tw.WriteLine($"{i++}, {kvp.Item2}, {kvp.Item1}");
                    }
                }
            }
        }

        private void ParseImage()
        {
            Console.Write($"Loading image '{_imagePath}'...");
            using (Bitmap bmp = new Bitmap(Bitmap.FromFile(_imagePath)))
            {
                placeCols = bmp.Width;
                placeRows = bmp.Height;
                place = new byte[placeRows, placeCols];
                alteredBitmap = new Bitmap(bmp.Width, bmp.Height);

                BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, placeCols, placeRows), ImageLockMode.ReadOnly, bmp.PixelFormat);
                BitmapData alteredBmpData = alteredBitmap.LockBits(new Rectangle(0, 0, placeCols, placeRows), ImageLockMode.WriteOnly, alteredBitmap.PixelFormat);

                int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(bmp.PixelFormat) / 8;
                int byteCount = bmpData.Stride * placeRows;
                byte[] pixels = new byte[byteCount];
                byte[] alteredPixels = new byte[byteCount];

                Marshal.Copy(bmpData.Scan0, pixels, 0, byteCount);

                for (int i = 0; i < byteCount; i += bytesPerPixel)
                {
                    int pixelValue = BitConverter.ToInt32(pixels, i);
                    if (!palette.Contains(pixelValue))
                        palette.Add(pixelValue);

                    byte paletteIndex = (byte)palette.IndexOf(pixelValue);
                    place[i / bytesPerPixel / placeCols, (i / bytesPerPixel) % placeCols] = paletteIndex;

                    pixels[i + 3] = 0x20; // Alpha channel
                }

                Marshal.Copy(pixels, 0, alteredBmpData.Scan0, byteCount);

                bmp.UnlockBits(bmpData);
                alteredBitmap.UnlockBits(alteredBmpData);
            }
            Console.WriteLine($" {placeCols}x{placeRows} {palette.Count} colours. DONE!");
        }
    }
}

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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmongUsExtractor
{
    class Sus
    {
        private Char[,] shortSusGuy =
        {
            { 'x', 'a', 'a', 'a' },
            { 'a', 'a', 'b', 'c' },
            { 'a', 'a', 'a', 'a' },
            { 'x', 'a', 'x', 'a' }
        };

        private Char[,] longSusGuy =
        {
            { 'x', 'a', 'a', 'a' },
            { 'a', 'a', 'b', 'c' },
            { 'a', 'a', 'a', 'a' },
            { 'x', 'a', 'a', 'a' },
            { 'x', 'a', 'x', 'a' }
        };

        private Char[,] altShortSusGuy =
        {
            { 'x', 'a', 'a', 'a' },
            { 'a', 'a', 'b', 'c' },
            { 'x', 'a', 'a', 'a' },
            { 'x', 'a', 'x', 'a' }
        };

        private Char[,] altLongSusGuy =
        {
            { 'x', 'a', 'a', 'a' },
            { 'a', 'a', 'b', 'c' },
            { 'x', 'a', 'a', 'a' },
            { 'x', 'a', 'a', 'a' },
            { 'x', 'a', 'x', 'a' }
        };

        private Char[,] otherAltLongSusGuy =
        {
            { 'x', 'a', 'a', 'a' },
            { 'a', 'a', 'b', 'c' },
            { 'a', 'a', 'a', 'a' },
            { 'a', 'a', 'a', 'a' },
            { 'x', 'a', 'x', 'a' }
        };

        private List<Char[,]> allGuys = new List<Char[,]>();

        private Bitmap alteredBitmap;

        private readonly String _imagePath;
        private Byte[,] place;
        private Int32 placeCols;
        private Int32 placeRows;
        private List<Int32> palette = new List<Int32>();
        public Sus(String imagePath)
        {
            _imagePath = imagePath;
        }

        public void FindSus()
        {
            BuildGuyList();
            ParseImage();

            Int32 susGuys = 0;
            Double pc = 100.0D / allGuys.Count;
            Double tpc = 0.0D;
            foreach(Char[,] guy in allGuys)
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
            Char[,] guy;

            guy = longSusGuy;
            for (Int32 i = 0; i < 4; i++)
            {
                allGuys.Add(guy);
                guy = RotateGuyCCW(guy);
            }

            guy = MirrorGuy(longSusGuy);
            for (Int32 i = 0; i < 4; i++)
            {
                allGuys.Add(guy);
                guy = RotateGuyCCW(guy);
            }

            guy = altLongSusGuy;
            for (Int32 i = 0; i < 4; i++)
            {
                allGuys.Add(guy);
                guy = RotateGuyCCW(guy);
            }

            guy = MirrorGuy(altLongSusGuy);
            for (Int32 i = 0; i < 4; i++)
            {
                allGuys.Add(guy);
                guy = RotateGuyCCW(guy);
            }

            guy = otherAltLongSusGuy;
            for (Int32 i = 0; i < 4; i++)
            {
                allGuys.Add(guy);
                guy = RotateGuyCCW(guy);
            }

            guy = MirrorGuy(otherAltLongSusGuy);
            for (Int32 i = 0; i < 4; i++)
            {
                allGuys.Add(guy);
                guy = RotateGuyCCW(guy);
            }

            guy = shortSusGuy;
            for(Int32 i = 0; i < 4; i++)
            {
                allGuys.Add(guy);
                guy = RotateGuyCCW(guy);
            }

            guy = MirrorGuy(shortSusGuy);
            for (Int32 i = 0; i < 4; i++)
            {
                allGuys.Add(guy);
                guy = RotateGuyCCW(guy);
            }

            guy = altShortSusGuy;
            for (Int32 i = 0; i < 4; i++)
            {
                allGuys.Add(guy);
                guy = RotateGuyCCW(guy);
            }

            guy = MirrorGuy(altShortSusGuy);
            for (Int32 i = 0; i < 4; i++)
            {
                allGuys.Add(guy);
                guy = RotateGuyCCW(guy);
            }
        }

        private Dictionary<Tuple<Int32, Int32>, Boolean> foundAt = new Dictionary<Tuple<Int32, Int32>, bool>();

        private Int32 ScanForSus(Char[,] sus)
        {
            Int32 matches = 0;
            Int32 rows = sus.GetLength(0);
            Int32 cols = sus.GetLength(1);
            for(Int32 row = 0; row < placeRows - rows; row++)
            {
                for (Int32 col = 0; col < placeCols - cols; col++)
                {
                    //if (foundAt.ContainsKey(rc) && foundAt[rc] == true)
                    //    continue;

                    Byte[,] cell = ExtractCell(row, col, rows, cols);
                    if (CellMatches(cell, sus, rows, cols))
                    {
                        Tuple<Int32, Int32> rc = new Tuple<Int32, Int32>(row, col);
                        foundAt[rc] = true;
                        UpdateBitmap(sus, row, col);
                        matches++;
                    }

                    //foundAt[rc] = false;
                }
            }
            return matches;
        }

        private void UpdateBitmap(Char[,] sus, Int32 ofsRow, Int32 ofsCol)
        {
            Int32 rows = sus.GetLength(0);
            Int32 cols = sus.GetLength(1);

            for (Int32 row = 0; row < rows; row++)
            {
                for (Int32 col = 0; col < cols; col++)
                {
                    if(sus[row, col] != 'x')
                    {
                        Color pixelValue = alteredBitmap.GetPixel(ofsCol + col, ofsRow + row);
                        Int32 argb = pixelValue.ToArgb();
                        Byte[] channels = BitConverter.GetBytes(argb);
                        channels[3] = 0xFF;

                        alteredBitmap.SetPixel(ofsCol + col, ofsRow + row, Color.FromArgb(BitConverter.ToInt32(channels)));
                    }
                }
            }
        }

        private Boolean CellMatches(Byte[,] cell, Char[,] sus, Int32 rows, Int32 cols)
        {
            Dictionary<Char, Byte> dict = new Dictionary<Char, Byte>();

            foreach (Char c in new Char[] { 'a', 'b', 'c', 'x' })
            {
                for (Int32 row = 0; row < rows; row++)
                {
                    for (Int32 col = 0; col < cols; col++)
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

        private Byte[,] ExtractCell(Int32 ofsRow, Int32 ofsCol, Int32 rows, Int32 cols)
        {
            Byte[,] cell = new Byte[rows, cols];
            for(Int32 row = 0; row < rows; row++)
            {
                for(Int32 col = 0; col < cols; col++)
                {
                    cell[row, col] = place[ofsRow + row, ofsCol + col];
                }
            }

            return cell;
        }

        private Char[,] RotateGuyCCW(Char[,] guy)
        {
            Char[,] newGuy = new Char[guy.GetLength(1), guy.GetLength(0)];
            Int32 newCol, newRow = 0;
            for (Int32 oldCol = guy.GetLength(1) - 1; oldCol >= 0; oldCol--)
            {
                newCol = 0;
                for (Int32 oldRow = 0; oldRow < guy.GetLength(0); oldRow++)
                {
                    newGuy[newRow, newCol] = guy[oldRow, oldCol];
                    newCol++;
                }
                newRow++;
            }

            return newGuy;
        }

        private Char[,] MirrorGuy(Char[,] guy)
        {
            Int32 rows = guy.GetLength(0);
            Int32 cols = guy.GetLength(1);

            Char[,] newGuy = new Char[rows, cols];

            for (Int32 row = 0; row < rows; row++)
            {
                for (Int32 col = 0; col < cols; col++)
                {
                    newGuy[rows - 1 - row, col] = guy[row, col];
                }
            }

            return newGuy;
        }

        private void WriteImage()
        {
            alteredBitmap.Save(@"D:\altered.png");

            using(FileStream fs = File.OpenWrite(@"D:\locations.csv"))
            {
                using (TextWriter tw = new StreamWriter(fs))
                {
                    tw.WriteLine("No, X, Y");
                    Int32 i = 1;
                    foreach(var kvp in foundAt)
                    {
                        if(kvp.Value == true)
                        {
                            tw.WriteLine($"{i++}, {kvp.Key.Item2}, {kvp.Key.Item1}");
                        }
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
                place = new Byte[placeRows, placeCols];

                alteredBitmap = new Bitmap(bmp.Width, bmp.Height);

                for(Int32 row = 0; row < placeRows; row++)
                {
                    for(Int32 col = 0; col < placeCols; col++)
                    {
                        Color pixel = bmp.GetPixel(col, row);
                        Int32 pixelValue = pixel.ToArgb();
                       
                        if (palette.Contains(pixelValue) == false)
                            palette.Add(pixelValue);

                        Byte paletteIndex = (Byte)palette.IndexOf(pixelValue);
                        place[row, col] = paletteIndex;

                        Byte[] channels = BitConverter.GetBytes(pixelValue);
                        channels[3] = 0x40;

                        alteredBitmap.SetPixel(col, row, Color.FromArgb(BitConverter.ToInt32(channels)));
                    }
                }
            }
            Console.WriteLine($" {placeCols}x{placeRows} {palette.Count} colours. DONE!");
        }
    }
}

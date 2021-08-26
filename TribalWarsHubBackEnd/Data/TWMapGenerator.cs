using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TribalWarsHubBackEnd.Models;

namespace TribalWarsHubBackEnd.Data
{
    public class TWMapGenerator
    {
        // TWMAP 4x4 -> 400 x 400 vills -> 160.000 vills -> (4*400)*400=640.000
        // 800x4x800 = 2.560.000
        private static readonly byte[] _imageBuffer = new byte[2560000];

        static async Task PlotPixel(int x, int y, byte redValue,
         byte greenValue, byte blueValue)
        {
            await Task.Run(() =>
            {
                int offset = ((800 * 4) * y) + (x * 4);
                _imageBuffer[offset] = blueValue;
                _imageBuffer[offset + 1] = greenValue;
                _imageBuffer[offset + 2] = redValue;
                // Fixed alpha value (No transparency)
                _imageBuffer[offset + 3] = 255;
            });            
        }

        static async Task PlotSquare(int x, int y, byte redValue, byte greenValue, byte blueValue)
        {
            await PlotPixel(x, y, redValue, greenValue, blueValue);
            await PlotPixel(x + 1, y, redValue, greenValue, blueValue);
            await PlotPixel(x, y + 1, redValue, greenValue, blueValue);
            await PlotPixel(x + 1, y + 1, redValue, greenValue, blueValue);
        }

        static async Task GenerateSquare(List<Village> vills, int x, int y)
        {
            int coordY = y / 2 + 300;
            int coordX = x / 2 + 300;

            int index = vills.FindIndex(t => (t.x == coordX) && (t.y == coordY));

            if (index >= 0)
            {
                await PlotSquare(x, y, 101, 63, 33);
            }
            else
            {
                await PlotSquare(x, y, 7, 143, 0);
            }
        }

        static async Task GeneratePlayerSquare(List<Player> players, List<Village> vills, int x, int y)
        {
            int coordY = y / 2 + 300;
            int coordX = x / 2 + 300;

            int index = vills.FindIndex(t => (t.x == coordX) && (t.y == coordY));

            if (index >= 0)
            {
                if(vills[index].Player_Id == players[0].Player_Id)
                {
                    // rank 1 = blue
                    await PlotSquare(x, y, 3, 36, 252);
                }
                else if(vills[index].Player_Id == players[1].Player_Id)
                {
                    // rank 2 = red
                    await PlotSquare(x, y, 252, 3, 3);
                }
                else if (vills[index].Player_Id == players[2].Player_Id)
                {
                    // rank 3 = yellow
                    await PlotSquare(x, y, 255, 251, 0);
                }
                else if (vills[index].Player_Id == players[3].Player_Id)
                {
                    // rank 4 = green
                    await PlotSquare(x, y, 68, 255, 0);
                }
                else if (vills[index].Player_Id == players[4].Player_Id)
                {
                    // rank 5 = purple
                    await PlotSquare(x, y, 255, 0, 251);
                }
                else
                {
                    // brown
                    await PlotSquare(x, y, 101, 63, 33);
                }
            }
            else
            {
                await PlotSquare(x, y, 7, 143, 0);
            }
        }

        // GREEN RGB = 7,143,0  BROWN RGB = 101, 63, 33
        /* 
        Top Left 300x300
        Bottom Left 699x300
        Top Right 300x699
        Bottom Right 699x699
        */

        public static async Task GenerateMap(List<Village> vills, string name)
        {
            for (int y = 0; y < 800; y += 2)
            {
                await Task.Run(() =>
                {
                    for (int x = 0; x < 800; x += 8)
                    {
                        var _gen1 = GenerateSquare(vills, x, y);
                        var _gen2 = GenerateSquare(vills, x + 2, y);
                        var _gen3 = GenerateSquare(vills, x + 4, y);
                        var _gen4 = GenerateSquare(vills, x + 6, y);
                    }
                });
            }

            unsafe
            {
                fixed (byte* ptr = _imageBuffer)
                {
                    using (Bitmap image = new Bitmap(800, 800, 800 * 4,
                       PixelFormat.Format32bppRgb, new IntPtr(ptr)))
                    {
                        var currentDirectory = Directory.GetCurrentDirectory();
                        var pathMap = Path.Combine(currentDirectory, "Data", "TWMaps", name);

                        image.Save(pathMap);
                    }
                }
            }
        }

        public static async Task GenerateTopPlayersMap(List<Player> players, List<Village> vills, string name)
        {
            for (int y = 0; y < 800; y += 2)
            {
                await Task.Run(() =>
                {
                    for (int x = 0; x < 800; x += 8)
                    {
                        var _gen1 = GeneratePlayerSquare(players, vills, x, y);
                        var _gen2 = GeneratePlayerSquare(players, vills, x + 2, y);
                        var _gen3 = GeneratePlayerSquare(players, vills, x + 4, y);
                        var _gen4 = GeneratePlayerSquare(players, vills, x + 6, y);
                    }
                });
            }

            unsafe
            {
                fixed (byte* ptr = _imageBuffer)
                {
                    using (Bitmap image = new Bitmap(800, 800, 800 * 4,
                       PixelFormat.Format32bppRgb, new IntPtr(ptr)))
                    {
                        var currentDirectory = Directory.GetCurrentDirectory();
                        var pathMap = Path.Combine(currentDirectory, "Data", "TWMaps", name);

                        image.Save(pathMap);
                    }
                }
            }
        }
    }
}

#pragma warning disable CA1416 // 验证平台兼容性
using System;
using System.Drawing;
using System.Drawing.Imaging;
using Xunit;

namespace Anh.WebP.Test
{
    public class TestSimpleEncoderDecoderRoundtrip
    {
        private static readonly Random random = new Random();

        private static byte RandomByte()
        {
            return (byte)random.Next(255);
        }

        private static Color RandomRgb()
        {
            return Color.FromArgb(0, RandomByte(), RandomByte(), RandomByte());
        }

        private static Color RandomArgb()
        {
            return Color.FromArgb(RandomByte(), RandomRgb());
        }

        private Bitmap GenerateTestBitmap(PixelFormat fmt, int width, int height, Func<Color> pixelValue)
        {
            var bitmap = new Bitmap(width, height, fmt);
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    var color = pixelValue();
                    bitmap.SetPixel(x, y, color);
                }
            }

            return bitmap;
        }

        private void TestLosslessRoundtrip(Bitmap gdiBitmap)
        {
            var encoder = new SimpleEncoder();
            var decoder = new SimpleDecoder();

            using (var outStream = new MemoryStream())
            {
                encoder.Encode(gdiBitmap, outStream, -1);
                outStream.Close();

                var webpBytes = outStream.ToArray();
                var reloaded = decoder.DecodeFromBytes(webpBytes, webpBytes.LongLength);


                Assert.Equal(gdiBitmap.Height, reloaded.Height);
                Assert.Equal(gdiBitmap.Width, reloaded.Width);

                for (var y = 0; y < reloaded.Height; y++)
                {
                    for (var x = 0; x < reloaded.Width; x++)
                    {
                        var expectedColor = gdiBitmap.GetPixel(x, y);
                        var actualColor = reloaded.GetPixel(x, y);
                        Assert.Equal(expectedColor, actualColor);
                    }
                }
            }
        }

        [Fact]
        public void TestRgb32()
        {
            Extern.LoadLibrary.LoadWebPOrFail();

            using (var gdiBitmap = GenerateTestBitmap(PixelFormat.Format32bppRgb, 10, 10, RandomRgb))
            {
                TestLosslessRoundtrip(gdiBitmap);
            }
        }

        [Fact]
        public void TestRgb24()
        {
            Extern.LoadLibrary.LoadWebPOrFail();

            using (var gdiBitmap = GenerateTestBitmap(PixelFormat.Format24bppRgb, 10, 10, RandomRgb))
            {
                TestLosslessRoundtrip(gdiBitmap);
            }
        }

        [Fact]
        public void TestAgb32()
        {
            Extern.LoadLibrary.LoadWebPOrFail();

            using (var gdiBitmap = GenerateTestBitmap(PixelFormat.Format32bppArgb, 10, 10, RandomArgb))
            {
                TestLosslessRoundtrip(gdiBitmap);
            }
        }
    }
}
#pragma warning restore CA1416 // 验证平台兼容性
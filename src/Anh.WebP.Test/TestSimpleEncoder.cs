using System;
using Xunit;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;
using Anh.WebP.Extern;

namespace Anh.WebP.Test
{
    public class TestSimpleEncoder
    {
        [Fact]
        public void TestVersion()
        {
            LoadLibrary.LoadWebPOrFail();
            Assert.Equal("0.6.0", SimpleEncoder.GetEncoderVersion());
        }
        [Fact]
        public void TestEncSimple()
        {
            LoadLibrary.LoadWebPOrFail();

            var encoder = new SimpleEncoder();
            var fileName = "testimage.jpg";
            var outFileName = "testimageout.webp";
            File.Delete(outFileName);

            Bitmap mBitmap;
            FileStream outStream = new FileStream(outFileName, FileMode.Create);
            using (Stream BitmapStream = File.Open(fileName, FileMode.Open))
            {
                Image img = Image.FromStream(BitmapStream);

                mBitmap = new Bitmap(img);

                encoder.Encode(mBitmap, outStream, 100);
            }

            FileInfo finfo = new FileInfo(outFileName);
            Assert.True(finfo.Exists);
        }
    }
}

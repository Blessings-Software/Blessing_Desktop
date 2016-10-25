using d2 = SharpDX.Direct2D1;
using wic = SharpDX.WIC;

using System.IO;

namespace St2D.Utils
{
    public static class BitmapHelper
    {
        private static wic.ImagingFactory Factory;

        static BitmapHelper()
        {
            Factory = new wic.ImagingFactory();
        }

        public static d2.Bitmap FromStream(this d2.DeviceContext device, Stream s)
        {
            return Load(device, new wic.BitmapDecoder(Factory, s, wic.DecodeOptions.CacheOnLoad));
        }

        public static d2.Bitmap FromFile(this d2.DeviceContext device, string fileName)
        {
            return Load(device, new wic.BitmapDecoder(Factory, fileName, wic.DecodeOptions.CacheOnLoad));
        }

        private static d2.Bitmap Load(d2.DeviceContext device, wic.BitmapDecoder decoder)
        {
            var converter = new wic.FormatConverter(Factory);
            var frame = decoder.GetFrame(0);

            converter.Initialize(frame, wic.PixelFormat.Format32bppPRGBA);
            var bmp = d2.Bitmap.FromWicBitmap(device, converter);

            frame.Dispose();
            decoder.Dispose();
            converter.Dispose();

            return bmp;
        }
    }
}
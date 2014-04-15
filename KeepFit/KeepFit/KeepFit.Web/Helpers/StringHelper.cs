using System;
using System.Drawing;
using System.IO;

namespace KeepFit.Web.Helpers
{
    public static class StringHelper
    {
        public static Image Base64ToImage(this string base64String)
        {
            // Convert Base64 String to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            var ms = new MemoryStream(imageBytes, 0,
              imageBytes.Length);

            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }
    }
}
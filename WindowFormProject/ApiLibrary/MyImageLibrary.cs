using System.Collections.Generic;
using System.Drawing;

namespace ProjectLibrary
{

    public class MyImageLibrary
    {
        
        static public Bitmap CreateImageFromRGB(int width, int height, byte[] data)
        {
           
            Bitmap pic = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            //convert to 3d array to represent the image
            //outer bound  length represents the height
            //mid bound length represents the width
            //inner bound represents rgb value
            byte [,,] imageData=DataStructureConverter.Convert1dArrayTo3d<byte>(data, height, width, 3);

            for(int y = 0; y < imageData.GetLength(0); y++)
            {
                for(int x = 0; x < imageData.GetLength(1); x++)
                {
                    List<byte> rgbValues = new List<byte>();
                    //get rgb value
                    for(int k = 0; k < imageData.GetLength(2); k++)
                    {
                        rgbValues.Add(imageData[y, x, k]);
                    }

                    Color color = Color.FromArgb(
                       255,
                       rgbValues[0],
                       rgbValues[1],
                       rgbValues[2]
                    );

                    
                    //draw pixel on coordinate x,y
                    pic.SetPixel(x, y, color);
                }
            }
            return pic;
        }
     
        /// <summary>
        /// Convert [System.Drawing.Color] to an array of rgba between 0 and 1
        /// </summary>
        /// <returns></returns>
        static public float[] ConvertColorToRGBA(Color color)
        {
            return new float[] {
                (float) color.R /255,
                (float) color.G /255,
                (float) color.B /255,
                (float) color.A /255,

            };
        }
    }
}

using System.Collections.Generic;
using System.Drawing;

namespace ProjectLibrary
{

    public class ImageReader
    {
        
        static public Bitmap CreateImageFromRGB(int width, int height, byte[] data)
        {
           
            Bitmap pic = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            //convert to 3d array to represent the image
            //outer bound  length represents the height
            //mid bound length represents the width
            //inner bound represents rgb value
            byte [,,] imageData=DataStructureConverter.Convert1dArrayTo3d<byte>(data, height, width, 3);

            for(int h = 0; h < imageData.GetLength(0); h++)
            {
                for(int w = 0; w < imageData.GetLength(1); w++)
                {
                    List<byte> rgbValues = new List<byte>();
                    //get rgb value
                    for(int k = 0; k < imageData.GetLength(2); k++)
                    {
                        rgbValues.Add(imageData[h, w, k]);
                    }

                    Color color = Color.FromArgb(
                       255,
                       rgbValues[0],
                       rgbValues[1],
                       rgbValues[2]
                    );

                    
                    //draw pixel on coordinate w,h
                    pic.SetPixel(w, h, color);
                }
            }
            return pic;
        }
      
        static public void ConvertArrayInStringToImage(string arrayInString)
        {
            //convert to bytes
            byte[] imageData=DataStructureConverter.ConvertArrayInStringToArrayOfByte(arrayInString);

        }
    }
}

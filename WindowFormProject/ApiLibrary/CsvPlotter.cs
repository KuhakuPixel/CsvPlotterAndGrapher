using ApiLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Threading.Tasks;

namespace ProjectLibrary
{
    public class CsvPlotter
    {
        static public async Task DisplayHistogram(string columnToHistogram)
        {
            string plotName = "plot1";
            string apiURL = "http://localhost:5000/Plotter/ColumnToHistogram" + "/" + plotName;

            //send request to python backend  to get the plot of [column]
            await FlaskApi.PutRequest(apiURL, new KeyValuePair<string, string>("columnName", columnToHistogram));
            string json = await FlaskApi.GetRequest(apiURL,printResponse:false);
            //deserialize json
            Dictionary<string, object> result = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);


           
            string imageDataInString = result[plotName] as string;
            string imageDimensionInString = result["img_shape"] as string;
            #region getting image Shape
            //(height,width ,3)
            int[] imageShape = DataStructureConverter.ConvertArrayInStringToArrayOfInt(imageDimensionInString);
            int height = imageShape[0];
            int width = imageShape[1];

            #endregion

            #region getting bitmap

            byte[] imageData = DataStructureConverter.ConvertArrayInStringToArrayOfByte(imageDataInString);

            Bitmap bitmap=ImageReader.CreateImageFromRGB(width, height, imageData);
            #endregion

          
            bitmap.Save(@"C:\Users\Nicho\Desktop\Projects\CsvPlotterAndGrapher\" +"plot1.png",ImageFormat.Png);
        }
    }
}

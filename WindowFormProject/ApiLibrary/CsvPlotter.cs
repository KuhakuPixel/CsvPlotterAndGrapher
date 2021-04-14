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
    static public class CsvPlotter
    {
       public enum PlotTypes
        {
            Histogram,
            Scatter,

        }
        static private string[] plotTypesValues = Enum.GetNames(typeof(PlotTypes));

        
        static public string[] GetPlotTypesValues()
        {
            return plotTypesValues;

        }
       
        static public async Task<Bitmap> CreateHistogram(HistogramAttributes attributes)
        {
            string plotName = attributes.PlotName;
            string apiURL = "http://localhost:5000/Plotter/ColumnToHistogram" + "/" + plotName;

          
            await FlaskApi.PutRequest(apiURL, new Dictionary<string, string>
            {
                {"columnName", attributes.XColumnName},
                {"plotName", attributes.PlotName},
            });

            Dictionary<string, object> result = await FlaskApi.GetRequest(apiURL, printResponse: false);
         



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

            //make bitmap 
            Bitmap bitmap = ImageReader.CreateImageFromRGB(width, height, imageData);
            #endregion


            return bitmap;
        }
    }
}

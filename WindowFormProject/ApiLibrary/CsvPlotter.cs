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
        /// <summary>
        /// list of available colours that can be used to decorate the plot 
        /// </summary>
        public enum ColorsCollection
        {
            blue,
            green,
            red,
            cyan,
            magenta,
            yellow,
            black,
            white

        }

        


       

        static public async Task<Bitmap> CreateHistogram(HistogramAttributes attributes)
        {
            string plotName = attributes.PlotName;



            await FlaskApi.PutRequest(ApiEndpointConfigurations.histogramPlotterApiEndPoint, new Dictionary<string, string>
            {
                {"columnName", attributes.XColumnName},
                {"plotName", attributes.PlotName},
                {"xLabel",attributes.XLabel},
                {"xAxisLabelColor",attributes.XAxisLabelColor.ToString()},

                {"yLabel",attributes.YLabel},
                {"yAxisLabelColor",attributes.YAxisLabelColor.ToString() },
                {"plotNameColor",attributes.PlotNameColor.ToString()}
            });

            Dictionary<string, object> result = await FlaskApi.GetRequest(ApiEndpointConfigurations.histogramPlotterApiEndPoint, printResponse: false);




            string imageDataInString = result[ApiEndpointConfigurations.histogramImageData_key] as string;
            string imageDimensionInString = result[ApiEndpointConfigurations.histogramImageShape_key] as string;
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

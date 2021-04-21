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






        static public async Task<Bitmap> CreateHistogram(HistogramAttributes attributes)
        {



            
            await FlaskApi.PutRequest(ApiEndpointConfigurations.histogramPlotterApiEndPoint, attributes.PlotToKeyAndArguments());
            
            
               
            Dictionary<string, object> result = await FlaskApi.GetRequest(ApiEndpointConfigurations.histogramPlotterApiEndPoint, printResponse: false);



            string imageDataInString = result[ApiEndpointConfigurations.plotImageData_key] as string;
            string imageDimensionInString = result[ApiEndpointConfigurations.plotImageShape_key] as string;
            #region getting image Shape
            //(height,width ,3)
            int[] imageShape = DataStructureConverter.ConvertArrayInStringToArrayOfInt(imageDimensionInString);
            int height = imageShape[0];
            int width = imageShape[1];

            #endregion

            #region getting bitmap

            byte[] imageData = DataStructureConverter.ConvertArrayInStringToArrayOfByte(imageDataInString);

            //make bitmap 
            Bitmap bitmap = MyImageLibrary.CreateImageFromRGB(width, height, imageData);
            #endregion


            return bitmap;
        }

        static public async Task<Bitmap> CreateScatterPlot(ScatterAttributes attributes)
        {

            await FlaskApi.PutRequest(ApiEndpointConfigurations.scatterPlotterApiEndPoint,attributes.PlotToKeyAndArguments());

            Dictionary<string, object> result = await FlaskApi.GetRequest(ApiEndpointConfigurations.scatterPlotterApiEndPoint, printResponse: false);




            string imageDataInString = result[ApiEndpointConfigurations.plotImageData_key] as string;
            string imageDimensionInString = result[ApiEndpointConfigurations.plotImageShape_key] as string;
            #region getting image Shape
            //(height,width ,3)
            int[] imageShape = DataStructureConverter.ConvertArrayInStringToArrayOfInt(imageDimensionInString);
            int height = imageShape[0];
            int width = imageShape[1];

            #endregion

            #region getting bitmap

            byte[] imageData = DataStructureConverter.ConvertArrayInStringToArrayOfByte(imageDataInString);

            //make bitmap 
            Bitmap bitmap = MyImageLibrary.CreateImageFromRGB(width, height, imageData);
            #endregion


            return bitmap;
        }
    }
}

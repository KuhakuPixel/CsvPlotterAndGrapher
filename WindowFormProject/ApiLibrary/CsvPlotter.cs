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




            await FlaskApi.PutRequest(ApiEndpointConfigurations.histogramPlotterApiEndPoint, new Dictionary<string, string>
            {
                {"columnName", attributes.XColumnName},
                {"plotName", attributes.PlotName},
                {"xLabel",attributes.XLabel},
                {"xAxisLabelColor",attributes.XAxisLabelColor.ToString()},
                {"barColor",attributes.BarColor.ToString() },
                {"yLabel",attributes.YLabel},
                {"yAxisLabelColor",attributes.YAxisLabelColor.ToString() },
                {"plotNameColor",attributes.PlotNameColor.ToString()},

                {"bottomSpineColor",attributes.BottomSpineColor.ToString()},
                {"topSpineColor",attributes.TopSpineColor.ToString()},
                {"leftSpineColor",attributes.LeftSpineColor.ToString()},
                {"rightSpineColor",attributes.RightSpineColor.ToString()},
            });

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
            Bitmap bitmap = ImageReader.CreateImageFromRGB(width, height, imageData);
            #endregion


            return bitmap;
        }

        static public async Task<Bitmap> CreateScatterPlot(ScatterAttributes attributes)
        {

            await FlaskApi.PutRequest(ApiEndpointConfigurations.scatterPlotterApiEndPoint, new Dictionary<string, string>
            {
                {"xColumnName", attributes.XColumnName},
                {"yColumnName", attributes.YColumnName},
                {"plotName", attributes.PlotName},
                {"dotColor",attributes.DotColor.ToString() },

                {"xLabel",attributes.XLabel},
                {"xAxisLabelColor",attributes.XAxisLabelColor.ToString()},

                {"yLabel",attributes.YLabel},
                {"yAxisLabelColor",attributes.YAxisLabelColor.ToString() },

                {"plotNameColor",attributes.PlotNameColor.ToString()},

                {"bottomSpineColor",attributes.BottomSpineColor.ToString()},
                {"topSpineColor",attributes.TopSpineColor.ToString()},
                {"leftSpineColor",attributes.LeftSpineColor.ToString()},
                {"rightSpineColor",attributes.RightSpineColor.ToString()},
            });

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
            Bitmap bitmap = ImageReader.CreateImageFromRGB(width, height, imageData);
            #endregion


            return bitmap;
        }
    }
}

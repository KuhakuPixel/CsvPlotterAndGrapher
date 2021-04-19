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




            await FlaskApi.PutRequest(ApiEndpointConfigurations.histogramPlotterApiEndPoint, new Dictionary<string, string>
            {
                {"xColumnName", attributes.XColumnName},
                {"plotName", attributes.PlotName},
                {"xLabel",attributes.XLabel},
                {"xAxisLabelColor", JsonConvert.SerializeObject(MyImageLibrary.ConvertColorToRGBA(attributes.XAxisLabelColor))},
                {"barColor",JsonConvert.SerializeObject(MyImageLibrary.ConvertColorToRGBA(attributes.BarColor))},
                {"yLabel",attributes.YLabel},
                {"yAxisLabelColor",JsonConvert.SerializeObject(MyImageLibrary.ConvertColorToRGBA(attributes.YAxisLabelColor)) },
                {"plotNameColor",JsonConvert.SerializeObject(MyImageLibrary.ConvertColorToRGBA(attributes.PlotNameColor))},

                {"bottomSpineColor",JsonConvert.SerializeObject(MyImageLibrary.ConvertColorToRGBA(attributes.BottomSpineColor))},
                {"topSpineColor",JsonConvert.SerializeObject(MyImageLibrary.ConvertColorToRGBA(attributes.TopSpineColor))},
                {"leftSpineColor",JsonConvert.SerializeObject(MyImageLibrary.ConvertColorToRGBA(attributes.LeftSpineColor))},
                {"rightSpineColor",JsonConvert.SerializeObject(MyImageLibrary.ConvertColorToRGBA(attributes.RightSpineColor))},
                //{"titleColorTest",JsonConvert.SerializeObject(MyImageLibrary.ConvertColorToRGBA(attributes.ColorTest))}
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
            Bitmap bitmap = MyImageLibrary.CreateImageFromRGB(width, height, imageData);
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
                {"xLabel",attributes.XLabel},
                {"xAxisLabelColor", JsonConvert.SerializeObject(MyImageLibrary.ConvertColorToRGBA(attributes.XAxisLabelColor))},
                {"barColor",JsonConvert.SerializeObject(MyImageLibrary.ConvertColorToRGBA(attributes.DotColor))},
                {"yLabel",attributes.YLabel},
                {"yAxisLabelColor",JsonConvert.SerializeObject(MyImageLibrary.ConvertColorToRGBA(attributes.YAxisLabelColor)) },
                {"plotNameColor",JsonConvert.SerializeObject(MyImageLibrary.ConvertColorToRGBA(attributes.PlotNameColor))},

                {"bottomSpineColor",JsonConvert.SerializeObject(MyImageLibrary.ConvertColorToRGBA(attributes.BottomSpineColor))},
                {"topSpineColor",JsonConvert.SerializeObject(MyImageLibrary.ConvertColorToRGBA(attributes.TopSpineColor))},
                {"leftSpineColor",JsonConvert.SerializeObject(MyImageLibrary.ConvertColorToRGBA(attributes.LeftSpineColor))},
                {"rightSpineColor",JsonConvert.SerializeObject(MyImageLibrary.ConvertColorToRGBA(attributes.RightSpineColor))},
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
            Bitmap bitmap = MyImageLibrary.CreateImageFromRGB(width, height, imageData);
            #endregion


            return bitmap;
        }
    }
}

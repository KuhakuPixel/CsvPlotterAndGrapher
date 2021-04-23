using System.ComponentModel;
using System.Drawing;
using System.Reflection;

namespace ProjectLibrary.PlotsAttributes
{


    public class TicksProperty
    {
        //x tick color
        private Color tickColor = Color.Black;
        [Category(PlotProperty.plotColorCategoryText)]
        [DisplayName("Ticks Color")]
        [Description("Change the color of the x ticks")]
        public Color TicksColor { get => tickColor; set => tickColor = value; }


        private bool useMinorLocator = false;
        [RefreshProperties(RefreshProperties.All)]
        public bool UseMinorLocator
        {
            get => useMinorLocator;

            set
            {
                useMinorLocator = value;

                PropertyDescriptor descriptor = TypeDescriptor.GetProperties(this.GetType())["MinorLocatorValue"];
                //set the ReadOnlyAttribute of the descriptor
                ReadOnlyAttribute readOnlyattribute = (ReadOnlyAttribute)descriptor.Attributes[typeof(ReadOnlyAttribute)];

                FieldInfo fieldToChange = readOnlyattribute.GetType().GetField("isReadOnly", BindingFlags.NonPublic | BindingFlags.Instance);


                fieldToChange.SetValue(readOnlyattribute, !useMinorLocator);
            }

        }


        private float minorLocatorValue;
        [ReadOnly(true)]
        public float MinorLocatorValue { get => minorLocatorValue; set => minorLocatorValue = value; }
    }
}

using System;
using System.Globalization;

namespace ObjectPrinting
{
    public class PropertyPrintingConfig<TOwner, TPropType>: IPropertyPrintingConfig<TOwner>
    {
        private readonly PrintingConfig<TOwner> printingConfig;
        public PropertyPrintingConfig(PrintingConfig<TOwner> printingConfig)
        {
            this.printingConfig = printingConfig;
        }

        public PrintingConfig<TOwner> Using(Func<TPropType, string> printer)
        {
            return printingConfig;
        }

        PrintingConfig<TOwner> IPropertyPrintingConfig<TOwner>.PrintingConfig => printingConfig;
    }

    public interface IPropertyPrintingConfig<TOwner>
    {
        PrintingConfig<TOwner> PrintingConfig { get; }
    }

    public static class PropertyPrintingConfigExtension
    {
        public static PrintingConfig<TOwner> ChangeCulture<TOwner>(this PropertyPrintingConfig<TOwner, int> config, CultureInfo cultureChanger)
        {
            return ((IPropertyPrintingConfig<TOwner>)config).PrintingConfig;
        }
        public static PrintingConfig<TOwner> ChangeCulture<TOwner>(this PropertyPrintingConfig<TOwner, double> config, CultureInfo cultureChanger)
        {
            return ((IPropertyPrintingConfig<TOwner>)config).PrintingConfig;
        }
        public static PrintingConfig<TOwner> ChangeCulture<TOwner>(this PropertyPrintingConfig<TOwner, long> config, CultureInfo cultureChanger)
        {
            return ((IPropertyPrintingConfig<TOwner>)config).PrintingConfig;
        }
    }
}
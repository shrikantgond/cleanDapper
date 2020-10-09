using CleanApp.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanApp.Infrastructure.Services
{
    
    public class ConversionService : IConversionService
    {
        public T From<T>(string _convertorType, string str)
        {
            switch (_convertorType)
            {
                case "json":
                    Converter.IConverter jsonConvert = new Converter.JSONConverter();
                    return jsonConvert.From<T>(str);
                case "xml":
                    Converter.IConverter xmlConvert = new Converter.XMLConverter();
                    return xmlConvert.From<T>(str);
                default:
                    Converter.IConverter defaultConvert = new Converter.JSONConverter();
                    return defaultConvert.From<T>(str);
            }

        }
        public string To(string _convertorType, object obj)
        {
            switch (_convertorType)
            {
                case "json":
                    Converter.IConverter jsonConvert = new Converter.JSONConverter();
                    return jsonConvert.To(obj);
                case "xml":
                    Converter.IConverter xmlConvert = new Converter.XMLConverter();
                    return xmlConvert.To(obj);
                default:
                    Converter.IConverter defaultConvert = new Converter.JSONConverter();
                    return defaultConvert.To(obj);
            }
        }
    }
}

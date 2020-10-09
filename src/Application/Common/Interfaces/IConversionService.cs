using System;
using System.Collections.Generic;
using System.Text;

namespace CleanApp.Application.Common.Interfaces
{
    public interface IConversionService
    {
        T From<T>(string _convertorType, string str);
        string To(string _convertorType, object obj);
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace CleanApp.Application.Common.Interfaces
{
    public interface IConverter
    {
        T From<T>(string str);
        string To(object obj);
    }
}

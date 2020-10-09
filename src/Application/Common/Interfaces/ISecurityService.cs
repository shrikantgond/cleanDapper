using System;
using System.Collections.Generic;
using System.Text;

namespace CleanApp.Application.Common.Interfaces
{
    public interface ISecurityService
    {
        public string ComputeSha1Hash(string rawData);
    }
}

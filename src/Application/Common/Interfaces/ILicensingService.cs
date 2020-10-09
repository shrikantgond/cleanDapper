using MyCleanApp.Application.Common.Models;
using MyCleanApp.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyCleanApp.Application.Common.Interfaces
{
    public interface ILicensingService
    {
        Task<LicenseResult> GetLicense(string enproductID);
    }

}

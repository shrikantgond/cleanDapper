using CleanApp.Application.Common.Interfaces;
using System;

namespace CleanApp.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}

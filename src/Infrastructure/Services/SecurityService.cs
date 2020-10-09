using CleanApp.Application.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace CleanApp.Infrastructure.Services
{

    public class SecurityService : ISecurityService
    {
        public string ComputeSha1Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA1 shaHash = SHA1.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = shaHash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}

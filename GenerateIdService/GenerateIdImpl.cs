using GenerateIdContracts;
using System;
using System.Text;

namespace GenerateIdService
{
    public class GenerateIdImpl: IGenerateIdService
    {
        public string GenerateId(string input)
        {
            var md5 = System.Security.Cryptography.MD5.Create();
            var ticks = DateTime.Now.Ticks;
            var bytes = System.Text.Encoding.ASCII.GetBytes(input + ticks);
            var hashBytes = md5.ComputeHash(bytes);
            var output = System.Text.Encoding.UTF8.GetString(hashBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
            return sb.ToString();
        }
    }
    
}

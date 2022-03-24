using System.Security.Cryptography;
using System.Text;

namespace Recruitment.Common.Helpers
{
    public static class HashCalculator
    {
        public static string CalculateSha256Hash(string textData)
        {
            if(String.IsNullOrEmpty(textData))
            {
                return null;
            }

            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(textData));

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

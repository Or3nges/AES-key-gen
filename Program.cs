using System;
using System.Security.Cryptography;
using System.Text;

namespace Laven
{
    public class KeyIVGenerator
    {
        public static void Main()
        {
            // Generate a random key using the GenerateRandomKey method
            byte[] aesKey = GenerateRandomKey(32);
            string formattedKEY = DisplayByteArray(aesKey);
            Console.WriteLine(formattedKEY);

            // Generate a random IV using the GenerateRandomIV method
            byte[] aesIV = GenerateRandomIV(16);
            string formattedIV = DisplayByteArray(aesIV);
            Console.WriteLine(formattedIV);
            // Use the generated key and IV in your program
            // Now you can use aesKey and aesIV in your encryption/decryption logic
        }

        public static byte[] GenerateRandomKey(int keySize)
        {
            using (var aes = new AesCryptoServiceProvider())
            {
                aes.GenerateKey();
                return aes.Key;
            }
        }

        public static byte[] GenerateRandomIV(int ivSize)
        {
            using (var aes = new AesCryptoServiceProvider())
            {
                aes.GenerateIV();
                return aes.IV;
            }
        }

        public static string DisplayByteArray(byte[] byteArray)
        {
            StringBuilder formattedArray = new StringBuilder("        { ");
            for (int i = 0; i < byteArray.Length; i++)
            {
                formattedArray.Append($"0x{byteArray[i]:X2}");
                if (i < byteArray.Length - 1)
                    formattedArray.Append(", ");
                if ((i + 1) % 8 == 0)
                    formattedArray.AppendLine();
            }
            formattedArray.Append("        };");

            return formattedArray.ToString();
        }

    }
}

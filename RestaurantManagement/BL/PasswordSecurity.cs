using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.BL
{
    sealed class PasswordSecurity
    {
       private const int Key = 255;
        static public String encrypt(String stringToEncrypt)
        {
            List<char> encrypted = new List<char>();
            int j = 0;
            foreach (char i in stringToEncrypt)
            {

                encrypted.Add(Convert.ToChar(Convert.ToInt32(i) + Key));
                j++;
            }
            return new String(encrypted.ToArray());
        }

        static public String decrypt(String stringToDecrypt)
        {
            List<char> decrypted = new List<char>();
            int j = 0;
            foreach (char i in stringToDecrypt)
            {
                decrypted.Add(Convert.ToChar(Convert.ToInt32(i) - Key));
                j++;
            }
            return new String(decrypted.ToArray());
        }
    }
}

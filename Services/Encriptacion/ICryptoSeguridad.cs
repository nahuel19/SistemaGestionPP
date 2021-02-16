using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Encriptación
{
    interface ICryptoSeguridad
    {
        byte[] Encrypt(string plainText);
        string Decrypt(byte[] cipherText);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RC4
{
    class RC4Class
    {
        public static string RC4(string input, string key)
        {
            StringBuilder result = new StringBuilder();
            int k, y, j;
            int[] S = new int[256];
            int[] u = new int[256];

            for (int i = 0; i < 256; i++)
            {
                S[i] = i;
            }
            j = 0;
            for (int i = 0; i < 256; i++)
            {

                u[i] = (S[i] + key[i % key.Length]) % 256;
                k = S[u[i]];
                S[u[i]] = S[j];
                S[j] = k;
            }
            j = 0;
            for (int i = 0; i < 256; i++)
            {
               
                j = (j + S[i] + key[i % key.Length]) % 256;
                k = S[i];
                S[i] = S[j];
                S[j] = k;
           
            }

            for (int i = 0; i < input.Length; i++)
            {
                y = (i + 1) % 256;
                j = (S[y] + j) % 256;
                k = S[y];
                S[y] = S[j];
                S[j] = k;

                result.Append((char)(input[i] ^ S[(S[y] + S[j]) % 256]));
            }
            return result.ToString();
        }

    }

}
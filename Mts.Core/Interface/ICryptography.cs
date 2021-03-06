﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Mts.Core.Interface
{
    public interface ICryptography
    {
        string CalculateHash(string input);
        bool CheckMatch(string hash, string input);
        string EncryptString(string text, string keyString);
        string DecryptString(string cipherText, string keyString);
    }
}

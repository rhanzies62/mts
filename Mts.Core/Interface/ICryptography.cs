using System;
using System.Collections.Generic;
using System.Text;

namespace Mts.Core.Interface
{
    public interface ICryptography
    {
        string CalculateHash(string input);
        bool CheckMatch(string hash, string input);
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Mts.Core.Interface.Entity
{
    public interface IAuditDate
    {
        DateTime CreatedDate { get; set; }
        DateTime UpdatedDate { get; set; }
    }
}

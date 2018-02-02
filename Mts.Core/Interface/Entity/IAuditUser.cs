using System;
using System.Collections.Generic;
using System.Text;

namespace Mts.Core.Interface.Entity
{
    public interface IAuditUser
    {
        string CreatedBy { get; set; }
        string UpdatedBy { get; set; }
    }
}

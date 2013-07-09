using System;

namespace JamieWroeDotCom.Models
{
    public interface IAuditInfo
    {
        DateTime CreationDate { get; set; }
        DateTime LastModified { get; set; }
    }
}
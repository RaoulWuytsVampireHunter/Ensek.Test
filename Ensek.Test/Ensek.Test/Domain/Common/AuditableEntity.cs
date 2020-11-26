using System;
using System.Collections.Generic;
using System.Text;

namespace Ensek.Test.Domain.Common
{
    public abstract class AuditableEntity : BaseEntity
    {
        public bool IsDeleted { get; set; }
        //public string CreatedBy { get; set; }
        //public string LastModifiedBy { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastModified { get; set; }
    }
}

using Ensek.Test.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ensek.Test.Domain.Entities
{
    public class Account : AuditableEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

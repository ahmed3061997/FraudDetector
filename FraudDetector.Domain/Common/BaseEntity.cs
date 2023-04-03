using System;
using System.Collections.Generic;
using System.Text;

namespace FraudDetector.Domain.Common
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime Created { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public string? LastModifiedBy { get; set; }
    }
}

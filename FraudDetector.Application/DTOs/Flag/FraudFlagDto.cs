using FraudDetector.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FraudDetector.Application.DTOs.Flag
{
    public class FraudFlagDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public FlagTypes ValueType { get; set; }
        public decimal MaxValue { get; set; }
    }
}

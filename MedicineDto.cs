using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trpo_7
{
    public class MedicineDto
    {
        public string? Name { get; set; } = null!;

        public string? Manufacturer { get; set; } = null!;

        public decimal? Price { get; set; }

        public DateOnly? ExpirationDate { get; set; }

        public bool? IsAvailable { get; set; }
    }
}

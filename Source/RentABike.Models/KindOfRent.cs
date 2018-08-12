using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace RentABike.Models
{
    public class KindOfRent : BaseModel
    {
        [MaxLength(10)]
        public string Kind { get; set; }
    }
}

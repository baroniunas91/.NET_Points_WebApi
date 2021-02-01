using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points.RestApi.Dto
{
    public class PointDto
    {
        [Required]
        [Range(-5000, 5000)]
        //[Remote("CheckPointExist", "Point", AdditionalFields = nameof(Ycoordinate))]
        public int Xcoordinate { get; set; }
        [Required]
        [Range(-5000, 5000)]
        //[Remote("CheckPointExist", "Point", AdditionalFields = nameof(Xcoordinate))]
        public int Ycoordinate { get; set; }
    }
}

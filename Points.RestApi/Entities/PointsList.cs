using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points.RestApi.Entities
{
    public class PointsList
    {
        public int Id { get; set; }
        public int Xcoordinate { get; set; }
        public int Ycoordinate { get; set; }
        public PointsListTitle Title { get; set; }
    }
}

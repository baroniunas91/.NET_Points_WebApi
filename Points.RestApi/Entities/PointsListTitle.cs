using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points.RestApi.Entities
{
    public class PointsListTitle
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<PointsList> PointsLists { get; set; } = new List<PointsList>();
    }
}

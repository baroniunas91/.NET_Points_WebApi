using Points.RestApi.Dto;
using Points.RestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points.RestApi.Services
{
    public class PointService
    {
        //public bool CheckPointExist(int xcoordinate, int ycoordinate)
        //{
        //    return true;
        //}

        public bool ValidateLimit(List<Point> points)
        {
            bool valid = true;
            if (points.Count > 10000)
            {
                valid = false;
                return valid;
            }
            return valid;
        }

        public bool IsDublicate(List<Point> points, PointDto point)
        {
            bool isDublicate = false;
            foreach (var item in points)
            {
                if(item.Xcoordinate == point.Xcoordinate && item.Ycoordinate == point.Ycoordinate)
                {
                    isDublicate = true;
                    break;
                }
            }
            return isDublicate;
        }
    }
}

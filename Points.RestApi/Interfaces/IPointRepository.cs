using Points.RestApi.Dto;
using Points.RestApi.Entities;
using Points.RestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points.RestApi.Interfaces
{
    public interface IPointRepository
    {
        Task<List<Point>> GetAll();
        Task<Point> Add(PointDto point);
        Task Delete(int id);
        Task ClearAllPoints();
        Task SavePoints(string title);
        Task<List<PointsListTitle>> GetLists();
        Task DeleteList(int id);
    }
}

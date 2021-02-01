using Microsoft.EntityFrameworkCore;
using Points.RestApi.Data;
using Points.RestApi.Dto;
using Points.RestApi.Interfaces;
using Points.RestApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Points.RestApi.Repositories
{
    public class PointRepository : IPointRepository
    {
        private readonly DataContext _context;

        public PointRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Point>> GetAll()
        {
            return await _context.Points.OrderBy(x => x.Id).ToListAsync();
        }

        public async Task<Point> Add(PointDto point)
        {
            var pointAdd = new Point();
            pointAdd.Xcoordinate = point.Xcoordinate;
            pointAdd.Ycoordinate = point.Ycoordinate;
            _context.Points.Add(pointAdd);
            await _context.SaveChangesAsync();
            return pointAdd;
        }

        public async Task Delete(int id)
        {
            var point = _context.Points.Where(i => i.Id == id).SingleOrDefault();
            _context.Points.Remove(point);
            await _context.SaveChangesAsync();
        }
    }
}
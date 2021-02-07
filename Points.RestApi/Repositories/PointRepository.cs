using Microsoft.EntityFrameworkCore;
using Points.RestApi.Data;
using Points.RestApi.Dto;
using Points.RestApi.Entities;
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

        public async Task ClearAllPoints()
        {
            var list = await _context.Points.ToListAsync();
            _context.Points.RemoveRange(list);
            await _context.SaveChangesAsync();
        }

        public async Task SavePoints(string title)
        {
            var savedLists = await _context.Titles.Include(x => x.PointsLists).OrderBy(x => x.Id).ToListAsync();
            foreach (var item in savedLists)
            {
                if (item.Title == title)
                {
                    _context.Titles.Remove(item);
                }
            }
            var list = await _context.Points.ToListAsync();
            var listToSaveTitle = new PointsListTitle();
            listToSaveTitle.Title = title;
            listToSaveTitle.PointsLists = new List<PointsList>();

            foreach (var item in list)
            {
                var point = new PointsList();
                point.Xcoordinate = item.Xcoordinate;
                point.Ycoordinate = item.Ycoordinate;
                point.Title = listToSaveTitle;
                listToSaveTitle.PointsLists.Add(point);
            }
            _context.Titles.Add(listToSaveTitle);
            await _context.SaveChangesAsync();
        }

        public async Task<List<PointsListTitle>> GetLists()
        {
            var lists = await _context.Titles.Include(x => x.PointsLists).OrderBy(x => x.Id).ToListAsync();
            return lists;
        }
        public async Task DeleteList(int id)
        {
            //var savedList = _context.Titles.Include(x => x.PointsLists).First(i => i.Id == id);
            var listTitle = _context.Titles.First(i => i.Id == id);
            var points = _context.PointsList.Where(x => x.Title.Id == listTitle.Id).ToList();
            foreach (var item in points)
            {
               _context.PointsList.Remove(item);
            }
            _context.Titles.Remove(listTitle);
            await _context.SaveChangesAsync();
        }
    }
}
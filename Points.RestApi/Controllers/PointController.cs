using Microsoft.AspNetCore.Mvc;
using Points.RestApi.Dto;
using Points.RestApi.Interfaces;
using Points.RestApi.Models;
using Points.RestApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Points.RestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PointController
    {
        private readonly IPointRepository _pointRepository;
        private readonly PointService _pointService;

        public PointController(IPointRepository pointRepository, PointService pointService)
        {
            _pointService = pointService;
            _pointRepository = pointRepository;
        }

        [HttpGet]
        public async Task<List<Point>> Get()
        {
            return await _pointRepository.GetAll();
        }

        [HttpPost]
        public async Task<ActionResult<Point>> Create(PointDto point)
        {
            bool validLimit = _pointService.ValidateLimit(await _pointRepository.GetAll());
            bool isDublicate = _pointService.IsDublicate(await _pointRepository.GetAll(), point);
            if (validLimit && !isDublicate)
            {
                return await _pointRepository.Add(point);
            }
            return null;
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _pointRepository.Delete(id);
        }

        [HttpDelete]
        public async Task ClearAllPoints()
        {
            await _pointRepository.ClearAllPoints();
        }
    }
}

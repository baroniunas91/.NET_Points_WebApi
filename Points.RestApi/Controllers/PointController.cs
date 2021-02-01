using Microsoft.AspNetCore.Mvc;
using Points.RestApi.Dto;
using Points.RestApi.Interfaces;
using Points.RestApi.Models;
using Points.RestApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            return await _pointRepository.Add(point);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _pointRepository.Delete(id);
        }

        //[AcceptVerbs("GET", "POST")]
        //public ActionResult CheckPointExist(int xcoordinate, int ycoordinate)
        //{
        //    if (!_pointService.CheckPointExist(xcoordinate, ycoordinate))
        //    {
        //        return Content("false");
        //    }

        //    return Json(true);
        //}
    }
}

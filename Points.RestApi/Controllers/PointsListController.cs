using Microsoft.AspNetCore.Mvc;
using Points.RestApi.Dto;
using Points.RestApi.Entities;
using Points.RestApi.Interfaces;
using Points.RestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Points.RestApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PointsListController
    {
        private readonly IPointRepository _pointRepository;

        public PointsListController(IPointRepository pointRepository)
        {
            _pointRepository = pointRepository;
        }

        [HttpGet]
        public async Task<List<PointsListTitle>> Get()
        {
            return await _pointRepository.GetLists();
        }

        [HttpPost]
        public async Task SaveList(PointsListTitleDto title)
        {
            var listTitle = title.Title;
            await _pointRepository.SavePoints(listTitle);
        }

        [HttpDelete("{id}")]
        public async Task DeleteList(int id)
        {
            await _pointRepository.DeleteList(id);
        }
    }
}

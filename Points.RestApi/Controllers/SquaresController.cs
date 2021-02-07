using Microsoft.AspNetCore.Mvc;
using Points.RestApi.Entities;
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
    public class SquaresController
    {
        private readonly IPointRepository _pointRepository;
        private readonly SquareService _squareService;

        public SquaresController(IPointRepository pointRepository, SquareService squareService)
        {
            _pointRepository = pointRepository;
            _squareService = squareService;
        }

        [HttpGet]
        public async Task<List<Square>> GetSquares()
        {
            List<Point> points = await _pointRepository.GetAll();
            //Point[] pointsArray = new Point[points.Count];
            //for (int i = 0; i < points.Count; i++)
            //{
            //    pointsArray[i] = points[i];
            //}
            //return _squareService.SquareCount(pointsArray);
            List<Square> squares = new List<Square>();
            for (int i = 0; i < points.Count-3; i++)
            {
                for (int j = i+1; j < points.Count-2 ; j++)
                {
                    for (int k = i+2; k < points.Count-1; k++)
                    {
                        for (int r = i+3; r < points.Count; r++)
                        {
                            if(SquareService.IsSquare(points[i], points[j], points[k], points[r]))
                            {
                                var square = new Square();
                                square.Point1 = points[i];
                                square.Point2 = points[j];
                                square.Point3 = points[k];
                                square.Point4 = points[r];
                                squares.Add(square);
                            }
                        }
                    }
                }
            }
            return squares;
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using xiecheng.api.Dtos;
using xiecheng.api.Services;

namespace xiecheng.api.Controllers;

[Route("api/[controller]")] // api/touistRoutes/xxx
[ApiController]
public class TouristRoutesController : ControllerBase
{
    private ITouristRouteRepository _touristRouteRepository;
    private readonly IMapper _mapper;

    public TouristRoutesController(ITouristRouteRepository touristRouteRepository, IMapper mapper)
    {
        _touristRouteRepository = touristRouteRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// 获取全部旅游路线
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [HttpHead]  //不在返回数据，只返回状态码等头部信息，没有相应主体，常用于检测缓存（）检测资源是否有效，资源是否存在
    public IActionResult GetTouristRoutes()
    {
        var data = _touristRouteRepository.getTouristRoutes();

        var touristRouteDto = _mapper.Map<IEnumerable<TouristRouteDto>>(data);
        if (data == null || data.Count() < 0)
        {
            return NotFound("无旅游路线");
        }

        return Ok(data);
    }

    /// <summary>
    /// 查询旅游路线
    /// </summary>
    /// <param name="touristRouteId"></param>
    /// <returns></returns>
    [HttpGet("{touristRouteId:Guid}")]
    // api/touistroutes/{touristRouteId}
    public IActionResult GetTouristRouteById(Guid touristRouteId)
    {
        var data = _touristRouteRepository.getTouristRoute(touristRouteId);
        // var touristRouteDto = new TouristRouteDto
        // {
        //     Id = data.Id,
        //     Title = data.Title,
        //     Description = data.Description,
        //     Price = data.OriginalPrice * (decimal)data.DiscountPresent,
        //     CreateTime = data.CreateTime,
        //     UpdateTime = data.UpdateTime,
        //     DepartureTime = data.DepartureTime,
        //     Features = data.Features,
        //     Fees = data.Features,
        //     Notes = data.Notes,
        //     Rating = data.Rating,
        //     TravelDays = data.TravelDays.ToString(),
        //     TripType = data.TravelDays.ToString(),
        //     DepartureCity = data.DepartureCity.ToString(),
        // };
        //使用mapper映射
        var touristRouteDto = _mapper.Map<TouristRouteDto>(data);
        if (data == null)
        {
            return NotFound("无旅游路线");
        }
        return Ok(data);
    }

    
}
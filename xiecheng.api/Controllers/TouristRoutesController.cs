using System.Text.RegularExpressions;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using xiecheng.api.Dtos;
using xiecheng.api.Modles;
using xiecheng.api.ResourceParameters;
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
    [HttpHead]  //不在返回数据，只返回状态码等头部信息，没有相应主体，常用于检测缓存（检测资源是否有效，资源是否存在）
    // api/touristRoutes?keyword = 参数
    public IActionResult GetTouristRoutes(
        [FromQuery] TouristRouteResourceParameters param
        //[FromQuery] string keyword,
        //string rating   //lessThan3
        )   //默认[FromQuery]
    {
        // //正则 已放入TouristRouteResourceParameters处理
        // Regex regex = new Regex(@"([A-Za-z0-9\-]+)(\d+)");
        // string op = string.Empty;
        // int value = 0;
        // Match match = regex.Match(param.Rating);
        // if (match.Success)
        // {
        //     op = match.Groups[1].Value;
        //     value = Int32.Parse(match.Groups[2].Value);
        // }

        var data = _touristRouteRepository.getTouristRoutes(param.Keyword, param.RatingOperator, param.RatingValue);

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
    [HttpGet("{touristRouteId:Guid} ",Name = "GetTouristRouteById")]    //Name属性可用于reatful风格的api自我发现功能
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
        return Ok(data);    //返回200
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="???"></param>
    /// <returns></returns>
    [HttpPost]
    //api/touristRoutes
    public IActionResult CreateTouristRoute([FromBody] TouristRouteForCreationDto touristRouteForCreationDto)
    {
        var touristRouteModel = _mapper.Map<TouristRoute>(touristRouteForCreationDto);
        _touristRouteRepository.AddTouristRoute(touristRouteModel);
        _touristRouteRepository.Save(); //存入数据库
        var touristRouteToReturn = _mapper.Map<TouristRouteDto>(touristRouteModel);
        return CreatedAtRoute("GetTouristRouteById",
            new
            {
                touristRouteId = touristRouteModel.Id
            },
            touristRouteToReturn); //返回201,且实现一个level3的restful风格api 即Hadoas，定义header的Location，实现api自我发现的功能
    }
    
}
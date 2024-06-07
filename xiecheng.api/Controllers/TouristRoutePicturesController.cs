using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using xiecheng.api.Dtos;
using xiecheng.api.Services;

namespace xiecheng.api.Controllers;

[Route("api/touristRoutes/{touristRouteId}/pictures")] // api/touistRoutes/xxx/pictures/xxx
[ApiController]
public class TouristRoutePicturesController : ControllerBase
{
    private ITouristRouteRepository _touristRouteRepository;
    private readonly IMapper _mapper;

    public TouristRoutePicturesController(ITouristRouteRepository touristRouteRepository, IMapper mapper)
    {
        _touristRouteRepository = touristRouteRepository;
        _mapper = mapper;
    }
    
    /// <summary>
    /// 获取旅游路线图片
    /// </summary>
    /// <param name="touristRouteiId"></param>
    /// <returns></returns>
    [HttpGet]
    public IActionResult GetPicturesByTouristRouteId(Guid touristRouteId)
    {
        if (_touristRouteRepository.TouristRouteExists(touristRouteId)) return NotFound("旅游路线不存在");

        var data = _touristRouteRepository.GetPicturesBuTouristRouteId(touristRouteId);
        if (data == null || data.Count() <= 0)
        {
            return NotFound("图片不存在");
        }

        return Ok(_mapper.Map<IEnumerable<TouristRoutePictureDto>>(data));
    }

    /// <summary>
    /// 查询旅游图片
    /// 限制路由 二级查询
    /// </summary>
    /// <param name="touristRouteId"></param>
    /// <param name="pictureId"></param>
    /// <returns></returns>
    [HttpGet("{pictureId:int}")]
    public IActionResult GetPicture(Guid touristRouteId, int pictureId)
    {
        if (_touristRouteRepository.TouristRouteExists(touristRouteId)) return NotFound("旅游路线不存在");

        var data = _touristRouteRepository.GetPicture(pictureId);
        if (data == null)
        { 
            return NotFound("图片不存在");
        }

        return Ok(data);
    }
    
    
}
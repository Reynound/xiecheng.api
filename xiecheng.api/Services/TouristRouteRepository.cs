using xiecheng.api.DB;
using xiecheng.api.Modles;

namespace xiecheng.api.Services;

/// <summary>
/// 数据仓库
/// </summary>
public class TouristRouteRepository : ITouristRouteRepository
{
    private readonly AppDBContext _context;

    public TouristRouteRepository(AppDBContext context)
    {
        _context = context;
    }

    public IEnumerable<TouristRoute> getTouristRoutes()
    {
        return _context.TouristRoutes;
    }

    public TouristRoute getTouristRoute(Guid touristRouteId)
    {
        return _context.TouristRoutes.FirstOrDefault();
    }

    public bool TouristRouteExists(Guid tourostRouteId)
    {
        return _context.TouristRoutes.Any(t => t.Id == tourostRouteId);
    }

    public IEnumerable<TouristRoutePicture> GetPicturesBuTouristRouteId(Guid tourostRouteId)
    {
        return _context.TouristRoutePictures.Where(t => t.TouristRouteId == tourostRouteId).ToList();
    }

    public TouristRoutePicture GetPicture(int pictureId)
    {
        return _context.TouristRoutePictures.FirstOrDefault(t => t.Id == pictureId);
    }
}
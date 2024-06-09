using Microsoft.EntityFrameworkCore;
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

    public IEnumerable<TouristRoute> getTouristRoutes(string keyword,string op,int value)
    {
        IQueryable<TouristRoute> result = _context
            .TouristRoutes;
            //.Include(t => t.TouristRoutePictures);
        if (!string.IsNullOrWhiteSpace(keyword))
        {
            keyword = keyword.Trim();
            result = result.Where(t => t.Title.Contains(keyword));
        }

        if (value >= 0)
        {
            switch (op)
            {
                case "largerThan":
                    result = result.Where(t => t.Rating >= value);  break;
                case "lessThan":
                    result = result.Where(t => t.Rating <= value);  break;
                case "equalTo":
                    result = result.Where(t => t.Rating == value);  break;
            }
        }

        //上述代码其实就是WhereIf 到最后聚合操作
        return result.ToList();
    }

    public TouristRoute getTouristRoute(Guid touristRouteId)
    {
        //return _context.TouristRoutes.FirstOrDefault();
        
        //由于有外键关系，include可以连表
        return _context.TouristRoutes.Include(t => t.TouristRoutePictures).FirstOrDefault();
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
using xiecheng.api.Modles;

namespace xiecheng.api.Services;

/// <summary>
/// 数据仓库接口
/// </summary>
public interface ITouristRouteRepository
{
    IEnumerable<TouristRoute> getTouristRoutes();

    TouristRoute getTouristRoute(Guid touristRouteId);

    bool TouristRouteExists(Guid tourostRouteId);

    IEnumerable<TouristRoutePicture> GetPicturesBuTouristRouteId(Guid tourostRouteId);

    TouristRoutePicture GetPicture(int pictureId);
}
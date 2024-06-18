using xiecheng.api.Modles;

namespace xiecheng.api.Services;

/// <summary>
/// 数据仓库接口
/// </summary>
public interface ITouristRouteRepository
{
    IEnumerable<TouristRoute> getTouristRoutes(string keyword,string op,int? value);
    TouristRoute getTouristRoute(Guid touristRouteId);
    bool TouristRouteExists(Guid tourostRouteId);
    IEnumerable<TouristRoutePicture> GetPicturesBuTouristRouteId(Guid tourostRouteId);
    TouristRoutePicture GetPicture(int pictureId);
    void AddTouristRoute(TouristRoute touristRoute);
    bool Save();
}
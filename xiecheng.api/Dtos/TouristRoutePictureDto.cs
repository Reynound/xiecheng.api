namespace xiecheng.api.Dtos;

/// <summary>
/// 旅游路线图片实体
/// </summary>
public class TouristRoutePictureDto
{
    public int Id { get; set; }

    public string Url { get; set; }
    
    public Guid TouristRouteId { get; set; }
}
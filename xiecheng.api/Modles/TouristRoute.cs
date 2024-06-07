using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using xiecheng.api.Enum;

namespace xiecheng.api.Modles;

/// <summary>
/// 旅游路线
/// </summary>
public class TouristRoute
{
    [Key] 
    public Guid Id { get; set; }

    [Required] [MaxLength(1500)] 
    public string Title { get; set; }

    [Required] 
    public string Description { get; set; }

    [Column(TypeName = "decimal(18,2)")] //保留两位小数
    public decimal OriginalPrice { get; set; }

    [Range(0.0, 1.0)] //范围
    public double? DiscountPresent { get; set; }

    public DateTime CreateTime { get; set; }

    public DateTime UpdateTime { get; set; }

    public DateTime DepartureTime { get; set; }

    [MaxLength] //最大长度 也可能写入html
    public string Features { get; set; }

    [MaxLength] 
    public string Fees { get; set; }

    [MaxLength] 
    public string Notes { get; set; }

    /// <summary>
    /// 外键联系
    /// </summary>
    public ICollection<TouristRoutePicture> TouristRoutePictures { get; set; }
        = new List<TouristRoutePicture>();

    public double? Rating { get; set; }

    public TravelDays TravelDays { get; set; }

    public TripType TripType { get; set; }

    public DepartureCity DepartureCity { get; set; }
}
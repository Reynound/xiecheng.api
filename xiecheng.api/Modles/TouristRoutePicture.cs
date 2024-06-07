using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace xiecheng.api.Modles;

public class TouristRoutePicture
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //自增主键
    public int Id { get; set; }

    [MaxLength(100)] 
    public string Url { get; set; }

    [ForeignKey("TouristRouteId")] //TouristRoute表的id主键作为外键时用 类名+id 的形式关联
    public Guid TouristRouteId { get; set; }

    /// <summary>
    /// 建立外键联系
    /// </summary>
    public TouristRoute TouristRoute { get; set; }
}
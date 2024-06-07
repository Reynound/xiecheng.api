using Microsoft.EntityFrameworkCore;
using xiecheng.api.Modles;
using System.Reflection;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;

namespace xiecheng.api.DB;

/// <summary>
/// 上下文
/// </summary>
public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions<AppDBContext> options)
        : base(options)
    {
        
    }

    //模型映射数据库表
    public DbSet<TouristRoute> TouristRoutes { get; set; }
    public DbSet<TouristRoutePicture> TouristRoutePictures { get; set; }

    //在创建数据模型和数据库表映射关系时，做补充说明用
    //例如用[key]声明主键也可在此函数声明
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //做种子数据
        // modelBuilder.Entity<TouristRoute>().HasData(new TouristRoute()
        // {
        //     Id = Guid.NewGuid(),
        //     Title = "ceshi",
        //     Description = "shuoming",
        //     Features = "liangdian",
        //     Fees = "123",
        //     OriginalPrice = 0,
        //     CreateTime = DateTime.Now,
        //     Notes = "jilu",
        //     DiscountPresent = 0.1
        // });
        var touristRouteJsonData = File.ReadAllText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) +
                                           @"/Db/touristRoutesMockData.json");
        IList<TouristRoute> touristRoutes = JsonConvert.DeserializeObject<IList<TouristRoute>>(touristRouteJsonData);
        modelBuilder.Entity<TouristRoute>().HasData(touristRoutes);
        var touristRoutePictureJsonData = File.ReadAllText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) +
                                                    @"/Db/touristRoutePicturesMockData.json");
        IList<TouristRoutePicture> touristRoutePictures = JsonConvert.DeserializeObject<IList<TouristRoutePicture>>(touristRoutePictureJsonData);
        modelBuilder.Entity<TouristRoutePicture>().HasData(touristRoutePictures);
        base.OnModelCreating(modelBuilder);
    }
}
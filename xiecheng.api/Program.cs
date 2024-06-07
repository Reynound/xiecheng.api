using IGeekFan.AspNetCore.Knife4jUI;
using Microsoft.AspNetCore.Mvc.Formatters;
using xiecheng.api.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using xiecheng.api.Services;
using AutoMapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//添加控制器并配置xml数据格式
builder.Services.AddControllers(setUpAction =>
{
    // http请求中的Accept格式验证
    setUpAction.ReturnHttpNotAcceptable = true;
    // setUpAction.OutputFormatters.Add(
    //     new XmlSerializerOutputFormatter()
    //     );  //古早时期 配置http请求中的Accept 
}).AddXmlSerializerFormatters();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Swagger", Version = "v1" });
    c.IncludeXmlComments(System.IO.Path.Combine(AppContext.BaseDirectory, "xiecheng.api.xml"), true);
});

//注入touristRoute服务
builder.Services.AddTransient<ITouristRouteRepository, TouristRouteRepository>();

//将数据库上下文注入
builder.Services.AddDbContext<AppDBContext>(options =>
{
    //三种读取配置方式
    var connectionString = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", true, true)
        .Build()
        .GetConnectionString("ConnectionString");
    connectionString = builder.Configuration.GetConnectionString("ConnectionString");
    connectionString = builder.Configuration.GetSection("ConnectionStrings")["ConnectionString"];
    //connectionString = "server=localhost; Database=xiechengDb; User Id=SA; Password=sa123456.;Encrypt=True;TrustServerCertificate=True;";

    //调用sqlserver配置，加载数据库
    options.UseSqlServer(connectionString);
});

//注入automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());    //扫描profile（映射配置有profile文件管理

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //Swagger使用自定义UI
    // app.UseKnife4UI(c =>
    // {
    //     c.RoutePrefix = string.Empty;
    //     c.SwaggerEndpoint($"/swagger/v1/swagger.json", "swagger v1");
    // });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
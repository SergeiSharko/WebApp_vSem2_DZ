using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using WebApp_vSem2.Abstraction;
using WebApp_vSem2.Data;
using WebApp_vSem2.Mapper;
using WebApp_vSem2.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MapperProfile));
builder.Services.AddMemoryCache(mc => mc.TrackStatistics = true);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(container =>
{
    container.RegisterType<ProductRepository>().As<IProductRepository>();
    container.RegisterType<ProductGroupRepository>().As<IProductGroupRepository>();
    container.Register(_ => new WebAppContext(builder.Configuration.GetConnectionString("db")!)).InstancePerDependency();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var staticFilePath = Path.Combine(Directory.GetCurrentDirectory(), "StaticFiles");
Directory.CreateDirectory(staticFilePath);
app.UseStaticFiles(new StaticFileOptions { FileProvider = new PhysicalFileProvider(staticFilePath), RequestPath = "/static" });

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

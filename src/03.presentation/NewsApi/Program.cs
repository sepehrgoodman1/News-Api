using ComplexProject.Persistence.Ef;
using Microsoft.EntityFrameworkCore;
using NewApi.Persistence.Ef;
using NewApi.Persistence.Ef.New;
using NewApi.Services.New;
using NewApi.Services.New.Contracts;
using NewsApi.Persistence.Ef.Cities;
using NewsApi.Persistence.Ef.Comments;
using NewsApi.Persistence.Ef.Groups;
using NewsApi.Persistence.Ef.NewsTags;
using NewsApi.Persistence.Ef.Tags;
using NewsApi.Services.Cities;
using NewsApi.Services.Cities.Contracts;
using NewsApi.Services.Comments;
using NewsApi.Services.Comments.Contracts;
using NewsApi.Services.Groups;
using NewsApi.Services.Groups.Contracts;
using NewsApi.Services.News.Contracts;
using NewsApi.Services.NewsTags.Contracts;
using NewsApi.Services.Tags;
using NewsApi.Services.Tags.Contracts;
using Taav.Contracts.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<EfDataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<CityRepository, EfCityRepository>();
builder.Services.AddScoped<CityService, CityAppService>();

builder.Services.AddScoped<GroupRepository, EfGroupRepository>();
builder.Services.AddScoped<GroupService, GroupAppService>();

builder.Services.AddScoped<TagRepository, EfTagRepository>();
builder.Services.AddScoped<TagService, TagAppService>();

builder.Services.AddScoped<NewsRepository, EfNewsRepository>();
builder.Services.AddScoped<NewsService, NewsAppService>();

builder.Services.AddScoped<CommentService, CommentAppService>();
builder.Services.AddScoped<CommentRepository, EfCommentRepository>();

builder.Services.AddScoped<NewsTagRepository, EfNewsTagRepository>();

builder.Services.AddScoped<UnitOfWork, EFUnitOfWork>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

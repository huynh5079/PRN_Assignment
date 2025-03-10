using BusinessLayer.Services;
using BusinessLayer.Services.Interfaces;
using DataLayer.Data;
using DataLayer.Entities;
using DataLayer.Repositories.Implementations;
using DataLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add Database
builder.Services.AddDbContext<DatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add Identity

// Add authentication
builder.Services.AddAuthentication()
    .AddCookie(options => {
        options.LoginPath = "/Account/Login";
        options.AccessDeniedPath = "/Account/AccessDenied";
    });

//Add Repository
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<INewsArticleRepository, NewsArticleRepository>();
builder.Services.AddScoped<ISystemAccountRepository, SystemAccountRepository>();
builder.Services.AddScoped<ITagRepository, TagRepository>();

//Add Service
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<INewsArticleService, NewsArticleService>();
builder.Services.AddScoped<ISystemAccountService, SystemAccountService>();
builder.Services.AddScoped<ITagService, TagService>();


// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

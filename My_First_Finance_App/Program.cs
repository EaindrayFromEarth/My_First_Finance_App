using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using My_First_Finance_App.Models;
using My_First_Finance_App.Repositories;
using My_First_Finance_App.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    //app.UseDatabaseErrorPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});
app.MapControllerRoute(
    name: "category",
    pattern: "Category/{action=Index}/{id?}",
    defaults: new { controller = "Category" });

app.MapControllerRoute(
    name: "user",
    pattern: "User/{action=Login}/{id?}",
    defaults: new { controller = "User" });

app.MapControllerRoute(
    name: "user_profile",
    pattern: "User/ProfileDetails/{userId}",
    defaults: new { controller = "User", action = "ProfileDetails" });


app.Run();

//using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc.ApplicationModels;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Options;
//using Microsoft.IdentityModel.Tokens;
//using newWebApi;
//using newWebApi.Data;
//using newWebApi.Migrations;
//using newWebApi.Repositories;
//using System.Text;

//var builder = WebApplication.CreateBuilder(args);



//// Add services to the container.



//builder.Services.AddDbContext<BookStoreContext>(options 
//    => options.UseSqlServer(builder.Configuration.GetConnectionString("BookStoreDb")));



//builder.Services.AddIdentity<ApplicationModel, IdentityRole>()
//    .AddEntityFrameworkStores<BookStoreContext>()
//    .AddDefaultTokenProviders();


//builder.Services.AddControllers().AddNewtonsoftJson();
//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

//})
//    .AddJwtBearer(option =>
//    {
//        option.SaveToken = true;
//        option.RequireHttpsMetadata = false;
//        option.TokenValidationParameters = new TokenValidationParameters()
//        {
//            ValidateAudience = true,
//            ValidateIssuer = true,
//            ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
//            ValidAudience = builder.Configuration["JWT:ValidAudience"],
//            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:secret"]))
//        };
//    });
//builder.Services.AddTransient<IBookRepository, BookRepository>();
//builder.Services.AddTransient<IAccountRepository, AccountRepository>();
//builder.Services.AddAutoMapper(typeof(Startup));

//builder.Services.AddCors(option =>
//{
//    option.AddDefaultPolicy(builder =>
//    {
//        builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
//    });
//});



//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var app = builder.Build();


//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseDeveloperExceptionPage();

//    app.UseSwagger();
//    app.UseSwaggerUI();
//}


//app.UseHttpsRedirection();

//app.UseAuthentication();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();
////using newWebApi;

using newWebApi;

public class Program
{
    public static void Main(string[] args)
        => CreateHostBuilder(args).Build().Run();

    // EF Core uses this method at design time to access the DbContext
    public static IHostBuilder CreateHostBuilder(string[] args)
        => Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(
                webBuilder => webBuilder.UseStartup<Startup>());

}
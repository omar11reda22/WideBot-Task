
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WideBot.Mycontext;
using WideBot.Repositories;
using WideBot.Services;

namespace WideBot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connection = builder.Configuration.GetConnectionString("Getconnection");
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddHttpContextAccessor(); 
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<Applicationcontext>(option => option.UseSqlServer(connection));
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<Applicationcontext>();
            builder.Services.AddAuthentication(option => {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;


            }).AddJwtBearer(option => {
                option.SaveToken = true;
                option.RequireHttpsMetadata = true;
                option.TokenValidationParameters = new TokenValidationParameters()
                {


                };

            });

            // registration services 
            builder.Services.AddTransient<IproductRepository, ProductRepository>();
            builder.Services.AddTransient<IcategoryRepository, CategoryRepository>();
            builder.Services.AddTransient<ICartRepository, CartRepository>();


            builder.Services.AddTransient<IProductService, ProductService>();
            builder.Services.AddTransient<IcategoryService, CategoryService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddTransient<IcartService, CartService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

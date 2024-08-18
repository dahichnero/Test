using Microsoft.EntityFrameworkCore;
using ServicesBot.Models;

namespace ServicesBot

{
    public class ServicesBot
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers().AddNewtonsoftJson();

            string connectionString = builder.Configuration.GetConnectionString("sqlite") ??
                throw new ApplicationException("Нет строки подключения");
            builder.Services.AddDbContext<ServicesSubsContext>(opt=>opt.UseSqlite(connectionString));

            var app = builder.Build();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
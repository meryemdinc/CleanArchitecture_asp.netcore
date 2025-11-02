using App.Repositories.Extensions;
using App.Services.Extensions;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using App.Services;

namespace App.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            // Validatorlarını ekle
            //  builder.Services.AddValidatorsFromAssemblyContaining<Program>();
            builder.Services.AddControllers(
                options =>{
                    options.Filters.Add<FluentValidationFilter>();
                    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true; //null kontrolünü .net default olarak yapmasın diye


                });
            //.net in default olarak üretmiş olduğu hata mesajlarını kapatıyoruz.Kendi filter'ımızı kendimiz eklicez.
            builder.Services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddRepositories(builder.Configuration).AddServices(builder.Configuration);

            var app = builder.Build();

     /*       app.MapPost("/register", (UserDto user, IValidator<UserDto> validator) =>
            {
                var result = validator.Validate(user);
                if (!result.IsValid)
                    return Results.BadRequest(result.Errors);

                return Results.Ok("Valid!");
            });*/
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

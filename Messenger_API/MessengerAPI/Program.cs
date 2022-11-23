using MessengerAPI.Filter;
using MessengerInfrastructure.IService;
using MessengerInfrastructure.Services;
using Messenger.DBContext;
using MessengerService;
using Messenger.Domain;
using MessengerService.IService;
using MessengerService.ModelAutoMapperProfile;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MessengerAPI.Models;
using MessengerService.DTO;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers(options => options.Filters.Add<AuthorizationFilter>());
//builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<SmtpConfig>(opt => builder.Configuration.GetSection("SmtpConfig").Bind(opt));
builder.Services.AddSingleton<TokenGenarator>();
builder.Services.AddSingleton<UserTokenGenarator>();
builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddScoped<ISSOService, SSOService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IMailService, MailService>();
builder.Services.AddDbContext<MessageDbContext>(options => options.UseNpgsql("name=ConnectionStrings:DefaultConnection"));
//builder.Services.AddDbContext<MessageDbContext>(options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder => builder
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod()
    );
});


builder.Services.AddAutoMapper(typeof(ModelAutoMapperProfile), typeof(DTOAutoMapperProfile));
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
}
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("AllowAll");


app.UseAuthorization();

app.MapControllers();

app.Run();

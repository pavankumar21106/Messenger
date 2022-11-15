using MessengerAPI.Filter;
using MessengerInfrastructure.IService;
using MessengerInfrastructure.MailService;
using MessengerInfrastructure.MessageContext;
using MessengerService;
using MessengerService.DTOAutoMapperProfile;
using MessengerService.IService;
using MessengerService.ModelAutoMapperProfile;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.Filters.Add<AuthorizationFilter>());
//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
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

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("AllowAll");

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

using TechChallangeFase01.Api.Extensions;
using TechChallangeFase01.Api.Middlewares;
using TechChallangeFase01.Infra.IoC.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddRouting(opt => opt.LowercaseUrls = true);
builder.Services.AddSwaggerDoc();
builder.Services.AddJwtBearer(builder.Configuration);
builder.Services.AddCorsPolicy();
builder.Services.AddDependencyInjection();
builder.Services.AddAutoMapperConfig();
builder.Services.AddDbContextConfig(builder.Configuration);
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

app.UseSwaggerDoc(app.Environment);
app.UseMiddleware<ExceptionMiddleware>();
//app.UseAuthentication();
//app.UseAuthorization();
app.UseCorsPolicy();
app.MapControllers();
app.Run();

public partial class Program { }
// Program.cs (ASP.NET Core 6 이상)
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS 정책 추가
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy
            .WithOrigins("http://localhost:5173") // 프론트엔드 주소 (포트에 맞게 수정)
            .AllowAnyHeader()
            .AllowAnyMethod()
    );
});

var app = builder.Build();

app.UseCors("AllowFrontend"); // 반드시 UseRouting, UseAuthorization 전에!

app.UseAuthorization();
app.MapControllers();

app.Run();
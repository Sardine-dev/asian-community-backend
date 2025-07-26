// Program.cs (ASP.NET Core 6 �̻�)
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS ��å �߰�
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy
            .WithOrigins("http://localhost:5173") // ����Ʈ���� �ּ� (��Ʈ�� �°� ����)
            .AllowAnyHeader()
            .AllowAnyMethod()
    );
});

var app = builder.Build();

app.UseCors("AllowFrontend"); // �ݵ�� UseRouting, UseAuthorization ����!

app.UseAuthorization();
app.MapControllers();

app.Run();
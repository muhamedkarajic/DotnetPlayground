var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSerilog();
builder.Services.AddCorsAngular();
builder.Host.UseSerilog();
builder.Services.AddSignalR();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwaggerIfDevelopment();
app.UseSerilogRequestLogging();
app.UseCorsAngular();
app.UseMinimalAPIs();
app.UseSignalRHub();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
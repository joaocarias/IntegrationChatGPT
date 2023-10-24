using jcf.lab.integrationchatgpt.Core.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddSerilog(builder.Configuration, "Sample ChatGPT");
builder.AddChatGpt(builder.Configuration);

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers();

builder.Services.AddSwagger(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseSwaggerDoc();

app.UseAuthorization();

app.MapControllers();

app.Run();


using BackendChatAspcore;
using BackendChatAspcore.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddSignalR();

builder.Services.AddSingleton<IDictionary<string,UserConnection>>(opts=>new Dictionary<string,UserConnection>());


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapHub<ChatHub>("/chat");
//});
//app.UseCors(options =>
//{
//    options
//    .AllowAnyOrigin()
//    .AllowAnyMethod()
//    .AllowAnyHeader();
//});

app.UseCors(options =>
{
    options
        .WithOrigins("http://localhost:3000")  // Replace with your actual frontend origin
        .AllowAnyMethod()
        .AllowAnyHeader() 
        .AllowCredentials();
});


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHub<ChatHub>("/chat");


app.Run();

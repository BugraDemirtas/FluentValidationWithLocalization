using FluentValidation;
using Microsoft.Extensions.Options;
using System.Globalization;
using FluentValidationWithLocalization.Model;
using FluentValidationWithLocalization.Validator;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IValidator<User>, UserValidator>();





#region Localization Configure


builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");


builder.Services.AddControllersWithViews().AddViewLocalization();


builder.Services.Configure<RequestLocalizationOptions>(options =>
{

	options.DefaultRequestCulture = new("tr-TR");
	
	CultureInfo[] cultures = new CultureInfo[]
	{
		new("tr-TR"),
		new("en-US"),

	};

	
	
	options.SupportedCultures = cultures;
	options.SupportedUICultures = cultures;
	options.ApplyCurrentCultureToResponseHeaders = true;
	


});


#endregion

var app = builder.Build();


app.UseRequestLocalization();

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



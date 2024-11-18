using Client.Matter.Persistence.Contracts;
using Client.Matter.Persistence.Implementations;
using Client.Matter.Services.Implementations;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
var apiVersioningBuilder = builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
                                    new HeaderApiVersionReader("x-api-version"),
                                    new MediaTypeApiVersionReader("x-api-version"));
});
apiVersioningBuilder.AddApiExplorer(options =>
{
    // add the versioned api explorer, which also adds IApiVersionDescriptionProvider service
    // note: the specified format code will format the version as "'v'major[.minor][-status]"
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});

builder.Services.AddDbContext<ClientMatterDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ClientMatterDb"));
});

builder.Services.AddHttpClient();//This enables HttpClient and IConfiguration to be accessed from the constructors

builder.Services.AddScoped<IClientRepository, ClientRepository>();
builder.Services.AddScoped<IMatterRepository, MatterRepository>();
builder.Services.AddScoped<IClientMatterDataSource, ClientMatterDataSource>();

builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IClientMatterSearchService, ClientMatterSearchService>();
builder.Services.AddScoped<IMatterService, MatterService>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSwaggerGen(c =>
{
    c.OperationFilter<AddParameterDescriptions>();
});

var app = builder.Build();

app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});

app.MapControllers();

app.Run();


public class AddParameterDescriptions : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        foreach (var tag in operation.Tags)
        {
            if (tag.Name == "ClientMatterSearch")
            {
                tag.Name = "Client and Matter Search - you can apply filters for your search here.";
            }
            if (tag.Name == "CollectData")
            {
                tag.Name = "Collect Data - This is the mechanism to save some client and matter data to our SQL Server database.";
            }
        }
        foreach (var parameter in operation.Parameters)
        {
            if (parameter.Name == "searchTerm")
            {
                parameter.Description = "Search term - client name.";
            }
            else if (parameter.Name == "columnOrder")
            {
                parameter.Description = "This is which column you wish to perform as sort against NAME or DATE. The default value if not supplied is NAME. NAME = 0, DATE = 1.";
            }
            else if (parameter.Name == "sort")
            {
                parameter.Description = "This is how you wish to sort the column described in {column order} ASCENDING or DESCENDING. ASCENDING = 1, DESCENDING = 2.";
            }
            else if (parameter.Name == "index")
            {
                parameter.Description = "This is the point in the result set you wish to take you offset records from. This must be 0 or greater. (Used for building pagination).";
            }
            else if (parameter.Name == "offset")
            {
                parameter.Description = "The count of records you wish to return from the index. This must be a value of between 1 and 50. (Used for building pagination).";
            }
            else if (parameter.Name == "clientId")
            {
                parameter.Description = "This is used to return matters for the given client id as returned from the initial Client Search endpoint.";
            }
            else if (parameter.Name == "matterId")
            {
                parameter.Description = "This is used to return the matter for the given matter id.";
            }
        }
    }
}
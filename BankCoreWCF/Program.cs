using CoreWCF;
using CoreWCF.Configuration;
using BankCoreWCF.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServiceModelServices();
builder.Services.AddServiceModelMetadata();

var app = builder.Build();

app.UseServiceModel(serviceBuilder =>
{
    serviceBuilder.AddService<BankService>();
    serviceBuilder.AddServiceEndpoint<BankService, IBankService>(
        new CoreWCF.BasicHttpBinding(),
        "/BankService.svc"
    );
});

app.UseHttpsRedirection();
app.UseRouting();

app.Run();
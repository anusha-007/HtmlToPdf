using HtmlToPdf;
using HtmlToPdf.Contracts;
using Razor.Templating.Core;

var builder = WebApplication.CreateBuilder(args);

IronPdf.License.LicenseKey = builder.Configuration["IronPdf:LicenseKey"];

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRazorTemplating();
builder.Services.AddSingleton<InvoiceFactory>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("invoice-report", async (InvoiceFactory invoiceFactory) =>
{
    Invoice invoice = invoiceFactory.CreateInvoice();
    
    var html = await RazorTemplateEngine.RenderAsync("Views/InvoiceReport.cshtml", invoice);

    var renderer = new ChromePdfRenderer();
    var pdf = renderer.RenderHtmlAsPdf(html);
    
   // File.WriteAllBytes(outputPdfPath, pdf);
    
    return Results.File(pdf.BinaryData, "application/pdf", $"invoice-{invoice.Number}.pdf");
});

app.UseHttpsRedirection();

app.Run();

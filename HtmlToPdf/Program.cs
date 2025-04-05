using HtmlToPdf;
using HtmlToPdf.Contracts;
using Razor.Templating.Core;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

app.MapGet("invoice-report", async (InvoiceFactory invoiceFactory) =>
{
    Invoice invoice = invoiceFactory.CreateInvoice();
    
    var html = await RazorTemplateEngine.RenderAsync("Views/InvoiceReport.cshtml", invoice);
    var htmlToPdf = new NReco.PdfGenerator.HtmlToPdfConverter();
    var pdf = htmlToPdf.GeneratePdf(html);
    
    return Results.File(pdf, "application/pdf", $"invoice-{invoice.Number}.pdf");

});

app.UseHttpsRedirection();

app.Run();

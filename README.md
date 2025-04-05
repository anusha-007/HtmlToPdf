# html to pdf generator

This project allows you to generate fake invoices in PDF format based on dynamically
generated data using HTML templates and CSS styling. The application leverages Razor Pages 
to render the fake invoice data into HTML content, which is then converted into a downloadable PDF file.

![Invoice Screenshot](images/invoice-screenshot.png)

## Features

- **Generate invoices as PDF**: The application generates random invoice data and converts it into a PDF document.
- **Tailwind CSS styling**: The invoice template uses Tailwind CSS for modern, responsive styling.
- **Customizable Invoice Layout**: You can customize the invoice appearance by editing the HTML templates and CSS styles.
- **Responsive Design**: The layout is mobile-friendly and adjusts well to different screen sizes.

## Technologies Used

- **ASP.NET Core**: The web framework used to build the API and Razor Pages.
- **Tailwind CSS**: A utility-first CSS framework for creating custom designs quickly.
- **HTML to PDF conversion**: The library `IronPdf` is used to convert HTML templates to PDF files.
- **Razor Pages**: To dynamically generate the content of the invoice based on model data.

## Getting Started

### Prerequisites

- .NET 5 or later installed on your machine.
- Visual Studio or any other IDE for .NET development.
- A PDF conversion library such as `IronPDF` (for local testing).

### Installing

1. Clone the repository:
   ```bash
   git clone git@github.com:anusha-007/HtmlToPdf.git
   cd HtmlToPdf

using Azure;
using Azure.AI.FormRecognizer;
using Azure.AI.FormRecognizer.Models;
using BBSA.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BBSA.API.Controllers
{
    [Route("api/competition-forms")]
    [ApiController]
    public class CompetitionFormsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public CompetitionFormsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("process")]
        public async Task<CompetitionFormProcessResult> Process(IFormFile file)
        {
            Uri uri = new Uri(_configuration.GetValue<string>("Azure:FormRecognizer:API:Endpoint"));
            AzureKeyCredential azureKeyCredential = new AzureKeyCredential(_configuration.GetValue<string>("Azure:FormRecognizer:API:Key"));
            FormRecognizerClient formRecognizerClient = new FormRecognizerClient(uri, azureKeyCredential);

            RecognizeContentOperation recognizeContentOperation = await formRecognizerClient.StartRecognizeContentAsync(file.OpenReadStream());

            FormPageCollection formPages = (await recognizeContentOperation.WaitForCompletionAsync()).Value;

            FormPage formPage = formPages.FirstOrDefault();
            if (formPage == null) throw new BadHttpRequestException("Competition form page not found.");

            FormTable formTable = formPage.Tables.FirstOrDefault(x => x.RowCount == 10 && x.ColumnCount == 11);
            if (formTable == null) throw new BadHttpRequestException("Competition form score table not recognized.");

            List<FormTableCell> formTableCells = formTable.Cells.Where(x =>
                x.RowIndex >= 1 &&
                (x.ColumnIndex >= 1 && x.ColumnIndex <= 4 || x.ColumnIndex >= 6 && x.ColumnIndex <= 9)
            ).ToList();

            return new CompetitionFormProcessResult()
            {
            };
        }
    }
}
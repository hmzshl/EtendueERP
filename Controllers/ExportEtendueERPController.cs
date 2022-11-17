using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using EtendueERP.Data;

namespace EtendueERP.Controllers
{
    public partial class ExportEtendueERPController : ExportController
    {
        private readonly EtendueERPContext context;
        private readonly EtendueERPService service;

        public ExportEtendueERPController(EtendueERPContext context, EtendueERPService service)
        {
            this.service = service;
            this.context = context;
        }

        [HttpGet("/export/EtendueERP/ttauxes/csv")]
        [HttpGet("/export/EtendueERP/ttauxes/csv(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTTauxesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(await service.GetTTauxes(), Request.Query), fileName);
        }

        [HttpGet("/export/EtendueERP/ttauxes/excel")]
        [HttpGet("/export/EtendueERP/ttauxes/excel(fileName='{fileName}')")]
        public async Task<FileStreamResult> ExportTTauxesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(await service.GetTTauxes(), Request.Query), fileName);
        }
    }
}

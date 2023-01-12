using LanchesMac.Areas.Admin.Servicos;
using Microsoft.AspNetCore.Mvc;
using FastReport.Web;
using FastReport.Data;
using LanchesMac.Areas.Admin.FastReportUtils;
using FastReport.Export.PdfSimple;

namespace LanchesMac.Areas.Admin.Controllers;

[Area("Admin")]
public class AdminLanchesReportController : Controller
{
    private readonly IWebHostEnvironment _webHostEnv;
    private readonly RelatorioLanchesService _relatorioLanchesService;

    public AdminLanchesReportController(IWebHostEnvironment webHostEnv,
        RelatorioLanchesService relatorioLanchesService)
    {
        _webHostEnv = webHostEnv;
        _relatorioLanchesService = relatorioLanchesService;
    }

    public async Task<ActionResult> LanchesCategoriaReport()
    {
        var webReport = new WebReport();
        var mssqlDataConnection = new MsSqlDataConnection();

        webReport.Report.Dictionary.AddChild(mssqlDataConnection);

        //Carregar o relatório
        //ContentPath obtém o caminho da pasta raiz que contém todos os arquivos da aplicação
        webReport.Report.Load(Path.Combine(_webHostEnv.ContentRootPath, "wwwroot/reports",
                                            "lanchesCategoria.frx"));


        var lanches = HelperFastReport.GetTable(await _relatorioLanchesService.GetLanchesReport(), "LanchesReport");
        var categorias = HelperFastReport.GetTable(await _relatorioLanchesService.GetCategoriasReport(), "CategoriasReport");

        //Registrar
        webReport.Report.RegisterData(lanches, "LanchesReport");
        webReport.Report.RegisterData(categorias, "CategoriasReport");

        return View(webReport);
    }

    [Route("LanchesCategoriasPDF")]
    public async Task<ActionResult> LanchesCategoriaPDF()
    {
        var webReport = new WebReport();
        var mssqlDataConnection = new MsSqlDataConnection();

        webReport.Report.Dictionary.AddChild(mssqlDataConnection);

        webReport.Report.Load(Path.Combine(_webHostEnv.ContentRootPath, "wwwroot/reports",
                                            "lanchesCategoria.frx"));


        var lanches = HelperFastReport.GetTable(await _relatorioLanchesService.GetLanchesReport(), "LanchesReport");
        var categorias = HelperFastReport.GetTable(await _relatorioLanchesService.GetCategoriasReport(), "CategoriasReport");

        webReport.Report.RegisterData(lanches, "LanchesReport");
        webReport.Report.RegisterData(categorias, "CategoriasReport");

        webReport.Report.Prepare();

        Stream stream = new MemoryStream();

        webReport.Report.Export(new PDFSimpleExport(), stream);
        stream.Position = 0;

        //fazer donwload PDF
        //return File(stream, "application/zip", "LancheCategoria.pdf");

        //abrir o PDF no navegador
        return new FileStreamResult(stream,"application/pdf");

    }
}

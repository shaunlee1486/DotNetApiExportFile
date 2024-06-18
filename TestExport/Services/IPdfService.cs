namespace TestExport.Services
{
    public interface IPdfService
    {
        byte[] GeneratePdfFromHtmlFile(string htmlFilePath, object model);
        byte[] GeneratePdfFromTableHtmlFile(string htmlFilePath, object model);
    }
}

namespace Thesis.Services
{
    public interface IExcelGenService
    {
        public void GenSheet();
        public MemoryStream DownloadSheet();
    }
}

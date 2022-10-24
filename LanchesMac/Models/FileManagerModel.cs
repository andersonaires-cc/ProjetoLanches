namespace LanchesMac.Models
{
    public class FileManagerModel
    {
        public FileInfo[] Files { get; set; }
        public IFormFile IformeFile { get; set; }
        public List<IFormFile> IformeFiles { get; set; }
        public string PathImagesProduto { get; set; }
    }
}

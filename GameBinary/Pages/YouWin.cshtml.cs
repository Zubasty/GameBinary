using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameBinary.Pages
{
    public class YouWinModel : PageModel
    {
        public string Message { get; private set; } = "";
        public List<string> Tryes { get; private set; }
        public void OnGet(string message, List<string> tryes)
        {
            Message = message;
            Tryes = tryes;
        }
    }
}

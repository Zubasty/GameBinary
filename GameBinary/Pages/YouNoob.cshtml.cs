using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameBinary.Pages
{
    public class YouNoobModel : PageModel
    {
        public string Message { get; private set; } = "";
        public int MyValue { get; private set; }
        public List<string> Tryes { get; private set; }
        public void OnGet(string message, int myValue, List<string> tryes)
        {
            Message = message;
            MyValue = myValue;
            Tryes = tryes;
        }
    }
}

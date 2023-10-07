using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace RazorPagesApp.Pages
{
	public class IndexModel : PageModel
	{
		public int MyValue { get; private set; }
		public List<string> Tryes { get; private set; } = new List<string>();
		public string Message { get; private set; } = "Угадайте какое число я загадал в диапазоне от 1 до 1000!";
		public int Value { get; private set; } = 0;
		public string CountTryes { get; private set; } = "";

		public void OnGet()
		{
			Random random = new Random();
			MyValue = random.Next(1, 1000);
            CountTryes = $"У вас осталось попыток: {10 - Tryes.Count}";
        }

		public IActionResult OnPost(int value, int myValue, List<string> tryes)
		{
            Tryes = tryes;
            MyValue = myValue;
            Value = value;	
			string s = $" Ваше предположение: {Value}. ";
			if(Value == MyValue)
			{
				s += "Ура вы угадали!";
                Tryes.Add(s);
                return RedirectToPage("YouWin", new { Message, Tryes });
            }
			else if (Value > MyValue)
			{
				s += "Не угадали. Дам подсказу, мое значение меньше!";
			}
			else
			{
				s += "Не угадали. Дам подсказу, мое значение больше!";
			}
			Tryes.Add(s);
            if (Tryes.Count == 10)
            {
                return RedirectToPage("YouNoob", new { Message, MyValue, Tryes });
            }
            CountTryes = $"У вас осталось попыток: {10 - Tryes.Count}";
            return null;
        }
	}
}
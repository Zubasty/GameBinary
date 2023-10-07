using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace RazorPagesApp.Pages
{
	public class IndexModel : PageModel
	{
		public int MyValue { get; private set; }
		public List<string> Tryes { get; private set; } = new List<string>();
		public string Message { get; private set; } = "�������� ����� ����� � ������� � ��������� �� 1 �� 1000!";
		public int Value { get; private set; } = 0;
		public string CountTryes { get; private set; } = "";

		public void OnGet()
		{
			Random random = new Random();
			MyValue = random.Next(1, 1000);
            CountTryes = $"� ��� �������� �������: {10 - Tryes.Count}";
        }

		public IActionResult OnPost(int value, int myValue, List<string> tryes)
		{
            Tryes = tryes;
            MyValue = myValue;
            Value = value;	
			string s = $" ���� �������������: {Value}. ";
			if(Value == MyValue)
			{
				s += "��� �� �������!";
                Tryes.Add(s);
                return RedirectToPage("YouWin", new { Message, Tryes });
            }
			else if (Value > MyValue)
			{
				s += "�� �������. ��� ��������, ��� �������� ������!";
			}
			else
			{
				s += "�� �������. ��� ��������, ��� �������� ������!";
			}
			Tryes.Add(s);
            if (Tryes.Count == 10)
            {
                return RedirectToPage("YouNoob", new { Message, MyValue, Tryes });
            }
            CountTryes = $"� ��� �������� �������: {10 - Tryes.Count}";
            return null;
        }
	}
}
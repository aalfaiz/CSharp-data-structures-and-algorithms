using System.Globalization;

string[] months = new string[12];

for(int month = 1; month <= months.Length; month++)
{
    DateTime firstDay = new DateTime(DateTime.Now.Year, month, 1);
    string name = firstDay.ToString("MMMM", CultureInfo.CreateSpecificCulture("en-US"));
    months[month - 1] = name;
}

foreach(string month in months)
{
    Console.WriteLine($"-> {month}");
}
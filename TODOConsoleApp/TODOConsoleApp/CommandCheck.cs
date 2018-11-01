using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;

public static class CommandCheck
{
    
    private static int[] days_31 = new int[] {1, 3, 5, 7, 8, 10, 12};
    private static int[] days_30 = new int[] {4, 6, 9, 11};

    public static string elements(string element)
    {
        
        string[] everyElement = element.Split(';');
        List<string> elements1 = everyElement.ToList();
        string[] startDate = everyElement[1].Split('.');
        if (startDate[0].Length == 4 && startDate[1].Length == 2 && startDate[2].Length == 2 && DateCheck(
                int.Parse(startDate[0]), int.Parse(startDate[1]),
                int.Parse(startDate[2])) == true)
        {
            if (everyElement.Length == 2)
            {
                elements1.Add("");
                elements1.Add("true");
                elements1.Add("");
                StringBuilder sb = new StringBuilder();
                sb.Append(elements1[0] + ";");
                sb.Append(elements1[1] + ";");
                sb.Append(elements1[2] + ";");
                sb.Append(elements1[3] + ";");
                sb.Append(elements1[4] + ";");
                return sb.ToString();

            }

            if (everyElement.Length == 3)
            {
                if (everyElement[2] == "tak")
                {
                    elements1[2] = "";
                    elements1.Add("true");
                    elements1.Add("true");
                    
                    StringBuilder sb = new StringBuilder();
                    sb.Append(elements1[0] + ";");
                    sb.Append(elements1[1] + ";");
                    sb.Append(elements1[2] + ";");
                    sb.Append(elements1[3] + ";");
                    sb.Append(elements1[4] + ";");
                    return sb.ToString();
                }
                else
                {
                    string[] endDate = everyElement[2].Split('.');
                    if (endDate[0].Length == 4 && endDate[1].Length == 2 && endDate[2].Length == 2 &&
                        DateCheck(int.Parse(endDate[0]), int.Parse(endDate[1]), int.Parse(endDate[2])) ==
                        true)
                    {
                        elements1.Add("");
                        elements1.Add("");
                        StringBuilder sb = new StringBuilder();
                        sb.Append(elements1[0] + ";");
                        sb.Append(elements1[1] + ";");
                        sb.Append(elements1[2] + ";");
                        sb.Append(elements1[3] + ";");
                        sb.Append(elements1[4] + ";");
                        return sb.ToString();
                    }
                }

                return ("Błędny format daty zakończenia");

            }

            if (everyElement.Length == 4)
            {
                string[] endDate = everyElement[2].Split('.');
                if (endDate[0].Length == 4 && endDate[1].Length == 2 && endDate[2].Length == 2 &&
                    DateCheck(int.Parse(endDate[0]), int.Parse(endDate[1]), int.Parse(endDate[2])) ==
                    true)
                {
                    elements1[3] = "";
                    elements1.Add("true");
                    StringBuilder sb = new StringBuilder();
                    sb.Append(elements1[0] + ";");
                    sb.Append(elements1[1] + ";");
                    sb.Append(elements1[2] + ";");
                    sb.Append(elements1[3] + ";");
                    sb.Append(elements1[4] + ";");
                    return sb.ToString();
                }
                return ("Błędny format daty zakończenia");

            }

        }
        return ("Błędny format daty rozpoczęcia");
    }

    public static bool DateCheck(int year, int month, int day)
    {
        if (month >= 1 && month != 2 && month <= 12 && day >= 1 && day <= 31)
        {
            foreach (var months in days_31)
            {
                if (month == months)
                    return true;
            }

            foreach (var months in days_30)
            {
                if (month == months)
                    return true;
            }

        }

        if (month == 2 && year % 4 == 0 && day <= 1 && day <= 29)
        {
            return true;
        }

        if (month == 2 && year % 4 != 0 && day >= 1 && day <= 28)
        {
            return true;
        }

        return false;
    }
}
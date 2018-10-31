using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class CommandCheck
{
    
    private static int[] days_31 = new int[] {1, 3, 5, 7, 8, 10, 12};
    private static int[] days_30 = new int[] {4, 6, 9, 11};

    public static string elements(string element)
    {
        string[] everyElement = element.Split(';');

        if (everyElement.Length == 2)
        {
            List<string> elements = everyElement.ToList();

            string[] date = everyElement[1].Split('.');
            
            if (DateCheck(int.Parse(date[0]), int.Parse(date[1]), int.Parse(date[2].Trim(';',' '))) == true)
            {
                    elements[3] = "true";
                    elements.Add("");
                    StringBuilder sb = new StringBuilder();
                    sb.Append(elements[0] + ";");
                    sb.Append(elements[1] + ";");
                    sb.Append(elements[2] + ";");
                    sb.Append(elements[3] + ";");
                    sb.Append(elements[4] + ";");
                    return sb.ToString();
                

            }
            return("Błędny format daty rozpoczęcia");
        }

        if (everyElement.Length == 3)
        {
            List<string> elements = everyElement.ToList();
            string[] date = everyElement[2].Split('.');
            if (DateCheck(int.Parse(date[0]), int.Parse(date[1]), int.Parse(date[2].Trim(';', ' '))) == true)
            {
                string[] dateEnd = everyElement[2].Split('.');
                if (DateCheck(int.Parse(dateEnd[0]), int.Parse(dateEnd[1]), int.Parse(dateEnd[2].Trim(';', ' '))) ==
                    true)
                { 
                    elements[3] = "";
                    elements.Add("");
                StringBuilder sb = new StringBuilder();
                sb.Append(elements[0] + ";");
                sb.Append(elements[1] + ";");
                sb.Append(elements[2] + ";");
                sb.Append(elements[3] + ";");
                sb.Append(elements[4] + ";");
                return sb.ToString();
                }
                return ("Błędny format daty zakończenia");
            }
            return("Błędny format daty zakończenia");
        }

        if (everyElement.Length == 4)
        {

            List<string> elements = everyElement.ToList();
            string[] date = everyElement[2].Split('.');
            if (DateCheck(int.Parse(date[0]), int.Parse(date[1]), int.Parse(date[2].Trim(';', ' '))) == true)
            {
                string[] dateEnd = everyElement[2].Split('.');
                if (DateCheck(int.Parse(dateEnd[0]), int.Parse(dateEnd[1]), int.Parse(dateEnd[2].Trim(';', ' '))) ==
                    true)
                {
                    elements[3] = "";
                    elements.Add("true");
                    StringBuilder sb = new StringBuilder();
                    sb.Append(elements[0] + ";");
                    sb.Append(elements[1] + ";");
                    sb.Append(elements[2] + ";");
                    sb.Append(elements[3] + ";");
                    sb.Append(elements[4] + ";");
                    return sb.ToString();
                }
                return ("Błędny format daty zakończenia");
            }
            return ("Błędny format daty rozpoczęcia");

        }
        return ("Błędne dane");
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
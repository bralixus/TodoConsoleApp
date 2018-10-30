namespace TODOConsoleApp
{
    public static class Date
    {
        private static int[] days_31 = new int[] { 1, 3, 5, 7, 8, 10, 12 };
        private static int[] days_30 = new int[] { 4, 6, 9, 11 };



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
}
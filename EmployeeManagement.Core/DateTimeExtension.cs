using System;

namespace EmployeeManagement.Core
{
    public static class DateTimeExtension
    {
        public static int CalculateAge(this DateTime birthDate)
        {
            return DateTime.Now.Subtract(birthDate).Days / 365;
        }
    }
}

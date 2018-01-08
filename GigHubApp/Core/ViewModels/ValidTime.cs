using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace GigHubApp.Core.ViewModels
{
    public class ValidTime : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime;
            // 1 Jan 2018
            var isValid = DateTime.TryParseExact(Convert.ToString(value), "HH:mm", CultureInfo.CurrentCulture, DateTimeStyles.None, out dateTime);

            return (isValid);
        }
    }
}
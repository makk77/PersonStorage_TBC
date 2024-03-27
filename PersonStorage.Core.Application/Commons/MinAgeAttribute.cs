using System.ComponentModel.DataAnnotations;

namespace PersonStorage.Core.Application.Commons
{
    public class MinAgeAttribute : ValidationAttribute
    {
        private int minAge;
        public MinAgeAttribute(int minAge) => this.minAge = minAge;

        public override bool IsValid(object? value)
        {
            DateTime date = Convert.ToDateTime(value);
            return date.Date.AddYears(minAge) <= DateTime.Now.Date;
        }
    }
}

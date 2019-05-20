using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Quorum.DataApi.Validators
{
	internal sealed class StringRangeAttribute : ValidationAttribute
	{
		private const string ValidationErrorMessage = "Invalid value '{0}'. Allowed values are: {1}";

		private readonly string              _allowedValuesString;
		private readonly IEnumerable<string> _allowedValues;

		public StringRangeAttribute(params string[] allowedValues)
		{
			_allowedValues       = allowedValues;
			_allowedValuesString = String.Join(", ", _allowedValues);
		}

		protected override ValidationResult IsValid(object value, ValidationContext context)
		{
			if (value is string stringValue && _allowedValues.Contains(stringValue))
			{
				return ValidationResult.Success;
			}

			var errorValue = value as string ?? "null";
			return new ValidationResult(String.Format(ValidationErrorMessage, errorValue, _allowedValuesString));
		}
	}
}
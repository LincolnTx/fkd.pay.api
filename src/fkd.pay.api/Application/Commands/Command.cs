﻿using FluentValidation.Results;

namespace fkd.pay.api.Application.Commands
{
    public abstract class Command
    {
        protected ValidationResult ValidationResult { get; set; }

        public ValidationResult GetValidationResult()
        {
            return ValidationResult;
        }

        public abstract bool IsValid();
    }
}
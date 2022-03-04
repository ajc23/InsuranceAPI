using System;
using Autofac;
using FluentValidation;

namespace Insurance.Api.Validators
{
    public class AutofacValidatorFactory : ValidatorFactoryBase
    {
        private readonly IComponentContext context;

        public AutofacValidatorFactory(IComponentContext context)
        {
            this.context = context;
        }

        public new  IValidator<T> GetValidator<T>()
        {
            return context.Resolve<IValidator<T>>();
        }

        public override IValidator CreateInstance(Type validatorType)
        {
            object instance;
            if (context.TryResolve(validatorType, out instance))
            {
                var validator = instance as IValidator;
                return validator;
            }
            throw new ApplicationException($"Unable to find validator for type {validatorType.GetType().Name}");
        }
    }
}
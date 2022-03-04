using System.Reflection;
using Autofac;
using Autofac.Integration.WebApi;
using FluentValidation;
using Insurance.Api.RequestHandlers;
using Insurance.Api.Validators;
using Insurance.Models.Claim;
using Insurance.Models.Policy;
using Insurance.Service;

namespace Insurance.Api
{
    public class IocConfig
    {
        public static ContainerBuilder ContainerBuilder { get; private set; }
        public static IContainer Container { get; set; }

        public static void RegisterModules()
        {
            ValidatorOptions.CascadeMode = CascadeMode.StopOnFirstFailure;

            ContainerBuilder = new ContainerBuilder();

            ContainerBuilder.RegisterType<CreateClaimRequestValidator>().As<IValidator<CreateClaimRequest>>();
            ContainerBuilder.RegisterType<SearchClaimRequestValidator>().As<IValidator<SearchClaimRequest>>();
            ContainerBuilder.RegisterType<SearchPolicyRequestValidator>().As<IValidator<SearchPolicyRequest>>();
            ContainerBuilder.RegisterType<AutofacValidatorFactory>().As<IValidatorFactory>().SingleInstance();

            ContainerBuilder.RegisterType<ClaimRequestHandler>().As<IClaimRequestHandler>();
            ContainerBuilder.RegisterType<PolicyRequestHandler>().As<IPolicyRequestHandler>();
            
            ContainerBuilder.RegisterType<ClaimService>().As<IClaimService>();
            ContainerBuilder.RegisterType<PolicyService>().As<IPolicyService>();
            
            ContainerBuilder.RegisterApiControllers(Assembly.GetExecutingAssembly());
        }

        public static void Build()
        {
            Container = ContainerBuilder.Build();
        }
    }
}
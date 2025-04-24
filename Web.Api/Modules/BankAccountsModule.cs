using Modules.BankAccount.DataAccess;
using Modules.BankAccounts.Api;
using Modules.BankAccounts.Core;
using Modules.Shared.DependencyInjection;

namespace Web.Api.Modules;

public class BankAccountsModule : Module
{
    protected override IModuleDependencyRegistration[] DependencyRegistrations =>
    [
        new BankAccountsDataAccessDependencyRegistration(),
        new BankAccountsCoreDependencyRegistration()
    ];

    protected override IEndpointMapper[] EndpointMappers =>
    [
        new BankAccountsEndpointsMapper()
    ];
}
using AuthFlow.Application.Authentication.Commands.Register;
using AuthFlow.Application.Authentication.Queries.Login;
using AuthFlow.Application.Authentication.Commands.Refresh;
using AuthFlow.Application.Authentication.Commands.Logout;
using AuthFlow.Application.Authentication.Common;
using AuthFlow.Application.Contracts.Authentication;
using Mapster;

namespace AuthFlow.Api.Common.Mapper;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();
        config.NewConfig<LoginRequest, LoginQuery>();
        config.NewConfig<RefreshRequest, RefreshCommand>();
        config.NewConfig<LogoutRequest, LogoutCommand>();
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest.UserId, src => (Guid) src.User.Id)
            .Map(dest => dest, src => src.User);
    }
}

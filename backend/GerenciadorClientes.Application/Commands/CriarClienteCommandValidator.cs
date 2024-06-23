using FluentValidation;
using GerenciadorClientes.Domain.Enums;

namespace GerenciadorClientes.Application.Commands
{
    public class CriarClienteCommandValidator : AbstractValidator<CriarClienteCommand>
    {
        public CriarClienteCommandValidator()
        {
            RuleFor(x => x.Porte)
                .Must(porte => Enum.IsDefined(typeof(PorteEmpresa), porte))
                .WithMessage("O valor fornecido para Porte está fora do intervalo permitido.");
        }
    }
}

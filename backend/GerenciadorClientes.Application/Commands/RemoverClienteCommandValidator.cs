using FluentValidation;

namespace GerenciadorClientes.Application.Commands
{

    public class RemoverClienteCommandValidator : AbstractValidator<RemoverClienteCommand>
    {
        public RemoverClienteCommandValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("O Id deve ser maior que zero.");
        }
    }

}

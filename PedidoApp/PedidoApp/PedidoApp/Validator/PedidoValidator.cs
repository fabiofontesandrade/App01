using FluentValidation;
using PedidoApp.Models;

namespace PedidoApp.Validator
{
    public class PedidoValidator : AbstractValidator<Pedido>
    {
        public PedidoValidator()
        {
            RuleFor(c => c.Titulo).Must(n => ValidateStringEmpty(n)).WithMessage("O nome não pode ser vazio.");
            RuleFor(c => c.Link).Must(n => ValidateStringEmpty(n)).WithMessage("O link não pode ser vazio.");
            RuleFor(c => c.Preco).NotEmpty().WithMessage("Informe o preço.").Must(PrecoMaiorqueZero).WithMessage("O valor deve ser maior que zero.");
            RuleFor(c => c.Descricao).Must(n => ValidateStringEmpty(n)).WithMessage("A descrição não pode estar em branco.");
        }

        private static bool PrecoMaiorqueZero(decimal preco)
        {
            return preco > 0;
        }

        bool ValidateStringEmpty( string stringValue)
        {
            if (!string.IsNullOrEmpty(stringValue))
                return true;
            return false;
        }
    }
}

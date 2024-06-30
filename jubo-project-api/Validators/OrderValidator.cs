using FluentValidation;
using jubo_project_api.Models;

namespace jubo_project_api.Validators;

public class OrderValidator : AbstractValidator<UpdateOrderRequest>
{
    public OrderValidator()
    {
        RuleFor(order => order.Message)
            .NotEmpty()
            .NotNull()
            .MaximumLength(50);
    }
}

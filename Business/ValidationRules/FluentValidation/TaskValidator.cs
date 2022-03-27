using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class TaskValidator:AbstractValidator<Task>
    {
        public TaskValidator()
        {
            RuleFor(t => t.TaskContent).NotEmpty();
        }
    }
}
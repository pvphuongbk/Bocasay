using Bocasay.Core.Events;
using FluentValidation.Results;

namespace Bocasay.Core.Commands
{
    public abstract class Command : Message
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ValidationResult ValidationResult { get; set; }
    }
}

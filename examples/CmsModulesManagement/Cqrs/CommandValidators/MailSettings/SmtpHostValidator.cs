using CmsModulesShared.Models.MailHosts;
using FluentValidation;
using MailWeb.Cqrs.Commands.MailSettings;
using MailWeb.Models;

namespace MailWeb.Cqrs.CommandValidators.MailSettings
{
    public class SmtpHostValidator : AbstractValidator<EditSiteMailSettingCommand>
    {
        public SmtpHostValidator(
            EditSmtpMailHostCommandValidator smtpHostValidator,
            MailGunHostValidator mailGunHostValidator)
        {
            RuleFor(command => command.DisplayName.Value)
                .NotEmpty()
                .When(command => command.DisplayName != null && command.DisplayName.HasModified);

            RuleFor(command => command.Timeout.Value)
                .GreaterThan(0)
                .When(command => command.Timeout != null && command.Timeout.HasModified);

            RuleFor(command => (SmtpHost) command.MailHost)
                .SetValidator(smtpHostValidator)
                .When(command => command.MailHost is SmtpHost);

            RuleFor(command => (MailGunHost) command.MailHost)
                .SetValidator(mailGunHostValidator)
                .When(command => command.MailHost is MailGunHost);
        }
    }
}
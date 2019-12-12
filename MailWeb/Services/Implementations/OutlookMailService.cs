﻿using MailManager.Models.Interfaces;
using MailManager.Services.Implementations;

namespace MailWeb.Services.Implementations
{
    public class OutlookMailService : BaseSmtpMailClient
    {
        #region Constructor

        public OutlookMailService(ISmtpMailServiceSetting smtpMailSetting) : base(smtpMailSetting)
        {
        }

        #endregion

        #region Properties

        public override string UniqueName => "Outlook";

        public override string DisplayName => "Outlook mail service";

        #endregion

        #region Methods

        #endregion
    }
}
// ****************************************************************************
// <copyright file="EmailComposeService.cs" company="Pedro Lamas">
// Copyright � Pedro Lamas 2011
// </copyright>
// ****************************************************************************
// <author>Pedro Lamas</author>
// <email>pedrolamas@gmail.com</email>
// <date>17-11-2011</date>
// <project>Cimbalino.Phone.Toolkit</project>
// <web>http://www.pedrolamas.com</web>
// <license>
// See license.txt in this solution or http://www.pedrolamas.com/license_MIT.txt
// </license>
// ****************************************************************************

using Microsoft.Phone.Tasks;

namespace Cimbalino.Phone.Toolkit.Services
{
    /// <summary>
    /// Represents an implementation of the <see cref="IEmailComposeService"/>.
    /// </summary>
    public class EmailComposeService : IEmailComposeService
    {
        /// <summary>
        /// Shows the e-mail compose screen with the specified subject and message body.
        /// </summary>
        /// <param name="subject">The e-mail subject.</param>
        /// <param name="body">The e-mail message body.</param>
        public void Show(string subject, string body)
        {
            Show(string.Empty, string.Empty, string.Empty, subject, body);
        }

        /// <summary>
        /// Shows the e-mail compose screen with the specified recipients, subject and message body.
        /// </summary>
        /// <param name="to">The e-mail recipients.</param>
        /// <param name="subject">The e-mail subject.</param>
        /// <param name="body">The e-mail message body.</param>
        public void Show(string to, string subject, string body)
        {
            Show(to, string.Empty, string.Empty, subject, body);
        }

        /// <summary>
        /// Shows the e-mail compose screen with the specified recipients, CC recipients, BCC recipients, subject and message body.
        /// </summary>
        /// <param name="to">The e-mail recipients.</param>
        /// <param name="cc">The e-mail CC recipients.</param>
        /// <param name="bcc">The e-mail BCC recipients.</param>
        /// <param name="subject">The e-mail subject.</param>
        /// <param name="body">The e-mail message body.</param>
        public void Show(string to, string cc, string bcc, string subject, string body)
        {
            new EmailComposeTask()
            {
                To = to,
                Cc = cc,
                Bcc = bcc,
                Subject = subject,
                Body = body
            }.Show();
        }
    }
}
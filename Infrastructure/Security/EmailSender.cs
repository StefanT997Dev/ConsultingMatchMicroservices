using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using FluentEmail.Core;
using FluentEmail.Smtp;

namespace Infrastructure.Security
{
	public class EmailSender : IEmailSender
	{
		public async Task SendEmail()
		{
			var sender = new SmtpSender(() => new SmtpClient("localhost") 
			{
				EnableSsl = false,
				DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory,
				PickupDirectoryLocation = @"C:\Users\Stefan"
			});

			Email.DefaultSender = sender;

			var result = await Email
				.From("stefantosicfitness@gmail.com")
				.To("stefantosic.dev@gmail.com", "Stefan")
				.Subject("Thanks!")
				.Body("Thanks for buying our product.")
				.SendAsync();
		}
	}
}

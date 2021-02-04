using MediatR;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Core.Comunication.Handler;
using NerdStore.Core.Comunication.Mediator;
using NerdStore.Core.Contracts.Mediator;
using NerdStore.Core.Messages.CommonMessages.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace NerdStore.Core.DomainObjects
{
	public class BaseController : Microsoft.AspNetCore.Mvc.Controller
	{
		private readonly DomainNotificationHandler _notifications;
		private readonly IMediatorHandler _mediatorHandler;

		protected Guid clientId = new Guid();

		public BaseController(INotificationHandler<DomainNotification> notifications, IMediatorHandler mediatorHandler)
		{
			_notifications = (DomainNotificationHandler)notifications;
			_mediatorHandler = mediatorHandler;
		}

		protected bool ValidOperation()
		{
			return (!_notifications.HasNotifications());
		}

		protected IEnumerable<string> GetErrorMessage()
		{
			return _notifications.GetNotifications().Select(c => c.Value).ToList();
		}

		protected void NotifyError(string code, string message)
		{
			_mediatorHandler.PublishNotification(new DomainNotification(code, message));
		}

		protected new IActionResult Response<T>(T result)
		{
			if (ValidOperation())
				return Ok(new { Success = true, Data = result });
			else return BadRequest(new
			{
				Success = false,
				ErrorMessages = new List<Error>()
				{
					new Error(HttpStatusCode.BadRequest.ToString(), String.Join(" ", GetErrorMessage()))
				}
			});
		}

		protected IActionResult Error(Exception ex)
		{
			var error = new
			{
				Success = false,
				ErrorMessages = new List<Error>()
				{
					new Error(ex.HResult.ToString(), ex.Message)
				}
			};

			return StatusCode((int)HttpStatusCode.InternalServerError, error);
		}

		protected IActionResult Error(string errorMessage, string errorCode, HttpStatusCode httpStatusCode)
		{
			var error = new
			{
				ErrorMessages = new List<Error>()
				{
					new Error(errorCode, errorMessage)
				}
			};

			return StatusCode((int)httpStatusCode, error);
		}
	}
}

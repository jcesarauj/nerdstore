using FluentValidation.Results;
using NerdStore.Core.Contracts;
using NerdStore.Core.DomainObjects;
using NerdStore.Core.Messages;
using NerdStore.Sales.Domain.Enums;
using System;
using System.Collections.Generic;

namespace NerdStore.Sales.Domain.Models.Order
{
	public class Order : Entity, IAggregateRoot
	{
		private readonly List<OrderItem> _orderItems;
		private List<Event> _notifications;
		public IReadOnlyCollection<Event> Notifications => _notifications?.AsReadOnly();

		protected Order()
		{
			_orderItems = new List<OrderItem>();
		}

		public Order(int code, Guid clientId, Guid voucherId, bool usedVoucher, decimal discount, decimal totalValue, DateTime createDate, OrderStatusEnum orderStatus)
		{
			Code = code;
			ClientId = clientId;
			VoucherId = voucherId;
			UsedVoucher = usedVoucher;
			Discount = discount;
			TotalValue = totalValue;
			CreateDate = createDate;
			OrderStatus = orderStatus;
		}

		public Order(Guid clientId)
		{
			ClientId = clientId;
		}

		public int Code { get; private set; }
		public Guid ClientId { get; private set; }
		public Guid VoucherId { get; private set; }
		public bool UsedVoucher { get; private set; }
		public decimal Discount { get; private set; }
		public decimal TotalValue { get; private set; }
		public OrderStatusEnum OrderStatus { get; private set; }
		public virtual Voucher Voucher { get; private set; }
		public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;

		public void AddItem(OrderItem orderItem)
		{
			_orderItems.Add(orderItem);
		}

		public bool VerifyIfItemExist(OrderItem orderItem)
		{
			return _orderItems.Contains(orderItem);
		}

		public void UpdateOrderITem(OrderItem orderItem)
		{

		}

		public ValidationResult ApplyVoucher(Voucher voucher)
		{
			return null;
		}

		public void UpdateStatus(OrderStatusEnum orderStatus)
		{
			OrderStatus = orderStatus;
		}

		public void RemoveItem(OrderItem orderItem)
		{
		}

		public bool OrderItemExist(OrderItem orderItem)
		{
			return true;
		}

		public bool UpdateUnits(OrderItem orderItem, int number)
		{
			return true;
		}

		public void AddEvent(Event evento)
		{
			_notifications = _notifications ?? new List<Event>();
			_notifications.Add(evento);
		}


		public void SetDone()
		{
			this.OrderStatus = OrderStatusEnum.Paid;
		}

		public void SetDraft()
		{
			this.OrderStatus = OrderStatusEnum.Draft;
		}


	}
}

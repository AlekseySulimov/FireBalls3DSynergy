using System;
using System.Collections.Generic;

namespace Structures.ReactiveProperties
{
	public class ReactiveProperty<T> : IReactiveProperty<T>
	{
		private readonly List<Action<T>> _subscribers = new List<Action<T>>();
		public T Value { get; private set; }

		public ReactiveProperty(T initialValue)
		{
			Change(initialValue);
		}
		public void Subscribe(Action<T> valueChanged)
		{
			valueChanged?.Invoke(Value);
			_subscribers.Add(valueChanged);
		}

		public void Unsubscribe(Action<T> valueChanged)
		{
			_subscribers.Remove(valueChanged);
		}

		public void Change(T value)
		{
			Value = value;
			_subscribers.ForEach(subscribers => subscribers.Invoke(Value));
		}
	}
}
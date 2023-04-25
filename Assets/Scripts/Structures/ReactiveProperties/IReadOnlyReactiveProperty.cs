using System;
using System.Collections.Generic;

namespace Structures.ReactiveProperties
{
	public interface IReadOnlyReactiveProperty<T>
	{
		T Value { get; }
		void Subscribe(Action<T> valueChanged);
		void Unsubscribe(Action<T> valueChanged);
	}
}
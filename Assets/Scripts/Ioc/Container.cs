using System.Collections.Generic;
using System;
using Mono.CompilerServices.SymbolWriter;

namespace Ioc
{
	public class Container
	{
		private static readonly Dictionary<Type, object> _context = new Dictionary<Type, object>();

		public static void Register<T>(T instance) =>
			_context.Add(typeof(T), instance);

		public static T InstanceOf<T>()
		{
			Type key = typeof(T);
			return (T)_context[key];
		}
	}
}
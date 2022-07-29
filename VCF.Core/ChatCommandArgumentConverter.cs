﻿namespace VampireCommandFramework
{
	public abstract class ChatCommandArgumentConverter<T>
	{
		public abstract T Parse(ICommandContext ctx, string input);
	}
}

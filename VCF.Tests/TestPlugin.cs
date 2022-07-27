﻿using Unity.Entities;
using VampireCommandFramework;

namespace Consumer;

[ChatCommandGroup("horse", shortHand: "h")]
public class HorseCommands
{
	private Entity? ClosestHorse;
	public HorseCommands(CommandContext ctx)
	{
		ClosestHorse = HorseUtility.FindClosestHorse(ctx);
	}

	[ChatCommand("breed")]
	public void Breed(CommandContext ctx)
	{
		Console.WriteLine("I don't mean to stare, we don't have to breed.");
	}

	[ChatCommand("call")]
	public void Call(CommandContext ctx, NamedHorse? target = null)
	{
		Console.WriteLine($"You called? {(target == null ? "Default" : "Closest")}");
		var horse = target?.Horse ?? ClosestHorse!;
		/* ... */
	}

	[ChatCommand("call")]
	public void Call(CommandContext ctx, int a, int b)
	{
	}

	[ChatCommand("set speed")]
	public void SetSpeed(CommandContext ctx, float newSpeed)
	{
		/* ... */
	}

	[ChatCommand("color")]
	public void ColorHorse(CommandContext ctx, HorseColor color)
	{
		/* ... */
	}
}

public record NamedHorse(Entity Horse);
public enum HorseColor { Black, Brown, Blonde }

public class NamedHorseConverter : ChatCommandArgumentConverter<NamedHorse?>
{
	// Only Ted apparently
	public override NamedHorse? Parse(CommandContext ctx, string input)
	{
		/* check some cache or perform entity query, null here to not pull in more */
		return (input == "Ted") ? null : throw new ArgumentException("baaa");
	}
}

internal class HorseUtility
{
	internal static Entity? FindClosestHorse(CommandContext ctx)
	{
		return null;
	}
}

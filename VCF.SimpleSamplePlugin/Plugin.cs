﻿using BepInEx;
using BepInEx.Unity.IL2CPP;
using VampireCommandFramework;

namespace VCF.SimpleSamplePlugin;

[BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
[BepInDependency("gg.deca.VampireCommandFramework")]
[VampireCommandFramework.Breadstone.Reloadable]
internal class Plugin : BasePlugin
{
	public override void Load()
	{
		Log.LogDebug("Simple Plugin Loaded");
		CommandRegistry.RegisterAll();
	}

	public override bool Unload()
	{
		CommandRegistry.UnregisterAssembly();
		return true;
	}
	public static int Counter = 0;

}

public class SimplePluginCommands
{
	[Command("ping")]
	public void Ping(ICommandContext ctx, int num = 5) => ctx.Reply($"pong Counter={Plugin.Counter += num}");
}

using Exiled.API.Features;

namespace EssentialBc
{
    public class Plugin : Plugin<Config>
	{
		public override string Name { get; } = "EssentialBroadcast";
		public override string Author { get; } = "Kevin - DIRECTOR OF DAON";
		public override string Prefix { get; } = "EssentialBroadcast";

		public static EventHandlers instance;

		public EventHandlers EventHandlers;

		public override void OnEnabled()
		{
			EventHandlers = new EventHandlers(this);
			base.OnEnabled();

			Exiled.Events.Handlers.Warhead.Starting += EventHandlers.OnWarheadStarting;
			Exiled.Events.Handlers.Warhead.Stopping += EventHandlers.OnWarheadStopping;
			Exiled.Events.Handlers.Warhead.Detonated += EventHandlers.OnWarheadDetonated;
			Exiled.Events.Handlers.Map.AnnouncingNtfEntrance += EventHandlers.OnMTFAnnounce;
			Exiled.Events.Handlers.Server.RespawningTeam += EventHandlers.OnRespawningTeam;
			Exiled.Events.Handlers.Map.AnnouncingScpTermination += EventHandlers.OnContainingSCP;
			Exiled.Events.Handlers.Player.Died += EventHandlers.OnDied;
			Exiled.Events.Handlers.Player.Verified += EventHandlers.OnVerified;
			Exiled.Events.Handlers.Player.Left += EventHandlers.OnLeft;
			Exiled.Events.Handlers.Map.AnnouncingDecontamination += EventHandlers.OnAnnouncingDecontamination;
			Exiled.Events.Handlers.Server.RoundStarted += EventHandlers.OnRoundStart;
			Exiled.Events.Handlers.Server.RoundEnded += EventHandlers.OnRoundEnded;
			Exiled.Events.Handlers.Map.GeneratorActivated += EventHandlers.OnGeneratorActivated;
			Exiled.Events.Handlers.Player.Spawning += EventHandlers.OnSpawning;
			Exiled.Events.Handlers.Server.RestartingRound += EventHandlers.OnRestarting;
			Exiled.Events.Handlers.Map.Decontaminating += EventHandlers.OnDecontamination;
			Exiled.Events.Handlers.Player.Died += EventHandlers.Last;
			Exiled.Events.Handlers.Player.Dying += EventHandlers.OnDying;
			Exiled.Events.Handlers.Player.Escaping += EventHandlers.OnEscape;
			Exiled.Events.Handlers.Scp079.GainingLevel += EventHandlers.onGaininglevel;
		}

		public override void OnDisabled()
		{
			base.OnDisabled();

			Exiled.Events.Handlers.Warhead.Starting -= EventHandlers.OnWarheadStarting;
			Exiled.Events.Handlers.Warhead.Stopping -= EventHandlers.OnWarheadStopping;
			Exiled.Events.Handlers.Warhead.Detonated -= EventHandlers.OnWarheadDetonated;
			Exiled.Events.Handlers.Map.AnnouncingNtfEntrance -= EventHandlers.OnMTFAnnounce;
			Exiled.Events.Handlers.Server.RespawningTeam -= EventHandlers.OnRespawningTeam;
			Exiled.Events.Handlers.Map.AnnouncingScpTermination -= EventHandlers.OnContainingSCP;
			Exiled.Events.Handlers.Player.Died -= EventHandlers.OnDied;
			Exiled.Events.Handlers.Player.Verified -= EventHandlers.OnVerified;
			Exiled.Events.Handlers.Player.Left -= EventHandlers.OnLeft;
			Exiled.Events.Handlers.Map.AnnouncingDecontamination -= EventHandlers.OnAnnouncingDecontamination;
			Exiled.Events.Handlers.Server.RoundStarted -= EventHandlers.OnRoundStart;
			Exiled.Events.Handlers.Server.RoundEnded -= EventHandlers.OnRoundEnded;
			Exiled.Events.Handlers.Map.GeneratorActivated -= EventHandlers.OnGeneratorActivated;
			Exiled.Events.Handlers.Player.Spawning -= EventHandlers.OnSpawning;
			Exiled.Events.Handlers.Server.RestartingRound -= EventHandlers.OnRestarting;
			Exiled.Events.Handlers.Map.Decontaminating -= EventHandlers.OnDecontamination; 
			Exiled.Events.Handlers.Player.Died -= EventHandlers.Last;
			Exiled.Events.Handlers.Player.Dying -= EventHandlers.OnDying;
			Exiled.Events.Handlers.Player.Escaping -= EventHandlers.OnEscape;
			Exiled.Events.Handlers.Scp079.GainingLevel -= EventHandlers.onGaininglevel;

			EventHandlers = null;
		}

	}
}

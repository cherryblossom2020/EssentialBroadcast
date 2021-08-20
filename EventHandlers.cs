using Exiled.Events.EventArgs;
using MEC;
using System.Collections.Generic;
using System.Linq;
using Respawning;
using Map = Exiled.API.Features.Map;
using Player = Exiled.API.Features.Player;
using Warhead = Exiled.API.Features.Warhead;

namespace EssentialBc
{
    public partial class EventHandlers
    {
        public Plugin plugin;
        public EventHandlers(Plugin plugin) => this.plugin = plugin;
        private static List<CoroutineHandle> coroutines = new List<CoroutineHandle>();
        public bool SCPsList;

        public void OnWarheadStarting(StartingEventArgs ev)
        {
            Map.Broadcast(7, plugin.Config.WarheadStart.Replace("%timeleft", Warhead.RealDetonationTimer.ToString()));
        }

        public void OnWarheadStopping(StoppingEventArgs ev)
        {
            Map.Broadcast(6,
                plugin.Config.WarheadStop.Replace("%user", ev.Player.Nickname)
                    .Replace("%timeleft", Warhead.RealDetonationTimer.ToString()));
        }

        public void OnWarheadDetonated()
        {
            Map.Broadcast(5, plugin.Config.WarheadDetonated);
        }

        public void OnMTFAnnounce(AnnouncingNtfEntranceEventArgs ev)
        {
            Map.Broadcast(10,
                plugin.Config.MTFspawn.Replace("%unit", ev.UnitName).Replace("%num", ev.UnitNumber.ToString())
                    .Replace("%scps", Player.Get(Team.SCP).Count().ToString()));
        }
        
        public void OnContainingSCP(AnnouncingScpTerminationEventArgs ev)
        {
            string name = plugin.Config.TranslatedRoles[ev.Role.roleId];
            {
                Map.Broadcast(7, plugin.Config.SCPcontained.Replace("%scpname", name).Replace("reason", plugin.Config.TranslatedDamageTypes[ev.HitInfo.GetDamageName()]));
            }
        }

        public void OnRespawningTeam(RespawningTeamEventArgs ev)
        {
            if (ev.NextKnownTeam != SpawnableTeamType.ChaosInsurgency) return;
            foreach (Player player in Player.List)
            {
                if (player.Team == Team.CDP || player.Team == Team.CHI)
                    Timing.CallDelayed(0.5f, () =>
                    {
                        player.Broadcast(10, plugin.Config.CHAOSspawn);
                    });
            }
        }

        public void OnDied(DiedEventArgs ev)
        {

            if (ev.Target.IsCuffed && ev.Killer.Team != Team.SCP)
            {
                string name = plugin.Config.TranslatedRoles[ev.Killer.Role];
                string vic = plugin.Config.TranslatedRoles[ev.Target.Role];
                Map.Broadcast(10,
                    plugin.Config.CuffedPlayerKilled.Replace("%Target", ev.Target.Nickname)
                        .Replace("%TST", ev.Target.UserId).Replace("%VictimRole", vic)
                        .Replace("%Killer", ev.Killer.Nickname).Replace("%Steamid", ev.Killer.UserId)
                        .Replace("%MurderRole", name));
            }
        }

        public void OnVerified(VerifiedEventArgs ev)
        {
            ev.Player.Broadcast(7,
                plugin.Config.PlayerJoin.Replace("%player", ev.Player.Nickname).Replace("%steamid", ev.Player.UserId));
        }

        public void OnLeft(LeftEventArgs ev)
        {
            if (ev.Player.Team == Team.SCP)
            {
                Map.Broadcast(10,
                    plugin.Config.SCPLeft.Replace("%scp", ev.Player.Role.ToString())
                        .Replace("%user", ev.Player.Nickname).Replace("%steamid", ev.Player.UserId));
            }
        }

        public void OnAnnouncingDecontamination(AnnouncingDecontaminationEventArgs ev)
        {
            switch (ev.Id)
            {
                case 0:
                {
                    Map.Broadcast(8, message: plugin.Config.LczDecon_15);
                    break;
                }
                case 1:
                {
                    Map.Broadcast(8, message: plugin.Config.LczDecon_10);
                    break;
                }
                case 2:
                {
                    Map.Broadcast(8, message: plugin.Config.LczDecon_5);
                    break;
                }
                case 3:
                {
                    Map.Broadcast(8, message: plugin.Config.LczDecon_1);
                    break;
                }
                case 4:
                {
                    Map.Broadcast(8, message: plugin.Config.LczDecon_30s);
                    break;
                }
            }
        }

        public void OnDecontamination(DecontaminatingEventArgs ev)
        {
            Map.Broadcast(8, message: plugin.Config.LczDecon);
        }
        
        public void OnRoundStart()
        {
            SCPsList = false;
            Map.Broadcast(6, message: plugin.Config.RoundStart);
            coroutines.Add(Timing.RunCoroutine(TimedBroadcast()));
            
        }
    
        public void OnRoundEnded(RoundEndedEventArgs ev)
        {
            Map.Broadcast(10, plugin.Config.RoundEnd);
        }

        public void OnGeneratorActivated(GeneratorActivatedEventArgs ev)
        {
            int curgen = Generator079.mainGenerator.NetworktotalVoltage + 1;
            if (curgen < 5)
            {
                Map.Broadcast(10, plugin.Config.GeneratorActivated.Replace("%activegenerators", curgen.ToString()));
            }
            else
            {
                Map.Broadcast(10, plugin.Config.AllGeneratorsActivated);
            }
        }

        public void onGaininglevel(GainingLevelEventArgs ev)
        {
            Timing.CallDelayed(0.5f, () =>
            {
                Map.Broadcast(10, plugin.Config.Gainlevel.Replace("%level", ev.Player.Levels.ToString()));
            });
        }

        public void OnSpawning(SpawningEventArgs ev)
        {
            if (ev.Player.Team != Team.SCP) return;
            string scpList = "";
            int count = 0;
            foreach (Player player in Player.List)
            {
                if (player.Team == Team.SCP)
                {
                    if (count != 0) scpList += " | ";
                    scpList += $"<color=red>{player.Role.ToString()}</color>";
                    count++;
                }
            }

            ev.Player.Broadcast(8, plugin.Config.Scplist.Replace("%scplist", $"{scpList}"));
        }

        public void OnRestarting()
        {
            foreach (CoroutineHandle coroutine in coroutines)
                Timing.KillCoroutines(coroutine);
            coroutines.Clear();
        }
        
        public void OnEscape(EscapingEventArgs ev)
        {
            foreach (Player player in Player.List)
            {
                {
                    string escape = plugin.Config.TranslatedRoles[ev.Player.Role];
                    {
                        Map.Broadcast(8, plugin.Config.Escape.Replace("%escaperole", escape));
                    }
                }
            }
            
        }
        
        
        public void OnDying(DyingEventArgs ev)
        {
            foreach (Player player in Player.List)
            {
                string kil = plugin.Config.TranslatedRoles[ev.Killer.Role];
                string vic = plugin.Config.TranslatedRoles[ev.Target.Role];
                if (player.Team == Team.RIP)
                {
                    player.Broadcast(2, plugin.Config.Killog.Replace("%Killer", kil)
                        .Replace("%MurdererType", ev.Killer.ToString()).Replace("%Victim", vic)
                        .Replace("%TargetType", ev.Target.Role.ToString()));
                }
            }
        }
        
IEnumerator<float> TimedBroadcast()
{
    for (; ; )
    {
        Map.Broadcast(10, plugin.Config.TimedBroadcasts[UnityEngine.Random.Range(0, plugin.Config.TimedBroadcasts.Count())]);
        yield return Timing.WaitForSeconds(250);
    }
}

        public void Last(DiedEventArgs ev)
        {
            Team playerTeam = ev.Target.Team;
            int teamLeft = 0;
            Player lastplayer = null;
            foreach (Player player in Player.List)
            {
                if (!player.IsEnemy(playerTeam) && player != ev.Target)
                {
                    teamLeft++;
                    lastplayer = player;
                }
            }
            if (teamLeft == 1)
            {
                lastplayer?.Broadcast(7, plugin.Config.PlayerLastRole);
            }
        }
    }
}


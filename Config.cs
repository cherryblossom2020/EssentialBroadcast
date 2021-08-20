using Exiled.API.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;

namespace EssentialBc
{
    public sealed class Config : IConfig
    {
        [Description("플러그인 사용 여부를 결정합니다")] 
        public bool IsEnabled { get; set; } = true; 
        
        [Description("알파 핵탄두 절차의 시작 방송을 설정합니다. % 값은 건드리지 마세요.")]
        public string WarheadStart { get; set; } = "알파 핵탄두 절차를 시작합니다. %timeleft 초 남았습니다.";
        
        [Description("알파 핵탄두 절차의 중지 방송을 설정합니다. % 값은 건드리지 마세요.")]
        public string WarheadStop { get; set; } = "알파 핵탄두 절차가 중지되었습니다. %timeleft 초 남았습니다. 중지시킨 유저: %user";
        
        [Description("알파 핵탄두 절차의 완료 방송을 설정합니다.")]
        public string WarheadDetonated { get; set; } = "알파 핵탄두 절차가 완료되었습니다.";
        
        [Description("MTF지원 방송을 설정합니다. % 값은 건드리지 마세요.")]
        public string MTFspawn { get; set; } = "MTF소속 %unit - %num 가 시설에 진입하였습니다. 남은 scp는 총 %scps 개체입니다. ";
        
        [Description("혼돈의 반란 지원 메세지를 설정합니다. $ 값은 건드리지 마세요.")]
        public string CHAOSspawn { get; set; } = "혼돈의 반란 요원이 시설에 진입하였습니다.";
        
        [Description("scp격리 메세지를 설정합니다.")]
        public string SCPcontained { get; set; } = "%scpname 가 격리되었습니다. 원인 %reason";
        
        [Description("서버 입장 메세지를 설정합니다. % 값은 건드리지 마세요.")]
        public string PlayerJoin { get; set; } = "%player 님 서버에 오신것을 환영합니다.";
        
        [Description("SCP탈주 메세지를 설정합니다. % 값은 건드리지 마세요.")]
        public string SCPLeft { get; set; } = "%scp 플레이어 %user (%steamid) 님이 중도퇴장 하였습니다.";
        
        [Description("저위험군 폐쇄까지 남은 시간을 방송합니다. 각각 15분, 10분, 5분, 1분, 30초")]
        public string LczDecon_15 { get; set; } = "<color=red>저위험군 격리 절차</color> 실행까지 <color=red>15분</color> 남았습니다.";
        public string LczDecon_10 { get; set; } = "<color=red>저위험군 격리 절차</color> 실행까지 <color=red>10분</color> 남았습니다.";
        public string LczDecon_5 { get; set; } = "<color=red>저위험군 격리 절차</color> 실행까지 <color=red>5분</color> 남았습니다.";
        public string LczDecon_1 { get; set; } = "<color=red>저위험군 격리 절차</color> 실행까지 <color=red>1분</color> 남았습니다.";
        public string LczDecon_30s { get; set; } = "<color=red>저위험군 격리 절차</color> 실행까지 <color=red>30초</color> 남았습니다.";
        
        [Description("저위험군 폐쇄 완료를 방송합니다.")]
        public string LczDecon { get; set; } = "<color=red>저위험군 격리 절차</color> 가 완료되었습니다.";
        
        [Description("라운드 시작 방송을 설정합니다.")]
        public string RoundStart { get; set; } = "라운드가 시작되었습니다.";
        
        [Description("라운드 종료 방송을 설정합니다")]
        public string RoundEnd { get; set; } = "라운드가 종료되었습니다.";
        
        [Description("모든 발전기가 작동되었을때 방송됩니다.")]
        public string AllGeneratorsActivated { get; set; } = "모든 발전기가 작동되었습니다. 1분후 고위험군이 과충전 됩니다.";
        
        [Description("발전기가 작동되었을때 방송됩니다. $ 값은 건드리지 마세요.")]
        public string GeneratorActivated { get; set; } = "총 5개중 %activegenerators 개의 발전기가 작동되었습니다. ";
        
        [Description("마지막 인원 알림을 방송합니다.")]
        public string PlayerLastRole { get; set; } = "당신은 마지막 인원입니다.";
        
        [Description("체포킬 발생시 방송됩니다. % 값은 건드리지 마세요.")]
        public string CuffedPlayerKilled { get; set; } = "%MurderRole %Killer 가 %Target %VictimRole 를 체포킬하였습니다. 신고용id 스팀 - %Steamid";
        
        [Description("BC로 상단에 킬로그를 출력합니다.")]
        public string Killog { get; set; } = "%Killer (%MurdererType) 님이 %Victim (%TargetType) 님을 사살하셨습니다." ;
        
        [Description("SCP리스트를 출력합니다. % 값은 건드리지 마세요.")]
        public string Scplist { get; set; } = "이번 라운드 SCP목록. %scplist";
        
        [Description("D계급이나 과학자가 탈출할때마다 방송됩니다. % 값은 건드리지 마세요.")]
        public string Escape { get; set; } = "%escaperole 가 시설을 탈출하였습니다.";
        
        [Description("SCP079의 티어를 얻을때 출력됩니다. % 값은 건드리지 마세요.")]
        public string Gainlevel { get; set; } = "주의: SCP079 가 %level 티어를 달성하였습니다. ";

        [Description("역할의 이름을 원하는대로 설정합니다. ex. tutorial = 뱀의손")]
        public Dictionary<RoleType, string> TranslatedRoles { get; set; } = new Dictionary<RoleType, string>
        {
            {
                RoleType.Scp049, "SCP-049"
            },
            {
                RoleType.Scp0492, "SCP-049-2"
            },
            {
                RoleType.Scp079, "SCP-079"
            },
            {
                RoleType.Scp096, "SCP-096"
            },
            {
                RoleType.Scp106, "SCP-106"
            },
            {
                RoleType.Scp173, "SCP-173"
            },
            {
                RoleType.Scp93953, "SCP-939-53"
            },
            {
                RoleType.Scp93989, "SCP-939-89"
            },
            {
                RoleType.ChaosInsurgency, "혼돈의 반란"
            },
            {
                RoleType.ClassD, "D계급"
            },
            {
                RoleType.FacilityGuard, "시설 경비"
            },
            {
                RoleType.NtfCadet, "NTF 사관생도"
            },
            {
                RoleType.NtfCommander, "NTF 사령관"
            },
            {
                RoleType.NtfLieutenant, "NTF 부관"
            },
            {
                RoleType.NtfScientist, "NTF 과학자"
            },
            {
                RoleType.Scientist, "과학자"
            },
            {
                RoleType.Tutorial, "튜토리얼"
            },
            {
                RoleType.Spectator, "관전자"
            },
            {
                RoleType.None, "알수없음"  
            },
        };
        
        [Description("SCP 격리사유를 자세하게 설정합니다")]
        public Dictionary<string, string> TranslatedDamageTypes { get; set; } = new Dictionary<string, string>()
        {
            { "NONE", "언노운" },
            { "LURE", "106 격리" },
            { "NUKE", "핵 폭발" },
            { "WALL", "SCP018 혹은 탄삼 낙사" },
            { "DECONT", "저위험 폐쇄" },
            { "TESLA", "테슬라" },
            { "FALLDOWN", "추락" },
            { "RECONTAINMENT", "재격리 절차" },
            { "CONTAIN", "Contain" },
            { "Com15", "Com15" },
            { "P90", "P90" },
            { "E11 Standard Rifle", "E11 Standard Rifle" },
            { "MP7", "MP7" },
            { "Logicier", "Logicier" },
            { "USP", "USP" },
            { "MicroHID", "MicroHID" },
            { "GRENADE", "수류탄" },
            { "SCP-049", "SCP-049" },
            { "SCP-049-2", "SCP-049-2" },
            { "SCP-096", "SCP-096" },
            { "SCP-106", "SCP-106" },
            { "SCP-173", "SCP-173" },
            { "SCP-939", "SCP-939" },
            { "SCP-207", "SCP-207" }
        };
        
        public List<string> TimedBroadcasts = new List<string>
        {
            "<size=40><color=#c0edad>해당 서버</color>는 <i><color=#f7d5d5>DAON</color></i> 에서 배포한 플러그인을 <color=#eb7167>사용 중</color> 입니다</size> \n <size=25>ㅣ<i><color=#f6d7fc>discord.gg/daon</color></i>ㅣ</size>"
        };

    }
}


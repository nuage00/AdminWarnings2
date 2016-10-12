using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rocket.API;
using System.Xml.Serialization;

namespace AdminWarnings
{
    public class WarningsConfig : IRocketPluginConfiguration
    {
        public bool Enabled;
        public bool AnnouceWarningKicksAndBansServerWide;
        public bool AnnouceWarningsServerWide;
        public string MessageColor;
        [XmlArrayItem(ElementName = "WarningPoint")]
        public List<WarningPoint> WarningPoints;
        [XmlArrayItem(ElementName = "PlayerWarning")]
        public List<PlayerWarning> PlayerWarnings;

        public void LoadDefaults()
        {
            Enabled = true;
            MessageColor = "Green";
            AnnouceWarningKicksAndBansServerWide = true;
            AnnouceWarningsServerWide = false;
            WarningPoints = new List<WarningPoint> {
                new WarningPoint{ WarningsToTrigger = 3, KickPlayer = true, BanPlayer = false, BanLengthSeconds = 0 },
                new WarningPoint{ WarningsToTrigger = 4, KickPlayer = false, BanPlayer = true, BanLengthSeconds = 600 },
                new WarningPoint{ WarningsToTrigger = 5, KickPlayer = false, BanPlayer = true, BanLengthSeconds = 1800 },
                new WarningPoint{ WarningsToTrigger = 6, KickPlayer = false, BanPlayer = true, BanLengthSeconds = 86400 },
            };
            PlayerWarnings = new List<PlayerWarning>();
        }

        
              /*  new WarningPoint(3, true, false, 0),
                new WarningPoint(4, false, true, 600),
                new WarningPoint(5, false, true, 1800),
                new WarningPoint(6, false, true, 86400)*/
    }

    public class WarningPoint
    {
       /* public WarningPoint(int warningsToTrigger, bool kickPlayer, bool banPlayer, uint BanLength)
        {
            WarningsToTrigger = warningsToTrigger;
            KickPlayer = kickPlayer;
            BanPlayer = banPlayer;
            BanLengthSeconds = BanLength;
        } */

        public int WarningsToTrigger;
        public bool KickPlayer;
        public bool BanPlayer;
        public uint BanLengthSeconds;
    }

    public class PlayerWarning
    {
        [XmlAttribute]
        public string CSteamID;
        [XmlAttribute]
        public int Warnings;
    }

}

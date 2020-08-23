using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGO_Bot
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class PlatformInfo
    {
        [JsonProperty("platformSlug")]
        public string PlatformSlug;

        [JsonProperty("platformUserId")]
        public string PlatformUserId;

        [JsonProperty("platformUserHandle")]
        public string PlatformUserHandle;

        [JsonProperty("platformUserIdentifier")]
        public string PlatformUserIdentifier;

        [JsonProperty("avatarUrl")]
        public string AvatarUrl;

        [JsonProperty("additionalParameters")]
        public object AdditionalParameters;
    }

    public class UserInfo
    {
        [JsonProperty("userId")]
        public object UserId;

        [JsonProperty("isPremium")]
        public bool IsPremium;

        [JsonProperty("isVerified")]
        public bool IsVerified;

        [JsonProperty("isInfluencer")]
        public bool IsInfluencer;

        [JsonProperty("countryCode")]
        public object CountryCode;

        [JsonProperty("customAvatarUrl")]
        public object CustomAvatarUrl;

        [JsonProperty("customHeroUrl")]
        public object CustomHeroUrl;

        [JsonProperty("socialAccounts")]
        public object SocialAccounts;
    }

    public class UserMetadata
    {
    }

    public class UserAttributes
    {
    }

    public class UserMetadata2
    {
        [JsonProperty("name")]
        public string Name;
    }

    public class UserMetadata3
    {
    }

    public class TimePlayed
    {
        [JsonProperty("rank")]
        public object Rank;

        [JsonProperty("percentile")]
        public double Percentile;

        [JsonProperty("displayName")]
        public string DisplayName;

        [JsonProperty("displayCategory")]
        public string DisplayCategory;

        [JsonProperty("category")]
        public string Category;

        [JsonProperty("UserMetadata")]
        public UserMetadata3 UserMetadata;

        [JsonProperty("value")]
        public int Value;

        [JsonProperty("displayValue")]
        public string DisplayValue;

        [JsonProperty("displayType")]
        public string DisplayType;
    }

    public class UserMetadata4
    {
    }

    public class Score
    {
        [JsonProperty("rank")]
        public object Rank;

        [JsonProperty("percentile")]
        public double Percentile;

        [JsonProperty("displayName")]
        public string DisplayName;

        [JsonProperty("displayCategory")]
        public string DisplayCategory;

        [JsonProperty("category")]
        public string Category;

        [JsonProperty("UserMetadata")]
        public UserMetadata4 UserMetadata;

        [JsonProperty("value")]
        public int Value;

        [JsonProperty("displayValue")]
        public string DisplayValue;

        [JsonProperty("displayType")]
        public string DisplayType;
    }

    public class UserMetadata5
    {
    }

    public class Kills
    {
        [JsonProperty("rank")]
        public object Rank;

        [JsonProperty("percentile")]
        public double Percentile;

        [JsonProperty("displayName")]
        public string DisplayName;

        [JsonProperty("displayCategory")]
        public string DisplayCategory;

        [JsonProperty("category")]
        public string Category;

        [JsonProperty("UserMetadata")]
        public UserMetadata5 UserMetadata;

        [JsonProperty("value")]
        public int Value;

        [JsonProperty("displayValue")]
        public string DisplayValue;

        [JsonProperty("displayType")]
        public string DisplayType;
    }

    public class UserMetadata6
    {
    }

    public class Deaths
    {
        [JsonProperty("rank")]
        public object Rank;

        [JsonProperty("percentile")]
        public double Percentile;

        [JsonProperty("displayName")]
        public string DisplayName;

        [JsonProperty("displayCategory")]
        public string DisplayCategory;

        [JsonProperty("category")]
        public string Category;

        [JsonProperty("UserMetadata")]
        public UserMetadata6 UserMetadata;

        [JsonProperty("value")]
        public int Value;

        [JsonProperty("displayValue")]
        public string DisplayValue;

        [JsonProperty("displayType")]
        public string DisplayType;
    }

    public class UserMetadata7
    {
    }

    public class Kd
    {
        [JsonProperty("rank")]
        public object Rank;

        [JsonProperty("percentile")]
        public double Percentile;

        [JsonProperty("displayName")]
        public string DisplayName;

        [JsonProperty("displayCategory")]
        public string DisplayCategory;

        [JsonProperty("category")]
        public string Category;

        [JsonProperty("UserMetadata")]
        public UserMetadata7 UserMetadata;

        [JsonProperty("value")]
        public double Value;

        [JsonProperty("displayValue")]
        public string DisplayValue;

        [JsonProperty("displayType")]
        public string DisplayType;
    }

    public class UserMetadata8
    {
    }

    public class Damage
    {
        [JsonProperty("rank")]
        public object Rank;

        [JsonProperty("percentile")]
        public double Percentile;

        [JsonProperty("displayName")]
        public string DisplayName;

        [JsonProperty("displayCategory")]
        public string DisplayCategory;

        [JsonProperty("category")]
        public string Category;

        [JsonProperty("UserMetadata")]
        public UserMetadata8 UserMetadata;

        [JsonProperty("value")]
        public int Value;

        [JsonProperty("displayValue")]
        public string DisplayValue;

        [JsonProperty("displayType")]
        public string DisplayType;
    }

    public class UserMetadata9
    {
    }

    public class Headshots
    {
        [JsonProperty("rank")]
        public object Rank;

        [JsonProperty("percentile")]
        public double Percentile;

        [JsonProperty("displayName")]
        public string DisplayName;

        [JsonProperty("displayCategory")]
        public string DisplayCategory;

        [JsonProperty("category")]
        public string Category;

        [JsonProperty("UserMetadata")]
        public UserMetadata9 UserMetadata;

        [JsonProperty("value")]
        public int Value;

        [JsonProperty("displayValue")]
        public string DisplayValue;

        [JsonProperty("displayType")]
        public string DisplayType;
    }

    public class UserMetadata10
    {
    }

    public class Dominations
    {
        [JsonProperty("rank")]
        public object Rank;

        [JsonProperty("percentile")]
        public double Percentile;

        [JsonProperty("displayName")]
        public string DisplayName;

        [JsonProperty("displayCategory")]
        public string DisplayCategory;

        [JsonProperty("category")]
        public string Category;

        [JsonProperty("UserMetadata")]
        public UserMetadata10 UserMetadata;

        [JsonProperty("value")]
        public int Value;

        [JsonProperty("displayValue")]
        public string DisplayValue;

        [JsonProperty("displayType")]
        public string DisplayType;
    }

    public class UserMetadata11
    {
    }

    public class ShotsFired
    {
        [JsonProperty("rank")]
        public object Rank;

        [JsonProperty("percentile")]
        public double Percentile;

        [JsonProperty("displayName")]
        public string DisplayName;

        [JsonProperty("displayCategory")]
        public string DisplayCategory;

        [JsonProperty("category")]
        public string Category;

        [JsonProperty("UserMetadata")]
        public UserMetadata11 UserMetadata;

        [JsonProperty("value")]
        public int Value;

        [JsonProperty("displayValue")]
        public string DisplayValue;

        [JsonProperty("displayType")]
        public string DisplayType;
    }

    public class UserMetadata12
    {
    }

    public class ShotsHit
    {
        [JsonProperty("rank")]
        public object Rank;

        [JsonProperty("percentile")]
        public double Percentile;

        [JsonProperty("displayName")]
        public string DisplayName;

        [JsonProperty("displayCategory")]
        public string DisplayCategory;

        [JsonProperty("category")]
        public string Category;

        [JsonProperty("UserMetadata")]
        public UserMetadata12 UserMetadata;

        [JsonProperty("value")]
        public int Value;

        [JsonProperty("displayValue")]
        public string DisplayValue;

        [JsonProperty("displayType")]
        public string DisplayType;
    }

    public class UserMetadata13
    {
    }

    public class ShotsAccuracy
    {
        [JsonProperty("rank")]
        public object Rank;

        [JsonProperty("percentile")]
        public double Percentile;

        [JsonProperty("displayName")]
        public string DisplayName;

        [JsonProperty("displayCategory")]
        public string DisplayCategory;

        [JsonProperty("category")]
        public string Category;

        [JsonProperty("UserMetadata")]
        public UserMetadata13 UserMetadata;

        [JsonProperty("value")]
        public double Value;

        [JsonProperty("displayValue")]
        public string DisplayValue;

        [JsonProperty("displayType")]
        public string DisplayType;
    }

    public class UserMetadata14
    {
    }

    public class SnipersKilled
    {
        [JsonProperty("rank")]
        public object Rank;

        [JsonProperty("percentile")]
        public double Percentile;

        [JsonProperty("displayName")]
        public string DisplayName;

        [JsonProperty("displayCategory")]
        public string DisplayCategory;

        [JsonProperty("category")]
        public string Category;

        [JsonProperty("UserMetadata")]
        public UserMetadata14 UserMetadata;

        [JsonProperty("value")]
        public int Value;

        [JsonProperty("displayValue")]
        public string DisplayValue;

        [JsonProperty("displayType")]
        public string DisplayType;
    }

    public class UserMetadata15
    {
    }

    public class DominationOverkills
    {
        [JsonProperty("rank")]
        public object Rank;

        [JsonProperty("percentile")]
        public double Percentile;

        [JsonProperty("displayName")]
        public string DisplayName;

        [JsonProperty("displayCategory")]
        public string DisplayCategory;

        [JsonProperty("category")]
        public string Category;

        [JsonProperty("UserMetadata")]
        public UserMetadata15 UserMetadata;

        [JsonProperty("value")]
        public int Value;

        [JsonProperty("displayValue")]
        public string DisplayValue;

        [JsonProperty("displayType")]
        public string DisplayType;
    }

    public class UserMetadata16
    {
    }

    public class DominationRevenges
    {
        [JsonProperty("rank")]
        public object Rank;

        [JsonProperty("percentile")]
        public double Percentile;

        [JsonProperty("displayName")]
        public string DisplayName;

        [JsonProperty("displayCategory")]
        public string DisplayCategory;

        [JsonProperty("category")]
        public string Category;

        [JsonProperty("UserMetadata")]
        public UserMetadata16 UserMetadata;

        [JsonProperty("value")]
        public int Value;

        [JsonProperty("displayValue")]
        public string DisplayValue;

        [JsonProperty("displayType")]
        public string DisplayType;
    }

    public class UserMetadata17
    {
    }

    public class BombsPlanted
    {
        [JsonProperty("rank")]
        public object Rank;

        [JsonProperty("percentile")]
        public double Percentile;

        [JsonProperty("displayName")]
        public string DisplayName;

        [JsonProperty("displayCategory")]
        public string DisplayCategory;

        [JsonProperty("category")]
        public string Category;

        [JsonProperty("UserMetadata")]
        public UserMetadata17 UserMetadata;

        [JsonProperty("value")]
        public int Value;

        [JsonProperty("displayValue")]
        public string DisplayValue;

        [JsonProperty("displayType")]
        public string DisplayType;
    }

    public class UserMetadata18
    {
    }

    public class BombsDefused
    {
        [JsonProperty("rank")]
        public object Rank;

        [JsonProperty("percentile")]
        public double Percentile;

        [JsonProperty("displayName")]
        public string DisplayName;

        [JsonProperty("displayCategory")]
        public string DisplayCategory;

        [JsonProperty("category")]
        public string Category;

        [JsonProperty("UserMetadata")]
        public UserMetadata18 UserMetadata;

        [JsonProperty("value")]
        public int Value;

        [JsonProperty("displayValue")]
        public string DisplayValue;

        [JsonProperty("displayType")]
        public string DisplayType;
    }

    public class UserMetadata19
    {
    }

    public class MoneyEarned
    {
        [JsonProperty("rank")]
        public object Rank;

        [JsonProperty("percentile")]
        public double Percentile;

        [JsonProperty("displayName")]
        public string DisplayName;

        [JsonProperty("displayCategory")]
        public string DisplayCategory;

        [JsonProperty("category")]
        public string Category;

        [JsonProperty("UserMetadata")]
        public UserMetadata19 UserMetadata;

        [JsonProperty("value")]
        public int Value;

        [JsonProperty("displayValue")]
        public string DisplayValue;

        [JsonProperty("displayType")]
        public string DisplayType;
    }

    public class UserMetadata20
    {
    }

    public class HostagesRescued
    {
        [JsonProperty("rank")]
        public object Rank;

        [JsonProperty("percentile")]
        public double Percentile;

        [JsonProperty("displayName")]
        public string DisplayName;

        [JsonProperty("displayCategory")]
        public string DisplayCategory;

        [JsonProperty("category")]
        public string Category;

        [JsonProperty("UserMetadata")]
        public UserMetadata20 UserMetadata;

        [JsonProperty("value")]
        public int Value;

        [JsonProperty("displayValue")]
        public string DisplayValue;

        [JsonProperty("displayType")]
        public string DisplayType;
    }

    public class UserMetadata21
    {
    }

    public class Mvp
    {
        [JsonProperty("rank")]
        public object Rank;

        [JsonProperty("percentile")]
        public double Percentile;

        [JsonProperty("displayName")]
        public string DisplayName;

        [JsonProperty("displayCategory")]
        public string DisplayCategory;

        [JsonProperty("category")]
        public string Category;

        [JsonProperty("UserMetadata")]
        public UserMetadata21 UserMetadata;

        [JsonProperty("value")]
        public int Value;

        [JsonProperty("displayValue")]
        public string DisplayValue;

        [JsonProperty("displayType")]
        public string DisplayType;
    }

    public class UserMetadata22
    {
    }

    public class UserWins
    {
        [JsonProperty("rank")]
        public object Rank;

        [JsonProperty("percentile")]
        public double Percentile;

        [JsonProperty("displayName")]
        public string DisplayName;

        [JsonProperty("displayCategory")]
        public string DisplayCategory;

        [JsonProperty("category")]
        public string Category;

        [JsonProperty("UserMetadata")]
        public UserMetadata22 UserMetadata;

        [JsonProperty("value")]
        public int Value;

        [JsonProperty("displayValue")]
        public string DisplayValue;

        [JsonProperty("displayType")]
        public string DisplayType;
    }

    public class UserMetadata23
    {
    }

    public class Ties
    {
        [JsonProperty("rank")]
        public object Rank;

        [JsonProperty("percentile")]
        public object Percentile;

        [JsonProperty("displayName")]
        public string DisplayName;

        [JsonProperty("displayCategory")]
        public string DisplayCategory;

        [JsonProperty("category")]
        public string Category;

        [JsonProperty("UserMetadata")]
        public UserMetadata23 UserMetadata;

        [JsonProperty("value")]
        public int Value;

        [JsonProperty("displayValue")]
        public string DisplayValue;

        [JsonProperty("displayType")]
        public string DisplayType;
    }

    public class UserMetadata24
    {
    }

    public class MatchesPlayed
    {
        [JsonProperty("rank")]
        public object Rank;

        [JsonProperty("percentile")]
        public double Percentile;

        [JsonProperty("displayName")]
        public string DisplayName;

        [JsonProperty("displayCategory")]
        public string DisplayCategory;

        [JsonProperty("category")]
        public string Category;

        [JsonProperty("UserMetadata")]
        public UserMetadata24 UserMetadata;

        [JsonProperty("value")]
        public int Value;

        [JsonProperty("displayValue")]
        public string DisplayValue;

        [JsonProperty("displayType")]
        public string DisplayType;
    }

    public class UserMetadata25
    {
    }

    public class Losses
    {
        [JsonProperty("rank")]
        public object Rank;

        [JsonProperty("percentile")]
        public object Percentile;

        [JsonProperty("displayName")]
        public string DisplayName;

        [JsonProperty("displayCategory")]
        public string DisplayCategory;

        [JsonProperty("category")]
        public string Category;

        [JsonProperty("UserMetadata")]
        public UserMetadata25 UserMetadata;

        [JsonProperty("value")]
        public int Value;

        [JsonProperty("displayValue")]
        public string DisplayValue;

        [JsonProperty("displayType")]
        public string DisplayType;
    }

    public class UserMetadata26
    {
    }

    public class RoundsPlayed
    {
        [JsonProperty("rank")]
        public object Rank;

        [JsonProperty("percentile")]
        public double Percentile;

        [JsonProperty("displayName")]
        public string DisplayName;

        [JsonProperty("displayCategory")]
        public string DisplayCategory;

        [JsonProperty("category")]
        public string Category;

        [JsonProperty("UserMetadata")]
        public UserMetadata26 UserMetadata;

        [JsonProperty("value")]
        public int Value;

        [JsonProperty("displayValue")]
        public string DisplayValue;

        [JsonProperty("displayType")]
        public string DisplayType;
    }

    public class UserMetadata27
    {
    }

    public class RoundsWon
    {
        [JsonProperty("rank")]
        public object Rank;

        [JsonProperty("percentile")]
        public double Percentile;

        [JsonProperty("displayName")]
        public string DisplayName;

        [JsonProperty("displayCategory")]
        public string DisplayCategory;

        [JsonProperty("category")]
        public string Category;

        [JsonProperty("UserMetadata")]
        public UserMetadata27 UserMetadata;

        [JsonProperty("value")]
        public int Value;

        [JsonProperty("displayValue")]
        public string DisplayValue;

        [JsonProperty("displayType")]
        public string DisplayType;
    }

    public class UserMetadata28
    {
    }

    public class WlPercentage
    {
        [JsonProperty("rank")]
        public object Rank;

        [JsonProperty("percentile")]
        public double Percentile;

        [JsonProperty("displayName")]
        public string DisplayName;

        [JsonProperty("displayCategory")]
        public string DisplayCategory;

        [JsonProperty("category")]
        public string Category;

        [JsonProperty("UserMetadata")]
        public UserMetadata28 UserMetadata;

        [JsonProperty("value")]
        public double Value;

        [JsonProperty("displayValue")]
        public string DisplayValue;

        [JsonProperty("displayType")]
        public string DisplayType;
    }

    public class UserMetadata29
    {
    }

    public class HeadshotPct
    {
        [JsonProperty("rank")]
        public object Rank;

        [JsonProperty("percentile")]
        public double Percentile;

        [JsonProperty("displayName")]
        public string DisplayName;

        [JsonProperty("displayCategory")]
        public string DisplayCategory;

        [JsonProperty("category")]
        public string Category;

        [JsonProperty("UserMetadata")]
        public UserMetadata29 UserMetadata;

        [JsonProperty("value")]
        public double Value;

        [JsonProperty("displayValue")]
        public string DisplayValue;

        [JsonProperty("displayType")]
        public string DisplayType;
    }

    public class UserStats
    {
        [JsonProperty("timePlayed")]
        public TimePlayed TimePlayed;

        [JsonProperty("score")]
        public Score Score;

        [JsonProperty("kills")]
        public Kills Kills;

        [JsonProperty("deaths")]
        public Deaths Deaths;

        [JsonProperty("kd")]
        public Kd Kd;

        [JsonProperty("damage")]
        public Damage Damage;

        [JsonProperty("headshots")]
        public Headshots Headshots;

        [JsonProperty("dominations")]
        public Dominations Dominations;

        [JsonProperty("shotsFired")]
        public ShotsFired ShotsFired;

        [JsonProperty("shotsHit")]
        public ShotsHit ShotsHit;

        [JsonProperty("shotsAccuracy")]
        public ShotsAccuracy ShotsAccuracy;

        [JsonProperty("snipersKilled")]
        public SnipersKilled SnipersKilled;

        [JsonProperty("dominationOverkills")]
        public DominationOverkills DominationOverkills;

        [JsonProperty("dominationRevenges")]
        public DominationRevenges DominationRevenges;

        [JsonProperty("bombsPlanted")]
        public BombsPlanted BombsPlanted;

        [JsonProperty("bombsDefused")]
        public BombsDefused BombsDefused;

        [JsonProperty("moneyEarned")]
        public MoneyEarned MoneyEarned;

        [JsonProperty("hostagesRescued")]
        public HostagesRescued HostagesRescued;

        [JsonProperty("mvp")]
        public Mvp Mvp;

        [JsonProperty("wins")]
        public Wins Wins;

        [JsonProperty("ties")]
        public Ties Ties;

        [JsonProperty("matchesPlayed")]
        public MatchesPlayed MatchesPlayed;

        [JsonProperty("losses")]
        public Losses Losses;

        [JsonProperty("roundsPlayed")]
        public RoundsPlayed RoundsPlayed;

        [JsonProperty("roundsWon")]
        public RoundsWon RoundsWon;

        [JsonProperty("wlPercentage")]
        public WlPercentage WlPercentage;

        [JsonProperty("headshotPct")]
        public HeadshotPct HeadshotPct;
    }

    public class Segment
    {
        [JsonProperty("type")]
        public string Type;

        [JsonProperty("attributes")]
        public UserAttributes Attributes;

        [JsonProperty("UserMetadata")]
        public UserMetadata2 UserMetadata;

        [JsonProperty("expiryDate")]
        public DateTime ExpiryDate;

        [JsonProperty("stats")]
        public UserStats Stats;
    }

    public class Data
    {
        [JsonProperty("platformInfo")]
        public PlatformInfo PlatformInfo;

        [JsonProperty("userInfo")]
        public UserInfo UserInfo;

        [JsonProperty("UserMetadata")]
        public UserMetadata UserMetadata;

        [JsonProperty("segments")]
        public List<Segment> Segments;

        [JsonProperty("availableSegments")]
        public List<object> AvailableSegments;

        [JsonProperty("expiryDate")]
        public DateTime ExpiryDate;
    }

    public class UserInfoRoot
    {
        [JsonProperty("data")]
        public Data Data;
    }


    class UserInfoModel
    {
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Enums
{
    public enum BuffEfect
    {
        SOUL_BARRIER = 1,
        GREATER_DAMAGE = 2,
        GREATER_DEFENSE = 3,
        GREATER_FORTITUDE = 4,
        CRITICAL_DAMAGE = 5,
        REFLEX = 6,
        WEAKNESS = 7,
        INNOVATION = 8,
        MAGIC_CIRCLE = 9,
        RED_ARMOR_IGNORE = 10,
        FITNESS = 11,
        DEFENSE_RATE = 12
    };
    public enum MapAttribute
    {
        GROUND = 0,
        SAFEZONE,
        SAFEZONE_NONGROUND = 4,
        NONGROUND
    };
    public enum EXP_GETTING_EVENT_TYPE
    {
        EVENT_TYPE_NONE = 0x0,
        EVENT_TYPE_PARTY = 0x1,
        EVENT_TYPE_DEVILSQUARE = 0x2,
        EVENT_TYPE_CHAOSCASTLE = 0x3,
        EVENT_TYPE_BLOODCASTLE = 0x4,
        EVENT_TYPE_CRYWOLF = 0x5,
    };
    enum EFFECT_LIST
    {
        EFFECT_GREATER_ATTACK = 1,
        EFFECT_GREATER_DEFENSE = 2,
        EFFECT_NPC_BUFF = 3,
        EFFECT_WIZARD_DEFENSE = 4,
        EFFECT_CRITICAL_DAMAGE = 5,
        EFFECT_INFINITY_ARROW = 6,
        EFFECT_SWELL_LIFE = 8,
        EFFECT_SWELL_MANA = 9,
        EFFECT_BLESS_POTION = 10,
        EFFECT_SOUL_POTION = 11,
        EFFECT_INVISIBLE = 18,
        EFFECT_BRAND_OF_SKILL = 19,
        EFFECT_GAMEMASTER = 28,
        EFFECT_EXP1_INCREASE = 29,
        EFFECT_EXPDROP1_INCREASE = 30,
        EFFECT_EXP_DISABLE1 = 31,
        EFFECT_ILLUSION_SHIELD = 34,
        EFFECT_HALLOWEEN_BLESS = 35,
        EFFECT_HALLOWEEN_WRATH = 36,
        EFFECT_HALLOWEEN_CRY = 37,
        EFFECT_HALLOWEEN_FOOD = 38,
        EFFECT_HALLOWEEN_DRINK = 39,
        EFFECT_EXP2_INCREASE = 40,
        EFFECT_EXPDROP2_INCREASE = 41,
        EFFECT_EXPDISABLE2_INCREASE = 42,
        EFFECT_MOBILITY = 43,
        EFFECT_QUICKNESS = 44,
        EFFECT_DEFENSE = 45,
        EFFECT_WRATH = 46,
        EFFECT_WIZARDRY = 47,
        EFFECT_HEALTH = 48,
        EFFECT_MANA = 49,
        EFFECT_ADDSTRENGTH = 50,
        EFFECT_ADDAGILITY = 51,
        EFFECT_ADDVITALITY = 52,
        EFFECT_ADDENERGY = 53,
        EFFECT_ADDLEADERSHIP = 54,
        EFFECT_POISON = 55,
        EFFECT_ICE = 56,
        EFFECT_HARDEN = 57,
        EFFECT_MAGUMSADEFENSEDOWN = 58,
        EFFECT_STERN = 61,
        EFFECT_IMMUNETOMAGIC = 63,
        EFFECT_IMMUNETOHARM = 64,
        EFFECT_ILLUSIONPARALYZE = 65,
        EFFECT_DAMAGEREF = 71,
        EFFECT_SLEEP = 72,
        EFFECT_NEIL = 74,
        EFFECT_SAHAMUTT = 75,
        EFFECT_DAMAGEDOWN = 76,
        EFFECT_DEFENSEDOWN = 77,
        EFFECT_BLOSSOMWINE = 78,
        EFFECT_BLOSSOMCAKE = 79,
        EFFECT_BLOSSOMPETAL = 80,
        EFFECT_SWORDPOWER = 81,
        EFFECT_MAGICCIRCLE = 82,
        EFFECT_FLAMESTRIKE = 83,
        EFFECT_GIGANTICSTORM = 84,
        EFFECT_LIGHTINGSHOCK = 85,
        EFFECT_PARALYZE = 86,
        EFFECT_SEALHELING = 87,
        EFFECT_SEALDIVINITY = 88,
        EFFECT_SCROLLBATTLE = 89,
        EFFECT_SCROLLSTRENGTH = 90,
        EFFECT_SANTABLESS = 91,
        EFFECT_SANTAHEALING = 92,
        EFFECT_SANTAPROTECTION = 93,
        EFFECT_SANTASTRENGTH = 94,
        EFFECT_SANTADEFENSE = 95,
        EFFECT_SANTAQUICKNESS = 96,
        EFFECT_SANTAFORTUNE = 97,
        EFFECT_GUARDIANTALISMAN = 99,
        EFFECT_ITEMPROTECTIONTALISMAN = 100,
        EFFECT_MASTEREXP_INCREASE = 101,
        EFFECT_MASTEREXPDROP_INCREASE = 102,
        EFFECT_GLADIATORBUFF = 103
    };
    public enum SkillList
    {
        POISON = 0x1,
        METEO = 0x2,
        THUNDER = 0x3,
        FIREBALL = 0x4,
        FLAME = 0x5,
        TELEPORT = 0x6,
        SLOW = 0x7,
        STORM = 0x8,
        EVIL = 0x9,
        HELL = 0xa,
        POWERWAVE = 0xb,
        FLASH = 0xc,
        BLAST = 0xd,
        INFERNO = 0xe,
        TARGET_TELEPORT = 0xf,
        MAGICDEFENSE = 0x10,
        ENERGYBALL = 0x11,
        BLOCKING = 0x12,
        SWORD1 = 0x13,
        SWORD2 = 0x14,
        SWORD3 = 0x15,
        SWORD4 = 0x16,
        SWORD5 = 0x17,
        CROSSBOW = 0x18,
        BOW = 0x19,
        HEALING = 0x1a,
        DEFENSE = 0x1b,
        ATTACK = 0x1c,
        CALLMON1 = 0x1e,
        CALLMON2 = 0x1f,
        CALLMON3 = 0x20,
        CALLMON4 = 0x21,
        CALLMON5 = 0x22,
        CALLMON6 = 0x23,
        CALLMON7 = 0x24,
        WHEEL = 0x29,
        BLOWOFFURY = 0x2a,
        STRIKE = 0x2b,
        KNIGHTSPEAR = 0x2f,
        KNIGHTADDLIFE = 0x30,
        KNIGHTDINORANT = 0x31,
        ELFHARDEN = 0x33,
        PENETRATION = 0x34,
        DEFENSEDOWN = 0x37,
        SWORD6 = 0x38,
        LCROSSBOW = 0x36,
        EXPPOISON = 0x26,
        EXPICE = 0x27,
        EXPHELL = 0x28,
        EXPHELL_START = 0x3a,
        IMPROVE_AG_REFILL = 0x35,
        DEVILFIRE = 0x32,
        COMBO = 0x3b,
        SPEAR = 0x3c,
        FIREBURST = 0x3d,
        DARKHORSE_ATTACK = 0x3e,
        RECALL_PARTY = 0x3f,
        ADD_CRITICALDAMAGE = 0x40,
        ELECTRICSPARK = 0x41,
        LONGSPEAR = 0x42,
        RUSH = 0x2c,
        JAVALIN = 0x2d,
        DEEPIMPACT = 0x2e,
        ONE_FLASH = 0x39,
        DEATH_CANNON = 0x49,
        SPACE_SPLIT = 0x4a,
        BRAND_OF_SKILL = 0x4b,
        STUN = 0x43,
        REMOVAL_STUN = 0x44,
        ADD_MANA = 0x45,
        INVISIBLE = 0x46,
        REMOVAL_INVISIBLE = 0x47,
        REMOVAL_MAGIC = 0x48,
        SUMMON = 0xc8,
        IMMUNE_TO_MAGIC = 0xc9,
        IMMUNE_TO_HARM = 0xca,
    };
    public enum PlayerAuthority
    {
        USER = 1,
        ADMIN = 2,
        SERVERADMIN = 4,
        GM = 8,
        SUBGM = 10

    };
    enum OBJECT_TYPE
    {
        OBJECT_EMPTY = -1,
        OBJECT_MONSTER = 2,
        OBJECT_USER = 1,
        OBJECT_NPC = 3
    };
    enum LoginMessage_e
    {
        // 0x00 - The password that the user inputted was incorrect
        LME_InvalidPassword,
        // 0x01 - The username and password were successfully validated
        LME_DataValid,
        // 0x02 - The username that the user inputted was incorrect
        LME_InvalidAccount,
        // 0x03 - The username is already connected
        LME_AccountAlreadyConnected,
        // 0x04 - The server is full
        LME_ServerFull,
        // 0x05 - The username is blocked from the server
        LME_AccountBlocked,
        // 0x06 - The user has an old version of the client
        LME_NewVersion,
        // 0x07 - Unknown error
        LME_ConnectionError1,
        // 0x08 - The user sent invalid data too many times
        LME_ConnectionClosedDueToInvalidPassword,
        // 0x09 - Unknown error
        LME_NoChargeInfo,
        // 0x0A - Unknown error
        LME_IndividualSubscriptionTermOver,
        // 0x0B - Unknown error
        LME_IndividualSubscriptionTimeOver,
        // 0x0C - Unknown error
        LME_IPSubscriptionTermOver,
        // 0x0D - Unknown error
        LME_IPSubscriptionTimeOver,
        // 0x0E - Unknown error
        LME_ConnectionError2,
        // 0x0F - Unknown error
        LME_ConnectionError3,
        // 0x10 - Unknown error
        LME_ConnectionError4,
        // 0x11 - Unknown error
        LME_BelowRequiredAge
    };
    public enum AccountAuthority
    {
        NOTICE = 1,
        ACCOUNTBLOCK = 2,
        DISCONNECT = 4,
        SETPOSITION = 8,
        COPYCHAR = 10,
        CHATBAN = 20,
     //   FULLCONTROL = 0xFFFFFFFF

    };
    public enum PlayerPenalty
    {
        ACCOUNTBLOCK = 1,
        CHATBAN = 2,
        ITEMDONTTOUCH = 4,
    };
    public enum TradeException
    {
        OPTION_TRADE = 1
    };

    public enum PlayerState
    {
        NONE = 0,
        CREATE = 1,
        PLAYING = 2,
        DYING = 4,
        DIECMD = 8,
        DIED = 10,
        DELCMD = 20
    };
    public enum ClientServiceState
    {
        LOGIN = 1,
        LOGINOKv2,
        CHARACTERVIEW = 2,
        GAMEPLAYING = 3
    };
    public enum ExitState
    {
        EXIT = 0,
        BACK = 1,
        SERVERLIST = 2
    };
    public enum SoccerState
    {
        BEATTACK = 2,
        FILLENERGY = 3,
        GUILDWAREND = 4,
        START = 5,
        PAUSE = 6,
        STOP = 7,
        BILLSEND = 1000
    };
    //public enum CreatureType
    //{
    //    PLAYER = 0,
    //    MONSTER = 1

    //};
    public enum ViewPortState
    {
        MAPJOIN = 0xF3,
        CREATE = 0x12,
        MONSTERCREATE = 0x13,
        DESTROY = 0x14
    };
    public enum GuildState
    {
        DISCONNECT = 100,
        SETPOSITION = 101,
        COPYCHAR = 102,
        ACCOUNTBLOCK = 103,
        CHATBAN = 104,
        ACCOUNTBLOCKFREE = 105,
        CHATBANFREE = 106,
        ITEMCREATE = 107,
        GUILDSETPOSITION = 108,
        GUILDWARSTART = 109,
        GUILDWARSTOP = 110,
        GUILDWAREND = 111,
        GUILDDISCONNECT = 112
    }

    //#define UMCMD_GUILDWAR 200 // Guild Wars
    //#define UMCMD_BILLCHECK 201 // sprawdzić czas pozostały
    //#define UMCMD_BATTLESOCCERWAR 202 // walki piłka nożna
    //#define UMCMD_TRADEOPTION 203 // wniosek on / off

    //#define MAX_MANAGER 5


    public enum MapIndex
    {
        LORENCIA = 0x0,
        DUNGEON = 0x1,
        DEVIAS = 0x2,
        NORIA = 0x3,
        LOSTTOWER = 0x4,
        RESERVED = 0x5,
        BATTLESOCCER = 0x6,
        ATHLANS = 0x7,
        TARKAN = 0x8,
        DEVILSQUARE = 0x9,
        ICARUS = 0xa,
        BLOODCASTLE1 = 0xb,
        BLOODCASTLE2 = 0xc,
        BLOODCASTLE3 = 0xd,
        BLOODCASTLE4 = 0xe,
        BLOODCASTLE5 = 0xf,
        BLOODCASTLE6 = 0x10,
        BLOODCASTLE7 = 0x11,
        CHAOSCASTLE1 = 0x12,
        CHAOSCASTLE2 = 0x13,
        CHAOSCASTLE3 = 0x14,
        CHAOSCASTLE4 = 0x15,
        CHAOSCASTLE5 = 0x16,
        CHAOSCASTLE6 = 0x17,
        KALIMA1 = 0x18,
        KALIMA2 = 0x19,
        KALIMA3 = 0x1a,
        KALIMA4 = 0x1b,
        KALIMA5 = 0x1c,
        KALIMA6 = 0x1d,
        CASTLESIEGE = 0x1e,
        CASTLEHUNTZONE = 0x1f,
        DEVILSQUARE2 = 0x20,
        AIDA = 0x21,
        CRYWOLF_FIRSTZONE = 0x22,
        CRYWOLF_SECONDZONE = 0x23,
        KALIMA7 = 0x24,
        KANTURU1 = 0x25,
        KANTURU2 = 0x26,
        KANTURU_BOSS = 0x27,
    };

    enum EventType
    {
        NONE = 0x0,
        PARTY = 0x1,
        DEVILSQUARE = 0x2,
        CHAOSCASTLE = 0x3,
        BLOODCASTLE = 0x4,
        CRYWOLF = 0x5,
    };

    public enum ResistenceType
    {
        MAX_RESISTENCE = 7,
        ICE = 0,
        POISON = 1,
        LIGHTNING = 2,
        FIRE = 3,
        EARTH = 4,
        WIND = 5,
        WATER = 6
    };
    public enum PlayerConnectionState
    {
        PLAYER_EMPTY = 0,
        PLAYER_CONNECTED = 1,
        PLAYER_LOGGED = 2,
        PLAYER_PLAYING = 3
    };


    public enum CreatureType
    {
        OBJ_EMPTY = -1,
        OBJ_MONSTER = 2,
        OBJ_USER = 1,
        OBJ_NPC = 3,
        MAX_PARTY_LEVEL_DIFFERENCE = 130,
        MAX_MAGIC = 60,
        MAX_VIEWPORT = 75
    };
    public enum FriendState
    {
        FRIEND_SERVER_STATE_LOGIN_FAIL = 0,
        FRIEND_SERVER_STATE_OFFLINE = 1,
        FRIEND_SERVER_STATE_ONLINE = 2
    };
    public enum WindowType
    {
        TYPE_INVENTORY = 0,
        TYPE_TRADE = 1,
        TYPE_WAREHOUSE = 2,
        TYPE_CHAOSMACHINE = 3,
        TYPE_PERSONALSHOP = 4,
        TYPE_PETTRAINER = 5,
    };
    public enum ServerProtocole
    {
        KOR,
        ENG,
        JPN,
        CHS,
        VTM,

    }
    public enum KorServerProtocole
    {
        Walk = 0xD3,
        Move = 0xDF,
        Attack = 0xD7
    };
   
    public enum KorClientProtocole
    {
        Walk = 0x1D,
        Move = 0xD6,
        Attack = 0xDC
    };
    public enum EngServerProtocole
    {
        Walk = 0xD4,
        Move = 0x11,
        Attack = 0x15
    };
   
    public enum EngClientProtocole
    {
        Walk = 0x1D,
        Move = 0xD6,
        Attack = 0xDC
    };
    public enum JpnServerProtocole
    {
        Walk = 0x1D,
        Move = 0xD6,
        Attack = 0xDC
    };
   
    public enum JpnClientProtocole
    {
        Walk = 0xD3,
        Move = 0xDF,
        Attack = 0xD7
    };

    public enum ChsServerProtocole
    {
        Walk = 0xD7,
        Move = 0xD0,
        Attack = 0xD9
    };
    
    public enum ChsClientProtocole
    {
        Walk = 0x1D,
        Move = 0xD6,
        Attack = 0xDC
    };
}
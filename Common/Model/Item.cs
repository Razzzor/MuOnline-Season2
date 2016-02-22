using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Model
{
    
    // ----------------------------------------------------------------------
    enum ITEMCREATE_PLACE
    {
        INVENTORY = 0xEB,
        CHAOSBOX = 0xFF,
    };
    // ----------------------------------------------------------------------
    enum VIEWPORT_WINGS03
    {
        WINGS_OF_STORM = 0x07,
        WINGS_OF_VORTEX = 0x08,
        WINGS_OF_ILLUSION = 0x0C,
        WINGS_OF_HURRICANE = 0x10,
        MANTLE_OF_MONARCH = 0x14,
        WINGS_OF_MISERY = 0x18,
        WINGS_OF_DESPAIR = 0x1C,
        WINGS_OF_DIMENSION = 0x1B,
        MINI_WINGS_OF_DL = 0x20,
        MINI_WINGS_OF_SUM = 0x40,
        MINI_WINGS_OF_ELF = 0x60,
        MINI_WINGS_OF_DW = 0x80,
        MINI_WINGS_OF_DK = 0xA0,
    };
    // ----------------------------------------------------------------------
    enum VIEWPORT_FENRIR
    {
        FENRIR_TYPE = 0x1A25,
        FENRIR_EMPTY = 0x00,
        FENRIR_GOLD = 0x03,
    };
    // ----------------------------------------------------------------------
    enum VIEWPORT_QUEST03_ITEMS
    {
        FLAME_OF_DEATH = 0x1C41,
        HELL_MAINE_HORN = 0x1C42,
        PHOENIX_FEATHER = 0x1C43,
    };
    // ----------------------------------------------------------------------
    enum VIEWPORT_EVENT_DROP_BOX
    {
        PURPLE_MISTERY_BOX = 0x1C39,
        PINK_MISTERY_BOX = 0x1C38,
        GREEN_MISTERY_BOX = 0x1C37,
        GAME_MASTER_BOX = 0x1C34,
        HALOWEEN_PUMPKIN = 0x1C2D,
    };

    enum SlotPlace_e
    {
        SPE_NONE = -1,
        SPE_LEFTHAND,
        SPE_RIGHTHAND,
        SPE_HELM,
        SPE_ARMOR,
        SPE_PANTS,
        SPE_GLOVES,
        SPE_BOOTS,
        SPE_WING,
        SPE_PET,
        SPE_PENDANT,
        SPE_RING
    };
    enum ExcellentOptions
    {
        Excellent_Money,			// 1
        Excellent_DefenseRate,		// 2
        Excellent_DamageReflect,	// 4
        Excellent_DamageReduce,		// 8
        Excellent_ExtraMana,		// 16
        Excellent_ExtraLife,		// 32
        Excellent_DamageRate = Excellent_ExtraLife,
        Excellent_AttackRate = Excellent_ExtraMana,
        Excellent_AttackRate2 = Excellent_DamageReduce,
        Excellent_AttackSpeed = Excellent_DamageReflect,
        Excellent_MonsterDieLife = Excellent_DefenseRate,
        Excellent_MonsterDieMana = Excellent_Money,
        Excellent_BlueFenrir = Excellent_Money,
        Excellent_BlackFenrir = Excellent_DefenseRate,
    };

   public class Item : Creature
    {
        public int type;
        public int index;
        public int durability;
        public int level;
        public int skill;
        public int luck;
        public int option1;
        public int option2;
        public int option3;
        public int excellentOption1;
        public int excellentOption2;
        public int excellentOption3;
        public int excellentOption4;
        public int excellentOption5;
        public int excellentOption6;
        public int option;
        public int ancient;
        public int harmonyType;
        public int harmonyLevel;
        public int count;

        public int requiredStrength;
        public int requiredAgility;
        public int requiredVitality;
        public int requiredEnergy;
        public int requiredCommand;
        public int requiredLevel;
        public int requiredRace;
        public int sizeX;
        public int sizeY;
        public int speed;
        
        internal void Release()
        {
           
        }
    }
}

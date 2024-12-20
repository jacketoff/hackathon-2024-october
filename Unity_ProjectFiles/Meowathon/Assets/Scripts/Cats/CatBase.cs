using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Cat", menuName = "Cat/Create new cat")]
public class CatBase : ScriptableObject
{
    [SerializeField] string name;
    [SerializeField] string description;
    [SerializeField] Sprite frontSprite;
    [SerializeField] Sprite backSprite;

    [SerializeField] CatType type1;
    [SerializeField] CatType type2;

    [SerializeField] int maxHp;
    [SerializeField] int attack;
    [SerializeField] int defense;
    [SerializeField] int spAttack;
    [SerializeField] int spDefense;
    [SerializeField] int speed;
    [SerializeField] List<LearnableMove> learnableMoves;

    public string Name {
        get { return name; }
    }
    public string Description {
        get { return description; }
    }

    public Sprite FrontSprite {
        get { return frontSprite; }
    }

    public Sprite BackSprite {
        get { return backSprite; }
    }

    public CatType Type1 {
        get { return type1; }
    }

    public CatType Type2 {
        get { return type2; }
    }

    public int MaxHp {
        get { return maxHp; }
    }

    public int Attack {
        get { return attack; }
    }

    public int Defense {
        get { return defense; }
    }

    public int SpAttack {
        get { return spAttack; }
    }

    public int SpDefense {
        get { return spDefense; }
    }

    public int Speed {
        get { return speed; }
    }

    public List<LearnableMove> LearnableMoves {
        get { return learnableMoves; }
    }
}
[System.Serializable]
public class LearnableMove
{
    [SerializeField] MoveBase moveBase;
    [SerializeField] int level;

    public MoveBase Base {
        get { return moveBase; }
    }
    public int Level {
        get { return level; }
    }
}
public enum CatType
{
    None,
    Normal,
    Fire,
    Water
}

public class TypeChart

    {
        static float [][] chart = 
        {
            //                   NOR   FIR    WAT
            /*NOR*/ new float[]  {1f,   1f,    1f},
            /*FIR*/ new float[] { 1f, 0.5f, 0.5f },
            /*WAT*/ new float[]  {1f,   2f,    0.5f}
        };

        public static float GetEffectiveness (CatType attackType, CatType defenseType)
        {
            if (attackType == CatType. None || defenseType == CatType. None)
                return 1;

            int row = (int)attackType - 1;
            int col = (int)defenseType - 1;

            return chart [row][col];
        }
    }

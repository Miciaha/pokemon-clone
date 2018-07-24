using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BasePokemon : MonoBehaviour {

    public string PName;
    public Sprite Image;
    public BiomeList BiomeFound;
    public PokemonType Type;
    public Rarity Rarity;
    public Stat AttackStat;
    public Stat DefenceStat;
    public int MaxHP;
    private int HP;

    private int level;

    public bool canEvolve;

    public PokemonEvolution evolveTo;

    public PokemonStats pokemonStats;

	// Use this for initialization
	void Start () {
        MaxHP = HP;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    /*
    public BasePokemon(string name, Sprite image, BiomeList biome, PokemonType type, Rarity rarity, Stat attack, Stat defense,int maxHP) {
        PName = name;
        Image = image;
        BiomeFound = biome;
        Type = type;
        Rarity = rarity;
        AttackStat = attack;
        DefenceStat = defense;
        MaxHP = maxHP;
    }
    */

    public void AddMember(BasePokemon bp)
    {
        this.PName = bp.PName;
        this.Image = bp.Image;
        this.BiomeFound = bp.BiomeFound;
        this.Type = bp.Type;
        this.Rarity = bp.Rarity;
        this.HP = bp.HP;
        this.MaxHP = bp.MaxHP;
        this.AttackStat = bp.AttackStat;
        this.DefenceStat = bp.DefenceStat;
        this.pokemonStats = bp.pokemonStats;
        this.canEvolve = bp.canEvolve;
        this.evolveTo = bp.evolveTo;
        this.level = bp.level;

    }

    
}

public enum Rarity
{
    VeryCommon,
    Common,
    SemiRare,
    Rare,
    VeryRare
}

public enum PokemonType
{
    Flying,
    Ground,
    Rock,
    Steel,
    Fire,
    Water,
    Grass,
    Ice,
    Electric,
    Psychic,
    Dark,
    Dragon,
    Fighting,
    Normal
}

[System.Serializable]
public class PokemonEvolution
{
    public BasePokemon nextEvolution;
    public int levelUpLevel;
}

[System.Serializable]
public class PokemonStats
{
    public int AttackStat;
    public int DefenseStat;
    public int SpeedStat;
    public int SpAttackStat;
    public int SpDefenseStat;
    public int Evasion;
}
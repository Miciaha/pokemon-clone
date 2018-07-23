using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BasePokemon : MonoBehaviour {

    public string PName;
    public Sprite image;
    public BiomeList biomeFound;
    public PokemonType type;
    public Rarity rarity;
    public Stat AttackStat;
    public Stat DefenceStat;
    private int maxHP;
    public int HP;

    private int level;

    public bool canEvolve;

    public PokemonEvolution evolveTo;

    public PokemonStats pokemonStats;

	// Use this for initialization
	void Start () {
        maxHP = HP;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AddMember(BasePokemon bp)
    {
        this.PName = bp.PName;
        this.image = bp.image;
        this.biomeFound = bp.biomeFound;
        this.type = bp.type;
        this.rarity = bp.rarity;
        this.HP = bp.HP;
        this.maxHP = bp.maxHP;
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
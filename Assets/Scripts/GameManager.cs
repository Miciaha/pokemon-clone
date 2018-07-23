using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public GameObject playerCamera;
    public GameObject battleCamera;
    public GameObject player;

    public List<BasePokemon> allPokemon = new List<BasePokemon>();
    public List<PokemonMoves> allMoves = new List<PokemonMoves>();


    public Transform defensePodium;
    public Transform attackPodium;
    public GameObject emptyPoke;

    public BattleManager bm;

	// Use this for initialization
	void Start () {
        playerCamera.SetActive(true);
        battleCamera.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void EnterBattle(Rarity rarity)
    {
        playerCamera.SetActive(false);
        battleCamera.SetActive(true);

        BasePokemon battlePokemon = GetRandomPokemonFromList(GetPokemonByRarity(rarity));

        Debug.Log(battlePokemon.name);

        player.GetComponent<PlayerMovement>().isAllowedToMove = false;

        GameObject dPoke = Instantiate(emptyPoke, defensePodium.transform.position, Quaternion.identity) as GameObject;

        dPoke.transform.parent = defensePodium;

        BasePokemon tempPoke = dPoke.AddComponent<BasePokemon>() as BasePokemon;
        tempPoke.AddMember(battlePokemon);

        dPoke.GetComponent<SpriteRenderer>().sprite = battlePokemon.image;

        bm.ChangeMenu(BattleMenu.Selection);
    }

    public List<BasePokemon> GetPokemonByRarity(Rarity rarity)
    {
        List<BasePokemon> returnPokemon = new List<BasePokemon>();
        foreach (BasePokemon Pokemon in allPokemon)
        {
            if (Pokemon.rarity == rarity)
            {
                returnPokemon.Add(Pokemon);
            }

        }

        return returnPokemon;
    }

    public BasePokemon GetRandomPokemonFromList(List<BasePokemon> pokeList)
    {
        BasePokemon poke = new BasePokemon();
        int pokeIndex = Random.Range(0, pokeList.Count - 1);
        poke = pokeList[pokeIndex];
        return poke;
    }
}

[System.Serializable]
public class PokemonMoves
{
    string Name;
    public MoveType category;
    public Stat moveStat;
    public PokemonType moveType;
    public int PP;
    public float power;
    public float accuracy;
}

[System.Serializable]
public class Stat
{
    public float minimum;
    public float maximum;
}

public enum MoveType
{
    Physical,
    Special,
    Status
}
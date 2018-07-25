using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    public GameObject playerCamera;
    public GameObject battleCamera;
    public GameObject overWorldPlayer;

    public Player playerOwns;

    public List<BasePokemon> allPokemon = new List<BasePokemon>();
    public List<PokemonMoves> allMoves = new List<PokemonMoves>();

    public Sprite[] pokemonSprites;


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
        //change camera
        playerCamera.SetActive(false);
        battleCamera.SetActive(true);

        //Find random pokemon
        BasePokemon battlePokemon = GetRandomPokemonFromList(GetPokemonByRarity(rarity));


        Debug.Log(battlePokemon.name);

        //stop player from moving
        overWorldPlayer.GetComponent<PlayerMovement>().isAllowedToMove = false;

        //instantiate enemy pokemon and player pokemon
        GameObject dPoke = Instantiate(emptyPoke, defensePodium.transform.position, Quaternion.identity) as GameObject;

        dPoke.transform.parent = defensePodium;

        BasePokemon tempPoke = dPoke.AddComponent<BasePokemon>() as BasePokemon;
        tempPoke.AddMember(battlePokemon);

        GameObject aPoke = Instantiate(emptyPoke, attackPodium.transform.position, Quaternion.identity) as GameObject;

        aPoke.transform.parent = attackPodium;
        
        aPoke.GetComponent<SpriteRenderer>().sprite = playerOwns.ownedPokemon[0].pokemon.Image;
        dPoke.GetComponent<SpriteRenderer>().sprite = battlePokemon.Image;

        //Sending pokemon to battle manager
        bm.wildPokemon = battlePokemon;

        //Add unique pokemon variables to battle menus
        //moves
        bm.movesList = playerOwns.ownedPokemon[0].moves;
        bm.moveO.text = playerOwns.ownedPokemon[0].moves[0].Name;
        bm.moveT.text = playerOwns.ownedPokemon[0].moves[1].Name;
        //bm.moveTH.text = playerOwns.ownedPokemon[0].moves[2].Name;
        //bm.movef.text = playerOwns.ownedPokemon[0].moves[3].Name;


        //Names, Levels, 
        bm.enemyName.text = battlePokemon.PName;
        bm.pokemonName.text = playerOwns.ownedPokemon[0].pokemon.name;
        bm.enemyLevel.text = battlePokemon.level.ToString();
        bm.pokemonLevel.text = playerOwns.ownedPokemon[0].pokemon.level.ToString();

        bm.ChangeMenu(BattleMenu.Selection);
    }

    public List<BasePokemon> GetPokemonByRarity(Rarity rarity)
    {
        List<BasePokemon> returnPokemon = new List<BasePokemon>();
        foreach (BasePokemon Pokemon in allPokemon)
        {
            if (Pokemon.Rarity == rarity)
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

    public void ExitBattle()
    {
        playerCamera.SetActive(true);
        battleCamera.SetActive(false);
        overWorldPlayer.GetComponent<PlayerMovement>().isAllowedToMove = true;
    }
}

[System.Serializable]
public class PokemonMoves
{
    public string Name;
    public MoveType category;
    public Stat moveStat;
    public PokemonType moveType;
    private int PP;
    public int maxPP;
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
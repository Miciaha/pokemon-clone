using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {

    public List<BasePokemon> ownedPokemon = new List<BasePokemon>();



	void Start () {
	
	}
	
	void Update () {
	
	}
}

[System.Serializable]
public class OwnedPokemon
{
    public string NickName;
    public BasePokemon pokemon;
    public int level;
    public List<PokemonMoves> moves = new List<PokemonMoves>();
}
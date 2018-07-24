using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEditor;

public static class World{

    public static readonly List<BasePokemon> Pokemon = new List<BasePokemon>();
    public static readonly List<PokemonMoves> Moves = new List<PokemonMoves>();
    public static readonly List<Items> Items = new List<Items>();
    public static readonly List<Pokeball> Pokeballs = new List<Pokeball>();
    public static readonly Sprite[] sprites = AssetDatabase.LoadAllAssetRepresentationsAtPath("Assets/Spritesheets/Pokemon/pokemon_sheet.png").OfType<Sprite>().ToArray();


    public const int POKEMON_ID_BULBY = 1;
    public const int POKEMON_ID_BIGBULBY = 2;
    public const int POKEMON_ID_HOTBOI = 3;
    public const int POKEMON_ID_FLYBOI = 4;
    public const int POKEMON_ID_ELECTRICBOI = 5;

    public const int MOVE_ID_TACKLE = 1;
    public const int MOVE_ID_GROWL = 2;
    public const int MOVE_ID_TAILWHIP = 3;
    public const int MOVE_ID_DANCE = 4;
    public const int MOVE_ID_MOCKMOTHER = 5;

    public const int ITEM_ID_POTION = 1;
    public const int ITEM_ID_ANTIDOTE = 2;

    public const int POKEBALL_ID_POKEBALL = 1;
    public const int POKEBALL_ID_GREATBALL = 2;
    public const int POKEBALL_ID_ULTRABALL = 3;

    static World()
    {
        PopulatePokemon();
        //PopulateMoves();
        //PopulateItems();
        //PopulatePokeballs();
    }

    private static void PopulatePokemon()
    {
        //BasePokemon bulby = new BasePokemon(POKEMON_ID_BULBY,Sprite)
    }
}

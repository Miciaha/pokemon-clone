using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class BattleManager : MonoBehaviour {

    public BattleMenu currentMenu;

    [Header("Enemy")]
    public GameObject EnemyInfo;
    public Text enemyName;
    private string enemyNameT;
    public Text enemyLevel;
    private string enemyLevelT;
    public BasePokemon wildPokemon;

    [Header("Trainer")]
    public Text pokemonName;
    private string pokemonNameT;
    public Text pokemonLevel;
    private string pokemonLevelT;
    public List<PokemonMoves> movesList;

    [Header("Selection")]
    public GameObject SelectionMenu;
    public GameObject SelectionInfo;
    public Text selectionInfoText;
    public Text fight;
    private string fightT;
    public Text bag;
    private string bagT;
    public Text pokemon;
    private string pokemonT;
    public Text run;
    private string runT;

    [Header("Moves")]
    public GameObject movesMenu;
    public GameObject movesDetails;
    public Text PP;
    public Text pType;
    public Text moveO;
    private string moveOT;
    public Text moveT;
    private string moveTT;
    public Text moveTH;
    private string moveTHT;
    public Text movef;
    private string movefT;

    [Header("Message")]
    public GameObject MessagePanel;
    public Text MessageText;

    [Header("Misc")]
    public int currentSelection;

    public Player playerOwns;
    public GameManager gm;
    

    void Start () {
        fightT = fight.text;
        bagT = bag.text;
        pokemonT = pokemon.text;
        runT = run.text;
         
        moveOT = moveO.text;
        moveTT = moveT.text;
        moveTHT = moveTH.text;
        movefT = movef.text;

        pokemonLevel.text = "Lv" + pokemonLevel.text;
        enemyLevel.text = "Lv" + enemyLevel.text;

    }
	
	void Update () {

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(currentSelection < 4)
            {
                currentSelection++;
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(currentSelection > 0)
            {
                currentSelection--;
            }
        }
        if(currentSelection == 0)
        {
            currentSelection = 1;
        }

        switch (currentMenu)
        {
            case BattleMenu.Fight:
                switch (currentSelection)
                {
                    case 1:
                        moveO.text = "> " + moveOT;
                        moveT.text = moveTT;
                        moveTH.text = moveTHT;
                        movef.text = movefT;
                        if (Input.GetKeyDown(KeyCode.Return)) { UseAbility(moveOT, 0); }
                        if (Input.GetKeyDown(KeyCode.Backspace)) { ChangeMenu(BattleMenu.Selection); }
                        break;
                    case 2:
                        moveO.text = moveOT;
                        moveT.text = "> " + moveTT;
                        moveTH.text = moveTHT;
                        movef.text = movefT;
                        if (Input.GetKeyDown(KeyCode.Backspace)) { ChangeMenu(BattleMenu.Selection); }
                        break;
                    case 3:
                        moveO.text = moveOT;
                        moveT.text = moveTT;
                        moveTH.text = "> " + moveTHT;
                        movef.text = movefT;
                        if (Input.GetKeyDown(KeyCode.Backspace)) { ChangeMenu(BattleMenu.Selection); }
                        break;
                    case 4:
                        moveO.text = moveOT;
                        moveT.text = moveTT;
                        moveTH.text = moveTHT;
                        movef.text = "> " + movefT;
                        if (Input.GetKeyDown(KeyCode.Backspace)) { ChangeMenu(BattleMenu.Selection); }
                        break;
                    
                        
                }

                break;
            case BattleMenu.Selection:
                switch (currentSelection)
                {
                    case 1:
                        fight.text = "> " + fightT;
                        bag.text = bagT;
                        pokemon.text = pokemonT;
                        run.text = runT;
                        selectionInfoText.text = "Attack opponent with current Pokemon!";
                        if (Input.GetKeyDown(KeyCode.Return)) { ChangeMenu(BattleMenu.Fight); }
                        break;
                    case 2:
                        fight.text = fightT;
                        bag.text = "> " + bagT;
                        pokemon.text = pokemonT;
                        run.text = runT;
                        selectionInfoText.text = "Check your bag for items!";
                        break;
                    case 3:
                        fight.text = fightT;
                        bag.text = bagT;
                        pokemon.text = "> " + pokemonT;
                        run.text = runT;
                        selectionInfoText.text = "Select a different Pokemon!";
                        break;
                    case 4:
                        fight.text = fightT;
                        bag.text = bagT;
                        pokemon.text = pokemonT;
                        run.text = "> " + runT;
                        selectionInfoText.text = "Leave this battle behind you.";
                        if (Input.GetKeyDown(KeyCode.Return)) { gm.ExitBattle(); }
                        break;

                    
                }

                break;
        }
    }

    public void ChangeMenu(BattleMenu m)
    {
        currentMenu = m;
        currentSelection = 1;
        switch (m)
        {
            case BattleMenu.Selection:
                SelectionMenu.gameObject.SetActive(true);
                SelectionInfo.gameObject.SetActive(true);
                movesMenu.gameObject.SetActive(false);
                movesDetails.gameObject.SetActive(false);
                MessagePanel.gameObject.SetActive(false);
                EnemyInfo.SetActive(true);
                break;

            case BattleMenu.Fight:
                SelectionMenu.gameObject.SetActive(false);
                SelectionInfo.gameObject.SetActive(false);
                movesMenu.gameObject.SetActive(true);
                movesDetails.gameObject.SetActive(true);
                MessagePanel.gameObject.SetActive(false);
                EnemyInfo.SetActive(true);
                break;

            case BattleMenu.Message:
                SelectionMenu.gameObject.SetActive(false);
                SelectionInfo.gameObject.SetActive(false);
                movesMenu.gameObject.SetActive(false);
                movesDetails.gameObject.SetActive(false);
                MessagePanel.gameObject.SetActive(true);
                EnemyInfo.SetActive(true);
                Messages();
                break;
        }
    }

     private void UseAbility(string moveName, int moveNum)
    {
        var ability = movesList[moveNum];

        MessageText.text = pokemonName.text + " used " + moveName;
        
        if(ability.power > 0)
        {
            wildPokemon.HP = (int)ability.power - wildPokemon.HP;
            MessageText.text += "\n" + (int)ability.power + "damage done.";

            if (wildPokemon.HP < 1)
            {
                gm.ExitBattle();
            }
            else
            {
                //ChangeMenu(BattleMenu.Selection);
            }
        }
        else
        {
            MessageText.text += "That ability doesn't cause damage";
        }

        ChangeMenu(BattleMenu.Message);

    }

    private void Messages()
    {
        if (Input.GetKeyDown(KeyCode.Return)) { ChangeMenu(BattleMenu.Selection); }
    }
}

public enum BattleMenu
{
    Selection, 
    Pokemon,
    Bag,
    Fight,
    Message
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class CombatSys
{
    //To use CombatSys
    //
    ///CombatSys combat = new CombatSys();
    ///combat.CombatSysCall();
    //
    public int PlayerHP = 100, EnemyHP = 100, PDefense = 100, EDefense = 100, PStrength = 10, EStrength = 10; // EAgility, PAgility;
    public string ActionType = "", AttackType = "", duma = "", uzenet = "Kaka került a palacsintába!";
    //public int PlayerHP, EnemyHP, PDefense, PStrength, EDefense, EStrength; // EAgility, PAgility;
    //public string ActionType = "", AttackType = "", duma = "";
    public bool fight = true, haswon = false, haslost = false, EFelad = false, PFelad = false, error = false;
    public void CombatSysCall()
    {
        int runtime = 0;
        while (fight && !error)
        {
            //TODO: Call menu for ActionType and AttackType
            if (runtime % 2 == 0) ActionType = "attack_player-enemy";
            else ActionType = "attack_enemy-player";
            if (error) Console.WriteLine(uzenet);
            Console.WriteLine(EnemyHP + " " + PlayerHP + " " + EDefense + " " + PDefense);
            Combat();
            runtime++;
        }
        Console.WriteLine("Someone died!" + " " + EnemyHP + " " + PlayerHP + " " + EDefense + " " + PDefense);
        Console.WriteLine("End of fight`s been hit!");
    }
    public int rando(int min, int max)
    {
        Random random = new Random();
        return random.Next(min, max);
    }
	public void Combat()
	{
        bool megegyszer = false;
        do
        {
            switch (ActionType)
            {
                case "attack_player-enemy":
                    if (EDefense <= 0) EnemyHP -= PStrength;
                    else EDefense -= PStrength;
                    break;
                case "attack_enemy-player":
                    if (PDefense <= 0) PlayerHP -= EStrength;
                    else PDefense -= EStrength;
                    break;
                case "talk_player-enemy":
                    //TODO: Call menu
                    break;
                case "talk_enemy-player":
                    //TODO: Call enemy
                    break;
                case "taunt":
                    if (EDefense < 0) EStrength += rando(0, 30);
                    else { EStrength += rando(0, 30); EDefense -= rando(0, 90); }
                    break;
                default:
                    error = true;
                    break;
            }
        } while (megegyszer && !error);
        if (EnemyHP <= 0 || EFelad) { haswon = true; fight = false; }
        if (PlayerHP <= 0 || PFelad) { haslost = true; fight = false; }
    }
}

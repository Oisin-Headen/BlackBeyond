using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PatrolAI : PirateAiModel
{
    protected PatrolAI(PirateModel.PirateType pirateType, MapModel map, ModelLink modelLink, List<SpaceModel> patrolPoints) : base(pirateType, map, modelLink)
    {
        // Create Patrol route from patrol points
        // PP 1 -> PP 2 -> PP 3... combined into one list. When it reaches the end, it starts again.
    }

    public override void EndTurn()
    {
        // If Pursuing
            // Pursue
        // else
            // Patrol
    }



// Moved from PirateController
    //public void Engagement()
    //{
    //    while (pirateModel.GetCurrentMovement() != 0)
    //    {
    //        if (engaged == true)
    //        {
    //            //pirateShip scans spaces inside detection range
    //            //is target within detection range, if yes
    //            //is target within attackRange, attack, reduce movment counter by 1

           // this has been replaced with a shoot function
    //            int armor = PlayerModel.GetArmor();
    //            int currentHealth = PlayerModel.GetHealth();
    //            int shotDamage = pirateModel.GetDamage();
    //            int adjDamage = armor - shotDamage;
    //            if (adjDamage <=0)
    //            {
    //                adjDamage = 0;
    //            }
    //            int remainingHP = currentHealth - adjDamage;
    //            PlayerModel.UpdatePlayerHealth(remainingHP);
    //        }
    //        else
    //        {
    //            engaged = false;
    //            //follow patrol route for 1 movement
    //            //pirateShip scans spaces inside detection range
    //            //if target found engaged = true

    //        }
    //    }


    //}
}

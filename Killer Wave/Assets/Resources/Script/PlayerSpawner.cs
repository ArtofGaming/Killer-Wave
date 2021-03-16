using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    SOActorModel actorModel;
    GameObject playerShip;
      // Start is called before the first frame update
      void Start()
    {
        CreatePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreatePlayer()
    {
        actorModel = Object.Instantiate(Resources.Load
       ("Script/ScriptableObject/Player_Default"))
           as SOActorModel;
        playerShip = GameObject.Instantiate(actorModel.actor) as GameObject;
        playerShip.GetComponent<Player>().ActorStats(actorModel);

        
    }
}

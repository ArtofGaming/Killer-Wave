using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Create Actor", menuName = "Create Actor")]
public class SOActorModel : ScriptableObject
{
    public string actorName;
    public AttackType attackType;
    public enum AttackType
    {
        wave, player, flee, bullet
    }
    public string description;
    public int health;
    public int speed;
    public int hitPower;
    public int score;
    public GameObject actor;
    public GameObject actorsBullets;
      // Start is called before the first frame update
      void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

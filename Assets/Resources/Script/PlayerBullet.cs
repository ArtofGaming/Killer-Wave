using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour, IActorTemplate
{
    GameObject actor;
    public int hitPower;
    int health;
    int travelSpeed;
    [SerializeField]
    SOActorModel bulletModel;
    public int SendDamage()
    {
        return hitPower;
    }

      void Awake()
    {
        ActorStats(bulletModel);
    }
      // Start is called before the first frame update
      void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(travelSpeed, 0, 0) * Time.deltaTime;
    }

    public void TakeDamage(int incomingDamage)
    {
        health -= incomingDamage;
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }

    public void ActorStats(SOActorModel actorModel)
    {
        hitPower = actorModel.hitPower;
        health = actorModel.health;
        travelSpeed = actorModel.speed;
        actor = actorModel.actor;
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            if (other.GetComponent<IActorTemplate>() != null)
            {
                if (health >= 1)
                {
                    health -= other.GetComponent<IActorTemplate>
                      ().SendDamage();
                }
                if (health <= 0)
                {
                    Die();
                }
            }
        }
    }

}

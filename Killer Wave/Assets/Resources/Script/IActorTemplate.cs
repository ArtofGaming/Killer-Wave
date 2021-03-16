using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActorTemplate
{
    int SendDamge();
    void TakeDamage(int incomingDamage);
    void Die();
    void ActorStats(SOActorModel actorModel);
}

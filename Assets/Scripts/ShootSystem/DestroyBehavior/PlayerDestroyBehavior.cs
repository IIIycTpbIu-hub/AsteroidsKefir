using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestroyBehavior : BaseCustomDestoroyModel
{
    public override void CustomDestroyBehavior()
    {
        
    }

    void Start() 
    {
        GameManager.Instanse.GameEventSystem.Hit += OnHit;
    }

    void OnHit(int damage, GameObject victim)
    {
        if(victim.tag == gameObject.tag)
        {
            Debug.Log(health);
            GameManager.Instanse.GameEventSystem.UpdateHealthValueLaunch(health);
        }
    }

    IEnumerator TemporaryOff()
    {
        yield return new WaitForSeconds(3f);
        this.enabled = true;
        gameObject.GetComponent<ObjectCollisionView>().enabled = true;
    }
}

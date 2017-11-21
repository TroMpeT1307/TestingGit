using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [System.Serializable]
    public class PlayerStats
    {
        public int HP = 100;
    }
    public PlayerStats PS = new PlayerStats();

    public int fallBoundry = -20;

    void Update()
    {
        if (transform.position.y <= fallBoundry) 
        {
            DamagePlayer(999);
        }

    }

    public void DamagePlayer(int dmg)
    {
        PS.HP -= dmg;
        if (PS.HP <= 0)
        {
            Debug.Log("GET REKT");
            GameMaster.killPlayer(this); 
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{

    public static GameMaster gm;

    void Start()
    {
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        }
    }
    public Transform playerPrefab;
    public Transform spawnPoint;
    public float spawnDelay = 3.28f;
    public Transform spawnPrefab;

    public IEnumerator respawnPlayer()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.Play();
        


        yield return new WaitForSeconds(spawnDelay);

        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        Transform clone = (Transform) Instantiate(spawnPrefab, spawnPoint.position, spawnPoint.rotation);
        Destroy(clone.gameObject, 3f);
        
    }
    public static void killPlayer(player player)
    {
        Destroy(player.gameObject);
        gm.StartCoroutine(gm.respawnPlayer());
    }


	
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<GameObject> enemies;
    [SerializeField] List<GameObject> powerupPrefabs;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Level1");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<GameObject> GetEnemies()
    {
        return enemies;
    }

    public void SpawnPowerup(Vector3 position)
    {
        int powerupChoice = Random.Range(0, 2);

        Instantiate(powerupPrefabs[powerupChoice], position, Quaternion.Euler(new Vector3(90, 0, 0)));
    }

    public bool AllEnemiesDead()
    {
        for (int i = 0; i < enemies.Count; i++)
        {
            if (enemies[i] != null)
            {
                return false;
            }
        }

        return true;
    }
}

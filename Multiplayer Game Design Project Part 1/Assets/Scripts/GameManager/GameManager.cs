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
        FindObjectOfType<AudioManager>().Play("NewLevel");
    }

    // Update is called once per frame
    void Update()
    {
        if (!FindObjectOfType<AudioManager>().IsPlaying("Level1") && !FindObjectOfType<AudioManager>().IsPlaying("NewLevel"))
        {
            FindObjectOfType<AudioManager>().Play("Level1");
        }
    }

    public List<GameObject> GetEnemies()
    {
        return enemies;
    }

    public void SpawnPowerup(Vector3 position)
    {
        int powerupChoice = Random.Range(0, 2);

        Instantiate(powerupPrefabs[powerupChoice], position, Quaternion.Euler(new Vector3(0, 0, 0)));
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

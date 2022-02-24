using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesHandler : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject target;
    public int nbrEnemy;

    // Start is called before the first frame update
    void Start()
    {
        // Generates enemies at random on the map
        for (int i = 0; i < nbrEnemy; i++)
        {
            var obj = Instantiate(enemyPrefab) as GameObject;
            obj.name = "Enemy " + i.ToString();
            obj.transform.position = new Vector3(Random.Range(70, 400), 70, Random.Range(70, 400));
            obj.GetComponent<EnemyHandler>().SetTarget(target);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

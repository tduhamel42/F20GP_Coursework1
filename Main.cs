using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

    public GameObject diamondPrefab;
    public GameObject fox;

    // Start is called before the first frame update
    void Start()
    {
        // Place the diamond at random position on the map
        var obj = Instantiate(diamondPrefab) as GameObject;
        obj.name = "WinDiamond";
        obj.transform.position = new Vector3(Random.Range(70, 400), 100, Random.Range(70, 400));
        // Set the targe for the fox
        fox.GetComponent<FoxHandler>().SetTarget(obj);
    }

    // Update is called once per frame
    void Update()
    {
        // Plays random sounds
        var audios = GetComponents<AudioSource>();
        if (Random.Range(0, 2000) < 10 && !audios[0].isPlaying)
            audios[0].Play();
        if (Random.Range(0, 2000) < 10 && !audios[1].isPlaying)
            audios[1].Play();

        // Quit the game using exit
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }
}

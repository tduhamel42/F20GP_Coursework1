using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Players HUD code
 */
public class PlayerHealth : MonoBehaviour
{

    public GameObject player;
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<UnityEngine.UI.Text>();
        text.text = "Text";
    }

    // Update is called once per frame
    void Update()
    {
        var health = player.GetComponent<PlayerHandler>().GetHealth();
        if (health <= 30)
            text.color = Color.red;
        text.text = "Health: " + health.ToString();
    }
}

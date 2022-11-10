using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon_Spawn : MonoBehaviour
{
    const int MAX_SPAWN = 12;
    [SerializeField] GameObject balloon;
    // Start is called before the first frame update
    void Start()
    {
        Spawn(balloon);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn(GameObject x)
    {
        float xMin = -30f;
        float xMax = 32f;
        float yMin = 2f;
        float yMax = 13f;

        for (float i = 0f; i < MAX_SPAWN; i++)
        {
            Vector2 pos = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
            Instantiate(x, pos, Quaternion.identity);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate = 0.7f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
            Debug.Log("the random index is : " + targets[index].name);
            Debug.Log("the random index is : " + index);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    // Variable impulsion
    private float minImpulse = 12;
    private float maxImpulse = 16;
    private float maxTorque = 10;
    private float maxSpawnX = 4;
    private float PointSpawnY = -1;
    private float lifeSpan = 5;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyTime", lifeSpan);
        //recupere le rigidbody
        targetRb = GetComponent<Rigidbody>();
        //Impulse
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        //faire tourner l'objet sur lui meme
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        //Pour eviter de spawn tjr au mm endroit, random la position de GO au start
        transform.position = RandomSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minImpulse, maxImpulse);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
    Vector3 RandomSpawn()
    {
        return new Vector3(Random.Range(-maxSpawnX, maxSpawnX),PointSpawnY);
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
    private void DestroyTime()
    {
        Destroy(gameObject);
        Debug.Log("Destroyed");
    }
}

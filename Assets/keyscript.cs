using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyscript : MonoBehaviour
{
    // Start is called before the first frame update
    AudioSource aS;
    void Start()
    {
        aS = GetComponent<AudioSource>();
        aS.Play();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(5, 0, 0 * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        Destroy(gameObject);
    }
}

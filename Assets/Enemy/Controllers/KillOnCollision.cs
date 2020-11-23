using UnityEngine;

public class KillOnCollision : MonoBehaviour
{
    // Update is called once per frame
    void OnCollisionEnter()
    {
        Debug.Log("We hit");
    }
}

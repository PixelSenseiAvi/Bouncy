using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyDelay());
    }

    IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(2f);
        Destroy(this.gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
    // Start is called before the first frame update
    public void RemoveMe() {

        Debug.Log("Destroyable's RemoveMe functions has been called on" + name);
        Destroy (gameObject);

    }
  
}

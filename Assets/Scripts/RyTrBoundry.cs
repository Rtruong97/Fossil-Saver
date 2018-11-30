using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RyTrBoundry : MonoBehaviour {

    // Use this for initialization
    
    private void OnTriggerExit2D(Collider2D other)
    { 
        Destroy(other.gameObject);
    }
}

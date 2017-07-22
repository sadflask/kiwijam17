using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {
    public TileMover tMover;

    void Start()
    {
        tMover = GetComponent<TileMover>();
    }
}

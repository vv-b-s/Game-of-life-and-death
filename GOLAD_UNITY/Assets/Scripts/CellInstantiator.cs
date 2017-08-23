using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellInstantiator : MonoBehaviour {

    public CellController Life;
    private float time;
	void Start ()
    {
        Life = GetComponent<CellController>();      // Instantiate Cell Controller

        Life.GenerateCells();
        Life.DrawCells();
        time = Time.time;
    }
	
	// Update is called once per frame
	void Update ()
    {
        var newTime = Time.time;
        if(newTime!=time)
        {
            time = newTime;
            Life.UpdateGrid();
            Life.DrawCells();
        }
	}
}

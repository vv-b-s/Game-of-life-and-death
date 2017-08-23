using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellInstantiator : MonoBehaviour {

    public CellController Life;
    private DateTime time;
	void Start ()
    {
        Life = GetComponent<CellController>();      // Instantiate Cell Controller

        Life.GenerateCells();
        Life.DrawCells();
        time = DateTime.Now;
    }
	
	// Update is called once per frame
	void Update ()
    {
        var newTime = DateTime.Now;
        if(newTime.Second!=time.Second)
        {
            time = newTime;
            Life.UpdateGrid();
            Life.DrawCells();
        }
	}
}

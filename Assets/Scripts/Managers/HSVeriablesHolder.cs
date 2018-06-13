using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class HSVariablesHolder {

    public static int timeChallaengeAmount;

    public static string name;
    public static float seconds;
    public static int points;
	
    public static void InsertVariables(string _name, float _seconds, int _points)
    {
        name = _name;
        seconds = _seconds;
        points = _points;
    }
}

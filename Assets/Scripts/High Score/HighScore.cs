using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore : IComparable<HighScore>{

    public int Points { get; set; }
    public int Seconds { get; set; }
    public string Name { get; set; }
    public int PlayerID { get; set; }

    public HighScore(int _playerID, string _name, int _points, int _seconds)
    {
        PlayerID = _playerID;
        Name = _name;
        Points = _points;
        Seconds = _seconds;
    }

    public int CompareTo(HighScore other)
    {
        if (other.Seconds < Seconds) return -1;
        else if (other.Seconds > Seconds) return 1;
        else if (other.Points < Points) return -1;
        else if (other.Points > Points) return 1;

        return 0;
    }
}

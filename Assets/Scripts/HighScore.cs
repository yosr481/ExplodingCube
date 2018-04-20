using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighScore {

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
}

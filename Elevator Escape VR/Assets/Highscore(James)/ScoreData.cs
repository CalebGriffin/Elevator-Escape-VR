using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


[Serializable]
public class ScoreData
{
    public List<Score> scores;

    public ScoreData()
    {
        scores= new List<Score>();
    }

}

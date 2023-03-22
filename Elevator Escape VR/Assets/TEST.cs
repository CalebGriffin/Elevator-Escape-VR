using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;

public class TEST : MonoBehaviour
{
    
    [ContextMenu(nameof(STUFF))]
    void STUFF()
    {
        int[] XArr = { 8, 12, 4, 6, 5, 11 };
        int[] YArr = { 7, 3, 6, 5, 10, 8 };
        int[] ZArr = { 5, 10, 7, 14, 6, 12 };

        string path = "Assets/TEST.txt";

        var shapes = from x in XArr
                        from y in YArr
                        from z in ZArr
                        let crossSectionArea = ((y + z) / 2) * x
                        let volume = crossSectionArea * z
                        select new { x, y, z, crossSectionArea, volume };
        
        StreamWriter writer = new StreamWriter(path, true);
        foreach (var shape in shapes)
        {
            string s = string.Format("X: {0}, Y: {1}, Z: {2}, Cross Section Area: {3}, Volume: {4}", shape.x, shape.y, shape.z, shape.crossSectionArea, shape.volume);
            writer.WriteLine(s);
        }
        writer.Close();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public GameObject bigdotPrefab;
    public GameObject arrowtipPrefab;
    
    private List<GameObject> dots = new List<GameObject>();
    private GameObject arrowtip;
    
    void Start()
    {
        for (var i = 0; i < 9; i++)
        {
            var dot = Instantiate(bigdotPrefab, transform);
            dots.Add(dot);
        }

        arrowtip = Instantiate(arrowtipPrefab, transform);
    }

    public void setArrow(Vector2 start, Vector2 end)
    {
        var dist = (end - start).magnitude;
        var numDots = Mathf.Max(1, Mathf.Min(10, (int)dist*0.8f));

        float distx = (end.x - start.x);
        float disty = (end.y - start.y);

        for (var i = 0; i < 9; i++)
        {
            if (i < numDots - 1)
            {
                var t = i / (float)numDots;
                var ypos = -disty * t * (t-2) + start.y;
                
                Vector2 dotPos = new Vector2(start.x + distx/numDots * i, ypos);

                dots[i].transform.position = dotPos;
            }
            else
            {
                dots[i].transform.position = start;
            }
        }

        var xposlast = start.x + distx / numDots * (numDots-2);
        
        var t2 = (numDots-2) / (float)numDots;
        var yposlast = -disty * t2 * (t2-2) + start.y;

        var dir = end - new Vector2(xposlast, yposlast);

        arrowtip.transform.position = end;
        arrowtip.transform.eulerAngles = new Vector3(0, 0, Vector2.SignedAngle(Vector2.up, dir));
        
        
    }

    public void setActive(bool active)
    {
        gameObject.SetActive(active);
    }
   
}

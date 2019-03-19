using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class UnitHealthbar : MonoBehaviour
{
    public GameObject heartPrefab;
    public GameObject dotPrefab;
    
    private UnitModel unitModel;

    private List<GameObject> hearts = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void setModel(UnitModel unitModel)
    {
        this.unitModel = unitModel;
        Redraw();

    }

    public void Redraw()
    {
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }
        hearts.Clear();

        Debug.Log(unitModel.maxhp);
        
        for (int i = 0; i < unitModel.maxhp; i++)
        {
            var prefab = heartPrefab;
            if (unitModel.hp-1 < i)
            {
                prefab = dotPrefab;
            }
            
            
            var heart = Instantiate(prefab, transform);
            
            heart.transform.localPosition = new Vector3(-(0.5f*(unitModel.maxhp-1))/2 + i*0.5f, 0, 0);
            hearts.Add(heart);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

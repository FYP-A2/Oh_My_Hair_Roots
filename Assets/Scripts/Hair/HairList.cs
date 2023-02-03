using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HairList : MonoBehaviour
{
    public GameObject headCenter;

    public List<GameObject> hairList = new List<GameObject>();
    public List<HairAutoTransform> hairAutoTransforms = new List<HairAutoTransform>();

    // Start is called before the first frame update
    void Start()
    {
        hairAutoTransforms = FindObjectsOfType<HairAutoTransform>().ToList();
        foreach (var hairAutoTransform in hairAutoTransforms)
        {
            hairList.Add(hairAutoTransform.gameObject);
            hairAutoTransform.AutoTransform(headCenter.transform.position);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

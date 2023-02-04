using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HairFollicle : MonoBehaviour
{
    [SerializeField]
    GameObject surroundingGO;

    [SerializeField]
    Color sHealthyColor;
    [SerializeField]
    Color sWaterExcessColor;
    [SerializeField]
    Color sOilExcessColor;
    [SerializeField]
    Color sOilConcretingColor;

    float healthyMin = 0.45f;
    float healthyMax = 0.55f;
    float concretingMin = 0.85f;

    Material sMaterial;


    [SerializeField]
    GameObject inflammationGO;
    Animator inflammationAnimator;


    [SerializeField]
    Color i0color;
    [SerializeField]
    Color i100color;

    Material iMaterial;

    [Header("Set Display")]
    [Range(0f, 100f)]
    public float s = 50;
    public bool concreting = false;
    [Range(0f, 100f)]
    public float i = 0;






    // Start is called before the first frame update
    void Start()
    {
        sMaterial = surroundingGO.GetComponent<Renderer>().material;
        iMaterial = inflammationGO.GetComponent<Renderer>().material;
        inflammationAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //SetSurroundingDisplay(s/100);
        //SetInfla(i/100);
    }

    public void SetAllPara(float surrounding, bool concreting, float inflammation)
    {
        SetSurroundingDisplay(surrounding);
        this.concreting = concreting;
        SetInfla((100f - inflammation) / 100);
    }


    public void AddS10()
    {
        StartCoroutine(AddS(5, 0.3f));
    }

    public void RemoveS10()
    {
        StartCoroutine(RemoveS(5, 0.3f));
    }

    IEnumerator AddS(float n,float duration)
    {

        float temp = n / duration * Time.deltaTime;
        while (n > 0)
        {
            n -= temp;
            s += temp;
            yield return null;
        }
    }

    IEnumerator RemoveS(float n, float duration)
    {

        float temp = n / duration * Time.deltaTime;
        while (n > 0)
        {
            n -= temp;
            s -= temp;
            yield return null;
        }
    }

    public void SetSurroundingDisplay(float n)
    {
        if (concreting)
        {
            sMaterial.color = sOilConcretingColor;
        }
        else if (n >= healthyMax && n <= 1)
        {
            sMaterial.color = Color.Lerp(sHealthyColor, sOilExcessColor, (n - healthyMax) / (1 - healthyMax));
        }
        
        else if (n >= healthyMin && n < healthyMax)
        {
            sMaterial.color = sHealthyColor;
        }
        
        else if (n >= 0 && n < healthyMin)
        {
            sMaterial.color = Color.Lerp(sWaterExcessColor, sHealthyColor, n / healthyMin);
        }



        //if (n >= concretingMin && n <= 1)
        //{
        //    m.color = sOilConcretingColor;
        //}
        //
        //else if (n >= 0.5f && n < concretingMin)
        //{
        //    Debug.Log("hi");
        //    m.color = Color.Lerp(sHealthyColor, sOilExcessColor, ( n - 0.5f) / (concretingMin - 0.5f));
        //}
        //
        //else if (n >= 0 && n < 0.5f)
        //{
        //    m.color = Color.Lerp(sWaterExcessColor, sHealthyColor, n / 0.5f);
        //}

    }

    public void SetInfla(float n){
        inflammationAnimator.SetFloat("Blend", n);
        iMaterial.color = Color.Lerp(i0color, i100color, n);
    
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HairAnimation : MonoBehaviour
{
    public float grow = 0;
    [Range(0f, 1f)]
    public float growInput = 0;
    public Animator animator;
    public Renderer renderer1;
    Color color;
    public Color colorGrowTo1;
    Vector3 originScale;

    public GameObject dropHair;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RandomAnimation());
        color = renderer1.material.color;
        originScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        //SetGrow(growInput);
    }

    public void SetGrow(float n)
    {
        if (n == grow)
            return;

        if (n >= 1 && grow < 1)
            StartCoroutine(HairFullGrow());

        grow = n;
        UpdateScale();

    }

    public void DropHair()
    {
        GameObject d = Instantiate(dropHair);
        d.transform.position = transform.position;
        d.transform.rotation = transform.rotation;
        d.transform.localScale = transform.lossyScale;
        d.GetComponent<HairAnimation>().InSpace(grow, transform.up, transform.forward, transform.up);

        Debug.Log("Animation Play " + grow);

        SetGrow(0);


    }

    public void InSpace(float grow,Vector3 up,Vector3 forward,Vector3 left)
    {
        SetGrow(grow);
        Rigidbody rb = GetComponent<Rigidbody>();

        rb.isKinematic = false;
        rb.velocity = up * Random.Range(1f, 2f) + forward * Random.Range(-2f, 2f) + left * Random.Range(-2f, 2f);

        StartCoroutine(DestroyAfterSecond(5f));
    }

    void UpdateScale()
    {
        transform.localScale = originScale * grow;
    }

    IEnumerator DestroyAfterSecond(float s)
    {
        yield return new WaitForSeconds(s);

        Destroy(gameObject);
    }

    IEnumerator HairFullGrow()
    {
        float x = 0;

        while (x < 1)
        {
            x += Time.deltaTime * 2;
            renderer1.material.color = Color.Lerp(color, colorGrowTo1, EaseInOutQuart(x));
            yield return null;
        }
        while (x > 0)
        {
            x -= Time.deltaTime * 2;
            renderer1.material.color = Color.Lerp(color, colorGrowTo1, EaseInOutQuart(x));
            yield return null;
        }

    }

    IEnumerator RandomAnimation()
    {
        yield return new WaitForSeconds(Random.Range(0f,4.6f));

        while (true)
        {
            int r = Random.Range(0, 12);

            //animator.SetInteger("SwingType",r);

            if (r <= 10)
            {
                animator.SetInteger("SwingType", 0);
            } else
            {
                animator.SetInteger("SwingType", r - 10);
            }


            yield return new WaitForSeconds(4.6666f);
        }
    }

        float EaseInOutQuart(float x) {
        return x< 0.5 ? 8 * x* x* x* x : 1 - Mathf.Pow(-2 * x + 2, 4) / 2;
    }
}

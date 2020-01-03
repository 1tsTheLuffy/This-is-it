using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dRAG : MonoBehaviour {

    public GameObject scrollbar;
    float scroll = 0;
    float[] pos;
    Vector2 hold;
    // Start is called before the first frame update
    void Start()
    {
       // hold = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        pos = new float[transform.childCount];

        float distance = 1f / (pos.Length - 1f);
        for(int i =0; i < pos.Length; i++)
        {
            pos[i] = distance * i;
        }

        if (Input.GetMouseButton(0))
        {
            scroll = scrollbar.GetComponent<Scrollbar>().value;
        }
        else
        {
            for(int i =0; i < pos.Length; i++)
            {
                if (scroll < pos[i] + (distance / 2) && scroll > pos[i] - (distance / 2))
                {
                    scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i], 0.1f);
                }
            }
        }
        for(int i = 0; i < pos.Length; i++)
        {

            if (scroll < pos[i] + (distance / 2) && scroll > pos[i] - (distance / 2))
            {
                transform.GetChild(i).localScale = Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(0.95f, 1.75f), 0.1f);
               // transform.position = Vector2.Lerp(transform.position, new Vector2(transform.position.x, 5f), 0.1f);
                for(int a = 0; a < pos.Length; a++)
                {
                    if(a != i)
                    {
                        transform.GetChild(a).localScale = Vector2.Lerp(transform.GetChild(a).localScale, new Vector2(0.9f, 1.50f), 0.1f);
                    }
                }
            }
        }
    }
}

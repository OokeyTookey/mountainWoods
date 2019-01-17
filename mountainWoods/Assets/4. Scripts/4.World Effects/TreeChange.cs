using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeChange : MonoBehaviour
{
    Renderer[] rends;
    public List<Color> OriginalColors;
    private IEnumerator coroutine;
   
    void Start()
    {
        OriginalColors = new List<Color>();
        rends = this.GetComponentsInChildren<MeshRenderer>();

        for (int i = 0; i < rends.Length; i++)
        {
            for (int j = 0; j < rends[i].materials.Length; j++)
            {
                OriginalColors.Add(rends[i].materials[j].color);
                float greyscale = OriginalColors[j].grayscale;
                rends[i].materials[j].color = new Color(greyscale, greyscale,greyscale);

                //rends[i].materials[j].color = Color.white;
            }
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartCoroutine(LerpColour());
        }
    }

    private IEnumerator LerpColour()
    {
        //yield return new WaitForSeconds(Random.Range(0, 3));

        float percentage = 0;
        while (percentage < 1)
        {
            percentage += 0.1f;
            int t = 0;
            for (int i = 0; i < rends.Length; i++)
            {
                for (int j = 0; j < rends[i].materials.Length; j++)
                {
                    rends[i].materials[j].color = Color.Lerp(Color.white, OriginalColors[t], percentage);
                    t++;
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
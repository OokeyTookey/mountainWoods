using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeChange : MonoBehaviour
{
    Renderer[] rends;
    ParticleSystem[] particleSystemArray;

    public List<Color> OriginalColors;
    private IEnumerator coroutine;
    bool pressOnce;

    List<Color> originalParticleColor;
    List<Color> greyscaleParticleColor;

    void Start()
    {
        OriginalColors = new List<Color>();
        originalParticleColor = new List<Color>();
        greyscaleParticleColor = new List<Color>();

        rends = this.GetComponentsInChildren<MeshRenderer>();
        particleSystemArray = this.GetComponentsInChildren<ParticleSystem>();
        int f = 0;

        for (int i = 0; i < rends.Length; i++)
        {
            for (int j = 0; j < rends[i].materials.Length; j++)
            {
                OriginalColors.Add(rends[i].materials[j].color);
                float greyscale = OriginalColors[f].grayscale;
                rends[i].materials[j].color = new Color(greyscale, greyscale, greyscale);
                f++;
            }
        }

        for (int i = 0; i < particleSystemArray.Length; i++)
        {
            ParticleSystem.MainModule mainModule = particleSystemArray[i].main;//Accessing each module
            originalParticleColor.Add(mainModule.startColor.color); //Adding said colour to the list
            float greyscale = mainModule.startColor.color.grayscale; //Creating a new greyscale
            greyscaleParticleColor.Add(new Color(greyscale, greyscale, greyscale)); //Adding greyscale varient to list
            mainModule.startColor = greyscaleParticleColor[i]; //Setting colour to greyscale
        }
    }

    public void PuzzleComplete()
    {
        if (!pressOnce)
        {
            pressOnce = true;
            StartCoroutine(LerpColour());
        }
    }

    private IEnumerator LerpColour()
    {
        float percentage = 0;
        while (percentage < 1)
        {
            percentage += 0.01f;
            int t = 0;
            for (int i = 0; i < rends.Length; i++)
            {
                for (int j = 0; j < rends[i].materials.Length; j++)
                {
                    float greyscale = OriginalColors[t].grayscale;
                    rends[i].materials[j].color = Color.Lerp(new Color(greyscale, greyscale, greyscale), OriginalColors[t], percentage);
                    t++;
                }
            }

            for (int i = 0; i < particleSystemArray.Length; i++)
            {
                ParticleSystem.MainModule mainModule = particleSystemArray[i].main;
                mainModule.startColor = Color.Lerp(greyscaleParticleColor[i], originalParticleColor[i], percentage);
            }

            yield return new WaitForSeconds(0.1f);
        }
    }
}

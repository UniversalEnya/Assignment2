using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioViz1 : MonoBehaviour
{
    public float scale = 20;
    List<GameObject> elements = new List<GameObject>();
    // Use this for initialization
    void Start()
    {
        CreateVisualisers();

    }

    //public float radius = 50;
    public float boxWidth = 8;
    public float boxLength = 8;

    void CreateVisualisers()
    {
        //float theta = (Mathf.PI * 2.0f) / (float)AudioAnalyzer.frameSize;

        for (int i = 0; i < AudioAnalyzer.frameSize; i++)
        {
            for (int x = 0; x <= boxWidth; x++)
            {
                for (int y = 0; y <= boxLength; y++)
                {
                    Vector3 pos = new Vector3
                        ( 
                           x, y, 0              
                        );
                    pos = transform.TransformPoint(pos);

                    Quaternion quat = Quaternion.AngleAxis(1 * i * Mathf.Rad2Deg, Vector3.up);

                    GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    cube.transform.position = pos;
                    cube.transform.parent = this.transform;

                    cube.GetComponent<Renderer>().material.color = Color.HSVToRGB
                        (
                            i / (float)AudioAnalyzer.frameSize, 1, 1
                        );
                    elements.Add(cube);
                }
            }
           
        }
    }
    

    void Update()
    {
        for (int i = 0; i < elements.Count; i++)
        {
            elements[i].transform.localScale = new Vector3(1, 1 + AudioAnalyzer.spectrum[i] * scale, 1);
        }
    }
}


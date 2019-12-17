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
    public float boxWidth = 9;
    public float boxLength = 9;

    void CreateVisualisers()
    {
        //float theta = (Mathf.PI * 2.0f) / (float)AudioAnalyzer.frameSize;

        for (int i = 0; i < AudioAnalyzer.frameSize; i++)
        {
            Vector3 pos = new Vector3
                (
                    (boxWidth / (float)AudioAnalyzer.frameSize) * i
                    , 0
                    , 0 //(boxLength / (float)AudioAnalyzer.frameSize) * i 
                );
            pos = transform.TransformPoint(pos);

            Quaternion quat = Quaternion.AngleAxis(1 * i * Mathf.Rad2Deg, Vector3.up);

            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = pos;
            cube.transform.parent = this.transform;

            cube.GetComponent<Renderer>().material.color = Color.HSVToRGB
                (
                    i / (float)AudioAnalyzer.frameSize
                    , 1
                    , 1
                );
            elements.Add(cube);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < elements.Count; i++)
        {
            elements[i].transform.localScale = new Vector3(1, 1 + AudioAnalyzer.spectrum[i] * scale, 1);
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teleport : MonoBehaviour
{
    public float range;
    ParticleSystem part;
    public float delay;
    float delayt;
    float val;
    public Slider slide;

    Ray ray;
    RaycastHit hit;
    void Start()
    {
        part = gameObject.GetComponent<ParticleSystem>();
        slide.maxValue = delay;
    }

    void Update()
    {
        val = delayt - Time.time;
        Mathf.Clamp(val, 0, delay);
        slide.value = val;
 
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (hit.collider.tag != "Solid")
                {
                    if (Vector3.Distance(transform.position, new Vector3(hit.point.x, hit.point.y, 0)) < range)
                    {
                        if (delayt <= Time.time)
                        {
                            transform.position = new Vector3(hit.point.x, hit.point.y, 0);
                            part.Play(false);
                            delayt = Time.time + delay;
                        }
                    }
                }
            }
        }        
    }
}

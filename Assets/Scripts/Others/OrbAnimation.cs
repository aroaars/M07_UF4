using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbAnimation : MonoBehaviour
{
    public float scaleTome = 2f;
    private float scale = 0.01f;
    public float rotateAmount = 2f;
    public float scaleAmount = 0.5f;
    private float currentTime = 0f;


    // Start is called before the first frame update
   private void Start()
    {
        //StartCoroutine(ScaleObject());
    }

   void FixedUpdate()
   {
    currentTime += Time.deltaTime;
    if(currentTime >= scaleAmount)
    {
        scale = -scale;
        scaleAmount += scaleAmount;
    }
    
    transform.Rotate(0, rotateAmount, 0);
    transform.localScale += new Vector3(1, 1f, 1f) * scale * scaleAmount;
   }

    private IEnumerator ScaleObject()
    {
        yield return new WaitForSeconds(scaleAmount);
        scale = -scale;
        yield return ScaleObject();
    }

}

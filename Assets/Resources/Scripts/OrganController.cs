using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrganController : MonoBehaviour 
{

    public Rigidbody2D myRigidbody;
    public float minForceX, maxForceX, minForceY, maxForceY;

    float lifetime = 0.75f;
    float fadetime = 0.375f;

	// Use this for initialization
	void Start () 
    {
        float forceX = Random.Range(minForceX, maxForceX);
        float forceY = Random.Range(minForceY, maxForceY);

        myRigidbody.AddForce(transform.right * forceX);
        myRigidbody.AddForce(transform.up * forceX);

        float ran = Random.Range(-7.0f, 7.0f);

        myRigidbody.AddTorque(ran* forceX);

        StartCoroutine(Fade());
	}
	
	
    IEnumerator Fade()
    {
        yield return new WaitForSeconds(lifetime);

        float percent = 0;
        float fadeSpeed = 1 / fadetime;
        Material mat = GetComponent<Renderer>().material;
        Color initialColour = mat.color;

        while (percent < 1)
        {
            percent += Time.deltaTime * fadeSpeed;
            mat.color = Color.Lerp(initialColour, Color.clear, percent);
            yield return null;
        }

        Destroy(gameObject);
    }
}

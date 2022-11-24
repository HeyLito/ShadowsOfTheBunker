using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public int moveIncrement = 100;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CheckKeyPress());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator CheckKeyPress()
    {
        float timeTarget = 0.075f;
        float time = 0;

        while (time < timeTarget)
        {
            time += Time.deltaTime;

            if (time >= timeTarget)
            {
                if (Input.GetKey(KeyCode.W))
                    transform.Translate(Vector3.up * moveIncrement, Space.World);
                if (Input.GetKey(KeyCode.A))
                    transform.Translate(Vector3.left * moveIncrement, Space.World);
                if (Input.GetKey(KeyCode.S))
                    transform.Translate(Vector3.down * moveIncrement, Space.World);
                if (Input.GetKey(KeyCode.D))
                    transform.Translate(Vector3.right * moveIncrement, Space.World);
                time = 0;
            }
            yield return null;
        }
    }
}

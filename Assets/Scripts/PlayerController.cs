using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float velocidadPlayer = 5f;
    [SerializeField] private float velocidadGiro = 10f;

    [SerializeField] private Animator animaPlayer;

    private float giroPlayer = 0f;


    private Rigidbody rbPlayer;

    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
        animaPlayer.SetBool("IsRun", false);
        animaPlayer.SetBool("IsBack", false);
    }


    // Update is called once per frame
    void Update()
    {
        Mover();
    }

    private void Mover()
    {

        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Girando con A");
            giroPlayer -= Time.deltaTime * velocidadGiro * 10;
            transform.rotation = Quaternion.Euler(0, giroPlayer, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Girando con D");
            giroPlayer += Time.deltaTime * velocidadGiro * 10;
            transform.rotation = Quaternion.Euler(0, giroPlayer, 0);
        }

        float ejeVertical = Input.GetAxisRaw("Vertical");

        Debug.Log($"Eje Vertical {ejeVertical}");
        Debug.Log($"IsRun {animaPlayer.GetBool("IsRun")}");
        Debug.Log($"IsBack {animaPlayer.GetBool("IsBack")}");

        if (ejeVertical > 0)
        {
            animaPlayer.SetBool("IsRun", true);
            animaPlayer.SetBool("IsBack", false);
            transform.Translate(velocidadPlayer * Time.deltaTime * new Vector3(0, 0, ejeVertical));
        }
        else if (ejeVertical < 0)
        {
            animaPlayer.SetBool("IsRun", false);
            animaPlayer.SetBool("IsBack", true);
            transform.Translate(velocidadPlayer / 4 * Time.deltaTime * new Vector3(0, 0, ejeVertical));
        }
        else
        {
            animaPlayer.SetBool("IsRun", false);
            animaPlayer.SetBool("IsBack", false);
        }

    }


}

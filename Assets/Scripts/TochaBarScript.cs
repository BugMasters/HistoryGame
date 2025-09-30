using Assets.Scripts.Model.Enum;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class TochaBarScript : MonoBehaviour
{
    [SerializeField]
    private float YMAX;

    [SerializeField]
    private float YMIN;

    [SerializeField]
    private GameObject Silex;

    [SerializeField]
    private ParticleSystem Faiscas;

    [SerializeField]
    private float Velocidade;

    [SerializeField]
    private float VelocidadeSilex;
    
    RectTransform rt;

    private Vector3 Max;
    private Vector3 Min;
    private Vector3 Para;

    private Vector3 SilexInicio;

    private bool Mover = true;
    private bool silexEmMovimento = false;

    void Awake()
    {
        rt = GetComponent<RectTransform>();

        SilexInicio = Silex.transform.position;

        Max = new Vector3(transform.position.x, YMAX);
        Min = new Vector3(transform.position.x, YMIN);
        Para = Max;
    }

    void Update()
    {
        MoverSeta();
        PararSeta();
    }

    private void MoverSeta()
    {
        if (Mover)
        {
            if (rt.position.y == YMAX)
            {
                Para = Min;
            }
            else if (rt.position.y == YMIN)
            {
                Para = Max;
            }

            rt.position = Vector3.MoveTowards(rt.position, Para, Velocidade * Time.deltaTime);
        }
    }

    private void PararSeta()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Mover = false;
            AtivarFaisca();
        }
    }

    private void AtivarFaisca()
    {
        float parou = rt.position.y;

        if (parou >= -50 || parou <= -53.3)
        {
            MoverSilex((float)FaiscaForca.Fraca);
        }
        else if (parou >= 51.2 || parou <= 52.1)
        {
            MoverSilex((float)FaiscaForca.Media) ;
        }
        else
        {
            MoverSilex((float)FaiscaForca.Forte);
        }
    }

    public void MoverSilex(float FaiscaEmission)
    {
        if (!silexEmMovimento)
            StartCoroutine(MoverSilexCoroutine(FaiscaEmission));
    }

    private IEnumerator MoverSilexCoroutine(float FaiscaEmission)
    {
        silexEmMovimento = true;

        Vector3 destino = new Vector3(SilexInicio.x, SilexInicio.y - 3);

        var emission = Faiscas.emission;
        emission.rateOverTime = FaiscaEmission;
        Faiscas.Play();

        while (Vector3.Distance(Silex.transform.position, destino) > 0.01f)
        {
            Silex.transform.position = Vector3.MoveTowards(Silex.transform.position, destino, VelocidadeSilex * Time.deltaTime);
            yield return null;
        }

        yield return new WaitForSeconds(0.2f);

        while (Vector3.Distance(Silex.transform.position, SilexInicio) > 0.01f)
        {
            Silex.transform.position = Vector3.MoveTowards(Silex.transform.position, SilexInicio, VelocidadeSilex * Time.deltaTime);
            yield return null;
        }

        Faiscas.Stop();

        silexEmMovimento = false;
        Mover = true;
    }
}

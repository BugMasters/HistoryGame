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
    private RectTransform Silex;

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

        SilexInicio = Silex.anchoredPosition;

        Max = new Vector2(rt.anchoredPosition.x, YMAX);
        Min = new Vector2(rt.anchoredPosition.x, YMIN);
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
            if (rt.anchoredPosition.y == YMAX)
            {
                Para = Min;
            }
            else if (rt.anchoredPosition.y == YMIN)
            {
                Para = Max;
            }

            rt.anchoredPosition = Vector3.MoveTowards(rt.anchoredPosition, Para, Velocidade * Time.deltaTime);
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
        float parou = rt.anchoredPosition.y;

        if (parou >= 80 || parou <= -95)
        {
            MoverSilex((float)FaiscaForca.Fraca);
        }
        else if (parou >= 15 || parou <= -30)
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

        Vector3 destino = new Vector3(SilexInicio.x, SilexInicio.y - 150);

        var emission = Faiscas.emission;
        emission.rateOverTime = FaiscaEmission;
        Faiscas.Play();

        while (Vector3.Distance(Silex.anchoredPosition, destino) > 0.01f)
        {
            Silex.anchoredPosition = Vector3.MoveTowards(Silex.anchoredPosition, destino, VelocidadeSilex * Time.deltaTime);
            yield return null;
        }

        yield return new WaitForSeconds(0.2f);

        while (Vector3.Distance(Silex.anchoredPosition, SilexInicio) > 0.01f)
        {
            Silex.anchoredPosition = Vector3.MoveTowards(Silex.anchoredPosition, SilexInicio, VelocidadeSilex * Time.deltaTime);
            yield return null;
        }

        Faiscas.Stop();

        silexEmMovimento = false;
        Mover = true;
    }
}

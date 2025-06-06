using  unityEngine;
using System.Collections;
using UnityEngine.UI;

public class Calculadora : MonoBehaviour
{
    public Text resultado;
    public Text lblTempo;
    public Text operation;
    private string textoimprimir;
    string valor1;
    string valor2;
    string operacionActual;
    double rta;

    public void Borrarc()
    {
        textoimprimir = "",
        resultado.text = textoimprimir;
        lblTempo.text = "";
    }

    public void Suma()
    {
        textoimprimir = "+",
        resultado.text = textoimprimir;
        lblTempo.text = "";
    }

    public void Resta()
    {
        textoimprimir = "-",
        resultado.text = textoimprimir;
        lblTempo.text = "";
    }

    public void colocarBilletes_2000(),

        textoimprimir = "2.000",
        resultado.text = resultado.text + textoimprimir;
     
#pragma warning disable IDE1006 // Estilos de nombres
    public void colocarBilletes_5000()
#pragma warning restore IDE1006 // Estilos de nombres
        textoimprimir = "5.000"
        resultado.text = resultado.text + textoimprimir;

    public void colocarBilletes_10000();
        textoimprimir = "10.000"
        resultado.text = resultado.text + textoimprimir;

    public void colocarBilletes_20000()
        textoimprimir = "20.000"
        resultado.text = resultado.text + textoimprimir;

    public void colocarBilletes_50000()
        textoimprimir = "50.000"
        resultado.text = resultado.text + textoimprimir;

    public void colocarBilletes_100000()
        textoimprimir = "100.000"
        resultado.text = resultado.text + textoimprimir;

    public void colocarBotón_Menos()
        textoimprimir = "-"
        resultado.text = resultado.text + textoimprimir;

    public void colocarBotón_Más
        textoimprimir = "+"
        resultado.text = resultado.text + textoimprimir;

    public void colocarMoneda_50() 
        textoimprimir = "50"
        resultado. text = resultado.text + textoimprimir;

    public void colocarMoneda_100()
        textoimprimir = "100"
        resultado.text = resultado.text + textoimprimir;

    public void colocarMoneda_200()
        textoimprimir = "200"
        resultado.text = resultado.text + textoimprimir;

    public void colocarMoneda_500()
        textoimprimir = "500"
        resultado.text = resultado.text + textoimprimir;

    public void colocarMoneda_1000()
        textoimprimir = "1.000"
        resultado.text = resultado.text + textoimprimir;

    }




void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

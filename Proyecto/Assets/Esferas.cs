using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esferas : MonoBehaviour
{
    
    int minwidth = 3; // Ancho mínimo
    int maxwidth = 12; // Ancho máximo
    int minheight = 3; // Altura mínima 
    int maxheight = 12; // Altura máxima
    private GameObject [,] grid; // Matriz 
    public bool activador; // CheckBox

    void Start()
    {
        StartCoroutine(CrearEsferas()); // Función que se ejecuta en paralelo para la creación de las esferas
    }

    public IEnumerator CrearEsferas() // Función creadora de esferas
    { 
        if (activador == true) // Opción de CheckBox que genera las esferas
        {
        int width = Random.Range (minwidth, maxwidth); // Se determina el la anchura maxima y miníma de las esferas
        int height = Random.Range(minheight, maxheight); // Se determina el la altura maxima y miníma de las esferas
        grid = new GameObject [width,height]; 
        Color objeto1 = Color.gray; 
        Color objeto2 = Color.gray;
        /*
        // En el bloque de la línea 32 a la 43 se crean las esferas de forma aleatoria
         y a su vez se le asigna el color de la misma forma. 
        */
        for (int x= 0; x < width; x++) 
        {
            GameObject m = null;
            for (int y= 0; y < height; y++)
            {
                GameObject go = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                Vector3 position= new Vector3(y, x, 0);
                go.GetComponent<Renderer>().material.color = GetRandomColor(); 
                go.transform.position= position;
                grid[x, y] = go;

                CompararColor compararColor = new CompararColor(); //Instancia que crea el comparador de color
                if(m!=null)
                {
                    /*
                    En el siguiente bloque de código se comparan las esperas
                    En caso de tener el mismo color se realiza el cambio por el color negro. 
                     */
                    objeto1 = go.GetComponent<Renderer>().material.color;
                    objeto2 = m.GetComponent<Renderer>().material.color;
                    go.GetComponent<Renderer>().material.color = compararColor.verificadorColor1(objeto1,objeto2);
                    m.GetComponent<Renderer>().material.color = compararColor.verificadorColor2(objeto1,objeto2);
                    
                }
                yield return new WaitForSeconds(0.3f); // se usa para retornar una espera con tiempo en segundos
                m = go; // Con esta asignación se reinicia el bloque del código "for"
            }
        }
        
        }
        else         
        print ("Debes seleccionar la opción de activador esferas"); // mensaje que se imprime cuando no esta seleccionada la opcion del CheckBox
    }
    Color GetRandomColor() // Se crea una función tipo menú para la asignación de los colores 
        {
            int randomColor = Random.Range(0,6); // con la función switch se crea un menú de colores que van desde el 0 al 6
            Color colorR = Color.black;
    switch(randomColor)
    {
        case 0:
            colorR = Color.white;
        break;
        
        case 1:
            colorR = Color.red;
        break;
        
        case 2:
            colorR = Color.blue;
        break;
        
        case 3:
            colorR = Color.cyan;
        break;
        
        case 4:
            colorR = Color.green;
        break;

        case 5:
            colorR = Color.yellow;
        break;

        case 6:
            colorR = Color.magenta;
        break;

    }
    
    return colorR; // se retorna el colorR 

    }
}
public class CompararColor  // Con esta clase compara el color anterior y el color actual, de esta manera se genera el cambio de color 
{
    Color colorNegro = Color.black;
    public Color verificadorColor1(Color a,Color b)
    {

        if(a==b)
        {
            a= colorNegro;
        }

        return a;
    }

    public Color verificadorColor2(Color a,Color b)
    {

        if(a==b)
        {
            b= colorNegro;
        }

        return b;
    }

}

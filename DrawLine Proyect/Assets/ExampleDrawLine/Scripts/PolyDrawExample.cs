#region Librerias
using UnityEngine;
using System.Collections;
#endregion

public class PolyDrawExample : MonoBehaviour
{
    #region Variables Publicas
    public int numberOfSides;
    public float polygonRadius;
    public Vector2 polygonCenter;
    #endregion

    #region Metodos
    void Update()
    {
        DebugDrawPolygon(polygonCenter, polygonRadius, numberOfSides);
    }

    // Dibujar un polígono en el plano XY con una posición especificada, número de lados y el radio
    void DebugDrawPolygon(Vector2 center, float radius, int numSides)
    {
        // La esquina que se utiliza para iniciar el polígono (paralela al eje X).
        Vector2 startCorner = new Vector2(radius, 0) + polygonCenter;

        // El "anterior" punto de esquina, inicializado a la esquina inicial.
        Vector2 previousCorner = startCorner;

        // Para cada curva después de la esquina de partida ...
        for (int i = 1; i < numSides; i++)
        {
            // Calcular el ángulo de la esquina en radianes.
            float cornerAngle = 2f * Mathf.PI / (float)numSides * i;

            // Obtener las coordenadas X e Y del punto de esquina.
            Vector2 currentCorner = new Vector2(Mathf.Cos(cornerAngle) * radius, Mathf.Sin(cornerAngle) * radius) + polygonCenter;

            // Dibuje un lado del polígono conectando la esquina actual a la anterior.
            Debug.DrawLine(currentCorner, previousCorner);

            // Después de haber utilizado la esquina actual, se convierte ahora en la esquina anterior.
            previousCorner = currentCorner;
        }

        // Dibujar el último lado mediante la conexión de la última curva de la esquina de partida.
        Debug.DrawLine(startCorner, previousCorner);
    }
    #endregion
}

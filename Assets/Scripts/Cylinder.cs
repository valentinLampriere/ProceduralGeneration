using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cylinder : MonoBehaviour
{
    public Material material;
    public float radius = 1;
    public float height = 2;
    public int numberOfMeridians = 8;
    public int numberOfParallels = 4;

    Vector3[] vertices;
    int[] triangles;

    void Init(Vector3 bottom, Vector3 top) {
        float h = height;
        float r = radius;

        gameObject.AddComponent<MeshFilter>();
        gameObject.AddComponent<MeshRenderer>();

        vertices = new Vector3[4 * numberOfMeridians * numberOfParallels + 2];
        triangles = new int[3 * 2 * numberOfParallels * numberOfMeridians + numberOfMeridians * 3 * 2];


        int indexVTop = vertices.Length - 2;
        int indexVBottom = vertices.Length - 1;

        vertices[indexVTop] = new Vector3(0, -height / 2, 0);
        vertices[indexVBottom] = new Vector3(0, height / 2, 0);
        for (int i = 0; i < numberOfMeridians; i++) {
            for (int j = 0; j < numberOfParallels; j++) {
                int indexV = (i + j * numberOfMeridians) * 4;
                int indexT = (i + j * numberOfMeridians) * 6;

                float theta0 = (2.0f * Mathf.PI / numberOfMeridians) * i;
                float theta1 = (2.0f * Mathf.PI / numberOfMeridians) * (i + 1);
                vertices[indexV] = new Vector3(Mathf.Cos(theta0) * radius, (float)(height / numberOfParallels) * j - height / 2, Mathf.Sin(theta0) * radius);
                vertices[indexV + 1] = new Vector3(Mathf.Cos(theta1) * radius, (float)(height / numberOfParallels) * j - height / 2, Mathf.Sin(theta1) * radius);
                vertices[indexV + 2] = new Vector3(Mathf.Cos(theta0) * radius, (float)(height / numberOfParallels) * (j + 1) - height / 2, Mathf.Sin(theta0) * radius);
                vertices[indexV + 3] = new Vector3(Mathf.Cos(theta1) * radius, (float)(height / numberOfParallels) * (j + 1) - height / 2, Mathf.Sin(theta1) * radius);

                // Create side faces
                triangles[indexT] = indexV;
                triangles[indexT + 1] = indexV + 2;
                triangles[indexT + 2] = indexV + 3;

                triangles[indexT + 3] = indexV;
                triangles[indexT + 4] = indexV + 3;
                triangles[indexT + 5] = indexV + 1;

                int iT = triangles.Length - (i + 1) * 6;
                if (j == 0) {
                    // Create Top faces
                    triangles[iT] = indexV + 1;
                    triangles[iT + 1] = indexVTop;
                    triangles[iT + 2] = indexV;
                } else if (j == numberOfParallels - 1) {
                    // Create Bottom faces
                    triangles[iT + 3] = indexV + 2;
                    triangles[iT + 4] = indexVBottom;
                    triangles[iT + 5] = indexV + 3;
                }
            }
        }

        Mesh msh = new Mesh();

        msh.vertices = vertices;
        msh.triangles = triangles;

        msh.RecalculateNormals();

        gameObject.GetComponent<MeshFilter>().mesh = msh;
        gameObject.GetComponent<MeshRenderer>().material = material;
    }
}

using UnityEngine;
using System.Collections;

public class CreateSquareBorder : MonoBehaviour 
{
	void Start () 
    {
        if (GetComponent<Collider>() is MeshCollider)
        {
            Debug.LogWarning("Mesh collider can create weird behaviors!");
            Debug.LogWarning("Consider using objects with box collider such as Cube!");
        }
        
        Renderer render = GetComponent<Renderer>();
        float stageWidth = render.bounds.size.x;
        float stageLength = render.bounds.size.z;
        Vector3 stageCenter = render.bounds.center;
        Vector3 scaleLengthWall = new Vector3(-0.5f, 0, stageLength);
        Vector3 scaleWidthWall = new Vector3(stageWidth, 0, -0.5f);
        Vector3 halfWidth = new Vector3(stageWidth / 2, 0, 0);
        Vector3 halfLength = new Vector3(0, 0, stageLength/2);

        GameObject leftWall = GameObject.CreatePrimitive(PrimitiveType.Cube);
        leftWall.name = "Left Wall";
        createWall(leftWall, stageCenter + halfWidth, scaleLengthWall);

        GameObject rightWall = GameObject.CreatePrimitive(PrimitiveType.Cube);
        rightWall.name = "Right Wall";
        createWall(rightWall, stageCenter - halfWidth, scaleLengthWall);

        GameObject bottomWall = GameObject.CreatePrimitive(PrimitiveType.Cube);
        bottomWall.name = "Bottom Wall";
        createWall(bottomWall, stageCenter - halfLength, scaleWidthWall);

        GameObject topWall = GameObject.CreatePrimitive(PrimitiveType.Cube);
        topWall.name = "Top Wall";
        createWall(topWall, stageCenter + halfLength, scaleWidthWall);
	}

    private void createWall(GameObject wall, Vector3 pos, Vector3 scale)
    {
        wall.transform.position = pos;
        wall.transform.transform.localScale += scale;
        wall.transform.parent = gameObject.transform;
    }
}

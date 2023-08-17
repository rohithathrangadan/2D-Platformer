using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform mainCam;
    public Transform middleBG;
    public Transform sideBG;

    [SerializeField] float length = 38.4f;
 
    void Update()
    {
        if (mainCam.position.x > middleBG.position.x)
            sideBG.position = middleBG.position + Vector3.right * length;


        if (mainCam.position.x < middleBG.position.x)
            sideBG.position = middleBG.position + Vector3.left * length;


        if (mainCam.position.x > sideBG.position.x || mainCam.position.x < sideBG.position.x) //when sideBG is the current displayBG,make it the middleBG(swap)
        {
            Transform temp = middleBG;

            middleBG = sideBG;
            sideBG = temp;
        }
    }
}

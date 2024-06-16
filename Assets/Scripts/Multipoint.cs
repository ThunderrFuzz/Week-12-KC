using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Multipoint : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text multitouchInfoDisplay;
    int maxTapCount;
    string multitouchinfo;
    Touch touchPoint;

    // Update is called once per frame
    void Update()
    {
        multitouchinfo = string.Format("Max tap count: {0}\n", maxTapCount);
        if(Input.touchCount > 0)
        {
            for(int i= 0; i<Input.touchCount; i++)
            {
                touchPoint = Input.GetTouch(i);
                multitouchinfo += string.Format("touch: {0} -Position {1} -tap Count: {2} -Finger ID:{3} \n Radius: {4} ({5}%)\n",
                    i, touchPoint.position, touchPoint.tapCount, touchPoint.fingerId, touchPoint.radius, ((touchPoint.radius / (touchPoint.radius + touchPoint.radiusVariance)) * 100f).ToString("F1"));
                if(touchPoint.tapCount > maxTapCount)
                {
                    maxTapCount = touchPoint.tapCount;
                }
            }
        }
        multitouchInfoDisplay.text = multitouchinfo;
    }
}

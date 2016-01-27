using UnityEngine;
using System.Collections;

public class TouchRotate3D : MonoBehaviour
{
    private RaycastHit hit;
    private Ray ray;
    private Vector3 origin;
    private string info;

    public Transform targetTransfrom;
    public bool isSelectZoom;
    public Vector3 zoomScale;
    private bool isDown;                 //表示鼠标是否按下
    private float distanceX;



    public void Awake() 
    {
        transform.position = targetTransfrom.position;
    }

    public void Update() 
    {

        
        if (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.WindowsPlayer)
        {
            if (isDown)
            {
                distanceX = Input.mousePosition.x - origin.x;
                this.transform.Rotate(new Vector3(0, -distanceX, 0));           //开始旋转
                origin = Input.mousePosition;                                   //重新记录鼠标的位置
            }
        }
        else if(Application.platform == RuntimePlatform.Android)
        {
            if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    origin = Input.mousePosition;

                }

                if (Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.collider.name == this.gameObject.name)
                        {
                            //开始左右移动
                            if ((origin - Input.mousePosition).x > 0)
                            {
                                Debug.Log("向左");
                                AddLine("向左");
                            }
                            else
                            {
                                Debug.Log("向右");
                                AddLine("向右");

                            }
                        }
                    }
                }

                if (Input.GetTouch(0).phase == TouchPhase.Canceled)
                {
                    Debug.Log("结束");
                    AddLine("结束了");

                }
            }
        }

    }

    public void OnGUI() 
    {
        //GUI.Box(new Rect(0,0,500,500),info);
    }

    public void AddLine(string str) 
    {
        info += "\r\n" + str;
    }


    public void OnMouseDown() 
    {
        if (isSelectZoom) 
        {
            this.transform.localScale += zoomScale;
        }
        isDown = true;
        origin = Input.mousePosition;
        
    }

    public void OnMouseUp() 
    {
        if (isSelectZoom) 
        {
            this.transform.localScale -= zoomScale;
        }
        isDown = false;
    }

}

using MRTKExtensions.QRCodes;
using UnityEngine;
using UnityEngine.UI;

public class JetController : MonoBehaviour
{

    public GameObject triggerObj;
    [SerializeField]
    private QRTrackerController trackerController;
    public Text text;
    public int i=1;
    public GameObject tryyyy;
    private void Start()
    {

        trackerController.PositionSet += PoseFound;
        

    }
    
    public void PoseFound(object sender, Pose pose)
    {

        tryyyy.SetActive(true);
        text.text = "(-3.09, -1.33, -1.32)";
        if (i == 1)
        {
            triggerObj = GameObject.Find("triggerObj");
            triggerObj.SendMessage("getbuttomdown");//找到"triggerObj"後觸發/執行裡面的"getbuttomdown"函數
            /*  QRloading.go1.gameObject.transform.SetParent(GameObject.Find("JetHolder").transform);
              var childObj = transform.GetChild(0);
              childObj.SetPositionAndRotation(pose.position, pose.rotation);
              childObj.transform.Translate(-3.09f, -1.33f, -1.32f, Space.Self);
              childObj.transform.Rotate(90, 0, 0, Space.Self);

              //pose.position + new Vector3(-3.09f, -1.45f, -0.1f);
              //childObj.transform.Rotate(90, 0, 0);
            */
            i++;
        }

        else if (i == 2)
        {
            closevis(QRloading.go1);
            i++;

        }

        else
        {
            openvis(QRloading.go1);
            i = 2;

        }

    }
    public void closevis(GameObject model)
    {
        foreach (Transform child in model.transform)
        {
            if (null == child)
                continue;
            if (child.gameObject.GetComponent<MeshRenderer>())
            {
                child.gameObject.GetComponent<MeshRenderer>().enabled = false;
            }

            closevis(child.gameObject);

        }
    }
    public void openvis(GameObject model)
    {
        foreach (Transform child in model.transform)
        {
            if (null == child)
                continue;
            if (child.gameObject.GetComponent<MeshRenderer>())
            {
                child.gameObject.GetComponent<MeshRenderer>().enabled = true;
            }

            openvis(child.gameObject);

        }
    }

}
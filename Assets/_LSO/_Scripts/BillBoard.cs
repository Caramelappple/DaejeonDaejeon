using UnityEngine;

public class BillBoard : MonoBehaviour
{
   [SerializeField] private Camera billCam;

   private void Update()
   {
      if (billCam == null)
         return;
      gameObject.transform.LookAt(billCam.transform);
      //gameObject.transform.rotation = Quaternion.LookRotation(gameObject.transform.position - billCam.transform.position);
   }
}

using UnityEngine;

public class WalkableAreaSize : MonoBehaviour
{
    #region Variables

    public Vector3 areaSize;
    public Vector3 areaCenter;
    //Put variables here.

    #endregion
    #region Functions


    
    
    void OnDrawGizmos(){
        Gizmos.DrawWireCube(areaCenter,areaSize);
        Gizmos.color=Color.yellow;
    }
    

    #endregion
}

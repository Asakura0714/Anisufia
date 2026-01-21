using UnityEngine;

public class ViewBase : MonoBehaviour
{
    public virtual void InitView()
    {

    }

    public void SetActiveView(bool isActive)
    {
        gameObject.SetActive(isActive);
    }

    public virtual AnisButtonBase FirstSelectedGameObject() => null;

}

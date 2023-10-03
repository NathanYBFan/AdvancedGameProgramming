using UnityEngine;
public interface UpgradeInterface
{
    public int upgradeID { get; set; }
    public virtual void Run()
    {
        Debug.Log("Run not overwritten");
    }
}

using UnityEngine;

[CreateAssetMenu(fileName = "ProjectileConfig", menuName = "Level Designer ToolBox/ProjectileConfig", order = 0)]
public class ProjectileConfig : ScriptableObject {
    public float speed = 10f;
    public float damage = 100f;
    public float lifetime = 5f;
}
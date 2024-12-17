using UnityEngine;
using UnityEngine.Events;

namespace Managers
{
    public class EventManager : MonoBehaviour
    {
        public static UnityEvent OnLevelChanged = new UnityEvent();
    
        public static void LevelChanged()
        {
            OnLevelChanged?.Invoke();
        }
    }
}

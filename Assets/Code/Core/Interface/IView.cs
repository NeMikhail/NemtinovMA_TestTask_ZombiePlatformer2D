using UnityEngine;

namespace Core.Interface
{
    public interface IView
    {
        public GameObject Object { get; }
        public string ViewID { get; set; }
    }
}

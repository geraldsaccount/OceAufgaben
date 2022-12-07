
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class VectorTest : MonoBehaviour {
    [SerializeField] private int vectorAmount = 20000;
    [SerializeField] private Vector2 randomRange;

    private void Start() {
        var sw = new Stopwatch();
        sw.Start();
        float distance;
        for (int i = 0; i < vectorAmount; i++) {
            Vector3 a = new Vector3(RandomNumber(), RandomNumber(), RandomNumber());
            Vector3 b = new Vector3(RandomNumber(), RandomNumber(), RandomNumber());
            Vector3 direction = b - a;
            distance = direction.sqrMagnitude;
        }
        sw.Stop();
        Debug.Log(sw.ElapsedMilliseconds);
    }

    private float RandomNumber() {
        return Random.Range(randomRange.x, randomRange.y);
    }
}

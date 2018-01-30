using UnityEngine;
using System.Linq;
//using System.Collections;
[ExecuteInEditMode]
public class particleHomingMultiTarget : MonoBehaviour {
	[Tooltip("Target objects. If this parameter is undefined it will assume the attached object itself which creates self chasing particle effect.")]
	public Transform[] target;
	[Tooltip("How fast the particle is guided to the index target.")]
	public float speed = 10f;
	[Tooltip("Cap the maximum speed to prevent particle from being flung too far from the missed target.")]
	public float maxSpeed = 50f;
	[Tooltip("How long in the projectile begins being guided towards the target. Higher delay and high particle start speed requires greater distance between attacker and target to avoid uncontrolled orbitting around the target.")]
	public float homingDelay = 1f;
	public enum TSOP{random=0,closest=1};
	[Tooltip("How each particle selects the target.")]
	public TSOP targetSelection = TSOP.random;
	//[Tooltip("Distance from target position which kills the particle. This has the similar effect of using sphere collider for the target combing with world collision or trigger in Particle System.")]
	//public float dyingRange = 0f;
	ParticleSystem m_System;
	ParticleSystem.Particle[] m_Particles;
	int index;
	
	void Start() {
		if (target[0] == null) {
			for (int i = 0; i < target.Length; i++) {
				target[i] = this.transform;
			}
		}
		m_System = GetComponent<ParticleSystem>();
		//m_Particles = new ParticleSystem.Particle[m_System.maxParticles];// Before Unity 5.5
		m_Particles = new ParticleSystem.Particle[m_System.main.maxParticles];// Since Unity 5.5
	}
	
	void LateUpdate() {
		int numParticlesAlive = m_System.GetParticles(m_Particles);
		for (int i = 0; i < numParticlesAlive; i++) {
			float[] dist = new float[target.Length];
			switch (targetSelection) {
				case TSOP.random:
					index = Mathf.Abs((int) m_Particles[i].randomSeed) % target.Length;
					break;
					
				case TSOP.closest:
					for (int j = 0; j < target.Length; j++) {
						dist[j] = Vector3.Distance(m_Particles[i].position, target[j].position);
					}
					//index = System.Array.IndexOf(dist, dist.Min());// slower than comparing in foreach.
					float minValue = float.MaxValue;
					int minindex = -1;
					index = -1;
					foreach (float num in dist) {
						minindex++;
						if (num <= minValue) {
							minValue = num;
							index = minindex;
						}
					}
					break;
			}
			//Debug.Log(index);
			float ted = (target[index].position - this.transform.position).sqrMagnitude + 0.001f;
			Vector3 diff = target[index].position - m_Particles[i].position;
			float diffsqrm = diff.sqrMagnitude;
			float face = Vector3.Dot(m_Particles[i].velocity.normalized, diff.normalized);
			float f = Mathf.Abs((ted - diffsqrm)/ted) * ted * (face + 1.001f);
			//m_Particles[i].velocity = Vector3.ClampMagnitude(m_Particles[i].velocity + diff * speed * 0.01f * f, maxSpeed);
			float t=0;
			t += Time.deltaTime / (homingDelay * 0.01f + 0.0001f);
			m_Particles[i].velocity = Vector3.ClampMagnitude(Vector3.Slerp(m_Particles[i].velocity, m_Particles[i].velocity + diff * speed * 0.01f * f, t), maxSpeed);
			/*
			if (Vector3.Distance(m_Particles[i].position, target[index].position) < dyingRange) {
				//m_Particles[i].lifetime = 0f;// Before Unity 5.5
				m_Particles[i].remainingLifetime = 0f;// Since Unity 5.5
			}
			*/
		}
		m_System.SetParticles(m_Particles, numParticlesAlive);
	}
	
	/*
	void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
		foreach (Transform i in target) {
			Gizmos.DrawSphere(i.position, dyingRange);
		}
    }
	*/
}

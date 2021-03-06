using UnityEngine;

namespace NaughtyAttributes.Test
{
	public class Validation : MonoBehaviour
	{
		[MinValue(0.0f), MaxValue(1.0f)]
		public float minMaxValidated;

		[Required]
		public Transform requiredTransform;

		[Required(message:"Must not be null")]
		public GameObject requiredGameObject;

		[ValidateInput("IsNotNull", "must not be null")]
		public Sprite notNullSprite;

		private bool IsNotNull(Sprite sprite)
		{
			return sprite != null;
		}
	}
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthManager : Photon.MonoBehaviour
{
	public enum PlayerHealthCount
	{
		One = 1,
		Two,
		Three,
		Four
	};

	private RectTransform m_rectTransformComponent;

	private Text m_childHealthText;
	private PlayerHealthCount m_playerHealth;

	// Use this for initialization
	void Start()
	{
		// Set UI to canvas in order for UI to properly work
		gameObject.transform.parent = GameObject.Find ("Canvas").transform;

		m_rectTransformComponent = gameObject.GetComponent<RectTransform>();

		m_childHealthText = gameObject.GetComponentInChildren<Text>();

		m_playerHealth = (PlayerHealthCount)photonView.instantiationData[0];
		SetupPlayerHealthPosition (m_playerHealth);
	}
	
	// Update is called once per frame
	void Update()
	{
	
	}

	[RPC]
	void RemoteHealthUpdate(int healthChanges){
		int healthText = int.Parse(m_childHealthText.text);
		healthText += healthChanges;
		m_childHealthText.text = healthText.ToString();
	}

	void SetupPlayerHealthPosition(PlayerHealthCount player){

		switch (player) {
		case PlayerHealthCount.One:
			m_rectTransformComponent.anchorMin = AnchorHelper.BottomCenter().Min;
			m_rectTransformComponent.anchorMax = AnchorHelper.BottomCenter().Max;
			m_rectTransformComponent.position = PlayerIndicatorHelper.PlayerOne();
			break;
		case PlayerHealthCount.Two:
			m_rectTransformComponent.anchorMin = AnchorHelper.MiddleLeft().Min;
			m_rectTransformComponent.anchorMax = AnchorHelper.MiddleLeft().Max;
			m_rectTransformComponent.position = PlayerIndicatorHelper.PlayerTwo();
			break;
		case PlayerHealthCount.Three:
			m_rectTransformComponent.anchorMin = AnchorHelper.TopCenter().Min;
			m_rectTransformComponent.anchorMax = AnchorHelper.TopCenter().Max;
			m_rectTransformComponent.position = PlayerIndicatorHelper.PlayerThree();
			break;
		case PlayerHealthCount.Four:
			m_rectTransformComponent.anchorMin = AnchorHelper.MiddleRight().Min;
			m_rectTransformComponent.anchorMax = AnchorHelper.MiddleRight().Max;
			m_rectTransformComponent.position = PlayerIndicatorHelper.PlayerFour();
			break;
		}
	}
}

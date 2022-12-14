// "Wave SDK 
// © 2020 HTC Corporation. All Rights Reserved.
//
// Unless otherwise required by copyright law and practice,
// upon the execution of HTC SDK license agreement,
// HTC grants you access to and use of the Wave SDK(s).
// You shall fully comply with all of HTC’s SDK license agreement terms and
// conditions signed by you and all SDK and API requirements,
// specifications, and documentation provided by HTC to You."

using UnityEngine;
using UnityEngine.UI;
using Wave.Essence.Hand;

namespace Wave.Essence.Interaction.Mode.Demo
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(Text))]
	sealed class InteractionModeText : MonoBehaviour
	{
		private Text m_Text = null;
		void Awake()
		{
			m_Text = GetComponent<Text>();
		}

		private void Update()
		{
			if (m_Text != null)
			{
				m_Text.text = "Interaction Mode: " + ClientInterface.InteractionMode;
				if (ClientInterface.InteractionMode == XR_InteractionMode.Hand && HandManager.Instance != null)
				{
					HandManager.TrackerType tracker = HandManager.TrackerType.Natural;
					if (HandManager.Instance.GetPreferTracker(ref tracker)) { m_Text.text += ", " + tracker; }
				}
			}
		}
	}
}

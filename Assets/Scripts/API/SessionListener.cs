using Supabase.Gotrue;
using Supabase.Gotrue.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace API
{
	public class SessionListener : MonoBehaviour
	{
		// Public Unity References
		[FormerlySerializedAs("SupabaseManager")] public SupabaseContainer supabaseContainer = null!;
		public TMP_Text LoggedInEmailAddress = null!;

		public void UnityAuthListener(IGotrueClient<User, Session> sender, Constants.AuthState newState)
		{
			if (sender.CurrentUser?.Email == null)
				LoggedInEmailAddress.text = "No user logged in";
			else
			{
				LoggedInEmailAddress.text = $"Logged in as {sender.CurrentUser.Email}";
			}

			switch (newState)
			{
				case Constants.AuthState.SignedIn:
					Debug.Log("Signed In");
					break;
				case Constants.AuthState.SignedOut:
					Debug.Log("Signed Out");
					break;
				case Constants.AuthState.UserUpdated:
					Debug.Log("Signed In");
					break;
				case Constants.AuthState.PasswordRecovery:
					Debug.Log("Password Recovery");
					break;
				case Constants.AuthState.TokenRefreshed:
					Debug.Log("Token Refreshed");
					break;
				case Constants.AuthState.Shutdown:
					Debug.Log("Shutdown");
					break;
				default:
					Debug.Log("Unknown Auth State Update");
					break;
			}
		}
	}
}

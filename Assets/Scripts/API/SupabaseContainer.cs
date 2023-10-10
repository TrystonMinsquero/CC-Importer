using UnityEngine;

namespace API
{
	[CreateAssetMenu(menuName = "Supabase/Container")]
	public class SupabaseContainer : ScriptableObject
	{
		public static SupabaseContainer Instance { get; private set; }

		// Public Unity references
		// public SessionListener sessionListener = null!;
		public SupabaseSettings supabaseSettings = null!;

		SupabaseConnection _connection;

		public Supabase.Client? Supabase => _connection?.GetClient();
		

		
		
		void OnEnable()
		{

			if (Instance != null)
			{
				OnDisable();
				return;
			}
			
			Instance = this;
			if(_connection == null || !_connection.IsConnected)
				_connection = new SupabaseConnection(supabaseSettings.SupabaseURL, supabaseSettings.SupabaseAnonKey);
		}

		// This is called when Unity shuts down. You want to be sure to include this so that the
		// background thread is terminated cleanly. Keep in mind that if you are running the app
		// in the Unity Editor, if you don't call this method you will leak the background thread!
		void OnDisable()
		{
			_connection?.CloseConnection();
		}
		
		
	}
}

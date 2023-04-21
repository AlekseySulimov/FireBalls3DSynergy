namespace Menu.StateMachine.States
{
	public class EnableVolumeButtonState : ConfigureVolumeButtonState 
	{

		protected override float VolumeLevel => 0.0f;
	}
}
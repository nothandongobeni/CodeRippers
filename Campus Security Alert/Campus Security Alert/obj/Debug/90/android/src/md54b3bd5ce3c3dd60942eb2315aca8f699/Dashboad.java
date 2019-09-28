package md54b3bd5ce3c3dd60942eb2315aca8f699;


public class Dashboad
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("Campus_Security_Alert.Activities.Dashboad, Campus Security Alert", Dashboad.class, __md_methods);
	}


	public Dashboad ()
	{
		super ();
		if (getClass () == Dashboad.class)
			mono.android.TypeManager.Activate ("Campus_Security_Alert.Activities.Dashboad, Campus Security Alert", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}

using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;

namespace SuperApp
{
    [Activity(Label = "Inscris-toi !", MainLauncher = true, Theme = "@style/Theme.SuperApp", Icon = "@drawable/icon")]
    public class ActivityInscription : AppCompatActivity
    {
        TextView m_textviewStep1;
        TextView m_textviewStep2;
        TextView m_textviewStep3;
        FragmentPseudoEmailPassword m_fragStep1;
        FragmentAvatar m_fragStep2;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the layout resource
            SetContentView(Resource.Layout.ActivityInscription);

            // Get our views
            m_textviewStep1 = FindViewById<TextView>(Resource.Id.ActivityInscription_textview_step1);
            m_textviewStep2 = FindViewById<TextView>(Resource.Id.ActivityInscription_textview_step2);
            m_textviewStep3 = FindViewById<TextView>(Resource.Id.ActivityInscription_textview_step3);

            m_fragStep1 = new FragmentPseudoEmailPassword();
            m_fragStep1.ThrowEventGoToNextStep += (s, e) => { GoToStep2(); };

            GoToStep1();
        }

        public void GoToStep1()
        {
            if (m_fragStep1 == null)
                return;

            SupportFragmentManager.BeginTransaction().Replace(Resource.Id.ActivityInscription_frameLayout, m_fragStep1).Commit();
        }

        public void GoToStep2()
        {
            m_fragStep2 = new FragmentAvatar();

            SupportFragmentManager.BeginTransaction().Replace(Resource.Id.ActivityInscription_frameLayout, m_fragStep2).Commit();
        }
    }
}


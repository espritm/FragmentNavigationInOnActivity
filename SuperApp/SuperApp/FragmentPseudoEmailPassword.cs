using Android.Support.V4.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using System;

namespace SuperApp
{
    public class FragmentPseudoEmailPassword : Fragment
    {
        public EditText m_edittextEmail { get; set; }
        public EditText m_edittextPassword { get; set; }
        public EditText m_edittextPseudo { get; set; }
        public Button m_btnNext { get; set; }

        public event PseudoEmailPasswordEventHandler ThrowEventGoToNextStep;

        public class PseudoEmailPasswordEventArgs : EventArgs
        {
            public bool m_bUserHasBeenAdded { get; set; }
        }

        public delegate void PseudoEmailPasswordEventHandler(object sender, PseudoEmailPasswordEventArgs args);

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.FragmentPseudoEmailPassword, null);
            m_edittextPseudo = view.FindViewById<EditText>(Resource.Id.fragmentPseudoEmailPassword_edittext_pseudo);
            m_edittextEmail = view.FindViewById<EditText>(Resource.Id.fragmentPseudoEmailPassword_edittext_mail);
            m_edittextPassword = view.FindViewById<EditText>(Resource.Id.fragmentPseudoEmailPassword_edittext_password);
            m_btnNext = view.FindViewById<Button>(Resource.Id.fragmentPseudoEmailPassword_btn_next);

            m_btnNext.Click += M_btnNext_Click;

            return view;
        }

        private void M_btnNext_Click(object sender, System.EventArgs e)
        {
            //...Add User on server and check if it has been done without error...

            ThrowEventGoToNextStep(this, new PseudoEmailPasswordEventArgs { m_bUserHasBeenAdded = true });
        }
    }
}
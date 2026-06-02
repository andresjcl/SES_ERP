using System;
using System.ComponentModel;
using System.Diagnostics;
using WebServiseSRI;

namespace DaxDocElectronicos.My
{
    internal static partial class MyProject
    {
        internal partial class MyForms
        {
            [EditorBrowsable(EditorBrowsableState.Never)]
            public frmMntDocElectrncos m_frmMntDocElectrncos;

            public frmMntDocElectrncos frmMntDocElectrncos
            {
                [DebuggerHidden]
                get
                {
                    m_frmMntDocElectrncos = Create__Instance__(m_frmMntDocElectrncos);
                    return m_frmMntDocElectrncos;
                }

                [DebuggerHidden]
                set
                {
                    if (ReferenceEquals(value, m_frmMntDocElectrncos))
                        return;
                    if (value is object)
                        throw new ArgumentException("Property can only be set to Nothing");
                    Dispose__Instance__(ref m_frmMntDocElectrncos);
                }
            }
        }
    }
}
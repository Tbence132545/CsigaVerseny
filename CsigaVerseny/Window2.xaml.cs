using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CsigaVerseny
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2(Csiga elso, Csiga ketto, Csiga harom)
        {



            InitializeComponent();
            csiga1elso.Content = elso.hanyszorVoltElso;
            csiga1masodik.Content = elso.hanyszorVoltMasodik;
            csiga1harmadik.Content = elso.hanyszorVoltHarmadik;
            csiga2elso.Content = ketto.hanyszorVoltElso;
            csiga2masodik.Content = ketto.hanyszorVoltMasodik;
            csiga2harmadik.Content = ketto.hanyszorVoltHarmadik;
            csiga3elso.Content = harom.hanyszorVoltElso;
            csiga3masodik.Content = harom.hanyszorVoltMasodik;
            csiga3harmadik.Content = harom.hanyszorVoltHarmadik;
            csiga1pont.Content = elso.pont;
            csiga2pont.Content = ketto.pont;
            csiga3pont.Content = harom.pont;

        }

    }
}

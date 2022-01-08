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
using System.Linq;

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
            List<Csiga> sorrend = new List<Csiga>() { elso, ketto, harom };
            sorrend = sorrend.OrderBy(x => x.pont).ToList();
            sorrend.Reverse();
            elsonev.Content = sorrend[0].Nev;
            masodiknev.Content = sorrend[1].Nev;
            harmadiknev.Content = sorrend[2].Nev;

            csiga1elso.Content = sorrend[0].hanyszorVoltElso;
            csiga1masodik.Content = sorrend[0].hanyszorVoltMasodik;
            csiga1harmadik.Content = sorrend[0].hanyszorVoltHarmadik;
            csiga2elso.Content = sorrend[1].hanyszorVoltElso;
            csiga2masodik.Content = sorrend[1].hanyszorVoltMasodik;
            csiga2harmadik.Content = sorrend[1].hanyszorVoltHarmadik;
            csiga3elso.Content = sorrend[2].hanyszorVoltElso;
            csiga3masodik.Content = sorrend[2].hanyszorVoltMasodik;
            csiga3harmadik.Content = sorrend[2].hanyszorVoltHarmadik;
            csiga1pont.Content = sorrend[0].pont;
            csiga2pont.Content = sorrend[1].pont;
            csiga3pont.Content = sorrend[2].pont;

        }

    }
}

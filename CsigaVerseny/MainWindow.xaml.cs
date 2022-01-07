using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Windows.Threading;

namespace CsigaVerseny
{
   
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static double[] sebessegek = new double[3] {1.15, 1.3 , 1.5 };
        static List<int> kiMelyikSebessegetKapja = new List<int>();
       

        DispatcherTimer idozito = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void start_btn_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();
            for (int i = 0; i < 3; i++)
            {
                int random = rnd.Next(0, 3);
                if(kiMelyikSebessegetKapja.Contains(random))
                while (kiMelyikSebessegetKapja.Contains(random))
                {
                    random = rnd.Next(0, 3);
                }
                kiMelyikSebessegetKapja.Add(random);
                

            }
           
            idozito.Tick += new EventHandler(IdozitoEvent);
            idozito.Interval = new TimeSpan(0, 0, 0,0, 10);
            idozito.Start();
        }

        private void IdozitoEvent(object sender, EventArgs e)
        {
            //Külön alprogramot írok Mozogtat néven mert 3 csiga van
            
            Mozogtat(csiga1, csiga1mezony, sebessegek[kiMelyikSebessegetKapja[0]]);
            Mozogtat(csiga2, csiga2mezony, sebessegek[kiMelyikSebessegetKapja[1]]);
            Mozogtat(csiga3, csiga3mezony, sebessegek[kiMelyikSebessegetKapja[2]]);
            if(csiga1.Margin.Left==930 && csiga2.Margin.Left==930 && csiga3.Margin.Left == 930)
            {
                idozito.Stop();
            }
        }
        private static void Mozogtat(Rectangle csiganev, Rectangle csigamezony, double sebesseg)
        {
            double currentLeft = csiganev.Margin.Left;
            double margintop = csiganev.Margin.Top;
            if (currentLeft + sebesseg < 930)
            {
                csiganev.Margin = new Thickness(currentLeft += sebesseg, margintop, 0 ,0);
            }
            else
            {
                csiganev.Margin = new Thickness(930, margintop, 0 ,0);

            }
        }
       
    }
}

using System.Windows;

namespace single_user_Zeus
{
    /// <summary>
    /// Interaction logic for ToothStatusWindow.xaml
    /// </summary>
    public partial class ToothStatusWindow : Window
    {
        /// current_status p;
        public ToothStatusWindow(uint i)  //current_status p1)
        {
            InitializeComponent();
            switch (i)
            {
                case 22:
                    {
                        load_22();
                        break;
                    }
                case 23:
                    {
                        load_23();
                        break;
                    }
                case 24:
                    {
                        load_24();
                        break;
                    }
            }
        }

        public void load_22()
        {

        }
        public void load_23()
        {

        }
        public void load_24()
        {

        }

    }
}

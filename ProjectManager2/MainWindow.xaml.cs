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

using ProjectManager2.UserControls;

namespace ProjectManager2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Push the first user control into the window
            PushNewUserControl(new MainMenuUC());
        }



        //--------------------//
        // User Control State //
        //--------------------//
        private Stack<UserControl> userControlStack = new Stack<UserControl>();

        /// <summary>
        /// Add a new user control to the window.
        /// </summary>
        /// <param name="control">The user control to display in the window.</param>
        public void PushNewUserControl(UserControl control)
        {
            // Add the new user control to the stack
            userControlStack.Push(control);

            // Set the window content to the control
            this.Content = control;
        }

        /// <summary>
        /// Remove the top user control from the window and restore the next user control to the window.
        /// </summary>
        /// <returns>The removed user control.</returns>
        public UserControl PopUserControl()
        {
            // Make sure we have at least one user control
            if (userControlStack.Count == 0)
            {
                return null;
            }

            // Pop the old control and set the next control as this window's content
            UserControl poppedControl = userControlStack.Pop();
            this.Content = userControlStack.Peek();

            return poppedControl;
        }
    }
}

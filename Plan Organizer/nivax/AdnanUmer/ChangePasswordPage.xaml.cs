using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Basic Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234237

namespace BabyJournal
{
    /// <summary>
    /// A basic page that provides characteristics common to most applications.
    /// </summary>
    public sealed partial class ChangePasswordPage : BabyJournal.Common.LayoutAwarePage
    {
        public ChangePasswordPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="navigationParameter">The parameter value passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested.
        /// </param>
        /// <param name="pageState">A dictionary of state preserved by this page during an earlier
        /// session.  This will be null the first time a page is visited.</param>
        protected override void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="pageState">An empty dictionary to be populated with serializable state.</param>
        protected override void SaveState(Dictionary<String, Object> pageState)
        {
        }

        void RequestGoBack(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(GroupedItemsPage));
        }

        async void OnChangeClick(object sender, RoutedEventArgs e)
        {
            if (iUserName.Text.Length < 4)
            {
                iInvalid.Text = "User Name must conatin atleast 4 characters.";
                iInvalid.Visibility = Windows.UI.Xaml.Visibility.Visible;
                return;
            }

            if (iPass.Password.Length < 4)
            {
                iInvalid.Text = "Password must be of atleat 4 characters long.";
                iInvalid.Visibility = Windows.UI.Xaml.Visibility.Visible;
                return;
            }

            if (iPass.Password != iPass2.Password)
            {
                iInvalid.Text = "Password Mismatch.";
                iInvalid.Visibility = Windows.UI.Xaml.Visibility.Visible;
                return;
            }

            StorageFile pwFile = await ApplicationData.Current.LocalFolder.CreateFileAsync("Passwords.txt", CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(pwFile, iUserName.Text + "\n" + iPass.Password);
            this.Frame.Navigate(typeof(GroupedItemsPage));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DatabaseManagementUI.Commands
{
    public static class SQLQueryPageCommands
    {
		public static readonly RoutedUICommand Exit = new RoutedUICommand
				(
					"Exit",
					"Exit",
					typeof(SQLQueryPageCommands),
					new InputGestureCollection()
					{
					new KeyGesture(Key.F4, ModifierKeys.Alt)
					}
				);
		public static void ExitCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
			{
				e.CanExecute = true;
			}

			public static void ExitCommand_Executed(object sender, ExecutedRoutedEventArgs e)
			{
				Application.Current.Shutdown();
			}
		}
	}

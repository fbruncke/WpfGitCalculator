using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WpfGitCalculator
{
	public class Command : ICommand
	{
		//Using the generic delegates
		readonly Func<object, bool> _canExecute;
		readonly Action<object> _execute;

		public Command(Action<object> execute)
		{
			if (execute == null)
				throw new ArgumentNullException(nameof(execute));

			_execute = execute;
		}

		public Command(Action execute) : this(o => execute())
		{
			if (execute == null)
				throw new ArgumentNullException(nameof(execute));
		}

		public Command(Action<object> execute, Func<object, bool> canExecute) : this(execute)
		{
			if (canExecute == null)
				throw new ArgumentNullException(nameof(canExecute));

			_canExecute = canExecute;
		}

		public Command(Action execute, Func<bool> canExecute) : this(o => execute(), o => canExecute())
		{
			if (execute == null)
				throw new ArgumentNullException(nameof(execute));
			if (canExecute == null)
				throw new ArgumentNullException(nameof(canExecute));
		}

		//CommandManager.RequerySuggested is not wired up, needs to be done before it can be used
		public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
		{
			if (_canExecute != null)
				return _canExecute(parameter);

			return true;
		}

		
		/// <summary>
		/// Forwarding the execute call
		/// Done by invoking the delegate instance
		/// </summary>
		/// <param name="parameter"></param>
		public void Execute(object parameter)
		{
			_execute(parameter);
		}

	}
}

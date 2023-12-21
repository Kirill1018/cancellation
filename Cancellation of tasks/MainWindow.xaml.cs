using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
namespace Cancellation_of_tasks
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Task task1 = new Task(() => Bar_val(1)), task2 = new Task(() => Bar_val(2)), task3 = new Task(() => Bar_val(3)), task4 = new Task(() => Bar_val(4)), task5 = new Task(() => MessageBox.Show("копирование завершено"));
            Task[] tasks = { task1, task2, task3, task4 };
            for (int i = 0; i < tasks.Length; i++) tasks[i].Start();
            task5.Start();
        }
        public void Bar_val(int task_numb)
        {
            for (int i = 0; i < 100; i++)
            {
                if (task_numb == 1) Dispatcher.Invoke(() => bar1.Value = i);
                else if (task_numb == 2) Dispatcher.Invoke(() => bar2.Value = i);
                else if (task_numb == 3) Dispatcher.Invoke(() => bar3.Value = i);
                else Dispatcher.Invoke(() => bar4.Value = i);
            }
        }
        public static void Waiting(Task task1, Task task2, Task task3, Task task4) { Task.WhenAll(task1, task2, task3, task4).Wait(); }
        private void button_Click(object sender, RoutedEventArgs e) { new CancellationTokenSource().Cancel(); }
    }
}
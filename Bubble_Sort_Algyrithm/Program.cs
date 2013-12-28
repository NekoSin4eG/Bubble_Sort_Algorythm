/*
 * Created by SharpDevelop.
 * User: Савельев Олег
 * Date: 28.12.2013
 * Time: 21:19
 */
using System;

namespace Bubble_Sort_Algyrithm
{
	class Program
	{
		#region Variables
			private static int elementsInArray = 0; //Количество элементов в массиве
			private static int[] mainArray; //Главный массив
			private static int temp = 0; //Переменная для метода алгоритма сортировки
		#endregion
		
		/// <summary>
    	/// Главная точка входа в программу
    	/// </summary>
    	/// <param name="args">Аргументы командной строки</param>
		public static void Main(string[] args)
		{
			SetSettings();
			MainDialog();
			SetCountDigitsInArray();
			InsertArray();
			BubbleSort();
			ShowArray();
			ShowExit();
		}
		
		/// <summary>
    	/// Вывод диалога о закрытии программы
    	/// </summary>
		private static void ShowExit()
		{
			Console.WriteLine();
			Console.WriteLine();
			Console.Write("Для выхода нажмите любую клавишу");
			Console.ReadKey(true);
		}
		
		/// <summary>
    	/// Вывод основного диалога программы
    	/// </summary>
		private static void MainDialog()
		{
			Console.Write("Демонстрация алгоритма сортировки одномерного массива \"пузырьком\".");
			Console.WriteLine();
		}
		
		/// <summary>
    	/// Вывод всех элементов массива на экран
    	/// </summary>
		private static void ShowArray()
		{
			Console.WriteLine();
			Console.Write("Отсортированный массив: ");
			
			for(int i = 1; i < mainArray.Length; i++)
			{
				Console.Write(mainArray[i]+ " ");
			}
		}
		
		/// <summary>
    	/// Сортировка массива "пузырьком"
    	/// </summary>
		private static void BubbleSort()
		{
			for(int j = 1; j < mainArray.Length - 1; j++)
			{
				int f = 0;
				for(int i = 1; i < mainArray.Length - j; i++)
				{
					if(mainArray[i] > mainArray[i + 1])
					{
						temp = mainArray[i];
						mainArray[i] = mainArray[i + 1];
						mainArray[i + 1] = temp;
						f = 1;
					}
				}
				if(f == 0) break;
			}
		}
		
		/// <summary>
    	/// Установка количества элементов в массиве
    	/// </summary>
		private static void SetCountDigitsInArray()
		{
			do
			{
				Console.Write("Введите количество элементов для сортировки[1-10]: ");
				Int32.TryParse(Console.ReadLine(), out elementsInArray); //Преобразование входных символов в целочисленный тип данных
				Console.WriteLine();
			} while (IsNotDigit(elementsInArray));
			
			mainArray = new int[elementsInArray + 1]; //Инициализируем массив
		}
		
		/// <summary>
    	/// Ввод чисел в массив
    	/// </summary>
		private static void InsertArray()
		{
			for(int i = 1; i <= elementsInArray; i++) //Цикл для ввода чисел в массив. #FIX: Сделать проверку, что вводится число
			{
				Console.Write(String.Format("Число #{0} = ",i));
				mainArray[i] = Int32.Parse(Console.ReadLine());
			}
		}
		
		/// <summary>
    	/// Установка параметров отображения консоли
    	/// </summary>
		private static void SetSettings()
		{
			Console.Title = "Сортировка массива \"пузырьком\""; //Установка заголовка окна консоли
			Console.ForegroundColor = ConsoleColor.Green; //Установка цвета выводимых символов в окне консоли (Зелёный)
		}
		
		/// <summary>
    	/// Проверка, что число - это число
    	/// </summary>
    	/// <param name="digit">Число для проверки. Если число равно 0, то был введен символ</param>
		private static bool IsNotDigit(int digit)
		{
			Math.Abs(digit);
			if(digit > 0 && digit <= 10)
			{
				return false; //Если число, то возвращаем false, что позволит заверщить цикл в методе Main
			}
			else
			{
				return true; //Если не число, то возвращаем true, что позволит продолжить цикл в методе Main
			}
		}
	}
}
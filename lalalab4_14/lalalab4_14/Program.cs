/*Класс - очередь Queue.
 * Дополнительно перегрузить следующие операции:
 * + - добавить элемент; -- - извлечь элемент;
 * true - проверка, пустая ли очередь; 
 * < - копирование одной очереди в другую
 * с сортировкой в убывающем порядке; неявный int() мощность.
Методы расширения:
1) Индекс первой точки
2) Последний элемент очереди
*/

//Rextester.Program.Main is the entry point for your code. Don't change it.
//Compiler version 4.0.30319.17929 for Microsoft (R) .NET Framework 4.5

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace lalalab4_14
{
	public class MyQueue
	{
		public Queue<int> queue;

		public MyQueue()
		{
			queue = new Queue<int>();
		}

		public MyQueue(Queue<int> q)
		{
			queue = q;
		}

		/*
        * декремент может возвращать только объект того же класса, что и входной параметр
        * невозможно перегрузить декремент так чтобы он возвращал элемент очереди, так как
        * очередь и элемент очереди принадлежат разным классам
        public static int operator — (MyQueue a)
        {
        return a.queue.Dequeue();
        }
        */

		//Перегруженный оператор + 
		public static MyQueue operator +(MyQueue a1, int element)
		{
			a1.queue.Enqueue(element);
			return a1;
		}

		// Перегруженный оператор true, юзается в том случае если q используется как условие
		public static Boolean operator true(MyQueue q)
		{
			return (q.queue.Count == 0);
		}

		// Перегружен потому что без него перегрузка true не работает
		public static Boolean operator false(MyQueue q)
		{
			return (q.queue.Count < 0);
		}

		// Перегруженный оператор < 
		public static MyQueue operator <(MyQueue q1, MyQueue q2)
		{
			// клеим две очереди
			while (q2.queue.Count != 0)
			{
				q1.queue.Enqueue(q2.queue.Dequeue());
			}
			// получаем массив элементов
			int[] arr = q1.queue.ToArray();

			// создаем новую очередь из упорядоченного по убыванию массива
			Queue<int> q = new Queue<int>(arr.OrderByDescending(x => x));
			return new MyQueue(q);
		}

		// Без него < не работает
		public static MyQueue operator >(MyQueue q1, MyQueue q2)
		{
			return null;
		}

		// сделано для удобства чтобы выводить содержимое очереди
		public override string ToString()
		{
			int[] arr = this.queue.ToArray();
			string arr_str = "[";
			for (int i = 0; i < arr.Length; i++)
			{
				arr_str += arr[i] + ", ";
			}
			arr_str = arr_str.Remove(arr_str.Length - 1);
			arr_str = arr_str.Remove(arr_str.Length - 1);
			arr_str += "]";
			return arr_str;
		}

		// перегрузка неявного преобразования к int
		public static implicit operator int(MyQueue q)
		{
			return (q.queue.Count);
		}

		// вложенный класс 1

		public class Owner
		{
			private int Id;
			private string name;
			private string org;

			public Owner(int _Id, string _name, string _org)
			{
				Id = _Id;
				name = _name;
				org = _org;
			}

			public string getInfo()
			{
				string s = "";
				s += "ID: ";
				s += Id + "\n";
				s += "Name: ";
				s += name + "\n";
				s += "ORGANISATION: ";
				s += org + "\n";
				return s;
			}
		}

		// вложенный класс 2
		public class MyDate
		{
			private string dateOfCreate;

			public MyDate()
			{
				dateOfCreate = DateTime.Now.ToString();
			}

			public string getDate()
			{
				return dateOfCreate;
			}
		}
	}

	public static class ExtensionMethod
	{
		// хз что такое "индекс первой точки" в очереди, вообще без понятия, этого метода тут нету

		// метод расширение, получение последнего элемента очереди
		public static int LastElement(this MyQueue q)
		{
			return q.queue.Peek();
		}
	}

	public static class MathObject
	{
		//методы расширения для работы с MyQueue

		//увеличение всех элементво в 2 раза
		public static void x2(this MyQueue q)
		{
			int[] arr = q.queue.ToArray();
			for (int i = 0; i < arr.Length; i++)
			{
				arr[i] = arr[i] * 2;
			}
			Queue<int> q_res = new Queue<int>(arr);
			q.queue = q_res;
			//return new MyQueue(q_res);
		}

		//инкремент
		public static void inc(this MyQueue q)
		{
			int[] arr = q.queue.ToArray();
			for (int i = 0; i < arr.Length; i++)
			{
				arr[i]++;
			}
			Queue<int> q_res = new Queue<int>(arr);
			q.queue = q_res;
			//return new MyQueue(q_res);
		}

		//декремент
		public static void dec(this MyQueue q)
		{
			int[] arr = q.queue.ToArray();
			for (int i = 0; i < arr.Length; i++)
			{
				arr[i]--;
			}
			Queue<int> q_res = new Queue<int>(arr);
			q.queue = q_res;
			//return new MyQueue(q_res);
		}

		//метод расширения для строки
		public static string sortChar(this string s)
		{
			char[] arr = s.ToArray();
			char[] arr2 = arr.OrderBy(x => x).ToArray();
			string s2 = new string(arr2);
			return s2;
		}
	}

	class MainClass
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Start testing");
			MyQueue q1 = new MyQueue();
			//проверка пустоты очереди
			if (q1) Console.WriteLine("Queue is empty");
			else Console.WriteLine("Queue is not empty");
			//добавляем элемент
			q1 = q1 + 1;
			Console.WriteLine("Очередь: " + q1);
			//еще один элемент
			q1 = q1 + 2;
			if (q1) Console.WriteLine("Queue is empty");
			else Console.WriteLine("Queue is not empty");
			Console.WriteLine("Очередь: " + q1);
			// Неявное приведение к int
			int a = q1;
			Console.WriteLine("Мощность: " + a);
			Console.WriteLine("Последний элемент очереди: " + q1.LastElement());
			// создаем новую очередь
			MyQueue q2 = new MyQueue();
			q2 = q2 + 3;
			q2 = q2 + 6;
			q2 = q2 + 4;
			Console.WriteLine("Очередь 2: " + q2);
			// объединяем очереди с сортировкой по убыванию
			MyQueue q = q1 < q2;
			Console.WriteLine(q.ToString());

			Console.WriteLine("Вложенный класс 1: ");
			MyQueue.Owner owner = new MyQueue.Owner(1, "Анастасия Томко", "Buiok Soset, Inc.");
			Console.WriteLine(owner.getInfo());
			Console.WriteLine("Вложенный класс 2: ");
			MyQueue.MyDate date = new MyQueue.MyDate();
			Console.WriteLine(date.getDate());

			// метод расширения: увеличение в 2 каждого элемента
			q.x2();
			Console.WriteLine("Увеличение общей очереди в 2 раза: " + q);
			// метод расширения: инкремент
			q.inc();
			Console.WriteLine("Инкремент: " + q);
			// метод расширения: декремент
			q.dec();
			Console.WriteLine("Декремент: " + q);
			// метод расширения: сортировка символов в строке
			string s = "iosnfgbasdfadjknv";
			Console.WriteLine("Начальная строка: " + s);
			s = s.sortChar();
			Console.WriteLine("Cтрока после сортировки: " + s);
		}
	}
}

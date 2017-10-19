using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lalalab2_1
{
    class MainClass
    {
		public static void Main(string[] args)
		{
			//примитивные типы С#
			int a = 25;
			string b = "hello";
			double c = 123.456;
			float d = 20.45F;
			byte e = 1;
			sbyte f = -36;
			uint n = 568230;
			short m = -20564;
			ushort o = 2036;
			long p = -85746925;
			ulong r = 4512298423;
			char[] z = { 'a', 'b', 'c' };
			bool q = true;
			object i = "asd";
			decimal u = 5561651654848545;

			//неявное преобразование типов;
			int num = 52561651;
			long bigNum = num;

			byte pre = 13;
			short newPre = pre;

			ulong first = 123654;
			decimal newFirst = first;

			long obed = -5165656;
			float newObed = obed;

			//явное преобразование типов
			double x = 1234.7;
			int ae = 0;
			ae = (int)x;

			sbyte acv = (sbyte)a;
			short pav = (short)p;
			long dev = (long)d;

			// упаковка и распаковка значимых типов
			Int32 xa = 5;
			Object op = xa;   // Упаковка x; o ссылается на упакованный объект
			byte mam = (byte)(int)op; // Распаковка, а затем приведение типа

			// типы Nullable применяется только для типов значений
			int? ix = null;// упрощенная форма использования структуры System.Nullable<T>, которая позволяет null значения
			Nullable<int> x2 = 5;

			//Строковые литералы. сравнение
			string message = "You can read this phrase";
			string message1 = "You can rememmber this phrase";

			/* Строки не поддерживают операторы < и >. Вместо них для сравнения строк нужно
               использовать строковой метод CompareTo, который возвращает 1 если первая
               строка предшествует второй, -1  если вторая строка предшествует первой 
               и 0 если строки равны:   */

			Console.Write("Boston".CompareTo("Austin")); // 1
			Console.Write("Boston".CompareTo("Boston")); // 0
			Console.Write("Boston".CompareTo("Chicago")); // -1

			//сцепление, копирование, выделение подстроки, разделение строки на слова, 
			//вставки подстроки в заданную позицию, удаление заданной подстроки. 
			string s = "a" + 5; // a5

			// copy
			string str1 = "abc";
			string str2 = "xyz";

			Console.WriteLine("\n After String.Copy...");
			str2 = String.Copy(str1);
			Console.WriteLine("str1 = '{0}'", str1);
			Console.WriteLine("str2 = '{0}'", str2);

			// удаление 
			string text = " hello world ";
			text = text.Trim(); // результат "hello world"
			text = text.Trim(new char[] { 'd', 'h' }); // результат "ello worl"
													   //or
			string text1 = "Хороший день";
			// индекс последнего символа
			int ind = text1.Length - 1;
			// вырезаем последний символ
			text1 = text1.Remove(ind);
			Console.WriteLine(text1);

			//замена
			string text2 = "хороший день";
			text2 = text2.Replace("хороший", "плохой");
			Console.WriteLine(text2);
			text2 = text2.Replace("о", "");
			Console.WriteLine(text2);

			//Вставка
			String strTarget = "asdf".Insert(1, "value");
			Console.WriteLine(strTarget);
			//avaluesdf

			//remove(итог He) 
			string s1 = "Hello C#";
			string s2 = s1.Remove(2);
			Console.WriteLine(s2);

			//пустая строка
			string empty = "";
			Console.WriteLine(empty == ""); // True
			Console.WriteLine(empty == string.Empty); // True
			Console.WriteLine(empty.Length == 0); // True

			//null string
			string nullString = null;
			Console.WriteLine(nullString == null); // True
			Console.WriteLine(nullString == ""); // False


			//stringBuildier
			StringBuilder sb = new StringBuilder();
			for (int ia = 0; ia < 50; ia++) sb.Append(ia + ",");
			Console.WriteLine(sb.ToString());
			// Результат: от 0 до 49
			sb.Insert(2, "hello world");
			sb.Remove(25, 10);

			// двумерный массив
			int[,] myArr = {
							 {1,10},
							 {2,20},
							 {3,30},
							 {4,40}
						};
			String[] collection = new String[] { "1-й элемент", "2-й элемент", "3-й элемент" };
			//Последовательно выводим в консоль элементы массива
			foreach (String element in collection)
			{
				Console.WriteLine(element);
			}
			Console.WriteLine(collection.Length + "элемента.");


			int[][] azaza = { new int[3], new int[5], new int[4] };
			foreach (int[] xup in azaza)
			{
				foreach (int bom in xup) Console.Write("\t" + bom);
				Console.WriteLine();
			}

			//неявно типизированная переменная для хранения массива
			var jagged = new[] { new[] { 1, 2, 3, 4 }, new[] { 9, 8, 7 }, new[] { 11, 12, 13, 14, 15 } };
			for (int j = 0; j < jagged.Length; j++)
			{
				for (int ie = 0; ie < jagged[j].Length; ie++)
					Console.Write(jagged[j][ie] + " ");
				Console.WriteLine();
			}


			//картеж с 5-ю типами
			Tuple<string, int, string, string, ulong> student =
            new Tuple<string, int, string, string, ulong>("Byi", 18, "student", "from_Minsk", 21071999);


            Console.WriteLine($"Tuple.Item1: {student.Item1}");
            Console.WriteLine($"Tuple.Item3: {student.Item3}");
            Console.WriteLine($"Tuple.Item4: {student.Item4}");

		}

		static void FunctionVar(string[] args)
		{
			var name = "Anton Edyardovich";
			var age = 26;
			var isProgrammer = true;

			// Определяем тип переменных
			Type nameType = name.GetType();
			Type ageType = age.GetType();
			Type isProgrammerType = isProgrammer.GetType();

			// Выводим в консоль результаты
			Console.WriteLine("Тип name: {0}", nameType);
			Console.WriteLine("Тип age: {0}", ageType);
			Console.WriteLine("Тип isProgrammer: {0}", isProgrammerType);
			Console.ReadLine();


		}
    }
}

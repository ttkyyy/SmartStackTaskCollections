namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Демонстрация работы SmartStack<T> ===\n");

            try
            {
                // Демонстрация конструктора без параметров
                Console.WriteLine("1. Конструктор без параметров:");
                var stack1 = new SmartStack<int>();
                Console.WriteLine($"Емкость: {stack1.Capacity}, Количество: {stack1.Count}");
                stack1.Push(10);
                stack1.Push(20);
                stack1.Push(30);
                Console.WriteLine($"После добавления элементов: Емкость: {stack1.Capacity}, Количество: {stack1.Count}");
                Console.WriteLine($"Вершина стека: {stack1.Peek()}");
                Console.WriteLine();

                // Демонстрация конструктора с указанием емкости
                Console.WriteLine("2. Конструктор с указанием емкости (10):");
                var stack2 = new SmartStack<int>(10);
                Console.WriteLine($"Емкость: {stack2.Capacity}, Количество: {stack2.Count}");
                Console.WriteLine();

                // Демонстрация конструктора с коллекцией
                Console.WriteLine("3. Конструктор с коллекцией (IEnumerable):");
                var initialData = new List<int> { 1, 2, 3, 4, 5 };
                var stack3 = new SmartStack<int>(initialData);
                Console.WriteLine($"Исходная коллекция: {string.Join(", ", initialData)}");
                Console.Write("Стек (от вершины к основанию): ");
                foreach (var item in stack3)
                {
                    Console.Write($"{item} ");
                }
                Console.WriteLine();
                Console.WriteLine($"Вершина стека: {stack3.Peek()}");
                Console.WriteLine();

                // Демонстрация Push и автоматического увеличения емкости
                Console.WriteLine("4. Демонстрация Push и автоматического увеличения емкости:");
                var stack4 = new SmartStack<int>(4);
                Console.WriteLine($"Начальная емкость: {stack4.Capacity}");

                for (int i = 1; i <= 10; i++)
                {
                    stack4.Push(i * 10);
                    Console.WriteLine($"Добавлен: {i * 10}, Количество: {stack4.Count}, Емкость: {stack4.Capacity}");
                }
                Console.WriteLine();

                // Демонстрация PushRange
                Console.WriteLine("5. Демонстрация PushRange:");
                var stack5 = new SmartStack<string>();
                stack5.Push("First");
                stack5.Push("Second");
                Console.Write("Исходный стек (от вершины к основанию): ");
                foreach (var item in stack5)
                {
                    Console.Write($"{item} ");
                }
                Console.WriteLine();

                var newItems = new List<string> { "A", "B", "C" };
                Console.WriteLine($"Добавляем коллекцию: {string.Join(", ", newItems)}");
                stack5.PushRange(newItems);
                Console.Write("Стек после добавления (от вершины к основанию): ");
                foreach (var item in stack5)
                {
                    Console.Write($"{item} ");
                }
                Console.WriteLine();
                Console.WriteLine($"Вершина стека: {stack5.Peek()}");
                Console.WriteLine();

                // Демонстрация Pop
                Console.WriteLine("6. Демонстрация Pop:");
                var stack6 = new SmartStack<int>();
                stack6.Push(10);
                stack6.Push(20);
                stack6.Push(30);
                stack6.Push(40);
                stack6.Push(50);
                Console.Write("Стек (от вершины к основанию): ");
                foreach (var item in stack6)
                {
                    Console.Write($"{item} ");
                }
                Console.WriteLine();

                while (stack6.Count > 0)
                {
                    var element = stack6.Pop();
                    Console.WriteLine($"Извлечен: {element}, Осталось: {stack6.Count}");
                }
                Console.WriteLine();

                // Демонстрация Contains
                Console.WriteLine("7. Демонстрация Contains:");
                var stack7 = new SmartStack<int>();
                stack7.Push(10);
                stack7.Push(20);
                stack7.Push(30);
                stack7.Push(40);
                stack7.Push(50);
                Console.Write("Стек (от вершины к основанию): ");
                foreach (var item in stack7)
                {
                    Console.Write($"{item} ");
                }
                Console.WriteLine();
                Console.WriteLine($"Содержит 30: {stack7.Contains(30)}");
                Console.WriteLine($"Содержит 100: {stack7.Contains(100)}");
                Console.WriteLine();

                // Демонстрация индексатора
                Console.WriteLine("8. Демонстрация индексатора:");
                var stack8 = new SmartStack<string>();
                stack8.Push("A");
                stack8.Push("B");
                stack8.Push("C");
                stack8.Push("D");
                stack8.Push("E");
                Console.Write("Стек (от вершины к основанию): ");
                foreach (var item in stack8)
                {
                    Console.Write($"{item} ");
                }
                Console.WriteLine();
                Console.WriteLine($"stack[0] (вершина): {stack8[0]}");
                Console.WriteLine($"stack[2] (глубина 2): {stack8[2]}");
                Console.WriteLine($"stack[Count-1] (основание): {stack8[stack8.Count - 1]}");
                Console.WriteLine();

                // Демонстрация итерации (IEnumerable)
                Console.WriteLine("9. Демонстрация итерации (foreach):");
                var stack9 = new SmartStack<string>();
                stack9.Push("Bottom");
                stack9.Push("Middle");
                stack9.Push("Top");
                Console.Write("Обход от вершины к основанию: ");
                foreach (var item in stack9)
                {
                    Console.Write($"{item} ");
                }
                Console.WriteLine("\n");

                // Демонстрация обработки исключений
                Console.WriteLine("10. Демонстрация обработки исключений:");
                var emptyStack = new SmartStack<int>();
                Console.WriteLine("Попытка извлечь элемент из пустого стека...");

                try
                {
                    emptyStack.Pop();
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($"Исключение: {ex.Message}");
                }

                Console.WriteLine("Попытка получить элемент по неверному индексу...");
                try
                {
                    var element = emptyStack[5];
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    Console.WriteLine($"Исключение: {ex.Message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }

    /// <summary>
    /// Умный стек с дополнительными возможностями.
    /// </summary>
    /// <typeparam name="T">Тип элементов стека.</typeparam>
    public class SmartStack<T> : IEnumerable<T>
    {
        private T[] _items;
        private int _count;
        private const int DefaultCapacity = 4;

        /// <summary>
        /// Конструктор без параметров (емкость 4).
        /// </summary>
        public SmartStack()
        {
            _items = new T[DefaultCapacity];
            _count = 0;
        }

        /// <summary>
        /// Конструктор с указанием начальной емкости.
        /// </summary>
        /// <param name="capacity">Начальная емкость стека.</param>
        /// <exception cref="ArgumentException">Если емкость меньше 0.</exception>
        public SmartStack(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentException("Емкость не может быть отрицательной.", nameof(capacity));

            _items = new T[capacity];
            _count = 0;
        }

        /// <summary>
        /// Конструктор, создающий стек из коллекции.
        /// </summary>
        /// <param name="collection">Коллекция для инициализации стека.</param>
        /// <exception cref="ArgumentNullException">Если коллекция null.</exception>
        public SmartStack(IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));

            var list = collection.ToList();
            _items = new T[list.Count];
            _count = list.Count;

            // Копируем элементы в обратном порядке (последний элемент коллекции - вершина)
            for (int i = 0; i < list.Count; i++)
            {
                _items[i] = list[list.Count - 1 - i];
            }
        }

        /// <summary>
        /// Получает количество элементов в стеке.
        /// </summary>
        public int Count => _count;

        /// <summary>
        /// Получает емкость стека (длину внутреннего массива).
        /// </summary>
        public int Capacity => _items.Length;

        /// <summary>
        /// Добавляет элемент на вершину стека.
        /// </summary>
        /// <param name="item">Добавляемый элемент.</param>
        public void Push(T item)
        {
            if (_count == _items.Length)
            {
                Resize(_items.Length * 2);
            }

            _items[_count] = item;
            _count++;
        }

        /// <summary>
        /// Добавляет коллекцию элементов на вершину стека.
        /// </summary>
        /// <param name="collection">Коллекция для добавления.</param>
        /// <exception cref="ArgumentNullException">Если коллекция null.</exception>
        public void PushRange(IEnumerable<T> collection)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));

            var list = collection.ToList();
            if (list.Count == 0)
                return;

            // Увеличиваем емкость при необходимости
            int newCount = _count + list.Count;
            if (newCount > _items.Length)
            {
                int newCapacity = _items.Length;
                while (newCapacity < newCount)
                {
                    newCapacity *= 2;
                }
                Resize(newCapacity);
            }

            // Добавляем элементы в обратном порядке (последний элемент коллекции - вершина)
            for (int i = list.Count - 1; i >= 0; i--)
            {
                _items[_count] = list[i];
                _count++;
            }
        }

        /// <summary>
        /// Удаляет и возвращает элемент с вершины стека.
        /// </summary>
        /// <returns>Элемент с вершины стека.</returns>
        /// <exception cref="InvalidOperationException">Если стек пуст.</exception>
        public T Pop()
        {
            if (_count == 0)
                throw new InvalidOperationException("Стек пуст. Невозможно извлечь элемент.");

            _count--;
            T item = _items[_count];
            _items[_count] = default(T); 

            return item;
        }

        /// <summary>
        /// Возвращает элемент с вершины стека без удаления.
        /// </summary>
        /// <returns>Элемент с вершины стека.</returns>
        /// <exception cref="InvalidOperationException">Если стек пуст.</exception>
        public T Peek()
        {
            if (_count == 0)
                throw new InvalidOperationException("Стек пуст. Невозможно получить элемент.");

            return _items[_count - 1];
        }

        /// <summary>
        /// Проверяет наличие элемента в стеке.
        /// </summary>
        /// <param name="item">Искомый элемент.</param>
        /// <returns>True, если элемент найден; иначе False.</returns>
        public bool Contains(T item)
        {
            return Array.IndexOf(_items, item, 0, _count) != -1;
        }

        /// <summary>
        /// Индексатор для доступа к элементам по глубине (0 - вершина, Count-1 - основание).
        /// </summary>
        /// <param name="index">Индекс элемента (0 - вершина).</param>
        /// <returns>Элемент на указанной глубине.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Если индекс вне диапазона.</exception>
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= _count)
                    throw new ArgumentOutOfRangeException(nameof(index), "Индекс находится вне границ стека.");

                return _items[_count - 1 - index];
            }
            set
            {
                if (index < 0 || index >= _count)
                    throw new ArgumentOutOfRangeException(nameof(index), "Индекс находится вне границ стека.");

                _items[_count - 1 - index] = value;
            }
        }

        /// <summary>
        /// Возвращает перечислитель для обхода стека от вершины к основанию.
        /// </summary>
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = _count - 1; i >= 0; i--)
            {
                yield return _items[i];
            }
        }

        /// <summary>
        /// Возвращает перечислитель для обхода стека от вершины к основанию.
        /// </summary>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Изменяет размер внутреннего массива.
        /// </summary>
        /// <param name="newCapacity">Новая емкость.</param>
        private void Resize(int newCapacity)
        {
            if (newCapacity < _items.Length)
                return;

            var newArray = new T[newCapacity];
            Array.Copy(_items, 0, newArray, 0, _count);
            _items = newArray;
        }
    }
}
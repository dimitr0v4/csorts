using System;

namespace _212251
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
           
            Worker[] firma = new Worker[] { new Worker("Georgi", 3500), new Worker("Mila",4000),new Worker("Nikiphor",3000),new Worker("Yakov",4500)};
           
            Sort(firma);
            foreach(Worker w in firma) 
            { Console.WriteLine(w.Name + " " + w.Salary); }
        }
        public static void Sort(Worker[] array)
        { MergeSortRecursive(array, 0, array.Length - 1); }
        private static void MergeSortRecursive(Worker[] array, int left, int right)
        {
            if (left < right)
            {
                int mid = left + (right - left) / 2;
                MergeSortRecursive(array, left, mid);
                MergeSortRecursive(array, mid + 1, right);
                Merge(array, left, mid, right);
            }
        }
        private static void Merge(Worker[] array ,int left, int mid, int right)
        {
            int leftSize = mid - left + 1, rightSize = right - mid;
            Worker[] leftArr = new Worker[leftSize], rightArr = new Worker[rightSize];

            Array.Copy(array, left, leftArr, 0, leftSize);
            Array.Copy(array, mid + 1, rightArr, 0, rightSize);

            int i = 0, j = 0, k = left;
            while (i < leftSize && j < rightSize)
                array[k++].Salary = (leftArr[i].Salary <= rightArr[j].Salary) ? leftArr[i++].Salary : rightArr[j++].Salary;

            while (i < leftSize) array[k++] = leftArr[i++];
            while (j < rightSize) array[k++] = rightArr[j++];

        }
    }
}

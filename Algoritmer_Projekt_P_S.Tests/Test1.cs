namespace Algoritmer_Projekt_P_S.Tests
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void BubbleSortTest_Empty()
        {
            var sort = new Sort();
            var liste = new MyList<int>();

            int comparisons = sort.BubbleSort(liste, Comparer<int>.Default);

            Assert.AreEqual(0, liste.Count);
            Assert.AreEqual(0, comparisons);
        }

        [TestMethod]
        public void InsertionSortTest_Empty()
        {
            var sort = new Insertion();
            var liste = new MyList<int>();

            int comparisons = sort.InsertionSort(liste, Comparer<int>.Default);

            Assert.AreEqual(0, liste.Count);
            Assert.AreEqual(0, comparisons);
        }

        [TestMethod]
        public void BubbleSortTest_Sorted()
        {
            var sort = new Sort();
            var liste = new MyList<int>();
            int[] ints = { 1, 2, 3, 4, 5, 6 };
            foreach (int tal in ints) liste.Add(tal);

            int comparisons = sort.BubbleSort(liste, Comparer<int>.Default);

            for (int i = 0; i < 6; i++)
            {
                Assert.AreEqual(i + 1, liste[i]);
            }
            Assert.AreEqual(15, comparisons);
        }
        [TestMethod]
        public void InsertionSortTest_Sorted()
        {
            var sort = new Insertion();
            var liste = new MyList<int>();
            int[] ints = { 1, 2, 3, 4, 5, 6 };
            foreach (int tal in ints) liste.Add(tal);

            int comparisons = sort.InsertionSort(liste, Comparer<int>.Default);

            for (int i = 0; i < 6; i++)
            {
                Assert.AreEqual(i + 1, liste[i]);
            }
            Assert.IsTrue(comparisons < 15);
        }

        [TestMethod]
        public void BubbleSortTest_OneElement()
        {
            var sort = new Sort();
            var liste = new MyList<int>();
            liste.Add(3);

            int comparisons = sort.BubbleSort(liste, Comparer<int>.Default);

            Assert.AreEqual(1, liste.Count);
            Assert.AreEqual(3, liste[0]);
        }

        [TestMethod]
        public void InsertionSortTest_OneElement()
        {
            var sort = new Insertion();
            var liste = new MyList<int>();
            liste.Add(3);

            int comparisons = sort.InsertionSort(liste, Comparer<int>.Default);

            Assert.AreEqual(1, liste.Count);
            Assert.AreEqual(3, liste[0]);
        }

        [TestMethod]
        public void BubbleSortTest_SameElements()
        {
            var sort = new Sort();
            var liste = new MyList<int>();
            int[] ints = { 6, 2, 6, 9, 6 };
            foreach (int tal in ints) liste.Add(tal);

            int comparisons = sort.BubbleSort(liste, Comparer<int>.Default);

            Assert.AreEqual(2, liste[0]);
            Assert.AreEqual(6, liste[1]);
            Assert.AreEqual(6, liste[2]);
            Assert.AreEqual(6, liste[3]);
            Assert.AreEqual(9, liste[4]);
        }


        [TestMethod]
        public void InsertionSortTest_SameElements()
        {
            var sort = new Insertion();
            var liste = new MyList<int>();
            int[] ints = { 6, 2, 6, 9, 6 };
            foreach (int tal in ints) liste.Add(tal);

            int comparisons = sort.InsertionSort(liste, Comparer<int>.Default);

            Assert.AreEqual(2, liste[0]);
            Assert.AreEqual(6, liste[1]);
            Assert.AreEqual(6, liste[2]);
            Assert.AreEqual(6, liste[3]);
            Assert.AreEqual(9, liste[4]);
        }
    }
}

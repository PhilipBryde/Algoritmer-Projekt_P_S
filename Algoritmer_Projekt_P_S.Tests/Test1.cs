namespace Algoritmer_Projekt_P_S.Tests


    /// Vores unit tests bliver lavet her 
    /// her følger vi kravene for de tests der skulle laves 
    /// 8 test hvor man nemt kan se hvad der bliver testet for, 4 for hver algoritme
    /// [TestClass] skrives for at det kan køres i test vinduet
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void BubbleSortTest_Empty() //Bubble sort tom test 
        {
            //Arrange
            var sort = new Bubble();
            var liste = new MyList<int>();

            //Act
            int comparisons = sort.BubbleSort(liste, Comparer<int>.Default);

            //Assert
            Assert.AreEqual(0, liste.Count);
            Assert.AreEqual(0, comparisons);
        }

        [TestMethod]
        public void InsertionSortTest_Empty() //Insertion sort tom test 
        {
            //Arrange
            var sort = new Insertion();
            var liste = new MyList<int>();

            //Act
            int comparisons = sort.InsertionSort(liste, Comparer<int>.Default);

            //Assert
            Assert.AreEqual(0, liste.Count);
            Assert.AreEqual(0, comparisons);
        }

        [TestMethod]
        public void BubbleSortTest_Sorted() //bubble sort sorteret liste 
        {
            //Arrange
            var sort = new Bubble();
            var liste = new MyList<int>();
            int[] ints = { 1, 2, 3, 4, 5, 6 };
            foreach (int tal in ints) liste.Add(tal);

            //Act
            int comparisons = sort.BubbleSort(liste, Comparer<int>.Default);

            //Assert
            for (int i = 0; i < 6; i++)
            {
                Assert.AreEqual(i + 1, liste[i]);
            }
            Assert.AreEqual(15, comparisons);
        }
        [TestMethod]
        public void InsertionSortTest_Sorted() //Insertion sort sorteret liste 
        {
            //Arrange
            var sort = new Insertion();
            var liste = new MyList<int>();
            int[] ints = { 1, 2, 3, 4, 5, 6 };
            foreach (int tal in ints) liste.Add(tal);

            //Act
            int comparisons = sort.InsertionSort(liste, Comparer<int>.Default);

            //Assert
            for (int i = 0; i < 6; i++)
            {
                Assert.AreEqual(i + 1, liste[i]);
            }
            Assert.IsTrue(comparisons < 15);
        }

        [TestMethod]
        public void BubbleSortTest_OneElement() //Bubble sort et element test 
        {
            //Arrange
            var sort = new Bubble();
            var liste = new MyList<int>();
            liste.Add(3);

            //Act
            int comparisons = sort.BubbleSort(liste, Comparer<int>.Default);

            //Assert
            Assert.AreEqual(1, liste.Count);
            Assert.AreEqual(3, liste[0]);
        }

        [TestMethod]
        public void InsertionSortTest_OneElement() //Insertion sort et element test
        {
            //Arrange
            var sort = new Insertion();
            var liste = new MyList<int>();
            liste.Add(3);

            //Act
            int comparisons = sort.InsertionSort(liste, Comparer<int>.Default);

            //Assert
            Assert.AreEqual(1, liste.Count);
            Assert.AreEqual(3, liste[0]);
        }

        [TestMethod]
        public void BubbleSortTest_SameElements() // Bubble sort flere elementer test 
        {
            //Arrange
            var sort = new Bubble();
            var liste = new MyList<int>();
            int[] ints = { 6, 2, 6, 9, 6 };
            foreach (int tal in ints) liste.Add(tal);

            //Act
            int comparisons = sort.BubbleSort(liste, Comparer<int>.Default);

            //Assert
            Assert.AreEqual(2, liste[0]);
            Assert.AreEqual(6, liste[1]);
            Assert.AreEqual(6, liste[2]);
            Assert.AreEqual(6, liste[3]);
            Assert.AreEqual(9, liste[4]);
        }


        [TestMethod]
        public void InsertionSortTest_SameElements() //insertion sort flere elementer test 
        {
            //Arrange
            var sort = new Insertion();
            var liste = new MyList<int>();
            int[] ints = { 6, 2, 6, 9, 6 };
            foreach (int tal in ints) liste.Add(tal);

            //Act
            int comparisons = sort.InsertionSort(liste, Comparer<int>.Default);

            //Assert
            Assert.AreEqual(2, liste[0]);
            Assert.AreEqual(6, liste[1]);
            Assert.AreEqual(6, liste[2]);
            Assert.AreEqual(6, liste[3]);
            Assert.AreEqual(9, liste[4]);
        }
    }
}

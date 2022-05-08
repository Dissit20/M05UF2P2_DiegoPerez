using System;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
                   
        }

        public static void Menu()
        {
            char opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("\t*************************************");
                Console.WriteLine("\t    1- Algoritmo Burbuja             ");
                Console.WriteLine("\t    2- Algoritmo Merge sort           ");
                Console.WriteLine("\t    3- Algoritmo Quick sort           ");
                Console.WriteLine("\t    0- Salir           ");
                Console.WriteLine("\t*************************************");
                Console.WriteLine("Opcion: ");
                do
                {
                    opcion = Console.ReadKey(true).KeyChar;

                } while (opcion < '0' || opcion > '8');
                Console.WriteLine(opcion + "\n");

                switch (opcion)
                {
                    case '1':
                        try
                        {
                            Burbuja();
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                        break;
                    case '2':
                        try
                        {
                            MergeSort();
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                            Console.ReadLine();
                        }
                        break;
                    case '3':
                        try
                        {
                            Quicksort();
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                            Console.ReadLine();
                        }
                        break;

                }



            } while (opcion != '0');


        }

        public static void Burbuja()
        {
            int[] array = { 12, 17, 8, 4, 64 };
            mostrar(array);
            Console.ReadLine();
            int x;

            for (int i = 1; i < array.Length; i++)
                for (int j = array.Length - 1; j >= i; j--)
                {
                    if (array[j - 1] > array[j])
                    {
                        x = array[j - 1];
                        array[j - 1] = array[j];
                        array[j] = x;

                    }

                }
            mostrar(array);
            Console.ReadLine();


        }

        public static void mostrar(int[] array)
        {
            foreach (int i in array)
                Console.Write(" " + i.ToString());

        }

        public static void MergeSort()
        {
            int[] array = { 12, 27, 16, 30, 2 };
            mostrar(array);
            Console.WriteLine("");
            MergeSort(array, 0, array.Length - 1);
            Console.ReadLine();
            mostrar(array);
            Console.ReadLine();



        }

        static private void MergeSort(int[] array, int inicio, int fin)
        {
            if (inicio == fin)
                return;

            int mitad = (inicio + fin) / 2;

            MergeSort(array, inicio, mitad);
            MergeSort(array, mitad + 1, fin);

            int[] aux = juntarArrays(array, inicio, mitad, mitad + 1, fin);

            Array.Copy(aux, 0, array, inicio, aux.Length);

            Console.WriteLine("");
            mostrar(array);
        }

        static private int[] juntarArrays(int[] x, int inicio, int fin, int inicio2, int fin2)
        {
            int aux1 = inicio;
            int aux2 = inicio2;

            int[] resultado = new int[fin - inicio + fin2 - inicio2 + 2];

            for(int i = 0; i < resultado.Length; i++)
                if(aux2 != x.Length)
                {
                    if(aux1 > fin && aux2 <= fin2)
                    {
                        resultado[i] = x[aux2];
                        aux2++;

                    }
                    if(aux2 > fin2 && aux1 <= fin)
                    {
                        resultado[i] = x[aux1];

                    }
                    if(aux1 <= fin && aux2 <= fin2)
                        if(x[aux2] <= x[aux1])
                        {
                            resultado[i] = x[aux2];
                            aux2++;
                        }
                        else
                        {
                            resultado[i] = x[aux1];
                            aux1++;
                        }





                }
                else
                {
                    if(aux1 <= fin)
                    {
                        resultado[i] = x[aux1];
                        aux1++;

                    }

                }
            return resultado;


        }
        
       public static void Quicksort()
        {
            int[] array = { 1, 4, 7, 8, 5, 6, 10, 20, 14, 26 };
            mostrar(array);
            Console.WriteLine("");
            Quicksort(array, 0, array.Length - 1);
            Console.ReadLine();
            mostrar(array);
            Console.ReadLine();

        }

        static private void Quicksort(int[] array, int inicio, int fin)
        {
            int x, y, central;
            double pivote;
            central = (inicio + fin) / 2;
            pivote = array[central];
            x = inicio;
            y = fin;

            do
            {
                while (array[x] < pivote) x++;
                while (array[y] > pivote) y--;
                if(x <= y)
                {
                    int aux;
                    aux = array[x];
                    array[x] = array[y];
                    array[y] = aux;
                    x++;
                    y--;




                }





            } while (x <= y);

            if(inicio < y)
            {
                Quicksort(array, inicio, y);

            }
            if(x < fin)
            {
                Quicksort(array, x, fin);
            }

            Console.WriteLine("");
            mostrar(array);
        }
    }
}

namespace Dynamique
{
    class Program_main
    {
        /*-----------Question 1-----------*/
        // profit / val : identifie le tableau de valeurs des objets
        // weight / wt : identifie le tableau de poids des objets
        // W : identifie la capacité du sac à dos
        // n : identifie le nombre d'objets
        // K : identifie le tableau (à 2 dimensions) des valeurs qu'on pourra emporter dans le sac à dos
        // i : variable d'itération pour parcourir le nombre d'objets
        // w : variable d'itération pour parcourir le nombre de capacité

        // fonction pour l'affichage des objets à emporter
        static void affichageObjetEmporte(int[] binaire, int n){
            for (int i = 0; i < n; i++){
                if (binaire[i] == 1)
                    System.Console.WriteLine("Objet "+(i+1)+" est emporté dans le sac à dos.");
            }
            System.Console.WriteLine();
        }
        // affichage en binaire des objets à emporter
        static void affichageObjetEmportNon(int[] binaire, int n){
            for (int i = 0; i < n; i++)
                System.Console.Write(binaire[i]+"  ");
            System.Console.WriteLine();
        }
        // fonction pour tester les objets à emporter ,c'est a dire le parcours inverse 
        static void testobjetEmport(double[,] K, Objet[] Tab, ref int[] binaire, int n, int W){
            int i = n;
            int k = W;
            System.Console.Write("Affichage du tableau en binaire :");
            do
            {
                if (K[i,k] == K[i-1,k]) 
                    binaire[i-1] = 0;
                else{
                    binaire[i-1] = 1;
                    k -= (int)Tab[i-1].Poids;
                }
                i--;
            }
            while(0 < i);
            System.Console.WriteLine();
        }

        // Fonction retournant le maximum entre deux entiers
        static double max(double a, double b) { return (a>b) ? a : b; }

        static void affichageMatrice(double[,] K, int n, int W){
            int i, w;
            System.Console.WriteLine("Affichage de la matrice :");
            for (i = 0; i <= n; i++){
                for (w = 0; w <= W; w++){
                    System.Console.Write($"{K[i,w], 5}");
                }
                System.Console.WriteLine();
            }
            System.Console.WriteLine();
        }

        // retourne la valeur max qu' on peut mettre dans le sac
        static double knapsack(int W, Objet[] tab, ref double[,] K, int n)
        {
            int i, w; 

            for (i = 0; i <= n; i++){
                for (w = 0; w <= W; w++){
                    if (i == 0 || w == 0)
                        K[i,w] = 0;
                    else if (tab[i - 1].Poids <= w){
                        K[i,w] = max(tab[i - 1].Valeur + K[i - 1,w -(int)tab[i - 1].Poids],K[i - 1,w]);
                        // System.Console.Write(K[i,w]+"   ");
                    }else
                        K[i,w] = K[i - 1,w];
                }
            }
            return K[n,W];
        }

        // Programme principal
        static void Main(string[] args)
        {
            //instanciation du sac 
            Kitapo k1 = new Kitapo(50);
            // instanciation des objets 
            Objet[] Tab = new Objet[3];
            Objet obj1 = new Objet(60,10.3);
            Tab[obj1.Index] = obj1; 
            Objet obj2 = new Objet(100,20);
            Tab[obj2.Index] = obj2;
            Objet obj3 = new Objet(120,30); 
            Tab[obj3.Index] = obj3;

            //capacité du sac
            int W = k1.Capacite;
            //nombre d' objets
            int n = Tab.Length;
            //création du tableau à deux dimensions contenant les valeurs
            double[,] K = new double[n+1,W+1];
            //création du tableau en binaire (pour les objets emportés = 1 et les objets laissés = 0)
            int[] binaire = new int[n];

            System.Console.WriteLine("Valeur Maximale : " + knapsack(W, Tab, ref K, n));
            System.Console.WriteLine();
            affichageMatrice(K,n,W);
            testobjetEmport(K,Tab,ref binaire,n,W);
            affichageObjetEmportNon(binaire,n);
            System.Console.WriteLine();
            affichageObjetEmporte(binaire,n);
        }
    }
}
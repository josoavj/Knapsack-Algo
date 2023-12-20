namespace Dynamique
{
    class Objet{
        public int Valeur{get; set;} // valeur de l'objet
        public double Poids{get; set;} // poids de l'objet
        public int Index{get; private set;} // indice de l'objet
        private static int LastIndex = 0; // variable de stockage contenant indice incrémentée

        // public void TabObjet(){
        //     Tab[Index,0] = Valeur;
        //     Tab[Index,1] = Poids; 
        // }
        public Objet(int val, double pds){
            this.Index = LastIndex++; // incrémentation de l'indice de l'objet à venir
            this.Valeur = val;
            this.Poids = pds;
        }
    }
}
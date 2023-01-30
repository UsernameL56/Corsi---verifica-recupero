using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corsi___verifica_recupero
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //dichiarazioni
            int riga, colonna;
            int tartufi;

            int verticale = 6, orizzontale = 0;
            //input dimensioni della matrice
            Console.WriteLine("Inserire il numeri di colonne: ");
            colonna = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Inserire il numeri di righe: ");
            riga = Convert.ToInt32(Console.ReadLine());
            //dichiarazione della matrice dopo aver ricevuto i parametri
            int[,] matrice = new int[riga, colonna];
            //input quanti tartufi si vogliono generare
            tartufi = (riga * colonna) / 10;
            //generazionde del campo
            GenerazioneCampo(matrice, riga, colonna, tartufi);
            //stampa del campo
            for (int i = 0; i < riga; i++)
            {   
                for (int z = 0; z < colonna; z++)
                {
                    //posizionamento del cursore
                    Console.SetCursorPosition(orizzontale, verticale);
                    Console.Write(matrice[i, z]);
                    orizzontale = orizzontale + 5;
                }
                //reset della posizione
                verticale= verticale+2;
                orizzontale = 0;
            }

            verticale = 6;
            //richiamo alla funzione per controllare il campo
            int contatore = ControlloCampo(matrice, riga, colonna);
            for (int i = 0; i < riga; i++)
            {
                for (int z = 0; z < colonna; z++)
                {
                    //posizionamento del cursore
                    Console.SetCursorPosition(orizzontale, verticale);
                    Console.Write(matrice[i, z]);
                    orizzontale = orizzontale + 5;
                }
                //reset della posizione
                verticale = verticale + 2;
                orizzontale = 0;
            }
            Console.WriteLine(" ");
            Console.WriteLine("\n"+contatore);
        }

        //funzione per generare il campo
        static int[,] GenerazioneCampo(int[,]campo, int riga, int colonna,int tartufi)
        {
            //dichiarazioni
            Random r = new Random();
            bool controllo;
            //ciclo per inserire i tartufi in posizione randomica
            for (int z = 0; z < tartufi; z++)
            {
                //ciclo di controllo per verificare che un tartufo non venga posizionata in una posizione già occupata
                do
                {
                    //generazione di indici casuali
                    int N = r.Next(0, riga);
                    int M = r.Next(0, colonna);
                    //controllo posizione vuota
                    if (campo[N, M] == 0)
                    {
                        //se posizione vuota allora true
                        controllo = true;
                        campo[N, M] = 100;
                    } 
                    else
                        controllo = false;
                //genera indici fino a che non si trova una posizione vuota
                } while (controllo == false);
            }
            return campo;
        }

        static int ControlloCampo(int[,] campo, int riga, int colonna)
        {
            //dichiarazioni
            int contatore=0;
            for (int i = 0; i < riga; i++)
            {
                for (int z = 0; z < colonna; z++)
                {
                    if (campo[i, z] == 100)
                    {
                        contatore++;
        //controllo prima riga della mappa
                        if (i==0 && z == 0)
                        {
                            //varie opzioni tutte attorno al numero 100
                            //destra
                            campo[i, z + 1] = campo[i, z + 1] + 1;
                            //basso a destra
                            campo[i + 1, z + 1] = campo[i + 1, z + 1] + 1;
                            //basso
                            campo[i + 1, z] = campo[i + 1, z] + 1;
                        }else if(i == 0 && z >= 1 && z < colonna-1)
                        {
                            //varie opzioni tutte attorno al numero 100
                            //destra
                            campo[i, z + 1] = campo[i, z + 1] + 1;
                            //basso a destra
                            campo[i + 1, z + 1] = campo[i + 1, z + 1] + 1;
                            //basso
                            campo[i + 1, z] = campo[i + 1, z] + 1;
                            //basso a sinistra
                            campo[i + 1, z - 1] = campo[i + 1, z - 1] + 1;
                            //sinistra
                            campo[i, z - 1] = campo[i, z - 1] + 1;
                        }else if(i==0 && z==colonna-1)
                        {
                            //varie opzioni tutte attorno al numero 100
                            //sinistra
                            campo[i, z - 1] = campo[i, z - 1] + 1;
                            //basso a sinistra
                            campo[i + 1, z - 1] = campo[i + 1, z - 1] + 1;
                            //basso
                            campo[i + 1, z] = campo[i + 1, z] + 1;
                        }
        //controllo lati della mappa
                        else if (i >= 1 && i <= riga - 2 && z == 0)
                        {
                            //varie opzioni tutte attorno al numero 100
                            //alto
                            campo[i - 1, z] = campo[i - 1, z] + 1;
                            //alto a destra
                            campo[i - 1, z + 1] = campo[i - 1, z + 1] + 1;
                            //destra
                            campo[i, z + 1] = campo[i, z + 1] + 1;
                            //basso a destra
                            campo[i + 1, z + 1] = campo[i + 1, z + 1] + 1;
                            //basso
                            campo[i + 1, z] = campo[i + 1, z] + 1;
                        }
                        else if (i >= 1 && i <= riga - 2 && z == colonna - 1)
                        {
                            //alto
                            campo[i - 1, z] = campo[i - 1, z] + 1;
                            //alto a sinistra
                            campo[i - 1, z - 1] = campo[i - 1, z - 1] + 1;
                            //sinistra
                            campo[i, z - 1] = campo[i, z - 1] + 1;
                            //basso a sinistra
                            campo[i + 1, z - 1] = campo[i + 1, z - 1] + 1;
                            //basso
                            campo[i + 1, z] = campo[i + 1, z] + 1;
                        }
        //controllo ultima riga della mappa
                        else if(i==riga-1 && z == 0)
                        {
                            //varie opzioni tutte attorno al numero 100
                            //alto
                            campo[i - 1, z] = campo[i - 1, z] + 1;
                            //alto a destra
                            campo[i - 1, z + 1] = campo[i - 1, z + 1] + 1;
                            //destra
                            campo[i, z + 1] = campo[i, z + 1] + 1;
                        }else if(i==riga-1 && z >= 1 && z < colonna - 1)
                        {
                            //varie opzioni tutte attorno al numero 100
                            //sinistra
                            campo[i, z - 1] = campo[i, z - 1] + 1;
                            //alto a sinistra
                            campo[i - 1, z - 1] = campo[i - 1, z - 1] + 1;
                            //alto
                            campo[i - 1, z] = campo[i - 1, z] + 1;
                            //alto a destra
                            campo[i - 1, z + 1] = campo[i - 1, z + 1] + 1;
                            //destra
                            campo[i, z + 1] = campo[i, z + 1] + 1;
                        }
                        else if (i == riga-1 && z == colonna - 1)
                        {
                            //varie opzioni tutte attorno al numero 100
                            //alto
                            campo[i - 1, z] = campo[i - 1, z] + 1;
                            //alto a sinistra
                            campo[i - 1, z - 1] = campo[i - 1, z - 1] + 1;
                            //sinistra
                            campo[i, z - 1] = campo[i, z - 1] + 1;

                        }
        //controllo centro della mappa
                        else
                        {
                            //varie opzioni tutte attorno al numero 100
                            //alto
                            campo[i - 1, z] = campo[i - 1, z] + 1;
                            //alto a destra
                            campo[i - 1, z + 1] = campo[i - 1, z + 1] + 1;
                            //destra
                            campo[i, z + 1] = campo[i, z + 1] + 1;
                            //basso a destra
                            campo[i + 1, z + 1] = campo[i + 1, z + 1] + 1;
                            //basso
                            campo[i + 1, z] = campo[i + 1, z] + 1;
                            //basso a sinistra
                            campo[i + 1, z - 1] = campo[i + 1, z - 1] + 1;
                            //sinistra
                            campo[i, z - 1] = campo[i, z - 1] + 1;
                            //alto a sinistra
                            campo[i - 1, z - 1] = campo[i - 1, z - 1] + 1;
                        }


                    }
                }
            }
            return contatore;
        }
    }
}

/*
destra
campo[i, z + 1] = campo[i, z + 1] + 1;

basso a destra
campo[i + 1, z + 1] = campo[i + 1, z + 1] + 1;

basso
campo[i + 1, z] = campo[i + 1, z] + 1;

basso a sinistra
campo[i + 1, z - 1] = campo[i + 1, z - 1] + 1;

sinistra
campo[i, z - 1] = campo[i, z - 1] + 1;

alto a sinistra
campo[i - 1, z + 1] = campo[i - 1, z + 1] + 1;

alto
campo[i - 1, z] = campo[i - 1, z] + 1;

alto a destra
campo[i - 1, z + 1] = campo[i - 1, z + 1] + 1;
*/